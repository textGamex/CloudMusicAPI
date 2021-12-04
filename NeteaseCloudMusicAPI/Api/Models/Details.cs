using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicAPI.Api
{
    public partial class CloudMusic
    {
        /// <summary>
        /// 歌曲详情
        /// </summary>
        public class Detail
        {
            /// <summary>
            /// 作者信息, <c>key</c>为作者名称, <c>value</c>为作者ID
            /// </summary>
            public Dictionary<string, long> AuthorInfos { get; private set; } = new Dictionary<string, long>();
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

            public Detail(long songId)
            {
                var data = api.Detail(songId);
                var songData = data.Songs[0];
                foreach (var item in songData.Ar)
                {
                    AuthorInfos.Add(item.Name, item.Id);
                }
                SongName = songData.Name;
                SongCover = songData.Al.PicUrl;
                SongAlbumId = songData.Al.Id;
                SongAlbumName = songData.Al.Name;
            }
        }
    }
}
