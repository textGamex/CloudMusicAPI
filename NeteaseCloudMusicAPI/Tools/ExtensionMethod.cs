using System.Collections.Specialized;

namespace NeteaseCloudMusicAPI.Tools
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtensionMethod
    {
        //参考JavaHashMap类的实现
        public static int HashCode(this NameValueCollection map)
        {
            int hashCode = 0;
            foreach (var key in map.AllKeys)
            {
                hashCode += (key == null ? 0 : key.GetHashCode()) ^
                            (map[key] == null ? 0 : map[key].GetHashCode());
            }
            return hashCode;
        }
    }
}