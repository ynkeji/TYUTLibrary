using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.op
{
    /// <summary>
    /// login
    /// </summary>
    public partial class Login
    {
        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("userTime")]
        public string UserTime { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
