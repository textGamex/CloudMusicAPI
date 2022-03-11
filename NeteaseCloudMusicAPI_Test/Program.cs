using System.Collections.Specialized;
using System.Text;
using NeteaseCloudMusicAPI;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.Net;
using Newtonsoft.Json;

namespace Test
{
    public static class Program
    {
        private static CloudMusicApi _api = new CloudMusicApi();
        public static async Task Main()
        {
            // var da = new CloudMusicAPI().Detail(54827972511);
            // var daa = new CloudMusicAPI().Lyrics(54827972511);
            var d = CloudMusic.GetLyrics(548279725);
            Console.WriteLine(d.LyricKrc);
            Console.WriteLine(d.LyricKrc == "");
            // Console.WriteLine(d.Details.IsNonExistent);
            // var a = CloudMusic.NewAsync(54827972511);
            // Console.WriteLine(123);
            // Console.WriteLine(a.Result);
            // Console.WriteLine("123");
            // Console.WriteLine(new CloudMusic(548279725).Lyrics.ContributorInfo);
            // string rootPath = @"D:\IDE\Project\Rid_C#\LyricsMessage\LyricsMessage\Lyrics";
            // DirectoryInfo folder = new DirectoryInfo(rootPath);
            // var data1 = folder.GetFiles();
            // var data = new List<long>();
            // foreach (var info in data1)
            // {
            //     data.Add(long.Parse(info.Name));
            // }
            // int max = 100;
            // for (int i = 0; i < max; ++i)
            // {
            //     var info = data1[i];
            //     data.Add(long.Parse(info.Name));
            // }
            // Console.WriteLine(data.Count);
            //
            // var api = new CloudMusicApi();
            // // api.Detail(1424617478);
            // foreach (var id in data)
            // {
            //     if (api.Comments(id)?.Total <= 999)
            //     {
            //         Console.WriteLine(api.Comments(id)?.Total);
            //         Console.WriteLine("宝藏音乐");
            //     }
            // }
        }
    }
}
