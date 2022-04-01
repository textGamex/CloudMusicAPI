using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class RawDetailsResult
    {
        public Song[] Songs { get; set; }
        public Privilege[] Privileges { get; set; }
        public long Code { get; set; }
    }

    public sealed class DetailResultBatch
    {
        public List<Song> Songs { get; set; }
        public List<Privilege> Privileges { get; set; }
        public long Code { get; set; }
    }
}
