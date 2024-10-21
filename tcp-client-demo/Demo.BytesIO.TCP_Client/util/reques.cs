using HttpCode.Core;
using JinYiHelp.EasyHTTPClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.TCP_Client
{
    public class requests
    {

        private System.Net.CookieContainer cc = new System.Net.CookieContainer();//自动处理Cookie对象

        private HttpHelpers helper = new HttpHelpers();//发起请求对象

        private HttpItems items = new HttpItems();//请求设置对象

        private HttpResults hr = new HttpResults();//请求结果

        private string url;

        private Dictionary<string, string> header;

        private Dictionary<string, string> cookies;

        private string baseUrl;

        public requests(string url)
        {
            this.baseUrl = url;
            this.items.Method = "POST";
        }




        public  HttpResults POST(string url, string data ,string header = null)
        {
            string res = string.Empty;//请求结果,请求类型不是图片时有效
            items.Url = this.baseUrl + url; //设置请求地址
            items.Header.Clear();
           items.Header.Set(System.Net.HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like " +
               "Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0");
            //items.Container = cc;//自动处理Cookie时,每次提交时对cc赋值即可
            if(header != null)
            {
                items.Header.Set(System.Net.HttpRequestHeader.Authorization, header);
            }
            Console.WriteLine("请求标头：");
            Console.WriteLine(items.Header);
            items.ContentType = "application/json;charset=utf-8";
            items.Postdata = data;//设置请求参数
            hr = helper.GetHtml(items);//发起异步请求
            return hr;
        }
    }
}
