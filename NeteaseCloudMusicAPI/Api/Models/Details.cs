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
    public class Detail
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

        public Detail(DetailResult data)
        {
            if (data.Songs.Length == 0)
            {
                IsNonExistent = true;
                return;
            }

            var songData = data.Songs[0];
            foreach (var item in songData.Ar)
            {
                AuthorInfos.Add(item.Name, item.Id.ToString());
            }

            SongName = songData.Name;
            SongCover = songData.Al.PicUrl;
            SongAlbumId = songData.Al.Id;
            SongAlbumName = songData.Al.Name;
            Popularity = songData.Pop;
        }

        /// <summary>
        /// 如果歌曲不存在,返回true
        /// </summary>
        internal bool IsNonExistent { get; }
    }
}