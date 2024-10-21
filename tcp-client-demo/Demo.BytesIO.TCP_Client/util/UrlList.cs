using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client
{
    public class UrlList
    {
        private string Verify = "api/Captcha/verify";
        private string Login = "api/login/login";
        private string Confirm = "api/Seat/confirm";
        private string Data = "api/Seat/date";
        private string GetSeat = "api/Seat/seat";
        private string QuickSelect = "reserve/index/quickSelect";
        private string subscribe = "api/index/subscribe";

        // Getter
        public string getSubscribe() { return subscribe; }
        public string getVerify() { return Verify; }
        public string getLogin() { return  Login; }
        public string getConfirm() { return Confirm; }
        public string getData() { return Data; }
        public string getGetSeat() { return GetSeat; }
        public string getQuickSelect() { return QuickSelect; }

    }

}
