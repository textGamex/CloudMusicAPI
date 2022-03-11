using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.Net;

namespace NeteaseCloudMusicAPI.Api.Models
{
    /// <summary>
    /// 关于歌词的数据
    /// </summary>
    public class Lyrics
    {
        /// <summary>
        /// 歌词贡献者的信息
        /// </summary>
        public class LyricsContributor
        {
            public LyricsContributor(string name, string timeStamp, long id)
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

        /// <summary>
        /// 歌词贡献者的信息, 为<c>null</c>则代表没有
        /// </summary>
        public LyricsContributor LyricsContributorInfo { get; }

        /// <summary>
        /// LRC格式的歌词
        /// </summary>
        public string Lyric { get; private set; }

        /// <summary>
        /// KRC格式的歌词
        /// </summary>
        public string LyricKrc { get; private set; }

        /// <summary>
        /// 译文
        /// </summary>
        public string Translation { get; private set; }

        internal Lyrics(LyricsResult data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Lyric = data.Lrc.Lyric ?? string.Empty;
            LyricKrc = data.Klyric.lyric ?? string.Empty;
            Translation = data.Tlyric.Lyric ?? string.Empty;
            if (data.LyricUser != null)
            {
                LyricsContributorInfo = new LyricsContributor(data.LyricUser.Nickname,
                    data.LyricUser.Uptime.ToString(), data.LyricUser.Id);
            }
            else
            {
                LyricsContributorInfo = null;
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
    }
}