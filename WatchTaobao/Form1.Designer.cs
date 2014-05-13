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
            this.axWebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_google = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_baidu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_web = new System.Windows.Forms.ComboBox();
            this.btn_end = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cbx_IP = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tmFindIP = new System.Windows.Forms.Timer(this.components);
            this.tmKey = new System.Windows.Forms.Timer(this.components);
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
            this.tabWatch.Controls.Add(this.axWebBrowser1);
            this.tabWatch.Controls.Add(this.label13);
            this.tabWatch.Controls.Add(this.label12);
            this.tabWatch.Controls.Add(this.txt_google);
            this.tabWatch.Controls.Add(this.label11);
            this.tabWatch.Controls.Add(this.txt_baidu);
            this.tabWatch.Controls.Add(this.label10);
            this.tabWatch.Controls.Add(this.cmb_web);
            this.tabWatch.Controls.Add(this.btn_end);
            this.tabWatch.Controls.Add(this.button1);
            this.tabWatch.Controls.Add(this.btn_start);
            this.tabWatch.Controls.Add(this.cbx_IP);
            this.tabWatch.Controls.Add(this.textBox3);
            this.tabWatch.Controls.Add(this.label9);
            this.tabWatch.Controls.Add(this.textBox1);
            this.tabWatch.Controls.Add(this.label8);
            this.tabWatch.Controls.Add(this.txt_time);
            this.tabWatch.Controls.Add(this.label7);
            this.tabWatch.Location = new System.Drawing.Point(4, 22);
            this.tabWatch.Name = "tabWatch";
            this.tabWatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabWatch.Size = new System.Drawing.Size(841, 625);
            this.tabWatch.TabIndex = 1;
            this.tabWatch.Text = "刷关键字";
            this.tabWatch.UseVisualStyleBackColor = true;
            // 
            // axWebBrowser1
            // 
            this.axWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWebBrowser1.Location = new System.Drawing.Point(6, 101);
            this.axWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.axWebBrowser1.Name = "axWebBrowser1";
            this.axWebBrowser1.Size = new System.Drawing.Size(827, 521);
            this.axWebBrowser1.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(391, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "统计结果";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 67;
            this.label12.Text = "搜索类型：";
            // 
            // txt_google
            // 
            this.txt_google.Location = new System.Drawing.Point(525, 43);
            this.txt_google.Name = "txt_google";
            this.txt_google.Size = new System.Drawing.Size(304, 21);
            this.txt_google.TabIndex = 66;
            this.txt_google.Text = "http://www.360yi.net/";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 65;
            this.label11.Text = "谷歌搜索结果：";
            // 
            // txt_baidu
            // 
            this.txt_baidu.Location = new System.Drawing.Point(106, 43);
            this.txt_baidu.Name = "txt_baidu";
            this.txt_baidu.Size = new System.Drawing.Size(325, 21);
            this.txt_baidu.TabIndex = 64;
            this.txt_baidu.Text = "只可意会 | 生活随笔,节日营销,热点评论,it分享,开源软件";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "百度搜索结果：";
            // 
            // cmb_web
            // 
            this.cmb_web.FormattingEnabled = true;
            this.cmb_web.Location = new System.Drawing.Point(82, 74);
            this.cmb_web.Name = "cmb_web";
            this.cmb_web.Size = new System.Drawing.Size(121, 20);
            this.cmb_web.TabIndex = 62;
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(299, 72);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(75, 23);
            this.btn_end.TabIndex = 61;
            this.btn_end.Text = "暂停";
            this.btn_end.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(209, 72);
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
            this.cbx_IP.Location = new System.Drawing.Point(645, 22);
            this.cbx_IP.Name = "cbx_IP";
            this.cbx_IP.Size = new System.Drawing.Size(156, 16);
            this.cbx_IP.TabIndex = 58;
            this.cbx_IP.Text = "启用代理IP(不选为ADSL)";
            this.cbx_IP.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(350, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(66, 21);
            this.textBox3.TabIndex = 57;
            this.textBox3.Text = "60";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "网站停留时间（秒）：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(562, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 21);
            this.textBox1.TabIndex = 55;
            this.textBox1.Text = "50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "广告停留时间（秒）：";
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(143, 13);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(66, 21);
            this.txt_time.TabIndex = 53;
            this.txt_time.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "点击停顿时间（秒）：";
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_google;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_baidu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_web;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox cbx_IP;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.WebBrowser axWebBrowser1;
        private System.Windows.Forms.Timer tmKey;
    }
}

