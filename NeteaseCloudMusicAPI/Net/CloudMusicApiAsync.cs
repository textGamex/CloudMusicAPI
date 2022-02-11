using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NeteaseCloudMusicAPI.Net
{
    public class CloudMusicApiAsync : CloudMusicApi
    {
         private const int MAX_DETAIL_REQUESTS_NUMBER = 1000;
         private const string _USERAGENT = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
         private const string _COOKIE = "os=pc;osver=Microsoft-Windows-10-Professional-build-16299.125-64bit;appver=2.0.3.131777;channel=netease;__remember_me=true";
         private const string _REFERER = "https://music.163.com/"; 
         private static readonly HttpClient _client = GetHttpClient();

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", _COOKIE);
            client.DefaultRequestHeaders.Add("User-Agent", _USERAGENT);
            client.DefaultRequestHeaders.Add("Referer", _REFERER);
            return client;
        }
        
        /// <summary>
        /// 异步的获得音乐信息
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public async Task<DetailResult> DetailAsync(long songId)
        {
            var raw = await PostAsync(ApiUrl.DETAIL_URL, GetDetailParams(songId));
            return JsonConvert.DeserializeObject<DetailResult>(raw);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        public async Task<DetailResultBatch> DetailBatchAsync(params long[] songId)
        {
            var raw = await PostAsync(ApiUrl.DETAIL_URL, GetDetailBatchParams(songId));
            return JsonConvert.DeserializeObject<DetailResultBatch>(raw);
        }
        
        /// <summary>
        /// 异步的获得音乐歌词
        /// </summary>
        /// <param name="songId">音乐ID</param>
        /// <returns></returns>
        public async Task<LyricsResult> LyricsAsync(long songId)
        {
            string raw = await PostAsync(ApiUrl.LYRICS_URL, GetLyricsParams(songId));
            return JsonConvert.DeserializeObject<LyricsResult>(raw);        
        }
        
        private static async Task<string> PostAsync(string url, Dictionary<string, string> paramsValue)
        {
            var reqparm = new FormUrlEncodedContent(paramsValue);
            using (var data = await _client.PostAsync(url, reqparm))
            {
                return await data.Content.ReadAsStringAsync();
            }
        }
    }
}