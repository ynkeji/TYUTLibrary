namespace Demo.BytesIO.TCP_Client
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbIntPort = new System.Windows.Forms.TextBox();
            this.tbStrIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbConnect = new System.Windows.Forms.ToolStripButton();
            this.tbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearConnect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.tbIntPort);
            this.groupBox1.Controls.Add(this.tbStrIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1356, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络设置";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(789, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 50);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // tbIntPort
            // 
            this.tbIntPort.Location = new System.Drawing.Point(429, 37);
            this.tbIntPort.Name = "tbIntPort";
            this.tbIntPort.Size = new System.Drawing.Size(100, 25);
            this.tbIntPort.TabIndex = 4;
            this.tbIntPort.Text = "8888";
            // 
            // tbStrIp
            // 
            this.tbStrIp.Location = new System.Drawing.Point(96, 37);
            this.tbStrIp.Name = "tbStrIp";
            this.tbStrIp.Size = new System.Drawing.Size(234, 25);
            this.tbStrIp.TabIndex = 3;
            this.tbStrIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP地址：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConnect,
            this.tbDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(625, 37);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(99, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbConnect
            // 
            this.tbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tbConnect.Image")));
            this.tbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(43, 24);
            this.tbConnect.Text = "连接";
            this.tbConnect.Click += new System.EventHandler(this.tbConnect_Click);
            // 
            // tbDisconnect
            // 
            this.tbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tbDisconnect.Image")));
            this.tbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDisconnect.Name = "tbDisconnect";
            this.tbDisconnect.Size = new System.Drawing.Size(43, 24);
            this.tbDisconnect.Text = "断开";
            this.tbDisconnect.Click += new System.EventHandler(this.tbDisconnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1356, 709);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据接收";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1344, 552);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "状态";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "来源";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "message";
            this.columnHeader3.Width = 1100;
            // 
            // btnClearConnect
            // 
            this.btnClearConnect.Location = new System.Drawing.Point(1020, 80);
            this.btnClearConnect.Name = "btnClearConnect";
            this.btnClearConnect.Size = new System.Drawing.Size(162, 59);
            this.btnClearConnect.TabIndex = 1;
            this.btnClearConnect.Text = "清空接收";
            this.btnClearConnect.UseVisualStyleBackColor = true;
            this.btnClearConnect.Click += new System.EventHandler(this.btnClearConnect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearConnect);
            this.groupBox3.Controls.Add(this.btnClearSend);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 652);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1356, 136);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据发送";
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(1203, 85);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(153, 54);
            this.btnClearSend.TabIndex = 2;
            this.btnClearSend.Text = "发送清空";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1020, 9);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(326, 70);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(25, 24);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(980, 106);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "{\"userTime\":\"00000\",\"data\":\"\"}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 788);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbIntPort;
        private System.Windows.Forms.TextBox tbStrIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbConnect;
        private System.Windows.Forms.ToolStripButton tbDisconnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearConnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}

