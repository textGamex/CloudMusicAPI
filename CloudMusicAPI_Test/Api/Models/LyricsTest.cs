using System;
using NeteaseCloudMusicAPI.Api;
using NeteaseCloudMusicAPI.JsonBase;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CloudMusicAPI_Test.Api.Models
{
    [TestFixture]
    public class LyricsTest
    {
        private const string TEST_DATA =
            "{\"Sgc\":false,\"Sfy\":true,\"Qfy\":true,\"Nolyric\":false," +
            "\"Uncollected\":false,\"TransUser\":null," +
            "\"LyricUser\":{\"Id\":3651114,\"Status\":99,\"Demand\":0,\"Userid\":85756151,\"Nickname\":\"星尘TwinkleStar\",\"Uptime\":0}," +
            "\"Lrc\":{\"Version\":36,\"Lyric\":\"[00:00.000] 作词 : 柚桐\n[00:01.000] 作曲 : 石页\n[00:10.35]如果星星还记得\n[00:14.78]编曲：石页\n[00:17.75]电吉他：石页\n[00:25.81]房瓦上停留着从何处飞来的寒鸦\n[00:32.21]零碎夜晚陪谁看烟火刹那\n[00:37.33]房前摆上一盆永不枯萎的花\n[00:41.46]静听 熄灭了灯火的人家\n[00:46.85]看夜空中星星多美丽闪烁着点点微光\n[00:52.03]等谁再说起那记忆中的年华\n[00:57.38]脚步太过沉重才会让人心灵那般拖沓\n[01:03.06]如果星星能记得的话\n[01:09.87]手边放着旧时候的那些泛黄书札\n[01:14.64]森林中密布盛开美丽繁花\n[01:19.62]看星星有多美听着流水哗啦\n[01:23.74]轻哼 青春唱过谁的童话\n[01:29.65]懵懂的年华我们也许总是在想着长大\n[01:34.89]随曾经一尘不变的记忆落下\n[01:40.24]只是想追寻昔日执着至今的小小步伐\n[01:45.88]如果星星能记得的话\n\"}," +
            "\"Klyric\":{\"Version\":0,\"lyric\":\"\"},\"Tlyric\":{\"Version\":0,\"Lyric\":\"\"},\"Code\":200}";
        
        [Test]
        public void ConstructorExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Lyrics(null));
        }

        [Test]
        public void Lyrics()
        {
            var data = new Lyrics(new RawLyricsResult());
            
            Assert.AreEqual(false, data.IsUncollected);
            Assert.AreEqual(string.Empty, data.Lyric);
            Assert.AreEqual(string.Empty, data.LyricKrc);
            Assert.AreEqual(string.Empty, data.Translation);
            Assert.AreEqual(null, data.LyricsContributorInfo);
        }

        [Test]
        public void TestToString()
        {
            var data = new Lyrics(JsonConvert.DeserializeObject<RawLyricsResult>(TEST_DATA));
            
            Assert.AreEqual(
                "Lyrics{IsUncollected=False, IsNotHasLyrics=False, " +
                "Lyric=[00:00.000] 作词 : 柚桐\n[00:01.000] 作曲 : 石页\n[00:10.35]如果星星还记得\n[00:14.78]编曲：石页\n[00:17.75]电吉他：石页\n[00:25.81]房瓦上停留着从何处飞来的寒鸦\n[00:32.21]零碎夜晚陪谁看烟火刹那\n[00:37.33]房前摆上一盆永不枯萎的花\n[00:41.46]静听 熄灭了灯火的人家\n[00:46.85]看夜空中星星多美丽闪烁着点点微光\n[00:52.03]等谁再说起那记忆中的年华\n[00:57.38]脚步太过沉重才会让人心灵那般拖沓\n[01:03.06]如果星星能记得的话\n[01:09.87]手边放着旧时候的那些泛黄书札\n[01:14.64]森林中密布盛开美丽繁花\n[01:19.62]看星星有多美听着流水哗啦\n[01:23.74]轻哼 青春唱过谁的童话\n[01:29.65]懵懂的年华我们也许总是在想着长大\n[01:34.89]随曾经一尘不变的记忆落下\n[01:40.24]只是想追寻昔日执着至今的小小步伐\n[01:45.88]如果星星能记得的话\n, " +
                "LyricKrc=, Translation=, " +
                "LyricsContributorInfo=LyricsContributor{Name=星尘TwinkleStar, UpTime=0, Id=85756151}}",
                data.ToString());
        }
    }
}