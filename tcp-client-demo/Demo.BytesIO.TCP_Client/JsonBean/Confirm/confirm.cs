using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Demo.BytesIO.TCP_Client.JsonBean
{
    internal class Confirm
    {
      
        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("new_time")]
        public string NewTime { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("seat")]
        public string Seat { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
