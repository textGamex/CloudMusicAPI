using NeteaseCloudMusicAPI;
namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            //Console.WriteLine(new CloudMusicAPI().Lyrics(548279725));
            Console.WriteLine(new CloudMusicAPI().Comment(548279725));
        }
    }
}
