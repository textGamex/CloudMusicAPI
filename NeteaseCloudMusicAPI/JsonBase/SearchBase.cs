using System;
using System.Collections.Generic;
using System.Text;
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
namespace NeteaseCloudMusicAPI.JsonBase
{
    public sealed class SearchResult
    {
        public SResult Result { get; set; }
        public long Code { get; set; }
    }

    public sealed class SResult
    {
        public List<Song> Songs { get; set; }
        public long SongCount { get; set; }
        public List<AlbumBase> Albums { get; set; }
        public long AlbumCount { get; set; }
        public List<Artist> Artists { get; set; }
        public long ArtistCount { get; set; }
        public List<PlaylistBase> Playlists { get; set; }
        public long PlaylistCount { get; set; }
        public List<User> Userprofiles { get; set; }
        public long UserprofileCount { get; set; }
    }
}
