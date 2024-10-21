using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean.Subscribe
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// ApifoxModel
    /// </summary>
    public partial class Subscribe
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("data")]
        public sub[] Data { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

    public partial class sub
    {
        [JsonProperty("area_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AreaId { get; set; }

        [JsonProperty("areaName", NullValueHandling = NullValueHandling.Ignore)]
        public string AreaName { get; set; }

        [JsonProperty("beginTime", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; set; }

        [JsonProperty("cancel", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cancel { get; set; }

        [JsonProperty("earlierPeriods", NullValueHandling = NullValueHandling.Ignore)]
        public string EarlierPeriods { get; set; }

        [JsonProperty("earlierPeriodsSignIn", NullValueHandling = NullValueHandling.Ignore)]
        public long? EarlierPeriodsSignIn { get; set; }

        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; set; }

        [JsonProperty("enname", NullValueHandling = NullValueHandling.Ignore)]
        public string Enname { get; set; }

        [JsonProperty("ennameMerge", NullValueHandling = NullValueHandling.Ignore)]
        public string EnnameMerge { get; set; }

        [JsonProperty("flag_in", NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagIn { get; set; }

        [JsonProperty("flag_leave", NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagLeave { get; set; }

        [JsonProperty("flag_out", NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagOut { get; set; }

        [JsonProperty("hasLight", NullValueHandling = NullValueHandling.Ignore)]
        public long? HasLight { get; set; }

        [JsonProperty("hasRelay", NullValueHandling = NullValueHandling.Ignore)]
        public long? HasRelay { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public string Height { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("isSingle", NullValueHandling = NullValueHandling.Ignore)]
        public string IsSingle { get; set; }

        [JsonProperty("lastSigninTime", NullValueHandling = NullValueHandling.Ignore)]
        public string LastSigninTime { get; set; }

        [JsonProperty("nameMerge", NullValueHandling = NullValueHandling.Ignore)]
        public string NameMerge { get; set; }

        [JsonProperty("no", NullValueHandling = NullValueHandling.Ignore)]
        public string No { get; set; }

        [JsonProperty("oksign", NullValueHandling = NullValueHandling.Ignore)]
        public long? Oksign { get; set; }

        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        [JsonProperty("point_x", NullValueHandling = NullValueHandling.Ignore)]
        public string PointX { get; set; }

        [JsonProperty("point_x2")]
        public object PointX2 { get; set; }

        [JsonProperty("point_x3")]
        public object PointX3 { get; set; }

        [JsonProperty("point_x4")]
        public object PointX4 { get; set; }

        [JsonProperty("point_y", NullValueHandling = NullValueHandling.Ignore)]
        public string PointY { get; set; }

        [JsonProperty("point_y2")]
        public object PointY2 { get; set; }

        [JsonProperty("point_y3")]
        public object PointY3 { get; set; }

        [JsonProperty("point_y4")]
        public object PointY4 { get; set; }

        [JsonProperty("ROW_NUMBER", NullValueHandling = NullValueHandling.Ignore)]
        public string RowNumber { get; set; }

        [JsonProperty("showTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ShowTime { get; set; }

        [JsonProperty("signIn", NullValueHandling = NullValueHandling.Ignore)]
        public string SignIn { get; set; }

        [JsonProperty("signintime", NullValueHandling = NullValueHandling.Ignore)]
        public string Signintime { get; set; }

        [JsonProperty("signOut", NullValueHandling = NullValueHandling.Ignore)]
        public string SignOut { get; set; }

        [JsonProperty("smartDeviceName")]
        public object SmartDeviceName { get; set; }

        [JsonProperty("space", NullValueHandling = NullValueHandling.Ignore)]
        public string Space { get; set; }

        [JsonProperty("space_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SpaceId { get; set; }

        [JsonProperty("spaceCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string SpaceCategory { get; set; }

        [JsonProperty("spaceName", NullValueHandling = NullValueHandling.Ignore)]
        public string SpaceName { get; set; }

        [JsonProperty("spaceStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string SpaceStatus { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("statusname", NullValueHandling = NullValueHandling.Ignore)]
        public string Statusname { get; set; }

        [JsonProperty("statusName", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusName { get; set; }

        [JsonProperty("SYS_WEB_MYYUYUE_LEAVE", NullValueHandling = NullValueHandling.Ignore)]
        public string SysWebMyyuyueLeave { get; set; }

        [JsonProperty("SYS_WEB_MYYUYUE_RIGHTBACK", NullValueHandling = NullValueHandling.Ignore)]
        public string SysWebMyyuyueRightback { get; set; }

        [JsonProperty("SYS_WEB_MYYUYUE_SIGNIN", NullValueHandling = NullValueHandling.Ignore)]
        public string SysWebMyyuyueSignin { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }

        [JsonProperty("use_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? UseTime { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public string Width { get; set; }
    }
}
