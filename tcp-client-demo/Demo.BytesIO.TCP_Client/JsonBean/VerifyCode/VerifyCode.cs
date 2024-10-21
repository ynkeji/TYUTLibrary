// 需要在NuGet里面添加 Newtonsoft.Json

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json
{

    public class VerifyCode
    {

        [JsonProperty("code")]
        public int Code;

        [JsonProperty("message")]
        public string Message;

        [JsonProperty("info")]
        public Info Info;
    }
    public class Info
    {

        [JsonProperty("base64")]
        public string Base64;

        [JsonProperty("key")]
        public string Key;

        [JsonProperty("md5")]
        public string Md5;
    }
}
