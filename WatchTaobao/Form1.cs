using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;
using WatchTaobao.Model;
using mshtml;

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
            BindCaiJiTypeData();
            GetLocalIP();
        }

        #region 采集代理IP

        public void BindCaiJiTypeData()
        {
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Text = "国内代理";
            cbi1.Value = "1";
            cbx_caijitype.Items.Add(cbi1);
            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Text = "国外代理";
            cbi2.Value = "2";
            cbx_caijitype.Items.Add(cbi2);
            cbx_caijitype.SelectedIndex = 0;
        }
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

                var ipresult = Util.YanzhengIp(ipmodel.Ip, int.Parse(ipmodel.IpPort));
                if (ipresult/* != null && ipresult != "Error"*/)
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

            string fillname = Environment.CurrentDirectory + "\\IP.txt";
            using (FileStream file = new FileStream(fillname, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(sbIP.ToString());
                file.Write(buffer, 0, buffer.Length);
            }
        }

        private void GetLocalIP()
        { 
            string fillname = Environment.CurrentDirectory + "\\IP.txt";

            using (StreamReader srReadFile = new StreamReader(fillname))
            {
                iplist.Clear();
                while (!srReadFile.EndOfStream)
                {
                    IpModel model = new IpModel();
                    string strReadLine = srReadFile.ReadLine();
                    string[] strs = strReadLine.Split(' ');
                    model.Ip = strs[0];
                    model.IpPort = strs[1];
                    model.IpType = strs[2].ToInt(0);
                    model.IsUse = strs[3].ToInt(0);
                    model.DaiLiType = strs[4].ToInt(0);

                    iplist.Add(model);
                }
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

        private void tmFindIP_Tick(object sender, EventArgs e)
        {
            this.lb_time.Text = "代理采集已用时：" + timecount.ToString();
            timecount++;
        }
        #endregion

        public void WriteLog(string message, string stackTrace)
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
        
        private WatchCommon watchCommon;
        private List<IPAndProduct> papList = new List<IPAndProduct>();
        private IpModel model;

        /// <summary>
        /// 当前正在操作的状态
        /// </summary>
        private string Status;
        
        /// <summary>
        /// 当前所在页索引
        /// </summary>
        private int pageindex = 1;
        /// <summary>
        /// 每次滚动屏幕的高度
        /// </summary>
        private const int height = 500;
        /// <summary>
        /// 已经移动滚动条的次数
        /// </summary>
        private int movebarcount = 0;
        /// <summary>
        /// 商品页面浏览的时间
        /// </summary>
        private int scantime = 0;
        /// <summary>
        /// 毫秒->秒
        /// </summary>
        private const int interval = 1000;
        /// <summary>
        /// 当前商品详情有几屏
        /// </summary>
        private int pagecount = 1;
        /// <summary>
        /// 深度浏览的数量
        /// </summary>
        private int depthviewindex = 1;
        /// <summary>
        /// 是否筛选了价格
        /// </summary>
        private bool isChoosePrice = true;
        /// <summary>
        /// 是否筛选了地区
        /// </summary>
        private bool isChooseAre = true;

        private void InitVariable()
        {
            Status = string.Empty;
            pageindex = 1;
            movebarcount = 0;
            scantime = 0;
            pagecount = 1;
            depthviewindex = 1;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            InitVariable();
            watchCommon = new WatchCommon(iplist, txtScanStart.Text.ToInt(5), txtScanEnd.Text.ToInt(10), txtCount.Text.ToInt(1), txtDepthView.Text.ToInt(0));
            tmKey.Start();
            this.btn_start.Enabled = false;
            isChoosePrice = !(txtPriceStart.Text.ToInt(0) > 0);
            isChooseAre = !(txtArea.Text.Length > 0);
        }

        private void tmKey_Tick(object sender, EventArgs e)
        {
            try
            {
                Status = "KeySearch";
                
                model = watchCommon.InitWatch(out scantime);
                tmKey.Interval = scantime * 60 * interval;
                var url = "http://www.taobao.com/";
                //验证代理IP                
                var ipresult = Util.YanzhengIp(model.Ip, int.Parse(model.IpPort));
                if (ipresult)
                {                    
                    Util.SetProxy(model.Ip + ":" + model.IpPort);
                    WriteLog(model.Ip + ":" + model.IpPort, "");
                    myWebBrowser.Navigate(url);
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

        private void axWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Util.SetAllWebItemSelf(this.myWebBrowser.Document.All);

            switch (Status)
            {
                case "KeySearch":
                    KeySearch();
                    break;
                case "Filtering":
                    Filtering();
                    break;
                case "SearchProduct":
                    SearchProduct();
                    break;
                case "BrowseProducts":
                    BrowseProducts();
                    break;
            }
        }

        /// <summary>
        /// 关键字搜索
        /// </summary>
        private void KeySearch()
        {
            try
            {
                HtmlElement txtcontent = myWebBrowser.Document.GetElementById("q");
                HtmlElement btnSubmit = myWebBrowser.Document.GetElementsByTagName("button")[0];
                if (txtcontent == null || btnSubmit == null)
                {
                    return;
                }
                var keywords = txtKeyWord.Text;
                txtcontent.SetAttribute("value", keywords);
                int xxvlaue = 2000;
                Thread.Sleep(xxvlaue);
                btnSubmit.InvokeMember("click");
                if (txtPriceStart.Text.ToInt() > 0 || txtArea.Text.Length > 0)
                {
                    Status = "Filtering";
                }
                else
                {
                    Status = "SearchProduct";
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// 内容筛选
        /// </summary>
        private void Filtering()
        {
            try
            {
                Thread.Sleep(txtInterval.Text.ToInt());

                if (!isChoosePrice)
                {
                    HtmlElement txtcontent = myWebBrowser.Document.GetElementById("q");
                    HtmlElement btnSubmit = myWebBrowser.Document.GetElementsByTagName("button")[0];
                    if (txtcontent == null || btnSubmit == null)
                    {
                        return;
                    }

                    isChoosePrice = true;
                }
                else if (!isChooseAre)
                {
                    isChooseAre = true;
                }

                if (isChoosePrice && isChooseAre) Status = "SearchProduct";
            }
            catch (Exception ex)
            {
                WriteLog("内容筛选出错:" + ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// 查找商品
        /// </summary>
        private void SearchProduct()
        {
            try
            {
                Thread.Sleep(txtInterval.Text.ToInt());
                HtmlElement nextpage = null;
                //如果找到产品,将pageindex=0,跳转到商品页面Status = "BrowseProducts";
                HtmlElement link = SearchLink(txtProductID.Text, out nextpage);

                if (link == null)
                {
                    pageindex++;

                    if (pageindex > txtMaxPagNo.Text.ToInt(50) && Status == "SearchProduct")
                    {
                        //结束当前的过程,需要调整最大搜索页面
                    }
                    else
                    {
                        if (nextpage != null)
                        {
                            nextpage.InvokeMember("click");
                        }
                    }
                }
                else
                {
                    Status = "BrowseProducts";
                    link.InvokeMember("click");
                }
            }
            catch (Exception ex)
            {
                WriteLog("查找商品出错:" + ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// 浏览商品
        /// </summary>
        private void BrowseProducts()
        {
            Thread.Sleep(txtInterval.Text.ToInt());

            IPAndProduct pap = new IPAndProduct();
            pap.ID = model.Id;
            pap.ProductID = "";
            pap.Number++;
            papList.Add(pap);

            //一共有几屏
            //一屏占用的时间
            pagecount = myWebBrowser.Document.Body.ScrollRectangle.Height / height + 1;
            tmBrowse.Enabled = true;
        }

        /// <summary>
        /// 浏览商品时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmBrowse_Tick(object sender, EventArgs e)
        {
            int pagetime = (int)((scantime / (pagecount * 1.00)) * 60 * interval);
            tmBrowse.Interval = pagetime;
            tmBrowse.Enabled = false;

            if (movebarcount == pagecount)
            {
                if (txtDepthView.Text.ToInt(0) > 0)
                {
                    DepthView();
                }
                else
                {
                    btn_start.Enabled = true;
                }
            }
            else
            {
                myWebBrowser.Document.Window.ScrollTo(0, height * movebarcount);
                movebarcount++;
                tmBrowse.Enabled = true;
            }
        }

        /// <summary>
        /// 深度浏览
        /// </summary>
        private void DepthView()
        {
            movebarcount = 0;

            //查找商品的链接
            HtmlElement nextpage = null;
            HtmlElement link = SearchLink("", out nextpage);
            link.InvokeMember("click");
        }

        /// <summary>
        /// 查询商品链接,如果没有传商品ID,则返回当前页面中第一个商品链接
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        private HtmlElement SearchLink(string productID, out HtmlElement nexpage)
        {
            HtmlElement link = null;
            int index = 0;
            nexpage = null;

            if (productID.Length > 0)
            {
                HtmlElement txt = myWebBrowser.Document.GetElementById("page");                
                var divs = txt.GetElementsByTagName("div");

                foreach (HtmlElement v in divs)
                {
                    string classname = ((mshtml.HTMLDivElement)v.DomElement).className;
                    if (classname == "row grid-view")
                    {
                        for (int i = 0; i < v.Children.Count; i++)
                        {
                            var s = v.Children[i];
                            if (s.InnerHtml.IndexOf(productID) > 0)
                            {
                                index = i;
                                var a = s.GetElementsByTagName("a");
                                link = a[0];
                                //Regex reg = new Regex("http\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                                //MatchCollection mc = reg.Matches(a[0].OuterHtml);
                                //link = mc[0].Value;
                                break;
                            }
                        }
                        break;
                    }
                    else if (classname == "page-top")
                    {
                        nexpage = v.GetElementsByTagName("a")[1];
                    }
                }

                if (link != null)
                {
                    WriteLog(string.Format("{0}目前排名是 第{1}页  第{2}位", productID, pageindex.ToString(), index.ToString()), "");
                }
                return link;
            }

            return link;
        }
        #endregion        
    }
}
