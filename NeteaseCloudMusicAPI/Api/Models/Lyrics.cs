using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.Net;
using NeteaseCloudMusicAPI.JsonBase;

namespace NeteaseCloudMusicAPI.Api

{
    /// <summary>
    /// 关于歌词的数据
    /// </summary>
    public partial class Lyrics
    {
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

        /// <summary>
        /// 歌曲是未收录的
        /// </summary>
        public bool IsUncollected { get; private set; }
        
        /// <summary>
        /// 没有歌词为true, 否则为false
        /// </summary>
        public bool IsNotHasLyrics { get; }
        
        public Lyrics(RawLyricsResult data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            IsUncollected = data.Uncollected;
            IsNotHasLyrics = data.Nolyric;
            Lyric = data.Lrc?.Lyric ?? string.Empty;
            LyricKrc = data.Klyric?.lyric ?? string.Empty;
            Translation = data.Tlyric?.Lyric ?? string.Empty;
            if (data.LyricUser != null)
            {
                LyricsContributorInfo = new LyricsContributor(data.LyricUser.Nickname,
                    data.LyricUser.Uptime.ToString(), data.LyricUser.Userid);
            }
            else
            {
                LyricsContributorInfo = null;
            }
        }
        
        public override int GetHashCode()
        {   
            int result = LyricsContributorInfo?.GetHashCode() ?? 0;
            result = result * 31 + IsUncollected.GetHashCode();
            result = result * 31 + IsNotHasLyrics.GetHashCode();
            result = result * 31 + Lyric.GetHashCode();
            result = result * 31 + LyricKrc.GetHashCode();
            result = result * 31 + Translation.GetHashCode();
            return result;
        }

        // public override string ToString()
        // {
        //     return $"{GetType().Name}{{LyricsContributorInfo={LyricsContributorInfo},}}";
        // }
        public override string ToString()
        {
            return $"{GetType().Name}{{{nameof(IsUncollected)}={IsUncollected}, " +
                   $"{nameof(IsNotHasLyrics)}={IsNotHasLyrics}, {nameof(Lyric)}={Lyric}, {nameof(LyricKrc)}={LyricKrc}, " +
                   $"{nameof(Translation)}={Translation}, {nameof(LyricsContributorInfo)}={LyricsContributorInfo}}}";
        }
    }
}