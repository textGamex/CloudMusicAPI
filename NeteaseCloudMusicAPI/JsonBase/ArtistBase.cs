using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class ArtistResult
    {
        public long Code { get; set; }
        public Artist Artist { get; set; }
        public bool More { get; set; }
        public List<HotSong> HotSongs { get; set; }
    }

    public sealed class Artist
    {
        public long Img1V1Id { get; set; }
        public long TopicPerson { get; set; }
        public long PicId { get; set; }
        public object BriefDesc { get; set; }
        public long AlbumSize { get; set; }
        public string Img1V1Url { get; set; }
        public string PicUrl { get; set; }
        public List<string> Alias { get; set; }
        public string Trans { get; set; }
        public long MusicSize { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public long PublishTime { get; set; }
        public long MvSize { get; set; }
        public bool Followed { get; set; }
    }

    public sealed class HotSong
    {
        public List<object> RtUrls { get; set; }
        public List<Ar> Ar { get; set; }
        public Al Al { get; set; }
        public long St { get; set; }
        public long Fee { get; set; }
        public long Ftype { get; set; }
        public long Rtype { get; set; }
        public object Rurl { get; set; }
        public long T { get; set; }
        public string Cd { get; set; }
        public long No { get; set; }
        public long V { get; set; }
        public object A { get; set; }
        public H M { get; set; }
        public long DjId { get; set; }
        public object Crbt { get; set; }
        public object RtUrl { get; set; }
        public List<object> Alia { get; set; }
        public long Pop { get; set; }
        public string Rt { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public string Cf { get; set; }
        public long Dt { get; set; }
        public long Pst { get; set; }
        public H H { get; set; }
        public H L { get; set; }
        public long Mv { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public Privilege Privilege { get; set; }
    }
}
