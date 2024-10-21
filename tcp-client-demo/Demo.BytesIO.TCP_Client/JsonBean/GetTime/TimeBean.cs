using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.op
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// ApifoxModel
    /// </summary>
    public partial class GetTimeBean
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
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("times")]
        public Time[] Times { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }
}
