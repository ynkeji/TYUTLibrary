using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Demo.BytesIO.TCP_Client;
using Demo.BytesIO.TCP_Client.JsonBean;
using Demo.BytesIO.TCP_Client.JsonBean.GetArea;
using Demo.BytesIO.TCP_Client.JsonBean.op;
using Demo.BytesIO.TCP_Client.JsonBean.SeatBean;
using Demo.BytesIO.TCP_Client.JsonBean.Subscribe;
using Demo.BytesIO.TCP_Client.util;
using HttpCode.Core;
using Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Demo.BytesIO.TCP_Client.Form1;

namespace Demo.BytesIO.TCP_Client
{
    public class DataDeal
    {
        private ListViewList ls = new ListViewList();
        private Form form;
        Library library = null;
        NetworkStream stream = null;
        public DataDeal(Form form, NetworkStream stream)
        {
            this.stream = stream;
            this.form = form;
            library = new Library();

        }
        ListViewList list = new ListViewList();
        public string GetAreaInformation(GetAreaInformation getAreaInformation)
        {
            Boolean flag = false;
            GetArea getArea = new GetArea();
            int i = 0;
            send s = new send();
            s.UserTime = getAreaInformation.UserTime;
            try
            {
                GetCodeString getCodeString = new GetCodeString();

                //while (i <= 5)
                //{
                //    if(getAreaInformation.Token != null) { 
                //        library.setToken(getAreaInformation.Token);
                //        break; 
                //    }
                //    string code_base64 = library.GetVerifyCode();
                //    code_base64 = code_base64.Replace("data:image/png;base64,", "");
                //    string code = getCodeString.GetCode(code_base64);
                //    string result = library.Login(getAreaInformation.Username, getAreaInformation.Password, code);
                    
                //    if (GetTextByKey(result,"msg").Equals("用户名或密码错误~"))
                //    {
                //        getArea.Msg = "用户名或密码错误";
                //    }
                //    if(GetTextByKey(result,"msg").Equals("操作成功"))
                //    {
                //        loginModel loginModel = Newtonsoft.Json.JsonConvert.DeserializeObject<loginModel>(result);
                //        string token = loginModel.Data.Token;
                //        library.setToken(token);
                //        break;
                //    }
                //    if (GetTextByKey(result,"msg").Equals("验证码验证失败！"))
                //    { 
                //        SetData(ls.getFail(), ls.getOriginSend(), getAreaInformation.Username + "第" + i + "次登录失败，请求重试！");
                //        getCodeString.ReportError();
                //        continue;
                //    }
                //    if (i > 5)
                //    {
                //        SetData(ls.getFail(), ls.getOriginSend(), getAreaInformation.Username + "登录失败！请联系管理员！");
                //        getArea.Msg = "System error";
                //        break;
                //    }
                    
                //    i++;

                //}
                //if (flag) { s.Data = getArea; return JsonConvert.SerializeObject(s) + "<END>"; }
                getArea = Newtonsoft.Json.JsonConvert.DeserializeObject<GetArea>(library.GetAreaInformation(getAreaInformation.Time));
                s.Data = JsonConvert.SerializeObject(getArea);
                return JsonConvert.SerializeObject(s) + "<END>";

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return JsonConvert.SerializeObject(s) + "<END>";
        }

        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public string login(Login login)
        {
            send s = new send();
            login_send send = new login_send();
            try
            {
                GetCodeString getCodeString = new GetCodeString();
                int i = 0;
                
                while (i <= 5)
                {
                    string code_base64 = library.GetVerifyCode();
                    if (code_base64.Equals(""))
                    {
                        send.Msg = "登录失败！请联系管理员！";
                        send.Data = null;
                        send.Code = 0;
                        s.UserTime = login.UserTime;
                        s.Data = JsonConvert.SerializeObject(send);
                        break;
                    }
                    code_base64 = code_base64.Replace("data:image/png;base64,", "");
                    string code = getCodeString.GetCode(code_base64);
                    string result = library.Login(login.Username, login.Password, code);
                    if (GetTextByKey(result, "msg").Equals("用户名或密码错误~"))
                    {
                        send.Code = 0;
                        send.Msg = "用户名或密码错误~";
                        send.Data = null;
                        s.UserTime = login.UserTime;
                        s.Data = JsonConvert.SerializeObject(send);
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("操作成功"))
                    {
                        loginModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<loginModel>(result);
                        send tokenSend = new send();
                        tokenSend.Data = model.Data.Token;
                        tokenSend.UserTime = login.Username + "token";
                        byte[] bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(tokenSend) + "<END>");
                        this.stream.Write(bytes, 0, bytes.Length);
                        send.Code = 1;
                        send.Msg = "登录成功";
                        send.Data.FlagName = model.Data.FlagName;
                        send.Data.Id = model.Data.Id;
                        send.Data.Name = model.Data.Name;
                        send.Data.RoleName = model.Data.RoleName;
                        send.Data.Email = model.Data. Email;
                        send.Data.Mobile = model.Data.Mobile;
                        send.Data.DeptName = model.Data.DeptName;
                        s.UserTime = login.UserTime;
                        s.Data = JsonConvert.SerializeObject(send);
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("验证码验证失败！"))
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), login.Username + "第" + i + "次登录失败，请求重试！");
                        getCodeString.ReportError();
                        continue;
                    }
                    if (i > 5)
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), login.Username + "登录失败！请联系管理员！");
                        send.Msg = "登录失败！请联系管理员！";
                        send.Data = null;
                        send.Code = 0;
                        s.UserTime = login.UserTime;
                        s.Data = JsonConvert.SerializeObject(send);
                        break;
                    }
                    i++;
                }
                return JsonConvert.SerializeObject(s); ;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            send.Msg = "登录失败！请联系管理员！";
            send.Data = null;
            send.Code = 0;
            s.UserTime = login.UserTime;
            s.Data = send;
            return JsonConvert.SerializeObject(s); ;
        }

        /// <summary>
        /// 我的预约
        /// </summary>
        /// <param name="myReserve"></param>
        /// <returns></returns>
        public string Subscribe(MyReserve myReserve)
        {
            Boolean flag = false;
            Subscribe subscribe = new Subscribe();
            int i = 0;
            send s = new send();
            s.UserTime = myReserve.UserTime;
            try
            {
                GetCodeString getCodeString = new GetCodeString();
                while (i <= 5)
                {
                    if (myReserve.Token != null)
                    {
                        library.setToken(myReserve.Token);
                        break;
                    }
                    string code_base64 = library.GetVerifyCode();
                    code_base64 = code_base64.Replace("data:image/png;base64,", "");
                    string code = getCodeString.GetCode(code_base64);
                    string result = library.Login(myReserve.Username, myReserve.Password, code);
                    if (GetTextByKey(result, "msg").Equals("用户名或密码错误~"))
                    {
                        subscribe.Msg = "用户名或密码错误";
                    }
                    if (GetTextByKey(result, "msg").Equals("操作成功"))
                    {
                        Console.WriteLine("登录成功！");
                        loginModel loginModel = Newtonsoft.Json.JsonConvert.DeserializeObject<loginModel>(result);
                        string token = loginModel.Data.Token;
                        library.setToken(token);
                        sendToken(myReserve.Username, loginModel.Data.Token);
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("验证码验证失败！"))
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), myReserve.Username + "第" + i + "次登录失败，请求重试！");
                        getCodeString.ReportError();
                        continue;
                    }
                    if (i > 5)
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), myReserve.Username + "登录失败！请联系管理员！");
                        subscribe.Msg = "System error";
                        break;
                    }

                    i++;

                }
                if (flag) { s.Data = subscribe; return JsonConvert.SerializeObject(s) + "<END>"; }
                var tt = library.Myreserve();
                Console.WriteLine(tt);
                subscribe = Newtonsoft.Json.JsonConvert.DeserializeObject<Subscribe>(tt);
                s.Data = JsonConvert.SerializeObject(subscribe);
                Console.WriteLine(s.Data);
                return JsonConvert.SerializeObject(s) + "<END>";
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return JsonConvert.SerializeObject(s) + "<END>";
        }

        /// <summary>
        /// 取学校给的日期参数
        /// </summary>
        /// <param name="getTime"></param>
        /// <returns></returns>
        public string getData(GetTime getTime)
        {
            Boolean flag = false;
            GetTimeBean getTimeBean = new GetTimeBean();
            int i = 0;
            send s = new send();
            s.UserTime = getTime.UserTime;
            try
            {
                GetCodeString getCodeString = new GetCodeString();
                while (i <= 5)
                {
                    if (getTime.Token != null)
                    {
                        library.setToken(getTime.Token);
                        break;
                    }
                    string code_base64 = library.GetVerifyCode();
                    code_base64 = code_base64.Replace("data:image/png;base64,", "");
                    string code = getCodeString.GetCode(code_base64);
                    string result = library.Login(getTime.Username, getTime.Password, code);
                    if (GetTextByKey(result, "msg").Equals("用户名或密码错误~"))
                    {
                        getTimeBean.Msg = "用户名或密码错误";
                    }
                    if (GetTextByKey(result, "msg").Equals("操作成功"))
                    {
                        Console.WriteLine("登录成功！");
                        SetData(list.getSuccess(),list.getSuccess(),"登录成功...");
                        loginModel loginModel = Newtonsoft.Json.JsonConvert.DeserializeObject<loginModel>(result);
                        ///发送token
                        sendToken(getTime.Username, loginModel.Data.Token);
                        string token = loginModel.Data.Token;
                        library.setToken(token);
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("验证码验证失败！"))
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), getTime.Username + "第" + i + "次登录失败，请求重试！");
                        getCodeString.ReportError();
                        continue;
                    }
                    if (i > 5)
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), getTime.Username + "登录失败！请联系管理员！");
                        getTimeBean.Msg = "System error";
                        flag = true;
                        break;
                    }

                    i++;

                }
                if (flag) { s.Data = getTimeBean; return JsonConvert.SerializeObject(s) + "<END>"; }
                var tt = library.GetTime(getTime.build);
                Console.WriteLine(tt);
                getTimeBean = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTimeBean>(tt);
                s.Data = JsonConvert.SerializeObject(getTimeBean);
                Console.WriteLine(s.Data);
                return JsonConvert.SerializeObject(s) + "<END>";

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return JsonConvert.SerializeObject(s) + "<END>";
        }

        /// <summary>
        /// 取座位信息
        /// </summary>
        /// <param name="getSeatBean"></param>
        /// <returns></returns>
        public string GetSeat(GetSeatBean getSeatBean)
        {
            Boolean flag = false;
            Seat seat = new Seat();
            int i = 0;
            send s = new send();
            s.UserTime = getSeatBean.UserTime;
            try
            {
                GetCodeString getCodeString = new GetCodeString();
                if (flag) { s.Data = seat; return JsonConvert.SerializeObject(s) + "<END>"; }
                var tt = library.GetSeat(getSeatBean.AreaId,getSeatBean.day,getSeatBean.endTime,getSeatBean.segment,getSeatBean.startTime);
                Console.WriteLine(tt);
                seat = Newtonsoft.Json.JsonConvert.DeserializeObject<Seat>(tt);
                
                s.Data = JsonConvert.SerializeObject(seat);
                Console.WriteLine(s.Data);
                return JsonConvert.SerializeObject(s) + "<END>";
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return JsonConvert.SerializeObject(s) + "<END>";
        }

        /// <summary>
        /// 预约函数
        /// </summary>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public string Confirm(Reserve reserve)
        {
            Confirm confirm = new Confirm();
            int i = 0;
            send s = new send();
            s.UserTime = reserve.UserTime;
            Boolean flag = false;
            try
            {
                GetCodeString getCodeString = new GetCodeString();
                while (i <= 5)
                {
                    if (reserve.Token != null)
                    {
                        library.setToken(reserve.Token);
                        break;
                    }
                    string code_base64 = library.GetVerifyCode();
                    code_base64 = code_base64.Replace("data:image/png;base64,", "");
                    string code = getCodeString.GetCode(code_base64);
                    string result = library.Login(reserve.Username, reserve.Password, code);
                    if (GetTextByKey(result, "msg").Equals("用户名或密码错误~"))
                    {
                        confirm.Msg = "用户名或密码错误";
                        flag = true;
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("操作成功"))
                    {
                        Console.WriteLine("登录成功！");
                        loginModel loginModel = Newtonsoft.Json.JsonConvert.DeserializeObject<loginModel>(result);
                        string token = loginModel.Data.Token;
                        library.setToken(token);
                        sendToken(reserve.Username, loginModel.Data.Token);
                        break;
                    }
                    if (GetTextByKey(result, "msg").Equals("验证码验证失败！"))
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), reserve.Username + "第" + i + "次登录失败，请求重试！");
                        getCodeString.ReportError();
                        continue;
                    }
                    if (i > 5)
                    {
                        SetData(ls.getFail(), ls.getOriginSend(), reserve.Username + "登录失败！请联系管理员！");
                        confirm.Msg = "System error";
                        flag = true;
                        break;
                    }

                    i++;

                }
                if (flag) { s.Data = confirm; return JsonConvert.SerializeObject(s) + "<END>"; }
                var tt = library.Confirm(reserve.area, reserve.seg);
                Console.WriteLine(tt);
                confirm = Newtonsoft.Json.JsonConvert.DeserializeObject<Confirm>(tt);
                s.Data = JsonConvert.SerializeObject(confirm);
                Console.WriteLine(s.Data);
                return JsonConvert.SerializeObject(s) + "<END>";
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            return JsonConvert.SerializeObject(s) + "<END>";
        }

        /// <summary>
        /// 根据关键字获取JSON数据里面的信息
        /// </summary>
        /// <param name="jsonText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetTextByKey(string jsonText, string key)
        {
            JObject jsonObj = JObject.Parse(jsonText);
            string str = jsonObj[key].ToString();
            return str;
        }

        private void sendToken(string username,string Token)
        {
            try
            {
                send tokenSend = new send();
                tokenSend.Data = Token;
                tokenSend.UserTime = username + "token";
                byte[] bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(tokenSend) + "<END>");
                this.stream.Write(bytes, 0, bytes.Length);
            }
            catch { }

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
