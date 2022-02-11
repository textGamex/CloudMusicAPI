namespace NeteaseCloudMusicAPI.Net
{
    public partial class CloudMusicApi
    {
        /// <summary>
        /// 网易云音乐的API接口
        /// </summary>
        protected static class ApiUrl
        {
            public const string LYRICS_URL = "https://music.163.com/weapi/song/lyric?csrf_token=";
            public const string DETAIL_URL = "https://music.163.com/weapi/v3/song/detail?csrf_token=";
        }
    }
}