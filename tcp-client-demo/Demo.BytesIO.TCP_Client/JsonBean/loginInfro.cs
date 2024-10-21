using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public partial class loginModel
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
        [JsonProperty("card")]
        public string Card { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("deptName")]
        public string DeptName { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("flagName")]
        public string FlagName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isClearLocker")]
        public long IsClearLocker { get; set; }

        [JsonProperty("isList")]
        public string IsList { get; set; }

        [JsonProperty("isQuickSelect")]
        public string IsQuickSelect { get; set; }

        [JsonProperty("isStorageLocker")]
        public long IsStorageLocker { get; set; }

        [JsonProperty("joinTime")]
        public string JoinTime { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("mobile")]
        public object Mobile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popUp")]
        public PopUp PopUp { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("ROW_NUMBER")]
        public string RowNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public partial class PopUp
    {
        [JsonProperty("userShowActivityTextFlag")]
        public long UserShowActivityTextFlag { get; set; }

        [JsonProperty("userShowLockerTextFlag")]
        public long UserShowLockerTextFlag { get; set; }

        [JsonProperty("userShowRoomTextFlag")]
        public long UserShowRoomTextFlag { get; set; }

        [JsonProperty("userShowSeatTextFlag")]
        public long UserShowSeatTextFlag { get; set; }
    }
}
