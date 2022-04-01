using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class MVResult
    {
        public string LoadingPic { get; set; }
        public string BufferPic { get; set; }
        public string LoadingPicFs { get; set; }
        public string BufferPicFs { get; set; }
        public bool Subed { get; set; }
        public Data Data { get; set; }
        public long Code { get; set; }
    }

    public sealed class Data
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string BriefDesc { get; set; }
        public string Desc { get; set; }
        public string Cover { get; set; }
        public long CoverId { get; set; }
        public long PlayCount { get; set; }
        public long SubCount { get; set; }
        public long ShareCount { get; set; }
        public long LikeCount { get; set; }
        public long CommentCount { get; set; }
        public long Duration { get; set; }
        public long NType { get; set; }
        public DateTime PublishTime { get; set; }
        public Brs Brs { get; set; }
        public Artist[] Artists { get; set; }
        public bool IsReward { get; set; }
        public string CommentThreadId { get; set; }
    }

    public sealed class Brs
    {
        public string The480 { get; set; }
        public string The240 { get; set; }
        public string The720 { get; set; }
    }
}
