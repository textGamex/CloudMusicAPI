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
        internal static readonly CloudMusicAPI api = new CloudMusicAPI();
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
            SongId = songId;
            var errorCode = api.Detail(songId).Privileges[0].St;
            if (errorCode != 0)
            {
                throw new ArgumentException($"歌曲Id错误:{songId}, 错误代码:{errorCode}");
            }
            if (mode == CreateMode.Normal)
            {
                _lyric = new Lyric(songId);
                _details = new Detail(songId);                
            }
        }

        /// <summary>
        /// 音乐ID
        /// </summary>
        public long SongId { get; }

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
                if (Details == null)
                {
                    _details = new Detail(SongId);
                }
                return _details;
            }
        }
    }
}
