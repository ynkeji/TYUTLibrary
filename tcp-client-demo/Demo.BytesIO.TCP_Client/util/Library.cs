using Demo.BytesIO.TCP_Client.util;
using HttpCode.Core;
using JinYiHelp.EasyHTTPClient;
using Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.TCP_Client
{
    public  class Library
    {

        private static UrlList UrlList = new UrlList();
        private ListViewList ls = new ListViewList();
        private string VerifyKey = string.Empty;
        private string token = string.Empty;
        private string url = "http://kjyy.lib.tyut.edu.cn/";
        requests requests = new requests("http://kjyy.lib.tyut.edu.cn/");
        public Library()
        {
        }

        /// <summary>
        /// 获取登录验证码
        /// </summary>
        public string GetVerifyCode()
        {
            
            HttpResults re = requests.POST(UrlList.getVerify(), "{}");
            try
            {
                VerifyCode verifyCode = Newtonsoft.Json.JsonConvert.DeserializeObject<VerifyCode>(re.Html);
                this.VerifyKey = verifyCode.Info.Key;
                this.SetData(ls.getFail(), ls.getOriginSend(), "获取验证码成功");
                return verifyCode.Info.Base64;
            }
            catch (Exception e)
            {
                this.SetData(ls.getFail(), ls.getOriginSend(), "获取验证码失败");
                Console.Error.WriteLine(e);
            }
            return "";

        }
        /// <summary>
        /// 登录函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        public string Login(string username, string password, string verifyCode)
        {
            try
            {
                string data = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"code\":\"" + verifyCode + "\",\"key\":\"" + this.VerifyKey + "\"}";
                data =aes.AES_Encrypt(data);
                data = $"{{\"aesjson\": \"{data}\"}}";
                //HttpResults re = requests.POST(UrlList.getLogin(), data);
                return Post(UrlList.getLogin(), data, "bearer" + token);
            }
            catch (Exception e)
            {
                this.SetData(ls.getFail(), ls.getOriginSend(), "登录失败");
            }
            return "{}";
        }


        public string GetAreaInformation(string d)
        {
            string data = $"{{\"id\":\"1\",\"date\":\"{d}\" ,\"categoryIds\":[\"1\"],\"members\":0,\"authorization\":\"{"bearer" + token}\"}}";
            //HttpResults re = requests.POST(UrlList.getQuickSelect(), data,"bearer" + token);
            return Post(UrlList.getQuickSelect(), data, "bearer" + token);
            //return re.Html;
        }

        public string Myreserve()
        {
            string data = $"{{\"authorization\":{"bearer" + token}}}";
            //HttpResults re = requests.POST(UrlList.getSubscribe(), data, "bearer" + token);
            return Post(UrlList.getSubscribe(), data, "bearer" + token);
        }

        public string GetTime(string d)
        {
            string data = $"{{\"build_id\":\"{d}\" ,\"authorization\":\"{"bearer" + token}\"}}";
            //Console.WriteLine(data);
            //HttpResults re = requests.POST(UrlList.getData(), data, "bearer" + token);
            //Console.WriteLine(re.Html);
            return Post(UrlList.getData(), data, "bearer" + token);
        }

        public string GetSeat(string area,string day,string endTime,string segment,string startTime)
        {
            string da = $"{{\"area\":\"{area}\",\"segment\":\"{segment}\",\"day\":\"{day}\",\"startTime\":\"{startTime}\",\"endTime\":\"{endTime}\",\"authorization\":\"{"bearer" + token}\"}}";
            //HttpResults re = requests.POST(UrlList.getGetSeat(), da, "bearer" + token);
            return Post(UrlList.getGetSeat(), da, "bearer" + token);
        }

        public string Confirm(string seat,string seg)
        {
            string data = $"{{\"seat_id\":\"{seat}\",\"segment\":\"{seg}\"}}";
            string send = aes.AES_Encrypt(data);
            string s = $"{{\"aesjson\":\"{send}\",\"authorization\":\"{"bearer" + token}\"}}";
            Console.WriteLine (s);
            Console.WriteLine(token);
            //HttpResults re = requests.POST(UrlList.getConfirm(), s, "bearer" + token);
            return Post(UrlList.getConfirm(),s, "bearer" + token);
        }


            private string Post(string api,string data, string token )
            {
                //创建Web访问对象
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(this.url + api);
                //把用户传过来的数据转成“UTF-8”的字节流
                byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);
                myRequest.Method = "POST";
                myRequest.ContentLength = buf.Length;
                myRequest.ContentType = "application/json";
                myRequest.MaximumAutomaticRedirections = 1;
                myRequest.AllowAutoRedirect = true;
                myRequest.Headers.Add(HttpRequestHeader.Authorization,token);
                //发送请求
                Stream stream = myRequest.GetRequestStream();
                stream.Write(buf, 0, buf.Length);
                stream.Close();

                //获取接口返回值
                //通过Web访问对象获取响应内容
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
                string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
                reader.Close();
                myResponse.Close();
                return returnXml;
            }
        public void setToken(string token)
        {
            this.token = token;
        }

        private void SetData(string state, string type, string data)
        {
            Form1.form.listView1.Invoke(new Action(() =>
            {
                Form1.form.setData(state, type, data);
            }));
        }
    }
}
