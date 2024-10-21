using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client
{
    public class ListViewList
    {
        private string fail = "失败";
        private string success = "成功";
        private string origin_send = "发送";
        private string origin_receive = "接收";

        //getter
        public string getFail() { return fail; }
        public string getSuccess() { return success; }
        public string getOriginSend() { return origin_send; }
        public string getOriginReceive() { return origin_receive; }

    }
}
