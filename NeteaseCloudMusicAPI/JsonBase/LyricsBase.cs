using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class RawLyricsResult
    {
        public bool Sgc { get; set; }
        public bool Sfy { get; set; }
        public bool Qfy { get; set; }
        public bool Nolyric { get; set; }
        public bool Uncollected { get; set; }
        public LyricUser TransUser { get; set; }
        public LyricUser LyricUser { get; set; }
        public Lrc Lrc { get; set; }
        public Klyric Klyric { get; set; }
        public Lrc Tlyric { get; set; }
        public long Code { get; set; }
    }

    public sealed class Klyric
    {
        public long Version { get; set; }
        public string lyric { get; set; }
    }

    public sealed class Lrc
    {
        public long Version { get; set; }
        public string Lyric { get; set; }
    }

    public sealed class LyricUser
    {
        public long Id { get; set; }
        public long Status { get; set; }
        public long Demand { get; set; }
        public long Userid { get; set; }
        public string Nickname { get; set; }
        public long Uptime { get; set; }
    }
}
