using NeteaseCloudMusicAPI;
namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(new CloudMusicAPI().Lyrics(548279725));
        }
    }
}
