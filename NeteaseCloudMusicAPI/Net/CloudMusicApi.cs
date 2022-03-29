/** 
 * License: MIT License
 * Copyright (c) 2018 GEEKiDoS
 * URL: https://github.com/GEEKiDoS/NeteaseMuiscApi
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Numerics;
using NeteaseCloudMusicAPI.JsonBase.CommentBase;
using System.Net.Http;

namespace NeteaseCloudMusicAPI.Net
{
    /// <summary>
    /// 网易云音乐API
    /// </summary>
    public partial class CloudMusicApi
    {
        /// <summary>
        /// Detail接口最大拉取数量
        /// </summary>
        public const int MAX_DETAIL_REQUESTS_NUMBER = 1000;
        private const string _MODULUS = "00e0b509f6259df8642dbc35662901477df22677ec152b5ff68ace615bb7b725152b3ab17a876aea8a5aa76d2e417629ec4ee341f56135fccf695280104e0312ecbda92557c93870114af6c9d05c4f7f0c3685b7a46bee255932575cce10b424d813cfe4875d3e82047b97ddef52741d546b8e289dc6935b3ece0462db0a22b8e7";
        private const string _NONCE = "0CoJUm6Qyw8W8jud";
        private const string _PUBKEY = "010001";
        private const string _VI = "0102030405060708";
        private const string _USERAGENT = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
        private const string _COOKIE = "os=pc;osver=Microsoft-Windows-10-Professional-build-16299.125-64bit;appver=2.0.3.131777;channel=netease;__remember_me=true";
        private const string _REFERER = "https://music.163.com/";

        private readonly string _secretKey;
        private readonly string _encSecKey;
        private static readonly HttpClient _client = GetHttpClient();
        
        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", _COOKIE);
            client.DefaultRequestHeaders.Add("User-Agent", _USERAGENT);
            client.DefaultRequestHeaders.Add("Referer", _REFERER);
            return client;
        }
        
        public CloudMusicApi()
        {
            _secretKey = CreateSecretKey(16);
            _encSecKey = RSAEncode(_secretKey);
        }

        public enum SearchType
        {
            Song = 1,
            Album = 10,
            Artist = 100,
            PlayList = 1000,
            User = 1002,
            Radio = 1009,
        }
        
        public SearchResult Search(string keyword, int limit = 30, int offset = 0, SearchType type = SearchType.Song)
        {
            var url = "https://music.163.com/weapi/cloudsearch/get/web";
            var data = new SearchJson
            {
                s = keyword,
                type = (int)type,
                limit = limit,
                offset = offset,
            };

            string raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            return JsonConvert.DeserializeObject<SearchResult>(raw);
        }

        /// <summary>
        /// 歌手信息
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public ArtistResult Artist(in long artistId)
        {
            var url = $"https://music.163.com/weapi/v1/artist/{artistId}?csrf_token=";
            var data = new Dictionary<string, string>
            {
                ["csrf_token"] = string.Empty
            };
            var raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            
            return JsonConvert.DeserializeObject<ArtistResult>(raw);
        }

        /// <summary>
        /// 专辑信息
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public AlbumResult Album(in long albumId)
        {
            string url = $"https://music.163.com/weapi/v1/album/{albumId}?csrf_token=";
            var data = new Dictionary<string, string> 
            {
                { "csrf_token", string.Empty },
            };
            string raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            return JsonConvert.DeserializeObject<AlbumResult>(raw);
        }

        /// <summary>
        /// 音乐信息
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public RawDetailsResult Details(in long songId)
        {
            string raw = CURL(ApiUrl.DETAIL_URL, GetDetailParams(songId));
            return JsonConvert.DeserializeObject<RawDetailsResult>(raw);
        }
        
        /// <summary>
        /// 异步的获得音乐信息
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public async Task<RawDetailsResult> DetailAsync(long songId)
        {
            var raw = await PostAsync(ApiUrl.DETAIL_URL, GetDetailParams(songId));
            return JsonConvert.DeserializeObject<RawDetailsResult>(raw);
        }

        /// <summary>
        /// 批量得到音乐信息
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id数超过MAX_DETAIL_REQUESTS_NUMBER</exception>
        /// <exception cref="ArgumentNullException">songId为null</exception>
        public DetailResultBatch DetailBatch(IEnumerable<long> songId)
        {
            if (songId == null)
            {
                throw new ArgumentNullException(nameof(songId));
            }
            if (songId.Count() > MAX_DETAIL_REQUESTS_NUMBER)
            {
                throw new ArgumentOutOfRangeException(nameof(songId),
                    $"超过最大请求数, 最大请求数={MAX_DETAIL_REQUESTS_NUMBER}");
            }
            var raw = CURL(ApiUrl.DETAIL_URL, GetDetailBatchParams(songId));
            return JsonConvert.DeserializeObject<DetailResultBatch>(raw);
        }
        
        private Dictionary<string, string> GetDetailBatchParams(IEnumerable<long> songId)
        {
            //TODO:效率很低,有空优化一下
            var list = new List<Dictionary<string, long>>(songId.Count());
            foreach (var i in songId)
            {
                list.Add(new Dictionary<string, long>{["id"] = i});
            }
            var data = new Dictionary<string, string> 
            {
                ["c"] = JsonConvert.SerializeObject(list),
                ["csrf_token"] = string.Empty
            };
            var json = JsonConvert.SerializeObject(data);
            return Prepare(json);
        }
        
        private Dictionary<string, string> GetDetailParams(long songId)
        {
            var data = new Dictionary<string, string> 
            {
                { "c",
                    "[" + JsonConvert.SerializeObject(new Dictionary<string, long> 
                    { //神tm 加密的json里套json mdzz (说不定一次可以查多首歌?)
                        { "id", songId }
                    }) + "]"
                },
                {"csrf_token", string.Empty}
            };
            var json = JsonConvert.SerializeObject(data);
            return Prepare(json);
        }

        private class GetSongUrlJson
        {
            public long[] ids;
            public long br;
            public string csrf_token = string.Empty;
        }

        public SongUrls GetSongsUrl(long[] songId, long bitrate = 999000)
        {
            string url = "https://music.163.com/weapi/song/enhance/player/url?csrf_token=";

            var data = new GetSongUrlJson
            {
                ids = songId,
                br = bitrate
            };

            string raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            
            return JsonConvert.DeserializeObject<SongUrls>(raw);
        }

        /// <summary>
        /// 播放列表
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        public PlayListResult Playlist(in long playlistId)
        {
            string url = "https://music.163.com/weapi/v3/playlist/detail?csrf_token=";
            var data = new Dictionary<string, string> 
            {
                { "id", playlistId.ToString() },
                { "n" , "1000" },
                { "csrf_token" , string.Empty },
            };
            string raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            return JsonConvert.DeserializeObject<PlayListResult>(raw);
        }

        /// <summary>
        /// 获得音乐歌词
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public RawLyricsResult Lyrics(in long songId)
        {
            string raw = CURL(ApiUrl.LYRICS_URL, GetLyricsParams(songId));
            return JsonConvert.DeserializeObject<RawLyricsResult>(raw);
        }
        
        private Dictionary<string, string> GetLyricsParams(in long songId)
        {
            var data = new Dictionary<string, string> 
            {
                { "id", songId.ToString()},
                { "os", "pc" },
                { "lv", "1" },
                { "kv", "1" },
                { "tv", "1" },
                { "csrf_token", string.Empty }
            };
            var da = JsonConvert.SerializeObject(data);
            return Prepare(da);
        }

        /// <summary>
        /// 歌曲评论
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <param name="offset">偏移量, offset的取值为:(评论页数-1)*20</param>
        /// <param name="limit">数量, 最大为100, 如果大于100, 则会变成20</param>
        /// <returns></returns>
        public CommentResult Comments(in long songId, in uint offset = 0, in uint limit = 20)
        {
            //! 网易云音乐Web版现在正在使用的API
            //string newApi = $"https://music.163.com/weapi/comment/resource/comments/get?csrf_token=";
            //! GET的评论API
            //string getApi = $"https://music.163.com/api/v1/resource/comments/R_SO_4_{songId}?offset=1&limit=100";

            string url = $"https://music.163.com/weapi/v1/resource/comments/R_SO_4_{songId}/?csrf_token=";
            var data = new Dictionary<string, string>
            {
                { "offset", offset.ToString() },
                { "limit", limit.ToString() },
                { "csrf_token", string.Empty }
            };
            var json = JsonConvert.SerializeObject(data);
            var resual = CURL(url, Prepare(json));
            return JsonConvert.DeserializeObject<CommentResult>(resual);
        }

        /// <summary>
        /// 歌曲的热门评论
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <returns></returns>
        public CommentResult HotComments(in long songId)
        {
            return Comments(songId, 0, 0);
        }

        public MVResult MV(int mvId)
        {
            const string url = "https://music.163.com/weapi/mv/detail?csrf_token=";
            var data = new Dictionary<string, string> 
            {
                { "id", mvId.ToString() },
                { "csrf_token", string.Empty },
            };
            string raw = CURL(url, Prepare(JsonConvert.SerializeObject(data)));
            var deserialedObj = JsonConvert.DeserializeObject<MVResult>(
                raw.Replace("\"720\"", "\"the720\"")
                   .Replace("\"480\"", "\"the480\"")
                   .Replace("\"240\"", "\"the240\"")); //不能解析数字key的解决方案
            return deserialedObj;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        public async Task<DetailResultBatch> DetailBatchAsync(IEnumerable<long> songId)
        {
            var raw = await PostAsync(ApiUrl.DETAIL_URL, GetDetailBatchParams(songId));
            return JsonConvert.DeserializeObject<DetailResultBatch>(raw);
        }
        
        /// <summary>
        /// 异步的获得音乐歌词
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public async Task<RawLyricsResult> LyricsAsync(long songId)
        {
            string raw = await PostAsync(ApiUrl.LYRICS_URL, GetLyricsParams(songId));
            return JsonConvert.DeserializeObject<RawLyricsResult>(raw);        
        }
        
        private static async Task<string> PostAsync(string url, Dictionary<string, string> paramsValue)
        {
            var reqparm = new FormUrlEncodedContent(paramsValue);
            using (var data = await _client.PostAsync(url, reqparm))
            {
                return await data.Content.ReadAsStringAsync();
            }
        }
        
        private static string CreateSecretKey(int length)
        {
            const string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder(length);
            var rnd = new Random();
            for (int i = 0; i < length; ++i)
            {
                sb.Append(str[rnd.Next(0, str.Length)]);
            }
            return sb.ToString();
        }

        private Dictionary<string, string> Prepare(string raw)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["params"] = AESEncode(raw, _NONCE)
            };
            data["params"] = AESEncode(data["params"], _secretKey);
            data["encSecKey"] = _encSecKey;
            return data;
        }

        // encrypt mod
        private static string RSAEncode(string text)
        {
            string srtext = new string(text.Reverse().ToArray());
            var a = BCHexDec(BitConverter.ToString(Encoding.Default.GetBytes(srtext)).Replace("-", string.Empty));
            var b = BCHexDec(_PUBKEY);
            var c = BCHexDec(_MODULUS);
            var key = BigInteger.ModPow(a, b, c).ToString("x");
            key = key.PadLeft(256, '0');
            if (key.Length > 256)
                return key.Substring(key.Length - 256, 256);
            else
                return key;
        }

        private static BigInteger BCHexDec(string hex)
        {
            BigInteger dec = new BigInteger(0);
            int len = hex.Length;
            for (int i = 0; i < len; ++i)
            {
                dec += BigInteger.Multiply(new BigInteger(Convert.ToInt32(hex[i].ToString(), 16)), BigInteger.Pow(new BigInteger(16), len - i - 1));
            }
            return dec;
        }

        private static string AESEncode(string secretData, string secret = "TA3YiYCfY2dDJQgg")
        {
            byte[] encrypted;
            byte[] IV = Encoding.UTF8.GetBytes(_VI);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(secret);
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var cstream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cstream))
                            {
                                sw.Write(secretData);
                            }
                            encrypted = stream.ToArray();
                        }
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        // fake curl
        private static string CURL(string url, Dictionary<string, string> paramsValue, string method = "POST")
        {
            string result;
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                wc.Headers.Add(HttpRequestHeader.Referer, _REFERER);
                wc.Headers.Add(HttpRequestHeader.UserAgent, _USERAGENT);
                wc.Headers.Add(HttpRequestHeader.Cookie, _COOKIE);
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                foreach (var keyPair in paramsValue)
                {
                    reqparm.Add(keyPair.Key, keyPair.Value);
                }
                byte[] responseBytes = wc.UploadValues(url, method, reqparm);
                result = Encoding.UTF8.GetString(responseBytes);
            }
#if DEBUG
            Console.WriteLine($"原始数据={result}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(JObject.Parse(result));
#endif
            return result;
        }

        // api start
        private class SearchJson
        {
            public string s;
            public int type;
            public int limit;
            public string total = "true";
            public int offset;
            public string csrf_token = string.Empty;
        }

        public override string ToString()
        {
            return $"{GetType().FullName}{{secretKey:{_secretKey} encSecKey:{_encSecKey}}}";
        }
    }
}