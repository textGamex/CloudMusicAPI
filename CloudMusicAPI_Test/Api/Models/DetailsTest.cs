using System.IO;
using NeteaseCloudMusicAPI;
using NeteaseCloudMusicAPI.Api.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CloudMusicAPI_Test.Api.Models
{
    [TestFixture]
    public class DetailsTest
    {
        private const string TEST_DATA =
            "{\"Songs\":[{\"Name\":\"如果星星能记得(Vocaloid)\",\"Id\":447309968,\"Pst\":0,\"T\":0," +
            "\"Ar\":[{\"Id\":12200045,\"Name\":\"石页\",\"Tns\":[],\"Alias\":[]}],\"Alia\":[],\"Pop\":75.0,\"St\":0," +
            "\"Rt\":null,\"Fee\":0,\"V\":103,\"Crbt\":null,\"Cf\":\"\",\"Al\":{\"Id\":35060085,\"Name\":\"石页的V家曲\"," +
            "\"PicUrl\":\"https://p4.music.126.net/CUMANQGhUXEjB-Db1CvSwQ==/109951162824061491.jpg\",\"Tns\":[]," +
            "\"Pic\":109951162824061491},\"Dt\":157506,\"H\":{\"Br\":320000,\"Fid\":0,\"Size\":6302868,\"Vd\":-11799.0}," +
            "\"M\":{\"Br\":192000,\"Fid\":0,\"Size\":3781738,\"Vd\":-9400.0},\"L\":{\"Br\":128000,\"Fid\":0," +
            "\"Size\":2521173,\"Vd\":-8100.0},\"A\":null,\"Cd\":\"01\",\"No\":1,\"RtUrl\":null,\"Ftype\":0," +
            "\"RtUrls\":[],\"Rurl\":null,\"Rtype\":0,\"Mst\":9,\"Cp\":0,\"Mv\":0,\"PublishTime\":1481880909423," +
            "\"Privilege\":null}],\"Privileges\":[{\"Id\":447309968,\"Fee\":0,\"Payed\":0,\"St\":0,\"Pl\":320000," +
            "\"Dl\":999000,\"Sp\":7,\"Cp\":1,\"Subp\":1,\"Cs\":false,\"Maxbr\":999000,\"Fl\":320000,\"Toast\":false," +
            "\"Flag\":2}],\"Code\":200}";
        
        [Test]
        public void TestToString()
        {
            var detail = new Details(JsonConvert.DeserializeObject<RawDetailsResult>(TEST_DATA));
            
            Assert.AreEqual("Details{AuthorInfos=[{石页=12200045}], SongId=447309968, SongName=如果星星能记得(Vocaloid), " +
                            "SongCover=https://p4.music.126.net/CUMANQGhUXEjB-Db1CvSwQ==/109951162824061491.jpg, " +
                            "SongAlbumId=35060085, SongAlbumName=石页的V家曲, Popularity=75}", detail.ToString());
        }
    }
}