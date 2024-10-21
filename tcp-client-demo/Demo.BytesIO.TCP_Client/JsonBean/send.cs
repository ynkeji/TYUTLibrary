using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean
{
    /// <summary>
    /// login_
    /// </summary>
    public partial class send
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("userTime")]
        public string UserTime { get; set; }
    }
}
