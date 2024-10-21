using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.op
{
    /// <summary>
    /// 请求：获取座位信息
    /// </summary>
    public  class GetSeatBean
    {
        [JsonProperty("area")]
        public string AreaId { get; set; }

        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userTime")]
        public string UserTime { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        //string area,string day,string endTime,string segment,string startTime
        [JsonProperty("day")]
        public string day { get; set; }

        [JsonProperty("endTime")]
        public string endTime { get; set; }

        [JsonProperty("segment")]
        public string segment { get; set; }

        [JsonProperty("startTime")]
        public string startTime { get; set; }

    }
}
