namespace WatchTaobao
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabFindIP = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cbx_caijitype = new System.Windows.Forms.ComboBox();
            this.txt_end = new System.Windows.Forms.TextBox();
            this.txt_start = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_time = new System.Windows.Forms.Label();
            this.lb_tongji = new System.Windows.Forms.Label();
            this.lb_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_caiji = new System.Windows.Forms.Button();
            this.txt_CaijiUrl = new System.Windows.Forms.TextBox();
            this.tabWatch = new System.Windows.Forms.TabPage();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPriceEnd = new System.Windows.Forms.TextBox();
            this.txtPriceStart = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDepthView = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkContrast = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScanEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.myWebBrowser = new System.Windows.Forms.WebBrowser();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cbx_IP = new System.Windows.Forms.CheckBox();
            this.txtScanStart = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaxPagNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tmFindIP = new System.Windows.Forms.Timer(this.components);
            this.tmKey = new System.Windows.Forms.Timer(this.components);
            this.tmBrowse = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabFindIP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabWatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabFindIP);
            this.tabMain.Controls.Add(this.tabWatch);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(849, 651);
            this.tabMain.TabIndex = 0;
            // 
            // tabFindIP
            // 
            this.tabFindIP.Controls.Add(this.button1);
            this.tabFindIP.Controls.Add(this.txtLog);
            this.tabFindIP.Controls.Add(this.cbx_caijitype);
            this.tabFindIP.Controls.Add(this.txt_end);
            this.tabFindIP.Controls.Add(this.txt_start);
            this.tabFindIP.Controls.Add(this.label5);
            this.tabFindIP.Controls.Add(this.label6);
            this.tabFindIP.Controls.Add(this.panel1);
            this.tabFindIP.Controls.Add(this.label1);
            this.tabFindIP.Controls.Add(this.btn_caiji);
            this.tabFindIP.Controls.Add(this.txt_CaijiUrl);
            this.tabFindIP.Location = new System.Drawing.Point(4, 22);
            this.tabFindIP.Name = "tabFindIP";
            this.tabFindIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindIP.Size = new System.Drawing.Size(841, 625);
            this.tabFindIP.TabIndex = 0;
            this.tabFindIP.Text = "采购代理IP";
            this.tabFindIP.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 192);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(822, 404);
            this.txtLog.TabIndex = 52;
            // 
            // cbx_caijitype
            // 
            this.cbx_caijitype.FormattingEnabled = true;
            this.cbx_caijitype.Location = new System.Drawing.Point(382, 6);
            this.cbx_caijitype.Name = "cbx_caijitype";
            this.cbx_caijitype.Size = new System.Drawing.Size(94, 20);
            this.cbx_caijitype.TabIndex = 51;
            // 
            // txt_end
            // 
            this.txt_end.Location = new System.Drawing.Point(203, 42);
            this.txt_end.Name = "txt_end";
            this.txt_end.Size = new System.Drawing.Size(99, 21);
            this.txt_end.TabIndex = 50;
            this.txt_end.Text = "10";
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(73, 42);
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(101, 21);
            this.txt_start.TabIndex = 49;
            this.txt_start.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 47;
            this.label6.Text = "页数范围：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lb_time);
            this.panel1.Controls.Add(this.lb_tongji);
            this.panel1.Controls.Add(this.lb_result);
            this.panel1.Location = new System.Drawing.Point(6, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 106);
            this.panel1.TabIndex = 46;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.ForeColor = System.Drawing.Color.Red;
            this.lb_time.Location = new System.Drawing.Point(13, 76);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(41, 12);
            this.lb_time.TabIndex = 37;
            this.lb_time.Text = "计时器";
            // 
            // lb_tongji
            // 
            this.lb_tongji.AutoSize = true;
            this.lb_tongji.ForeColor = System.Drawing.Color.Red;
            this.lb_tongji.Location = new System.Drawing.Point(12, 42);
            this.lb_tongji.Name = "lb_tongji";
            this.lb_tongji.Size = new System.Drawing.Size(53, 12);
            this.lb_tongji.TabIndex = 34;
            this.lb_tongji.Text = "统计结果";
            // 
            // lb_result
            // 
            this.lb_result.AutoSize = true;
            this.lb_result.ForeColor = System.Drawing.Color.Red;
            this.lb_result.Location = new System.Drawing.Point(13, 6);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(53, 12);
            this.lb_result.TabIndex = 33;
            this.lb_result.Text = "等待采集";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "采集网址：";
            // 
            // btn_caiji
            // 
            this.btn_caiji.Location = new System.Drawing.Point(323, 40);
            this.btn_caiji.Name = "btn_caiji";
            this.btn_caiji.Size = new System.Drawing.Size(75, 23);
            this.btn_caiji.TabIndex = 41;
            this.btn_caiji.Text = "开始采集";
            this.btn_caiji.UseVisualStyleBackColor = true;
            this.btn_caiji.Click += new System.EventHandler(this.btn_caiji_Click);
            // 
            // txt_CaijiUrl
            // 
            this.txt_CaijiUrl.Location = new System.Drawing.Point(73, 6);
            this.txt_CaijiUrl.Name = "txt_CaijiUrl";
            this.txt_CaijiUrl.Size = new System.Drawing.Size(303, 21);
            this.txt_CaijiUrl.TabIndex = 40;
            this.txt_CaijiUrl.Text = "http://www.youdaili.cn/Daili/guonei/528";
            // 
            // tabWatch
            // 
            this.tabWatch.Controls.Add(this.txtInterval);
            this.tabWatch.Controls.Add(this.txtArea);
            this.tabWatch.Controls.Add(this.label15);
            this.tabWatch.Controls.Add(this.label14);
            this.tabWatch.Controls.Add(this.txtPriceEnd);
            this.tabWatch.Controls.Add(this.txtPriceStart);
            this.tabWatch.Controls.Add(this.label13);
            this.tabWatch.Controls.Add(this.label12);
            this.tabWatch.Controls.Add(this.txtDepthView);
            this.tabWatch.Controls.Add(this.label4);
            this.tabWatch.Controls.Add(this.chkContrast);
            this.tabWatch.Controls.Add(this.label3);
            this.tabWatch.Controls.Add(this.txtScanEnd);
            this.tabWatch.Controls.Add(this.label2);
            this.tabWatch.Controls.Add(this.myWebBrowser);
            this.tabWatch.Controls.Add(this.txtProductID);
            this.tabWatch.Controls.Add(this.label11);
            this.tabWatch.Controls.Add(this.txtKeyWord);
            this.tabWatch.Controls.Add(this.label10);
            this.tabWatch.Controls.Add(this.btn_end);
            this.tabWatch.Controls.Add(this.btn_start);
            this.tabWatch.Controls.Add(this.cbx_IP);
            this.tabWatch.Controls.Add(this.txtScanStart);
            this.tabWatch.Controls.Add(this.label9);
            this.tabWatch.Controls.Add(this.txtMaxPagNo);
            this.tabWatch.Controls.Add(this.label8);
            this.tabWatch.Controls.Add(this.txtCount);
            this.tabWatch.Controls.Add(this.label7);
            this.tabWatch.Location = new System.Drawing.Point(4, 22);
            this.tabWatch.Name = "tabWatch";
            this.tabWatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabWatch.Size = new System.Drawing.Size(841, 625);
            this.tabWatch.TabIndex = 1;
            this.tabWatch.Text = "刷关键字";
            this.tabWatch.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(741, 43);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(92, 21);
            this.txtInterval.TabIndex = 83;
            this.txtInterval.Text = "5000";
            // 
            // txtArea
            // 
            this.txtArea.Enabled = false;
            this.txtArea.Location = new System.Drawing.Point(322, 70);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(74, 21);
            this.txtArea.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(251, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 81;
            this.label15.Text = "卖家所在地";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(122, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 80;
            this.label14.Text = "-";
            // 
            // txtPriceEnd
            // 
            this.txtPriceEnd.Enabled = false;
            this.txtPriceEnd.Location = new System.Drawing.Point(139, 70);
            this.txtPriceEnd.Name = "txtPriceEnd";
            this.txtPriceEnd.Size = new System.Drawing.Size(33, 21);
            this.txtPriceEnd.TabIndex = 79;
            this.txtPriceEnd.Text = "0";
            // 
            // txtPriceStart
            // 
            this.txtPriceStart.Enabled = false;
            this.txtPriceStart.Location = new System.Drawing.Point(83, 70);
            this.txtPriceStart.Name = "txtPriceStart";
            this.txtPriceStart.Size = new System.Drawing.Size(33, 21);
            this.txtPriceStart.TabIndex = 78;
            this.txtPriceStart.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 77;
            this.label13.Text = "价格区间";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(383, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(239, 12);
            this.label12.TabIndex = 76;
            this.label12.Text = "设置0不会进行深度浏览,请设置3以内的数字";
            // 
            // txtDepthView
            // 
            this.txtDepthView.Enabled = false;
            this.txtDepthView.Location = new System.Drawing.Point(298, 103);
            this.txtDepthView.Name = "txtDepthView";
            this.txtDepthView.Size = new System.Drawing.Size(74, 21);
            this.txtDepthView.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 74;
            this.label4.Text = "随机进行深度浏览";
            // 
            // chkContrast
            // 
            this.chkContrast.AutoSize = true;
            this.chkContrast.Enabled = false;
            this.chkContrast.Location = new System.Drawing.Point(20, 108);
            this.chkContrast.Name = "chkContrast";
            this.chkContrast.Size = new System.Drawing.Size(96, 16);
            this.chkContrast.TabIndex = 73;
            this.chkContrast.Text = "是否货比三家";
            this.chkContrast.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "-";
            // 
            // txtScanEnd
            // 
            this.txtScanEnd.Location = new System.Drawing.Point(366, 16);
            this.txtScanEnd.Name = "txtScanEnd";
            this.txtScanEnd.Size = new System.Drawing.Size(33, 21);
            this.txtScanEnd.TabIndex = 71;
            this.txtScanEnd.Text = "15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "次";
            // 
            // myWebBrowser
            // 
            this.myWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myWebBrowser.Location = new System.Drawing.Point(6, 170);
            this.myWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.myWebBrowser.Name = "myWebBrowser";
            this.myWebBrowser.Size = new System.Drawing.Size(827, 452);
            this.myWebBrowser.TabIndex = 69;
            this.myWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.axWebBrowser1_DocumentCompleted);
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(490, 43);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(138, 21);
            this.txtProductID.TabIndex = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 65;
            this.label11.Text = "商品ID";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(83, 43);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(316, 21);
            this.txtKeyWord.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "关 键 词";
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(123, 133);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(75, 23);
            this.btn_end.TabIndex = 61;
            this.btn_end.Text = "暂停";
            this.btn_end.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(22, 133);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 60;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cbx_IP
            // 
            this.cbx_IP.AutoSize = true;
            this.cbx_IP.Checked = true;
            this.cbx_IP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IP.Location = new System.Drawing.Point(620, 18);
            this.cbx_IP.Name = "cbx_IP";
            this.cbx_IP.Size = new System.Drawing.Size(156, 16);
            this.cbx_IP.TabIndex = 58;
            this.cbx_IP.Text = "启用代理IP(不选为ADSL)";
            this.cbx_IP.UseVisualStyleBackColor = true;
            // 
            // txtScanStart
            // 
            this.txtScanStart.Location = new System.Drawing.Point(310, 16);
            this.txtScanStart.Name = "txtScanStart";
            this.txtScanStart.Size = new System.Drawing.Size(33, 21);
            this.txtScanStart.TabIndex = 57;
            this.txtScanStart.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "宝贝停留时间(分钟)";
            // 
            // txtMaxPagNo
            // 
            this.txtMaxPagNo.Location = new System.Drawing.Point(526, 16);
            this.txtMaxPagNo.Name = "txtMaxPagNo";
            this.txtMaxPagNo.Size = new System.Drawing.Size(66, 21);
            this.txtMaxPagNo.TabIndex = 55;
            this.txtMaxPagNo.Text = "50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "最大搜索页数";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(83, 16);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(45, 21);
            this.txtCount.TabIndex = 53;
            this.txtCount.Tag = "一个IP一天优化次数";
            this.txtCount.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "优化次数";
            // 
            // tmFindIP
            // 
            this.tmFindIP.Interval = 1000;
            this.tmFindIP.Tick += new System.EventHandler(this.tmFindIP_Tick);
            // 
            // tmKey
            // 
            this.tmKey.Tick += new System.EventHandler(this.tmKey_Tick);
            // 
            // tmBrowse
            // 
            this.tmBrowse.Tick += new System.EventHandler(this.tmBrowse_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 53;
            this.button1.Text = "开始采集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 651);
            this.Controls.Add(this.tabMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabMain.ResumeLayout(false);
            this.tabFindIP.ResumeLayout(false);
            this.tabFindIP.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabWatch.ResumeLayout(false);
            this.tabWatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabFindIP;
        private System.Windows.Forms.ComboBox cbx_caijitype;
        private System.Windows.Forms.TextBox txt_end;
        private System.Windows.Forms.TextBox txt_start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Label lb_tongji;
        private System.Windows.Forms.Label lb_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_caiji;
        private System.Windows.Forms.TextBox txt_CaijiUrl;
        private System.Windows.Forms.TabPage tabWatch;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer tmFindIP;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox cbx_IP;
        private System.Windows.Forms.TextBox txtScanStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxPagNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.WebBrowser myWebBrowser;
        private System.Windows.Forms.Timer tmKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDepthView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkContrast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScanEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPriceEnd;
        private System.Windows.Forms.TextBox txtPriceStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer tmBrowse;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button button1;
    }
}

