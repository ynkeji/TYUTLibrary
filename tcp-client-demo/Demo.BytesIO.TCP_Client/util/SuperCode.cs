using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.util
{
    public class SuperCode
    {


        public static string CJY_GetScore(string lpUser, string lpPass)
        {
            string paramData = "user=" + lpUser + "&pass2=" + lpPass;
            string ResultStr = PostWebRequest("http://code.chaojiying.net/Upload/GetScore.php", paramData, Encoding.UTF8);
            return ResultStr;
        }
        //报错返分
        public static string CJY_ReportError(string lpUser, string lpPass, string lpPicId, string lpSoftId)
        {
            string paramData = "user=" + lpUser + "&pass2=" + lpPass + "&id=" + lpPicId + "&softid=" + lpSoftId;
            string ResultStr = PostWebRequest("http://code.chaojiying.net/Upload/ReportError.php", paramData, Encoding.UTF8);
            return ResultStr;
        }
        //用户注册
        public static string CJY_UserReg(string lpUser, string lpPass)
        {
            string paramData = "user=" + lpUser + "&pass=" + lpPass;
            string ResultStr = PostWebRequest("http://code.chaojiying.net/Upload/UserReg.php", paramData, Encoding.UTF8);
            return ResultStr;
        }
        //账号充值
        public static string CJY_UserPay(string lpUser, string lpCard)
        {
            string paramData = "user=" + lpUser + "&card=" + lpCard;
            string ResultStr = PostWebRequest("http://code.chaojiying.net/Upload/UserPay.php", paramData, Encoding.UTF8);
            return ResultStr;
        }
        //按图片路径识别
        public static string CJY_RecognizeFile(string lpPicPath, string lpUser, string lpPass, string lpSoftId, string lpCodeType, string len_min, string time_add, string lpDebug)
        {
            byte[] _fileblob = null;
            FileStream stream = null;
            try
            {
                stream = new FileStream(lpPicPath, FileMode.Open, FileAccess.Read);
                _fileblob = new byte[stream.Length];
                stream.Read(_fileblob, 0, (int)stream.Length);
            }
            finally
            {
                stream.Close();
            }

            string ResultStr = CJY_RecognizeBytes(_fileblob, _fileblob.Length, lpUser, lpPass, lpSoftId, lpCodeType, len_min, time_add, lpDebug);
            return ResultStr;
        }
        //按图片内存流识别
        public static string CJY_RecognizeBytes(byte[] pPicBytes, int LenBytes, string lpUser, string lpPass, string lpSoftId, string lpCodeType, string len_min, string time_add, string lpDebug)
        {
            var param = new Dictionary<object, object>
                        {
                            {"user",lpUser},
                            {"pass2",lpPass},
                            {"softid",lpSoftId},
                            {"codetype",lpCodeType},
                            {"len_min",len_min},
                            {"time_add",time_add},
                            {"str_debug",lpDebug}
                        };

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://upload.chaojiying.net/Upload/Processing.php");
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)";
            wr.ServicePoint.Expect100Continue = false;
            wr.Referer = "c#f";
            wr.Method = "POST";

            wr.Timeout = 60000;
            //wr.KeepAlive = true;

            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream rs = wr.GetRequestStream();
            string responseStr = null;

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in param.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, param[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            //string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string headerTemplate = "Content-Disposition: form-data; name=\"userfile\"; filename=\"ccc.jpg\"\r\nContent-Type: application/octet-stream\r\n\r\n";
            string header = string.Format(headerTemplate, "image", pPicBytes, "image/gif");//image/jpeg
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            rs.Write(pPicBytes, 0, LenBytes);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();

                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                responseStr = reader2.ReadToEnd();

            }
            catch
            {
                //throw;
            }
            finally
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                wr.Abort();
                wr = null;

            }
            return responseStr;
        }
        //普通POST提交函数
        private static string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;

            byte[] byteArray = dataEncode.GetBytes(paramData); //转化
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)";
            webReq.ServicePoint.Expect100Continue = false;
            webReq.Referer = "c#";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();

            return ret;
        }

    }
}
