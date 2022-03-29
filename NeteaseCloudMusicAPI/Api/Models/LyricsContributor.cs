using System;

namespace NeteaseCloudMusicAPI.Api.Models
{
    public partial class Lyrics
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
            public string Name { get; }

            /// <summary>
            /// 上传时间
            /// </summary>
            public DateTime UpTime { get; }

            /// <summary>
            /// 账号ID
            /// </summary>
            public long Id { get; }

            public override int GetHashCode()
            {
                int result = Name?.GetHashCode() ?? 0;
                result = 31 * result + UpTime.GetHashCode();
                result = 31 * result + Id.GetHashCode();
                return result;
            }

            public override string ToString()
            {
                string time = UpTime == GetDateTime("0") ? "0" : UpTime.ToString("s");
                return $"{GetType().Name}{{Name={Name}, UpTime={time}, Id={Id}}}";
            }

            /// <summary>
            /// 时间戳转为C#格式时间
            /// </summary>
            /// <param name="timeStamp">时间戳</param>
            /// <returns>C#格式时间</returns>
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
}