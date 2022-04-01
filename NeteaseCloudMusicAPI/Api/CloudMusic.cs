using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Net;

namespace NeteaseCloudMusicAPI.Api
{
    /// <summary>
    /// 一个已经包装好的网易云音乐信息类
    /// </summary>
    public static class CloudMusic
    {
        private static readonly CloudMusicApi _api = new CloudMusicApi();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <exception cref="WebException"></exception>
        /// <returns></returns>
        public static Lyrics GetLyrics(long songId)
        {
            return new Lyrics(_api.Lyrics(songId));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <exception cref="WebException"></exception>
        /// <returns></returns>
        public static async Task<Lyrics> GetLyricsAsync(long songId)
        {
            return new Lyrics(await _api.LyricsAsync(songId));
        }

        /// <summary>
        /// 获得<see cref="Details"/>
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        public static Details GetDetails(long songId)
        {
            return new Details(_api.Details(songId));
        }
        
        /// <summary>
        /// 异步获得<see cref="Details"/>
        /// </summary>
        /// <param name="songId">歌曲ID</param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        public static async Task<Details> GetDetailsAsync(long songId)
        {
            return new Details(await _api.DetailAsync(songId));
        }

        /// <summary>
        /// 批量异步获得<see cref="Details"/>列表
        /// </summary>
        /// <param name="songIds">歌曲ID</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="WebException"></exception>
        public static List<Details> GetDetailsBatch(IEnumerable<long> songIds)
        {
            if (songIds == null)
            {
                throw new ArgumentNullException(nameof(songIds));
            }
            var data = _api.DetailBatch(songIds);
            var list = new List<Details>(songIds.Count());
            for (int i = 0; i < data.Songs.Count; ++i)
            {
                list.Add(new Details(data.Songs[i]));
            }
            return list;
        }
        
        /// <summary>
        /// 如果歌曲不存在,返回true
        /// </summary>
        // public bool IsNonExistent { get; private set;}
        
        // public static async Task<(bool, long)> IsEffectiveSongIdAsync(long songId)
        // {
        //     var api = new CloudMusicAPI();
        //     var errorCode = await api.DetailAsync(songId);
        //     return (errorCode.Privileges[0].St == 0, songId);
        // }
    }
}
