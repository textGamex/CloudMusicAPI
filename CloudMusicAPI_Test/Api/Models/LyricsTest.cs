using System;
using NeteaseCloudMusicAPI.Api.Models;
using NeteaseCloudMusicAPI;
using NUnit.Framework;

namespace CloudMusicAPI_Test.Api.Models
{
    [TestFixture]
    public class LyricsTest
    {
        [Test]
        public void ConstructorExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Lyrics(null));
        }

        [Test]
        public void Lyrics()
        {
            var data = new Lyrics(new LyricsResult());
            
            Assert.AreEqual(false, data.IsUncollected);
            Assert.AreEqual(string.Empty, data.Lyric);
            Assert.AreEqual(string.Empty, data.LyricKrc);
            Assert.AreEqual(string.Empty, data.Translation);
            Assert.AreEqual(null, data.LyricsContributorInfo);
        }
    }
}