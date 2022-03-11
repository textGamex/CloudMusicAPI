using System;
using NeteaseCloudMusicAPI.Api.Models;
using NUnit.Framework;

namespace CloudMusicAPI_Test.Api.Models
{
    [TestFixture]
    public class LyricsTest
    {
        [Test]
        public void LyricsConstructorExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Lyrics(null));
        }
    }
}