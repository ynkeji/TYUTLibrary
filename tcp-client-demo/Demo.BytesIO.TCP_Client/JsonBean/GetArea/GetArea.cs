using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.GetArea
{
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        /// <summary>
        /// GetArea
        /// </summary>
        public partial class GetArea
        {
            [JsonProperty("code")]
            public long Code { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("msg")]
            public string Msg { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("area")]
            public Area[] Area { get; set; }

            [JsonProperty("date")]
            public string[] Date { get; set; }

            [JsonProperty("premises")]
            public Premises[] Premises { get; set; }

            [JsonProperty("storey")]
            public Storey[] Storey { get; set; }
        }

        public partial class Area
        {
            [JsonProperty("enname")]
            public string Enname { get; set; }

            [JsonProperty("ennameMerge")]
            public string EnnameMerge { get; set; }

            [JsonProperty("free_num")]
            public long FreeNum { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nameMerge")]
            public string NameMerge { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("thumb_img")]
            public string ThumbImg { get; set; }

            [JsonProperty("topId")]
            public string TopId { get; set; }

            [JsonProperty("total_num")]
            public string TotalNum { get; set; }

            [JsonProperty("typeCategory")]
            public string TypeCategory { get; set; }
        }

        public partial class Premises
        {
            [JsonProperty("enname", NullValueHandling = NullValueHandling.Ignore)]
            public string Enname { get; set; }

            [JsonProperty("ennameMerge", NullValueHandling = NullValueHandling.Ignore)]
            public string EnnameMerge { get; set; }

            [JsonProperty("free_num", NullValueHandling = NullValueHandling.Ignore)]
            public long? FreeNum { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("nameMerge", NullValueHandling = NullValueHandling.Ignore)]
            public string NameMerge { get; set; }

            [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
            public long? ParentId { get; set; }

            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            public string Sort { get; set; }

            [JsonProperty("topId", NullValueHandling = NullValueHandling.Ignore)]
            public string TopId { get; set; }

            [JsonProperty("total_num", NullValueHandling = NullValueHandling.Ignore)]
            public long? TotalNum { get; set; }

            [JsonProperty("typeCategory", NullValueHandling = NullValueHandling.Ignore)]
            public long? TypeCategory { get; set; }
        }

        public partial class Storey
        {
            [JsonProperty("enname")]
            public string Enname { get; set; }

            [JsonProperty("ennameMerge")]
            public string EnnameMerge { get; set; }

            [JsonProperty("free_num")]
            public long FreeNum { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nameMerge")]
            public string NameMerge { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("sort")]
            public string Sort { get; set; }

            [JsonProperty("topId")]
            public string TopId { get; set; }

            [JsonProperty("total_num")]
            public long TotalNum { get; set; }

            [JsonProperty("typeCategory")]
            public long TypeCategory { get; set; }
        }
    }
