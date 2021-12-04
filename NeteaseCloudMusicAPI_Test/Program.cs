using NeteaseCloudMusicAPI;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.Net;

namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            //Console.WriteLine(new CloudMusicAPI().Lyrics(548279725));
            Console.WriteLine(new CloudMusic(548279725).Lyrics.ContributorInfo);
        }
    }
}
