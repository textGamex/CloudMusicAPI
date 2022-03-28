using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Net;
using System.Collections.Specialized;

namespace NeteaseCloudMusicAPI.Api.Models
{
    /// <summary>
    /// 歌曲详情
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 作者信息, <c>key</c>为作者名称, <c>value</c>为作者ID
        /// </summary>
        public NameValueCollection AuthorInfos { get; private set; } = new NameValueCollection();

        /// <summary>
        /// 歌曲名
        /// </summary>
        public string SongName { get; private set; }

        /// <summary>
        /// 歌曲封面
        /// </summary>
        public string SongCover { get; private set; }

        /// <summary>
        /// 歌曲所属专辑ID
        /// </summary>
        public long SongAlbumId { get; private set; }

        /// <summary>
        /// 歌曲所属专辑名称
        /// </summary>
        public string SongAlbumName { get; private set; }

        /// <summary>
        /// 歌曲所属专辑封面
        /// </summary>
        public string SongAlbumCover
        {
            get { return SongCover; }
            private set { SongCover = value; }
        }

        /// <summary>
        /// 热度
        /// </summary>
        public double Popularity { get; private set; }

        public Details(Song song)
        {
            foreach (var item in song.Ar)
            {
                AuthorInfos.Add(item.Name, item.Id.ToString());
            }

            SongName = song.Name;
            SongCover = song.Al.PicUrl;
            SongAlbumId = song.Al.Id;
            SongAlbumName = song.Al.Name;
            Popularity = song.Pop;
        }

        public Details(RawDetailsResult data) : this(data.Songs[0]) {}

        /// <summary>
        /// 如果歌曲不存在,返回true
        /// </summary>
        public bool IsNonExistent { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }
}