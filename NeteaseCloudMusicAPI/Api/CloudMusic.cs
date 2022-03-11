using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Net;
using NeteaseCloudMusicAPI.Api.Models;

namespace NeteaseCloudMusicAPI.Api
{
    /// <summary>
    /// 一个已经包装好的网易云音乐信息类
    /// </summary>
    public static class CloudMusic
    {
        private static readonly CloudMusicApi _api = new CloudMusicApi();
        
        public static Lyrics GetLyrics(long songId)
        {
            return new Lyrics(_api.Lyrics(songId));
        }
        
        public static async Task<Lyrics> GetLyricAsync(long songId)
        {
            return new Lyrics(await _api.LyricsAsync(songId));
        }

        public static Detail GetDetails(long songId)
        {
            return new Detail(_api.Detail(songId));
        }
        
        public static async Task<Detail> GetDetailAsync(long songId)
        {
            return new Detail(await _api.DetailAsync(songId));
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
