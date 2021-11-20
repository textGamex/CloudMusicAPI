using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicAPI
{
    /// <summary>
    /// 一个已经包装好的网易云音乐信息类
    /// </summary>
    public partial class CloudMusic
    {
        internal static readonly CloudMusicAPI api = new();
        private Lyric _Lyric;
        private Image _Images;
        private Detail _Details;

        public CloudMusic(in long songId)
        {
            SongId = songId;
        }

        /// <summary>
        /// 音乐ID
        /// </summary>
        public long SongId { get; }

        public Lyric Lyrics
        {
            get
            {
                if (_Lyric == null)
                    _Lyric = new Lyric(SongId);
                return _Lyric;
            }
        }

        public Image Images
        {
            get
            {
                if (_Images == null)
                {
                    _Images = new Image(SongId);
                }
                return _Images;
            }
        }

        public Detail Details
        {
            get
            {
                if (Details == null)
                {
                    _Details = new Detail(SongId);
                }
                return _Details;
            }
        }
    }
}
