using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;
using WatchTaobao.Model;

namespace WatchTaobao
{
    public partial class Form1 : Form
    {
        #region 属性
        Thread nonParameterThread1 = null;
        private static int timecount = 0;
        List<IpUrl> IpUrlList = new List<IpUrl>();
        List<IpModel> iplist = new List<IpModel>();
        int xxcount = 1;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region 采集代理IP
        private void btn_caiji_Click(object sender, EventArgs e)
        {
            this.btn_caiji.Enabled = false;            
            Control.CheckForIllegalCrossThreadCalls = false;
            nonParameterThread1 = new Thread(GetDataThread);
            nonParameterThread1.IsBackground = true;
            nonParameterThread1.Start();
            tmFindIP.Interval = 1000;
            tmFindIP.Start();
        }
        
        /// <summary>
        /// 采集信息线程
        /// </summary>
        private void GetDataThread()
        {
            iplist = new List<Model.IpModel>();
            HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
            hw.AutoDetectEncoding = false;
            
            HttpWebRequest req;
            req = WebRequest.Create(new Uri(txt_CaijiUrl.Text)) as HttpWebRequest;
            req.Method = "GET";

            HttpWebResponse rs = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(rs.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));

            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(sr);
                GetHrefs(doc);
            }
            catch (Exception e)
            {
                WriteLog(e.Message, e.StackTrace);
            }
        }

        /// <summary>
        /// 获取链接
        /// </summary>
        /// <param name="_doc"></param>
        private void GetHrefs(HtmlAgilityPack.HtmlDocument _doc)
        {
            string todaydaili = DateTime.Now.ToString("MM月dd日");
            HtmlNodeCollection hrefs = _doc.DocumentNode.SelectNodes("//ul/li/a");
            if (hrefs == null)
                return;

            foreach (HtmlNode href in hrefs)
            {
                if (href.Attributes["title"] != null && href.Attributes["href"] != null)
                {
                    string tilte = href.Attributes["title"].Value;
                    string urll = href.Attributes["href"].Value;
                    if (tilte.IndexOf(todaydaili) >= 0 && urll.Length > 0)
                    {
                        IpUrl model = new IpUrl();
                        if (urll.IndexOf("guonei") > 0)
                        {
                            model.DaiLi = 0;
                            model.Url = urll;
                            IpUrlList.Add(model);
                        }
                        if (urll.IndexOf("guowai") > 0)
                        {
                            model.DaiLi = 1;
                            model.Url = urll;
                            IpUrlList.Add(model);
                        }
                    }
                }
            }
            string url = "";

            int tmppage = 1;
            foreach (IpUrl urla in IpUrlList)
            {
                for (int startpage = Convert.ToInt32(txt_start.Text); startpage <= Convert.ToInt32(txt_end.Text); startpage++)
                {
                    this.lb_result.Text = "正在采集第" + tmppage.ToString() + "页IP列表请稍后.........";
                    url = urla.Url.Replace(".html", "");
                    if (tmppage != 1)
                    {
                        url = url + "_" + startpage.ToString() + ".html";
                    }
                    else
                    {
                        url = url + ".html";
                    }
                    CaiJiIp(url, tmppage, urla.DaiLi);
                    tmppage++;
                }
            }
            this.lb_result.Text = "本次采集采集完毕！";
            this.btn_caiji.Enabled = true;
            this.tmFindIP.Stop();

            SaveIp();
        }

        /// <summary>
        /// 采集函数
        /// </summary>
        /// <param name="url">列表网址</param>
        /// <param name="nowpage">第几页</param>
        private void CaiJiIp(string url, int nowpage, int dailitype)
        {
            #region start 采集IP列表页内容
            WebResponse result = null;
            string resultstring = "";
            try
            {
                WebRequest req = WebRequest.Create(url);
                req.Timeout = 8000;
                result = req.GetResponse();
                this.lb_result.Text = "第" + nowpage.ToString() + "页IP列表网页代码正在GetResponseStream解析.......";
                Stream ReceiveStream = result.GetResponseStream();
                this.lb_result.Text = "第" + nowpage.ToString() + "页IP列表网页代码解析完成.......";
                string strEncod = result.ContentType;
                StreamReader sr = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
                this.lb_result.Text = "第" + nowpage.ToString() + "页IP列表网页代码解析后正在读取.......";
                resultstring = sr.ReadToEnd();
                this.lb_result.Text = "第" + nowpage.ToString() + "页IP列表网页代码解析后读取完毕.......";
            }
            catch
            {
                this.lb_result.Text = "获取IP列表请求超时,请重新尝试采集！";                
            }
            finally
            {
                if (result != null)
                {
                    result.Close();
                }
            }
            #endregion end采集IP列表页内容

            List<string> listurl = SniffwebCode(resultstring, "<br />", "@HTTP#");
            foreach (string xx in listurl)
            {
                var strxx = xx.Replace("\r\n", "");
                string[] arr = xx.Split(':');
                IpModel ipmodel = new IpModel();
                ipmodel.Ip = arr[0].Replace("\r", "").Replace("\n", "").Trim();
                ipmodel.IpPort = arr[1];

                var ipresult = YanzhengIp(ipmodel.Ip, int.Parse(ipmodel.IpPort));
                if (ipresult != null && ipresult != "Error")
                {
                    ComboBoxItem item = cbx_caijitype.SelectedItem as ComboBoxItem;
                    ipmodel.IpType = int.Parse(item.Value.ToString());
                    ipmodel.IsUse = 1;
                    ipmodel.DaiLiType = dailitype;
                    ipmodel.LastUseTime = DateTime.Now;
                    
                    this.lb_result.Text = "第" + xxcount.ToString() + "个IP正在入库.......";
                    if (iplist.SingleOrDefault(a => a.Ip == ipmodel.Ip) == null)
                    {
                        iplist.Add(ipmodel);
                        xxcount++;
                        this.lb_result.Text = "第" + xxcount.ToString() + "个IP入库成功.......";
                        this.lb_tongji.Text = "已经成功采集" + xxcount.ToString() + "条";
                    }
                    else
                    {
                        this.lb_tongji.Text = "已存在,已经成功采集" + xxcount.ToString() + "条";
                    }
                }
                else
                {
                    this.lb_tongji.Text = "IP不可用,已经成功采集" + xxcount.ToString() + "条";
                }
            }
            this.lb_result.Text = "第" + nowpage.ToString() + "页：开始遍历采集会员信息.......";
        }

        /// <summary>
        /// 保存IP
        /// </summary>
        private void SaveIp()
        {
            StringBuilder sbIP = new StringBuilder(iplist.Count);
            foreach (IpModel ipmodel in iplist)
            {
                sbIP.AppendLine(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", " ", ipmodel.Ip, ipmodel.IpPort, ipmodel.IpType, ipmodel.IsUse, ipmodel.DaiLiType));
            }

            using (FileStream file = new FileStream("D:\\IP.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(sbIP.ToString());
                file.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 匹配指定字符之间的字符串
        /// </summary>
        /// <param name="code">html源码</param>
        /// <param name="wordsBegin">开始字符串</param>
        /// <param name="wordsEnd">结束字符串</param>
        /// <returns></returns>
        List<string> SniffwebCode(string code, string wordsBegin, string wordsEnd)
        {
            List<string> listurl = new List<string>();
            Regex regex1 = new Regex("" + wordsBegin + @"(?<content>[\s\S]+?)" + wordsEnd + "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (Match match1 = regex1.Match(code); match1.Success; match1 = match1.NextMatch())
            {
                if (!listurl.Contains(match1.Groups[1].Value))
                {
                    listurl.Add(match1.Groups["content"].ToString());
                }
            }
            return listurl;
        }
        
        /// <summary>
        /// 验证代理IP是否有效的方法
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private String YanzhengIp(string IP, int port)
        {
            bool isok = true;
            string rs = null;
            while (isok)
            {
                try
                {
                    //设置代理IP
                    WebProxy proxyObject = new WebProxy(IP, port);
                    //向指定地址发送请求
                    HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
                    HttpWReq.Proxy = proxyObject;
                    HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                    HttpWReq.Timeout = 6000;
                    StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
                    string xmlContent = sr.ReadToEnd().Trim();
                    sr.Close();
                    HttpWResp.Close();
                    HttpWReq.Abort();
                    rs = xmlContent;
                    isok = false;
                }
                catch (Exception)
                {
                    isok = false;
                    rs = "Error";
                }
            }
            return rs;
        }

        private void tmFindIP_Tick(object sender, EventArgs e)
        {
            this.lb_time.Text = "代理采集已用时：" + timecount.ToString();
            timecount++;
        }
        #endregion

        private void WriteLog(string message, string stackTrace)
        {
            string dividing = "-------------------------------";
            txtLog.Text = string.Format("{0}{1}{2}{1}{3}{1}{0}", dividing, Environment.NewLine, message, stackTrace);
        }

        public class ComboBoxItem
        {
            private string _text = null;
            private object _value = null;
            public string Text { get { return this._text; } set { this._text = value; } }
            public object Value { get { return this._value; } set { this._value = value; } }
            public override string ToString()
            {
                return this._text;
            }
        }

        #region 刷排名
        public void SetProxy(string ip_port)
        {
            //打开注册表
            RegistryKey regKey = Registry.CurrentUser;
            string SubKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            RegistryKey optionKey = regKey.OpenSubKey(SubKeyPath, true);
            //更改健值，设置代理，
            optionKey.SetValue("ProxyEnable", 1);
            if (ip_port.Length == 0)
            {
                optionKey.SetValue("ProxyEnable", 0);
            }
            optionKey.SetValue("ProxyServer", ip_port);

            //激活代理设置
            InternetSetOption(0, 39, IntPtr.Zero, 0);
            InternetSetOption(0, 37, IntPtr.Zero, 0);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer2.Start();
            this.btn_start.Enabled = false;
        }

        private void tmKey_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Interval = 60000;//30秒一次
                ComboBoxItem item = cmb_web.SelectedItem as ComboBoxItem;
                var url = item.Value.ToString();
                //验证代理IP
                Model.IpModel model = GetCanUseIp();
                var ipresult = YanzhengIp(model.Ip, int.Parse(model.IpPort));
                if (ipresult != null && ipresult != "Error")
                {
                    model.UsedNumber++;
                    model.LastUseTime = DateTime.Now;
                    SetProxy(model.Ip + ":" + model.IpPort);
                    //CustomLib.Log.logger(model.Ip + ":" + model.IpPort + ";" + DateTime.Now);
                    WriteLog(model.Ip + ":" + model.IpPort, "");
                    axWebBrowser1.Navigate(url);
                }
                else
                {

                    WriteLog(model.Ip + ":" + model.IpPort, "代理IP不可用");
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, ex.StackTrace);
            }
        }

        private Model.IpModel GetCanUseIp()
        {
            List<Model.IpModel> listtemp = iplist.Where(a => a.DaiLiType == 0 && a.UsedNumber < 6).ToList();
            return CustomLib.OtherHelper.GetRandomList(listtemp).First(a => a.Ip.Length > 0);
        }
        #endregion


    }
}
