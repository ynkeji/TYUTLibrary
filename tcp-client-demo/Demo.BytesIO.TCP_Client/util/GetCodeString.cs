using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.util
{
    public class GetCodeString
    {
        /// <summary>
        /// 超级鹰打码平台
        /// 在这里填入
        /// </summary>
        private string username = "";
        private string password = "";
        private string codeType = "1902";
        private string softId = "";
        private string key = string.Empty;
        private string code = string.Empty;
        public  string GetCode(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            string json =SuperCode.CJY_RecognizeBytes(bytes, bytes.Length, username, MD5String(password.Trim()), softId, codeType, "0", "0", "0");
            this.code = GetTextByKey(json, "pic_str");
            this.key = GetTextByKey(json, "pic_id");
            return code;
        }
        public void ReportError()
        {
            string str = SuperCode.CJY_ReportError(username, MD5String(password.Trim()), key, softId );
        }



        public  string MD5String(string str)
        {
            if (str == "") return str;
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            return MD5String(b);
        }
        public  string MD5String(byte[] b)
        {
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        /// <summary>
        /// 根据关键字获取JSON数据里面的信息
        /// </summary>
        /// <param name="jsonText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public  string GetTextByKey(string jsonText, string key)
        {
            JObject jsonObj = JObject.Parse(jsonText);
            string str = jsonObj[key].ToString();
            return str;
        }
    }
}
