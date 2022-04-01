using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NeteaseCloudMusicAPI.JsonBase;
using System.Collections.Specialized;
using NeteaseCloudMusicAPI.Tools;

namespace NeteaseCloudMusicAPI.Api

{
    /// <summary>
    /// 歌曲详情
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 作者信息, <c>key</c>为作者名称, <c>value</c>为作者ID
        /// </summary>
        public NameValueCollection AuthorInfos { get; private set; } = new NameValueCollection();

        /// <summary>
        /// 歌曲名
        /// </summary>
        public string SongName { get; private set; }
        
        /// <summary>
        /// 歌曲ID
        /// </summary>
        public long SongId { get; }

        /// <summary>
        /// 歌曲封面
        /// </summary>
        public string SongCover { get; private set; }

        /// <summary>
        /// 歌曲所属专辑ID
        /// </summary>
        public long SongAlbumId { get; private set; }

        /// <summary>
        /// 歌曲所属专辑名称
        /// </summary>
        public string SongAlbumName { get; private set; }

        /// <summary>
        /// 歌曲所属专辑封面
        /// </summary>
        public string SongAlbumCover
        {
            get { return SongCover; }
            private set { SongCover = value; }
        }

        /// <summary>
        /// 热度
        /// </summary>
        public double Popularity { get; private set; }
        
        /// <summary>
        /// 歌曲时长, 单位为毫秒
        /// </summary>
        public long SongTime { get; }

        public Details(Song song)
        {
            foreach (var item in song.Ar)
            {
                AuthorInfos.Add(item.Name, item.Id.ToString());
            }

            SongId = song.Id;
            SongName = song.Name;
            SongCover = song.Al.PicUrl;
            SongAlbumId = song.Al.Id;
            SongAlbumName = song.Al.Name;
            Popularity = song.Pop;
            SongTime = song.Dt;
        }

        public Details(RawDetailsResult data) : this(data.Songs[0]) {}

        /// <summary>
        /// 如果歌曲不存在,返回true
        /// </summary>
        public bool IsNonExistent { get; }

        public override string ToString()
        {
            var sb = new StringBuilder($"{GetType().Name}{{");
            sb.Append("AuthorInfos=[");
            int count = 0;
            foreach (var key in AuthorInfos.AllKeys)
            {
                ++count;
                sb.Append($"{{{key}={AuthorInfos[key]}}}");
                if (count != AuthorInfos.Count)
                {
                    sb.Append(", ");
                }
            }
            sb.Append($"], {nameof(SongId)}={SongId}, ");
            sb.Append($"{nameof(SongName)}={SongName}, SongCover={SongCover}, SongAlbumId={SongAlbumId}, " +
                      $"SongAlbumName={SongAlbumName}");
            sb.Append(", Popularity=").Append(Popularity).Append($", {nameof(SongTime)}={SongTime}").Append('}');
            return sb.ToString();
        }

        /// <summary>
        /// 散列码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = AuthorInfos?.HashCode() ?? 0;
            result = result * 31 + SongId.GetHashCode();
            result = result * 31 + SongName?.GetHashCode() ?? 0;
            result = result * 31 + SongCover?.GetHashCode() ?? 0;
            result = result * 31 + SongAlbumName?.GetHashCode() ?? 0;
            result = result * 31 + SongAlbumId.GetHashCode();
            result = result * 31 + Popularity.GetHashCode();
            result = result * 31 + SongTime.GetHashCode();
            return result;
        }
    }
}