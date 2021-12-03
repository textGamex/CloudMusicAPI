using System;
using System.Collections.Generic;

namespace NeteaseCloudMusicAPI.JsonBase.CommentBase
{
    public partial class CommentResult
    {
        public bool IsMusician { get; set; }
        public long UserId { get; set; }
        public List<object> TopComments { get; set; }
        public bool MoreHot { get; set; }
        public List<HotComment> HotComments { get; set; }
        public object CommentBanner { get; set; }
        public long Code { get; set; }
        public List<Comment> Comments { get; set; }
        public long Total { get; set; }
        public bool More { get; set; }
    }

    public partial class Comment
    {
        public User User { get; set; }
        public List<BeReplied> BeReplied { get; set; }
        public PendantData PendantData { get; set; }
        public object ShowFloorComment { get; set; }
        public long Status { get; set; }
        public long CommentId { get; set; }
        public string Content { get; set; }
        public object ContentResource { get; set; }
        public long Time { get; set; }
        public string TimeStr { get; set; }
        public bool NeedDisplayTime { get; set; }
        public long LikedCount { get; set; }
        public object ExpressionUrl { get; set; }
        public long CommentLocationType { get; set; }
        public long ParentCommentId { get; set; }
        public CommentDecoration Decoration { get; set; }
        public object RepliedMark { get; set; }
        public bool Liked { get; set; }
    }

    public partial class BeReplied
    {
        public User User { get; set; }
        public long BeRepliedCommentId { get; set; }
        public string Content { get; set; }
        public long Status { get; set; }
        public object ExpressionUrl { get; set; }
    }

    public partial class User
    {
        public object LocationInfo { get; set; }
        public object LiveInfo { get; set; }
        public long Anonym { get; set; }
        public object CommonIdentity { get; set; }
        public long UserId { get; set; }
        public AvatarDetail AvatarDetail { get; set; }
        public long UserType { get; set; }
        public object ExpertTags { get; set; }
        public object Experts { get; set; }
        public long VipType { get; set; }
        public bool Followed { get; set; }
        public bool Mutual { get; set; }
        public object RemarkName { get; set; }
        public VipRights VipRights { get; set; }
        public string Nickname { get; set; }
        public Uri AvatarUrl { get; set; }
        public long AuthStatus { get; set; }
    }

    public partial class AvatarDetail
    {
        public long UserType { get; set; }
        public long IdentityLevel { get; set; }
        public Uri IdentityIconUrl { get; set; }
    }

    public partial class VipRights
    {
        public Associator Associator { get; set; }
        public object MusicPackage { get; set; }
        public long RedVipAnnualCount { get; set; }
        public long RedVipLevel { get; set; }
    }

    public partial class Associator
    {
        public long VipCode { get; set; }
        public bool Rights { get; set; }
    }

    public partial class CommentDecoration
    {
    }

    public partial class PendantData
    {
        public long Id { get; set; }
        public Uri ImageUrl { get; set; }
    }

    public partial class HotComment
    {
        public User User { get; set; }
        public List<BeReplied> BeReplied { get; set; }
        public PendantData PendantData { get; set; }
        public object ShowFloorComment { get; set; }
        public long Status { get; set; }
        public long CommentId { get; set; }
        public string Content { get; set; }
        public object ContentResource { get; set; }
        public long Time { get; set; }
        public DateTimeOffset TimeStr { get; set; }
        public bool NeedDisplayTime { get; set; }
        public long LikedCount { get; set; }
        public object ExpressionUrl { get; set; }
        public long CommentLocationType { get; set; }
        public long ParentCommentId { get; set; }
        public HotCommentDecoration Decoration { get; set; }
        public object RepliedMark { get; set; }
        public bool Liked { get; set; }
    }

    public partial class HotCommentDecoration
    {
        public long? RepliedByAuthorCount { get; set; }
    }
}
