using NeteaseCloudMusicAPI;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.Net;

namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            // Console.WriteLine(new CloudMusicAPI().Comments(548279725));
            //Console.WriteLine(new CloudMusic(548279725).Lyrics.ContributorInfo);
            // string rootPath = @"D:\IDE\Project\Rid_C#\LyricsMessage\LyricsMessage\Lyrics";
            // DirectoryInfo folder = new DirectoryInfo(rootPath);
            // var data = folder.GetFiles();
            // var list = new List<CloudMusic>(data.Length);
            var aa = new CloudMusicAPI();
            var data = new Dictionary<string, string>
            {
                {"1", "2"},
                {"5", "6"},
            };
            var a = CloudMusicAPI.PostAsync("https://www.httpbin.org/post", data);
            Console.WriteLine(a.Result);
        }
    }
}
