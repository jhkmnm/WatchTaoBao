﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchTaobao.Model;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace WatchTaobao
{
    /// <summary>
    /// 
    /// </summary>
    public class WatchCommon
    {
        //代理IP列表
        private IList<IpModel> IPList;
        private IpModel ipModel;
        
        //单个页面停留时间(分钟)
        private int ScanTimeStart, ScanTimeEnd;
        //一个IP一个商品浏览次数
        private int Count;
        //深度浏览的数量
        private int DepthView;

        #region　浏览时的变量
        //当前正在使用的IP的索引
        private int ipindex;
        //当前单个商品浏览的时间
        private int scanTime;
        
        #endregion

        //private WebBrowser myWebBrowser;
        private SearchModel searchModel;

        /// <summary>
        /// 浏览构造函数
        /// </summary>
        /// <param name="ipList">代理IP列表</param>
        /// <param name="scanTimeStart">页面停留时间区间</param>
        /// <param name="scanTimeEnd">页面停留时间区间</param>
        /// <param name="count">单个商品浏览次数</param>
        /// <param name="depthView">深度浏览的数量</param>
        public WatchCommon(IList<IpModel> ipList,  int scanTimeStart, int scanTimeEnd, int count, int depthView/*, WebBrowser webBrowser*/)
        {
            this.IPList = ipList;
            this.ScanTimeStart = scanTimeStart;
            this.ScanTimeEnd = scanTimeEnd;
            this.Count = count;
            this.DepthView = depthView;
            //this.myWebBrowser = webBrowser;
            
            //myWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(myWebBrowser_DocumentCompleted);
        }

        /// <summary>
        /// 初始化浏览,主要是初始化 当前的代理IP 和 浏览时间
        /// </summary>
        public IpModel InitWatch(out int scanTime)
        {
            Random random = new Random();
            scanTime = random.Next(ScanTimeStart, ScanTimeEnd);

            if (ipindex >= IPList.Count)
                return null;

            ipModel = IPList[ipindex];
            ipindex++;
            return ipModel;
        }

        ///// <summary>
        ///// 启动搜索
        ///// </summary>
        //public void SearchStart()
        //{
        //    try
        //    {
        //        Status = "KeySearch";
        //        var url = "www.taobao.com";
        //        //验证代理IP
        //        var ipresult = YanzhengIp(model.Ip, int.Parse(model.IpPort));
        //        if (ipresult)
        //        {
        //            model.UsedNumber++;
        //            model.LastUseTime = DateTime.Now;
        //            Util.SetProxy(model.Ip + ":" + model.IpPort);
        //            Form1.WriteLog(model.Ip + ":" + model.IpPort, "");
        //            myWebBrowser.Navigate(url);
        //        }
        //        else
        //        {
        //            Form1.WriteLog(model.Ip + ":" + model.IpPort, "代理IP不可用");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Form1.WriteLog(ex.Message, ex.StackTrace);
        //    }
        //}

        //private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    switch (Status)
        //    {
        //        case "KeySearch":
        //            KeySearch();
        //    }
        //}

        
    }

    /// <summary>
    /// 搜索实体
    /// </summary>
    public class SearchModel
    {        
        private string _keyword;
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword
        { get { return _keyword; } }

        //价格区间
        private decimal _priceStart, _priceEnd;

        public decimal PriceStart
        { get { return _priceStart; } }

        public decimal PriceEnd
        { get { return _priceEnd; } }

        private string _salesArea;
        //卖家所在地
        public string SalesArea
        { get { return _salesArea; } }
        
        private string _productID;
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductID
        { get { return _productID; } }
                
        private int _maxPageNo;
        /// <summary>
        /// 最大搜索页数
        /// </summary>
        public int MaxPageNo
        { get { return _maxPageNo; } }

        /// <summary>
        /// 搜索构造函数
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="priceStart">价格区间</param>
        /// <param name="priceEnd">价格区间</param>
        /// <param name="salesArea">所在地</param>
        /// <param name="productID">商品ID</param>
        public SearchModel(string keyword, decimal priceStart, decimal priceEnd, string salesArea, string productID, int maxPageNo)
        {
            this._keyword = keyword;
            this._priceStart = priceStart;
            this._priceEnd = PriceEnd;
            this._salesArea = salesArea;
            this._productID = productID;
            this._maxPageNo = maxPageNo;
        }
    }

    public class Util
    {
        public static void SetProxy(string ip_port)
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

        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "InternetSetOption",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool InternetSetOption
        (
            int hInternet,
            int dmOption,
            IntPtr lpBuffer,
            int dwBufferLength
        );

        /// <summary>
        /// 验证代理IP是否有效的方法
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool YanzhengIp(string IP, int port)
        {
            bool isok = true;
            string rs = null;
            try
            {
                //设置代理IP
                WebProxy proxyObject = new WebProxy(IP, port);
                //向指定地址发送请求
                HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("http://www.taobao.com/");

                //HttpWReq.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/msword, */*";
                //HttpWReq.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                //HttpWReq.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //HttpWReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";


                HttpWReq.Proxy = proxyObject;
                HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                HttpWReq.Timeout = 6000;
                StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
                string xmlContent = sr.ReadToEnd().Trim();
                sr.Close();
                HttpWResp.Close();
                HttpWReq.Abort();
                rs = xmlContent;
                return true;
            }
            catch (Exception)
            {
                isok = false;
            }
            return false;
        }

        public static void SetAllWebItemSelf(HtmlElementCollection items)
        {
            try
            {
                foreach (HtmlElement item in items)
                {
                    if (item.TagName.ToLower().Equals("iframe", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        try
                        {
                            item.SetAttribute("target", "_self");
                        }
                        catch
                        { }
                    }
                    else
                    {
                        try
                        {
                            HtmlElementCollection fitems = item.Document.Window.Frames[item.Name].Document.All;
                            SetAllWebItemSelf(fitems);
                        }
                        catch
                        { }
                    }
                }
            }
            catch
            {
            }
        }
    }

    public class HttpHelper
    {
        #region 委托 事件
        public delegate void dgtProgValueChanged(long Value);
        /// <summary>
        /// 进度改变事件
        /// </summary>
        public event dgtProgValueChanged OnProgValueChanged;
        #endregion

        #region 属性
        /// <summary>
        /// 代理
        /// </summary>
        public WebProxy Proxy { get; set; }
        /// <summary>
        /// Cookie
        /// </summary>
        public CookieContainer UserCookie { get; set; }
        /// <summary>
        /// 重试次数
        /// </summary>
        public int IAfreshTime { get; set; }
        /// <summary>
        /// 错误次数
        /// </summary>
        public int IErrorTime { get; private set; }

        long m_ProgValue = 0;
        /// <summary>
        /// 当前读取字节
        /// </summary>
        public long ProgValue
        {
            get { return m_ProgValue; }
            private set
            {
                m_ProgValue = value;
                if (OnProgValueChanged != null)
                {
                    OnProgValueChanged(value);
                }
            }
        }
        /// <summary>
        /// 待读取最大字节
        /// </summary>
        public long ProgMaximum { get; private set; }

        #endregion

        #region 方法
        #region Get
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="Accept">Accept请求头</param>
        /// <returns>Html代码</returns>
        public string GetHTML(string URL, string Accept)
        {
            return GetHTML(URL, Accept, System.Text.Encoding.UTF8);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="Accept">Accept请求头</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>Html代码</returns>
        public string GetHTML(string URL, string Accept, Encoding encoding)
        {
            return GetHTML(URL, Accept, encoding, 1024);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="Accept">Accept请求头</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="bufflen">数据包大小</param>
        /// <returns>Html代码</returns>
        public string GetHTML(string URL, string Accept, Encoding encoding, int bufflen)
        {
            IErrorTime = 0;
            return _GetHTML(URL, Accept, encoding, bufflen);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="Accept">Accept请求头</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="bufflen">数据包大小</param>
        /// <returns>Html代码</returns>
        private string _GetHTML(string URL, string Accept, Encoding encoding,int bufflen)
        {
            try
            {
                HttpWebRequest MyRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
                MyRequest.Proxy = Proxy;
                MyRequest.Accept = Accept;
                if (UserCookie == null)
                {
                    UserCookie = new CookieContainer();
                }
                MyRequest.CookieContainer = UserCookie;
                HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();
                return _GetHTML(MyResponse, encoding, bufflen);
            }
            catch (Exception erro)
            {
                if (erro.Message.Contains("连接") && IAfreshTime - IErrorTime > 0)
                {
                    IErrorTime++;
                    return _GetHTML(URL, Accept, encoding, bufflen);
                }
                throw;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="MyResponse"></param>
        /// <param name="encoding">字符编码</param>
        /// <param name="bufflen">数据包大小</param>
        /// <returns></returns>
        private string _GetHTML(HttpWebResponse MyResponse, Encoding encoding, int bufflen)
        {
            using (Stream MyStream = MyResponse.GetResponseStream())
            {
                    ProgMaximum = MyResponse.ContentLength;
                    string result = null;
                    long totalDownloadedByte = 0;
                    byte[] by = new byte[bufflen];
                    int osize = MyStream.Read(by, 0, by.Length);
                    while (osize > 0)
                    {
                        totalDownloadedByte = osize + totalDownloadedByte;
                        result += encoding.GetString(by, 0, osize);
                        ProgValue = totalDownloadedByte;
                        osize = MyStream.Read(by, 0, by.Length);
                    }
                    MyStream.Close();
                    return result;
            }
        }
        #endregion


        #region GetImg

        public System.Drawing.Bitmap Getimg(string URL, string Accept)
        {
            return _GetBit(URL, Accept);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="URL">地址</param>
        /// <param name="Accept">Accept请求头</param>
        /// <returns>Html代码</returns>
        private System.Drawing.Bitmap _GetBit(string URL, string Accept)
        {
            HttpWebRequest MyRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            MyRequest.Proxy = Proxy;
            MyRequest.Accept = Accept;
            if (UserCookie == null)
            {
                UserCookie = new CookieContainer();
            }
            MyRequest.CookieContainer = UserCookie;
            HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();
            return _GetBit(MyResponse);
        }

        /// <summary>
        /// 获取图像
        /// </summary>
        /// <param name="MyResponse"></param>
        /// <returns></returns>
        private System.Drawing.Bitmap _GetBit(HttpWebResponse MyResponse)
        {
            using (Stream MyStream = MyResponse.GetResponseStream())
            {
                return new System.Drawing.Bitmap(MyStream);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// 回发(字符编码默认UTF-8)
        /// </summary>
        /// <param name="URL">回发地址</param>
        /// <param name="PostData">参数</param>
        /// <returns>Html代码</returns>
        public string PostPage(string URL, string PostData)
        {
            return PostPage(URL, PostData, System.Text.Encoding.UTF8);
        }
        /// <summary>
        /// 回发
        /// </summary>
        /// <param name="URL">回发地址</param>
        /// <param name="PostData">参数</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>Html代码</returns>
        public string PostPage(string URL, string PostData, Encoding encoding)
        {
            return PostPage(URL, PostData, encoding, null);
        }
        /// <summary>
        /// 回发
        /// </summary>
        /// <param name="URL">回发地址</param>
        /// <param name="PostData">参数</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>Html代码</returns>
        public string PostPage(string URL, string PostData, Encoding encoding, string ContentType)
        {
            IErrorTime = 0;
            return _PostPage(URL, PostData, encoding, ContentType);
        }
        /// <summary>
        /// 回发
        /// </summary>
        /// <param name="URL">回发地址</param>
        /// <param name="PostData">参数</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>Html代码</returns>
        private string _PostPage(string URL, string PostData, Encoding encoding,string ContentType)
        {
            try
            {
                if (ContentType==null)
                {
                    ContentType = "application/x-www-form-urlencoded";
                }
                HttpWebRequest MyRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
                MyRequest.Proxy = Proxy;
                if (UserCookie == null)
                {
                    UserCookie = new CookieContainer();
                }
                MyRequest.CookieContainer = UserCookie;
                MyRequest.Method = "POST";
                MyRequest.ContentType = ContentType;
                byte[] b = encoding.GetBytes(PostData);
                MyRequest.ContentLength = b.Length;
                using (System.IO.Stream sw = MyRequest.GetRequestStream())
                {
                    try
                    {
                        sw.Write(b, 0, b.Length);
                    }
                    catch
                    {
                    }
                }
                HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();
                return _GetHTML(MyResponse, encoding, 1024);
            }
            catch (Exception erro)
            {
                if (erro.Message.Contains("连接") && IAfreshTime - IErrorTime > 0)
                {
                    IErrorTime++;
                    return _PostPage(URL, PostData, encoding, ContentType);
                }
                throw;
            }
        }
        #endregion
        #endregion
    }

}

public enum ShowCommands : int

{

SW_HIDE = 0,

SW_SHOWNORMAL = 1,

SW_NORMAL = 1,

SW_SHOWMINIMIZED = 2,

SW_SHOWMAXIMIZED = 3,

SW_MAXIMIZE = 3,

SW_SHOWNOACTIVATE = 4,

SW_SHOW = 5,

SW_MINIMIZE = 6,

SW_SHOWMINNOACTIVE = 7,

SW_SHOWNA = 8,

SW_RESTORE = 9,

SW_SHOWDEFAULT = 10,

SW_FORCEMINIMIZE = 11,

SW_MAX = 11

}

public static class Extension
{
    #region Ojbect To ToInt
    /// <summary>
    /// 此方法慎用
    /// 将指定的值转换为有符号整数
    /// 此方法不会抛出异常，转换失败将返回defValue
    /// </summary>
    /// <param name="str">指定对象</param>
    /// <param name="defValue">缺省值</param>
    /// <returns></returns>
    public static int ToInt(this object value, int defValue)
    {
        try
        {
            if (value != null)
            {
                return ((IConvertible)value).ToInt32(null);
            }
            else
            {
                return defValue;
            }
        }
        catch (Exception)
        {
            return defValue;
        }
    }

    /// <summary>
    /// 将指定的值转换为有符号整数
    /// </summary>
    /// <param name="str">指定对象</param>
    /// <returns></returns>
    public static int ToInt(this object value)
    {
        if (value != null)
        {
            return ((IConvertible)value).ToInt32(null);
        }
        else
        {
            return 0;
        }
    }
    #endregion
}
