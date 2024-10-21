    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using Demo.BytesIO.TCP_Client;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using Demo.BytesIO.TCP_Client.JsonBean;
using Demo.BytesIO.TCP_Client.JsonBean.op;
using STTech.BytesIO.Core;



namespace Demo.BytesIO.TCP_Client
{
    public partial class Form1 : Form
    {
        public static Form1 form;
        // 连接tcp
        ListViewList ListViewList = new ListViewList();
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;
        // 创建一个负责监听服务端请求的线程
        Thread threadClient = null;
        public const int TCPBufferSize = 6999; // 缓存的最大数据个数
        public byte[] TCPBuffer = new byte[TCPBufferSize]; // 缓存数据的数组
        private Thread ping = null;
        private int ReconnectTime = 0;
        private DateTime dateTime = DateTime.Now;
        private DateTime v = DateTime.Now;
        private string Receive = string.Empty;
        int TT = 0;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }


        /// <summary>
        /// 直接获取端口字符串数据没有则返回空
        /// </summary>
        private void Recive()
        {
            //定义一个1M的内存缓冲区 用于临时性存储接收到的信息
            byte[] data = new byte[1024];
            String responseData = String.Empty;
            while (true) // 持续监听服务端发来的消息
            {
                try
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.Default.GetString(data, 0, bytes);
                    if (responseData != null)
                    {
                        // 显示在日志上
                        // listView1.Items.Add(responseData); //会报错：控件不能控制线程，用线程控制线程
                        //用Action线程委托操作
                        Invoke((new Action(() =>
                        {
                            setData(ListViewList.getSuccess(), ListViewList.getOriginReceive(), $"{responseData}");
                        })));
                        if (responseData == "")
                        {
                            Invoke((new Action(() =>
                            {
                                
                                if(ping.ThreadState!= System.Threading.ThreadState.Aborted) ping.Abort();
                                listView1.Items.Add($"[{DateTime.Now}]：服务端异常断开连接\r\n");
                                setData(ListViewList.getFail(), ListViewList.getOriginReceive(), $"服务端异常断开连接");
                            })));
                            stream.Close();
                            tcpClient.Close();
                            threadClient.Abort();
                            break;
                        }
                    }
                }
                catch (ObjectDisposedException odex)
                {
                    //服务端异常断开连接，然后点击断开出现的异常
                    // 结束循环
                    if (ping.ThreadState != System.Threading.ThreadState.Aborted) ping.Abort();
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "已断开连接");
                    break;
                }
            }
        }

        /// <summary>
        /// 断开服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                //先判断连接状态
                if (ConnectStatus()) // 存在连接服务端
                {
                    tcpClient.Close();
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "已断开连接");
                }
                else
                {
                    MessageBox.Show("未存在连接！！");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 清空发送按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSend_Click(object sender, EventArgs e)
        {
            // 清空输入框里的内容
            richTextBox2.Clear();
        }
        private void btnClearConnect_Click(object sender, EventArgs e)
        {
            // 清空输入框里的内容
            richTextBox2.Clear();
        }
        /// <summary>
        /// 连接的状态
        /// </summary>
        /// <returns></returns>
        private bool ConnectStatus()
        {
            try
            {
                return tcpClient.Connected;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 服务端状态
        /// </summary>
        /// <returns></returns>
        private bool ServerStatus()
        {
            return false;
        }
        /// <summary>
        /// 重新连接服务端
        /// </summary>
        /// <param name="strIp"></param>
        /// <param name="intPort"></param>
        private void ReConnect(string strIp, int intPort)
        {
            try
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
                tcpClient = new TcpClient(strIp, intPort);
                if (tcpClient.Connected)
                {
                    stream = tcpClient.GetStream();
                }
            }
            catch (Exception ex)
            {

            }
        }



        /// <summary>
        /// 发送心跳数据
        /// </summary>
        private void Getping()
        {
            TimeSpan ts = new TimeSpan(0, 0, 10);         
            while (true) {
                if (TT > 5)
                {
                    Reconnect();
                }
                Thread.Sleep(ts);
                if (DiffSeconds(dateTime, DateTime.Now) < 20)
                {
                    continue;
                }
                v = DateTime.Now;
                byte[] send = Encoding.UTF8.GetBytes("ping" + v +  "<END>");
                try
                {
                    stream.Write(send, 0, send.Length);
                    Invoke((new Action(() => {
                        setData(ListViewList.getSuccess(), ListViewList.getOriginSend(), "心跳测试==>ping");
                    })));
                    Thread.Sleep(1000*5);
                    if(this.Receive != v.ToString())
                    {
                        Invoke((new Action(() => {
                            setData(ListViewList.getFail(), ListViewList.getOriginSend(), "心跳测试异常==>ping");
                            if (ConnectStatus()) // 存在连接服务端
                            {
                                tcpClient.Close();
                                setData(ListViewList.getSuccess(), ListViewList.getOriginSend(), "已断开连接");
                            }
                            else
                            {
                                setData(ListViewList.getFail(), ListViewList.getOriginSend(), "当前未存在链接");
                            }
                        })));   
                        TT++;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }
                //    // 异步发送数据
                //    // 异步发送数据

            }
        }

        /*==========================异步处理方法====================*/
        /// <summary>
        /// 连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbConnect_Click(object sender, EventArgs e)
        {
            // 判断IP地址和端口号不能为空
            if (string.IsNullOrEmpty(tbStrIp.Text) == false && string.IsNullOrEmpty(tbIntPort.Text) == false)
            {

                try
                {
                    // 获取IP地址和端口号
                    string strIP = tbStrIp.Text;
                    int intPort = int.Parse(tbIntPort.Text);

                    // 创建一个tcpClient
                    tcpClient = new TcpClient();
                    // 根据服务端的IP地址和端口号 异步连接服务器
                    tcpClient.BeginConnect(strIP, intPort, new AsyncCallback(ConnectCallback), tcpClient);
                    
                }
                catch (Exception)
                {

                }
            }
            else if (string.IsNullOrEmpty(tbIntPort.Text))
            {
                MessageBox.Show("请输入IP地址", "提示");
            }
            else if (string.IsNullOrEmpty(tbIntPort.Text))
            {
                MessageBox.Show("请输入端口", "提示");
            }
        }


        private void Reconnect()
        {
            if(ReconnectTime < 5)
            {
                try
                {

                    Invoke((new Action(() =>
                    {
                        setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "正在重连...");

                        //重连前先断开已有    
                        try
                        {
                            if (ping.ThreadState != System.Threading.ThreadState.Aborted) ping.Abort();
                            tcpClient.Close();
                            stream.Close();
                        }
                        catch (Exception) { }
                    })));
                    
                    string strIP = tbStrIp.Text;
                    int intPort = int.Parse(tbIntPort.Text);
                    // 创建一个tcpClient
                    tcpClient = new TcpClient();
                    // 根据服务端的IP地址和端口号 异步连接服务器
                    tcpClient.BeginConnect(strIP, intPort, new AsyncCallback(ConnectCallback), tcpClient);
                    ReconnectTime++;
                }catch (Exception) { }

            }
            else
            {
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "第" + ReconnectTime + "次重连失败");
                })));
                ReconnectTime = 0;
                return;
            }

        }
        /// <summary>
        /// 连接异步回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void ConnectCallback(IAsyncResult ar)
        {
            TcpClient tcp = (TcpClient)ar.AsyncState;
            // System.InvalidOperationException:“不允许对非连接的套接字执行此操作。”
            //stream = tcp.GetStream();

            try
            {
                stream = tcpClient.GetStream();//创建于服务端连接的数据流
                tcp.EndConnect(ar);
                // 设置异步读取数据，接收的数据缓存到TCPBuffer，接收完成跳转ReadCallback函数
                stream.BeginRead(TCPBuffer, 0, TCPBufferSize, new AsyncCallback(ReadCallback), stream);

                Invoke((new Action(() =>
                {
                    setData(ListViewList.getSuccess(), ListViewList.getOriginReceive(), $" 服务端连接成功！\r\n");
                })));
                send("{\"userTime\":\"00000\",\"data\":\"\"}");
                ping = new Thread(Getping);
                ping.Start();
                ReconnectTime = 0;
                TT = 0;

            }
            catch (Exception ex)
            {

                if(ping != null && ping.ThreadState != System.Threading.ThreadState.Aborted) ping.Abort();
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), ping.ThreadState.ToString());
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), $"断开链接连接失败：{ex.ToString()}\r\n");
                })));
                if (ReconnectTime < 5) {
                    Thread.Sleep(1000 * 3);
                    Invoke((new Action(() => {
                        setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "第" + ReconnectTime + "次重连");
                    })));
                    Reconnect();
                }
            }
        }



        /// <summary>
        /// 接收服务端数据的回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void ReadCallback(IAsyncResult ar)
        {
            /*无法将类型为“System.Net.Sockets.NetworkStream”的对象强制转换为类型“System.Net.Sockets.TcpClient”。”
            *TcpClient tcp = (TcpClient)ar.AsyncState;  
            *int CanReadLen = tcp.Client.EndReceive(ar);
            * 用这种方式需要把stream.BeginRead(TCPBuffer, 0, TCPBufferSize, new AsyncCallback(ReadCallback), stream);
            * 最后面的一个参数改为TcpClient类型，否则会报最上面的类型无法转化的错误
            */
            NetworkStream networkStream = (NetworkStream)ar.AsyncState;
            try
            {
                int CanReadLen = networkStream.EndRead(ar);
                if (CanReadLen > 0)
                {
                    string data = Encoding.Default.GetString(TCPBuffer, 0, CanReadLen);
                    Invoke((new Action(() =>
                    {
                        setData(ListViewList.getSuccess(), ListViewList.getOriginReceive(), $"{data}\r\n");
                        //开启一个线程处理请求
                        if (data.StartsWith("pong"))
                            this.Receive = data.Replace("pong", "");   
                        Thread thread = new Thread(requests);
                        thread.Start(data);
                    })));
                    this.dateTime = DateTime.Now;
                    // 设置异步读取数据，接收的数据缓存到TCPBuffer，接收完成跳转ReadCallback函数
                    stream.BeginRead(TCPBuffer, 0, TCPBufferSize, new AsyncCallback(ReadCallback), stream);
                }
                else
                {   //异常
                    Invoke((new Action(() =>
                    {
                        setData(ListViewList.getFail(), ListViewList.getOriginReceive(), "异常断开！");
                    })));
                    if(ping.ThreadState != System.Threading.ThreadState.Aborted) ping.Abort();

                    Reconnect();
                }
            }
            catch (Exception ex)
            {
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getFail(), ListViewList.getOriginReceive(), $"接收数据失败：{ex.ToString()}\r\n");
                })));
                Reconnect();
            }
        }

        /// <summary>
        /// 发送按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //stream = tcpClient.GetStream(); // 创建于服务器连接的数据流
            // 获取文本框中的内容
            string rtbStr = richTextBox2.Text;
            try
            {
                if (rtbStr.Length > 0) //文本框里有内容
                {
                    // 转换成字节
                    byte[] data = Encoding.Default.GetBytes(rtbStr);
                    // 异步发送数据
                    //stream.BeginWrite(data, 0, data.Length, new AsyncCallback(SendCallback), stream);
                    // 发送数据
                    stream.Write(data, 0, data.Length);
                    Invoke((new Action(() =>
                    {
                        setData(ListViewList.getSuccess(), ListViewList.getOriginSend(), $"{rtbStr}\r\n");
                    })));
                }
                else
                {
                    Invoke((new Action(() =>
                    {
                        setData(ListViewList.getFail(), ListViewList.getOriginSend(), "请输入内容");
                    })));
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 添加ListView数据
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public void setData(string state, string type, string data)
        {


            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = state;
            item.SubItems.Add(type);
            item.SubItems.Add($"{DateTime.Now}:{data}");
            listView1.Items.Add(item);
            if (listView1.Items.Count > 500)
            {
                string stFilePath = string.Empty;
                //此处的文本文件在工程下Bin的程序集目录下
                stFilePath = Application.StartupPath.Trim() + "//students" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒") + ".txt";
                StreamWriter swStream;
                if (File.Exists(stFilePath))
                {
                    swStream = new StreamWriter(stFilePath);
                }
                else
                {
                    swStream = File.CreateText(stFilePath);
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < listView1.Items[i].SubItems.Count; j++)
                    {
                        string _strTemp = listView1.Items[i].SubItems[j].Text;
                        swStream.Write("==>");
                        swStream.Write(_strTemp);
                        //插入"<----->"作为分隔符,可以任取

                    }
                    swStream.Write("\r\n");
                    swStream.WriteLine();

                }
                listView1.Items.Clear();
                //关闭流,释放资源
                swStream.Flush();
                swStream.Close();

            }
        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        /// <param name="data"></param>
        private void requests(object data)
        {
            string str = (string)data;
            string op = string.Empty;
            //try
            //{
            try
            {
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getSuccess(), ListViewList.getOriginReceive(), str);
                })));
                op = GetTextByKey(str, "op");

            }
            catch (Exception e) { }
            if (op.Equals("GetAreaInformation"))
            {
                //取楼层和区域信息
                GetAreaInformation areainformation = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAreaInformation>(str);
                DataDeal dataDeal = new DataDeal(form,stream);
                string da = dataDeal.GetAreaInformation(areainformation);
                send(da);
                return;
            }
            if (op.Equals("GetSeat"))
            {
                //取每个座位的信息
                GetSeatBean getSeatBean = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSeatBean>(str);
                DataDeal dataDeal = new DataDeal(form, stream);
                string da = dataDeal.GetSeat(getSeatBean);
                send(da);
                return;
            }
            if (op.Equals("GetDate"))
            {
                //取时间参数
                GetTime getTime = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTime>(str);
                Console.WriteLine(getTime);
                Console.WriteLine(str.Length);
                DataDeal dataDeal = new DataDeal(form, stream);
                string da = dataDeal.getData(getTime);
                send(da);
                return;
            }
            if(op.Equals("login"))
            {
                //登录
                Login login = Newtonsoft.Json.JsonConvert.DeserializeObject<Login>(str);
                DataDeal dataDeal = new DataDeal(form,stream);
                string da = dataDeal.login(login);
                send(da);
                return;
            }
            if(op.Equals("Confirm"))
            {
                Reserve reserve = Newtonsoft.Json.JsonConvert.DeserializeObject<Reserve>(str);
                DataDeal dataDeal = new DataDeal(form,stream);
                string da = dataDeal.Confirm(reserve);
                send(da);
                return;
            }
            if(op.Equals("Mydefault"))
            {
                
            }
            if (op.Equals("MyBook"))
            {
                MyReserve myReserve = Newtonsoft.Json.JsonConvert.DeserializeObject<MyReserve>(str);
                DataDeal dataDeal = new DataDeal(form, stream);
                string da = dataDeal.Subscribe(myReserve);
                send(da);
                return;
            }
        }

        /// <summary>
        /// 判断时间戳间的秒
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public double DiffSeconds(DateTime startTime, DateTime endTime)
        {
            TimeSpan secondSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return secondSpan.TotalSeconds;
        }


        /// <summary>
        /// 发送消息函数
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private Boolean send(string msg)
        {
            try
            {

                byte[] send = Encoding.UTF8.GetBytes(msg + "<END>");
                stream.Write(send, 0, send.Length);
                Console.WriteLine(send.Length);
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getSuccess(), ListViewList.getOriginSend(), $" 消息发送成功！\r\n" + msg );
                })));
                return true;
            }
            catch (Exception ex)
            {
                Invoke((new Action(() =>
                {
                    setData(ListViewList.getFail(), ListViewList.getOriginSend(), $" 消息发送失败！\r\n" + msg);
                })));
                return false;
            }
        }
        public string GetTextByKey(string jsonText, string key)
        {
            JObject jsonObj = JObject.Parse(jsonText);
            Console.Error.WriteLine(jsonObj);
            string str = jsonObj[key].ToString();
            return str;
        }
    }
}
