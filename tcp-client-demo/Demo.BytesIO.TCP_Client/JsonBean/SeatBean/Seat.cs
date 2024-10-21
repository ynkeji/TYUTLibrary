using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.SeatBean
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// ApifoxModel
    /// </summary>
    public partial class Seat
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("area_levels")]
        public string AreaLevels { get; set; }

        [JsonProperty("area_name")]
        public string AreaName { get; set; }

        [JsonProperty("area_type")]
        public string AreaType { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("in_label")]
        public long InLabel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("point_x")]
        public string PointX { get; set; }


        [JsonProperty("point_y")]
        public string PointY { get; set; }


        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }
}
