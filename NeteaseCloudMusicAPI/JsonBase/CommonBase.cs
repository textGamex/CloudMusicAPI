using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class Song
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long Pst { get; set; }
        public long T { get; set; }
        public List<Ar> Ar { get; set; }
        public List<object> Alia { get; set; }
        public double Pop { get; set; }
        public long St { get; set; }
        public string Rt { get; set; }
        public long Fee { get; set; }
        public long V { get; set; }
        public object Crbt { get; set; }
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
        public List<object> RtUrls { get; set; }
        public object Rurl { get; set; }
        public long Rtype { get; set; }
        public long Mst { get; set; }
        public long Cp { get; set; }
        public long Mv { get; set; }
        public long PublishTime { get; set; }
        public Privilege Privilege { get; set; }
    }

    public sealed class Ar
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<object> Tns { get; set; }
        public List<object> Alias { get; set; }
    }

    public sealed class H
    {
        public long Br { get; set; }
        public long Fid { get; set; }
        public long Size { get; set; }
        public double Vd { get; set; }
    }

    public sealed class Al
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public List<object> Tns { get; set; }
        public long Pic { get; set; }
    }

    public sealed class Privilege
    {
        public long Id { get; set; }
        public long Fee { get; set; }
        public long Payed { get; set; }
        public long St { get; set; }
        public long Pl { get; set; }
        public long Dl { get; set; }
        public long Sp { get; set; }
        public long Cp { get; set; }
        public long Subp { get; set; }
        public bool Cs { get; set; }
        public long Maxbr { get; set; }
        public long Fl { get; set; }
        public bool Toast { get; set; }
        public long Flag { get; set; }
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
}
