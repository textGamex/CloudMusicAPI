using System;
using System.Collections.Generic;
using System.Text;
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class PlayListResult
    {
        public PlaylistBase Playlist { get; set; }
        public long Code { get; set; }
        public Privilege[] Privileges { get; set; }
    }

    public sealed class PlaylistBase
    {
        public object[] Subscribers { get; set; }
        public bool Subscribed { get; set; }
        public User Creator { get; set; }
        public Track[] Tracks { get; set; }
        public TrackId[] TrackIds { get; set; }
        public long CoverImgId { get; set; }
        public long CreateTime { get; set; }
        public long UpdateTime { get; set; }
        public bool NewImported { get; set; }
        public long Privacy { get; set; }
        public long SpecialType { get; set; }
        public string CommentThreadId { get; set; }
        public long TrackUpdateTime { get; set; }
        public long TrackCount { get; set; }
        public bool HighQuality { get; set; }
        public long SubscribedCount { get; set; }
        public long CloudTrackCount { get; set; }
        public string CoverImgUrl { get; set; }
        public long PlayCount { get; set; }
        public long AdType { get; set; }
        public long TrackNumberUpdateTime { get; set; }
        public object Description { get; set; }
        public bool Ordered { get; set; }
        public object[] Tags { get; set; }
        public long Status { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public long ShareCount { get; set; }
        public string CoverImgIdStr { get; set; }
        public long CommentCount { get; set; }
    }

    public sealed class User
    {
        public bool DefaultAvatar { get; set; }
        public long Province { get; set; }
        public long AuthStatus { get; set; }
        public bool Followed { get; set; }
        public string AvatarUrl { get; set; }
        public long AccountStatus { get; set; }
        public long Gender { get; set; }
        public long City { get; set; }
        public long Birthday { get; set; }
        public long UserId { get; set; }
        public long UserType { get; set; }
        public string Nickname { get; set; }
        public string Signature { get; set; }
        public string Description { get; set; }
        public string DetailDescription { get; set; }
        public long AvatarImgId { get; set; }
        public long BackgroundImgId { get; set; }
        public string BackgroundUrl { get; set; }
        public long Authority { get; set; }
        public bool Mutual { get; set; }
        public object ExpertTags { get; set; }
        public object Experts { get; set; }
        public long DjStatus { get; set; }
        public long VipType { get; set; }
        public object RemarkName { get; set; }
        public string BackgroundImgIdStr { get; set; }
        public string AvatarImgIdStr { get; set; }
    }

    public sealed class Track
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long Pst { get; set; }
        public long T { get; set; }
        public Ar[] Ar { get; set; }
        public string[] Alia { get; set; }
        public double Pop { get; set; }
        public long St { get; set; }
        public string Rt { get; set; }
        public long Fee { get; set; }
        public long V { get; set; }
        public string Crbt { get; set; }
        public string Cf { get; set; }
        public Al Al { get; set; }
        public long Dt { get; set; }
        public H H { get; set; }
        public H M { get; set; }
        public H L { get; set; }
        public object A { get; set; }
        public string Cd { get; set; }
        public long No { get; set; }
        public object RtUrl { get; set; }
        public long Ftype { get; set; }
        public object[] RtUrls { get; set; }
        public long DjId { get; set; }
        public long Copyright { get; set; }
        public long SId { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public long Mv { get; set; }
        public long Rtype { get; set; }
        public object Rurl { get; set; }
        public long PublishTime { get; set; }
        public string[] Tns { get; set; }
    }

    public sealed class TrackId
    {
        public long Id { get; set; }
        public long V { get; set; }
    }
}
