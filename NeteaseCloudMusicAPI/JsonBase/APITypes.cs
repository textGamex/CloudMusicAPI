/** 
 * License: MIT License
 * Copyright (c) 2018 GEEKiDoS
 * URL: https://github.com/GEEKiDoS/NeteaseMuiscApi
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

namespace NeteaseCloudMusicAPI.JsonBase
{       
    public sealed class SongUrls
    {
        public Datum[] Data { get; set; }
        public long Code { get; set; }
    }

    public sealed class Datum
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long Br { get; set; }
        public long Size { get; set; }
        public string Md5 { get; set; }
        public long Code { get; set; }
        public long Expi { get; set; }
        public string Type { get; set; }
        public double Gain { get; set; }
        public long Fee { get; set; }
        public object Uf { get; set; }
        public long Payed { get; set; }
        public long Flag { get; set; }
        public bool CanExtend { get; set; }
    }             
}