using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Net;

namespace NeteaseCloudMusicAPI.Api
{
    /// <summary>
    /// 一个已经包装好的网易云音乐信息类
    /// </summary>
    public partial class CloudMusic
    {
        private static readonly CloudMusicApiAsync _api = new CloudMusicApiAsync();
        private Lyric _lyric;
        private Detail _details;

        /// <summary>
        /// 构造模式
        /// </summary>
        public enum CreateMode
        {
            /// <summary>
            /// 构造对象时请求所有信息
            /// </summary>
            Normal,
            /// <summary>
            /// 使用时再请求
            /// </summary>
            Lazy
        }

        public CloudMusic(in long songId, CreateMode mode = CreateMode.Normal)
        {
            var api = new CloudMusicApi();
            SongId = songId;
            if (mode == CreateMode.Normal)
            {
                _lyric = new Lyric(songId);
                _details = new Detail(songId);                
            }
        }
        
        public static async Task<CloudMusic> NewAsync(long songId)
        {
            var detailAsync = await Detail.GetDetailAsync(songId);
            var lyricAsync = await Lyric.GetLyricAsync(songId);
            var cloudMusic = new CloudMusic(songId, detailAsync, lyricAsync);
            cloudMusic.IsNonExistent = detailAsync.IsNonExistent;
            return cloudMusic;
        }

        private CloudMusic(long songId, Detail detail, Lyric lyric)
        {
            SongId = songId;
            _details = detail ?? throw new ArgumentNullException(nameof(detail));
            _lyric = lyric ?? throw new ArgumentNullException(nameof(lyric));
        }
        
        public async Task<Lyric> GetLyricAsync()
        {
            return await Lyric.GetLyricAsync(SongId);
        }

        public async Task<Detail> GetDetailAsync()
        {
            return await Detail.GetDetailAsync(SongId);
        }

        /// <summary>
        /// 音乐ID
        /// </summary>
        public long SongId { get; }
        
        /// <summary>
        /// 如果歌曲不存在,返回true
        /// </summary>
        public bool IsNonExistent { get; private set;}

        public Lyric Lyrics
        {
            get
            {
                if (_lyric == null)
                    _lyric = new Lyric(SongId);
                return _lyric;
            }
        }

        public Detail Details
        {
            get
            {
                if (_details == null)
                {
                    _details = new Detail(SongId);
                }
                return _details;
            }
        }

        // public static async Task<(bool, long)> IsEffectiveSongIdAsync(long songId)
        // {
        //     var api = new CloudMusicAPI();
        //     var errorCode = await api.DetailAsync(songId);
        //     return (errorCode.Privileges[0].St == 0, songId);
        // }
    }
}
