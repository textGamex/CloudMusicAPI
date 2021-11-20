using System;
using System.Collections.Generic;

namespace NeteaseCloudMusicAPI
{
    public partial class CloudMusic
    {
        /// <summary>
        /// 关于歌词的数据
        /// </summary>
        public class Lyric
        {
            public class Author
            {
                public Author(string name, string timeStamp, long id)
                {
                    Name = name;
                    UpTime = GetDateTime(timeStamp);
                    Id = id;
                }
                /// <summary>
                /// 歌词贡献者
                /// </summary>
                public string Name { get; private set; }
                /// <summary>
                /// 上传时间
                /// </summary>
                public DateTime UpTime { get; private set; }
                /// <summary>
                /// 账号ID
                /// </summary>
                public long Id { get; private set; }               
            }

            public Author AuthorInfo { get; }
            /// <summary>
            /// LRC格式的歌词
            /// </summary>
            public string Lyrics { get; private set; }
            /// <summary>
            /// KRC格式的歌词
            /// </summary>
            public string LyricKrc { get; private set; }
            /// <summary>
            /// 译文
            /// </summary>
            public string Translation { get; private set; }

            public Lyric(long musicId)
            {
                var data = api.Lyric(musicId);
                Lyrics = data.Lrc.Lyric;
                LyricKrc = data.Klyric.lyric;
                Translation = data.Tlyric.Lyric;
                if (data.LyricUser != null)
                {
                    AuthorInfo = new Author(data.LyricUser.Nickname, data.LyricUser.Uptime.ToString(), data.LyricUser.Id);                   
                }
                else
                {
                    AuthorInfo = null;
                }
            }
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        private static DateTime GetDateTime(string timeStamp)
        {
            if (timeStamp.Length > 10)
            {
                timeStamp = timeStamp.Substring(0, 10);
            }
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dateTimeStart.Add(toNow);
        }

        /// <summary>
        /// 图片
        /// </summary>
        public class Image
        {
            /// <summary>
            /// 歌曲所属专辑封面的链接
            /// </summary>
            public string AlbumCover { get; private set; }
            public Image(long songId)
            {
                var data = api.Detail(songId);
                AlbumCover = data.Songs[0].Al.PicUrl;
            }
        }

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