using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.op
{
    /// <summary>
    /// 请求：预约座位
    /// </summary>
    public partial class Reserve
    {


        [JsonProperty("op")]
        public string Op { get; set; }


        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("seg")]
        public string seg { get; set; }
        [JsonProperty("area")]
        public string area { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("userTime")]
        public string UserTime { get; set; }

    }
}
