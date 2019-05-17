namespace AutoTestTool
{
    partial class dfu_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dfu_Form));
            this.comboBox_PathAndFile = new System.Windows.Forms.ComboBox();
            this.button_open_file = new System.Windows.Forms.Button();
            this.button_start_transform = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_recv_show = new System.Windows.Forms.CheckBox();
            this.chk_recv_hex = new System.Windows.Forms.CheckBox();
            this.lbl_recv_clear = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBox_dfu_SerialPortSelect = new System.Windows.Forms.ComboBox();
            this.ComboBox_dfu_SerialBuateSelect = new System.Windows.Forms.ComboBox();
            this.button_open_serial = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_txt_show_recv = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dfu_serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Label_UpGrade = new CCWin.SkinControl.SkinLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_PathAndFile
            // 
            this.comboBox_PathAndFile.FormattingEnabled = true;
            this.comboBox_PathAndFile.Location = new System.Drawing.Point(15, 20);
            this.comboBox_PathAndFile.Name = "comboBox_PathAndFile";
            this.comboBox_PathAndFile.Size = new System.Drawing.Size(396, 23);
            this.comboBox_PathAndFile.TabIndex = 0;
            this.comboBox_PathAndFile.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button_open_file
            // 
            this.button_open_file.Location = new System.Drawing.Point(445, 15);
            this.button_open_file.Name = "button_open_file";
            this.button_open_file.Size = new System.Drawing.Size(78, 28);
            this.button_open_file.TabIndex = 1;
            this.button_open_file.Text = "打开文件";
            this.button_open_file.UseVisualStyleBackColor = true;
            this.button_open_file.Click += new System.EventHandler(this.Button_open_file_Click);
            // 
            // button_start_transform
            // 
            this.button_start_transform.Location = new System.Drawing.Point(445, 44);
            this.button_start_transform.Name = "button_start_transform";
            this.button_start_transform.Size = new System.Drawing.Size(78, 28);
            this.button_start_transform.TabIndex = 2;
            this.button_start_transform.Text = "开始升级";
            this.button_start_transform.UseVisualStyleBackColor = true;
            this.button_start_transform.Click += new System.EventHandler(this.Button_start_transform_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Crimson;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "深圳长丰影像";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.ToolStripStatusLabel1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, -1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Size = new System.Drawing.Size(831, 474);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_recv_show);
            this.groupBox3.Controls.Add(this.chk_recv_hex);
            this.groupBox3.Controls.Add(this.lbl_recv_clear);
            this.groupBox3.Location = new System.Drawing.Point(3, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 112);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收设置";
            // 
            // chk_recv_show
            // 
            this.chk_recv_show.AutoSize = true;
            this.chk_recv_show.Location = new System.Drawing.Point(6, 42);
            this.chk_recv_show.Name = "chk_recv_show";
            this.chk_recv_show.Size = new System.Drawing.Size(98, 19);
            this.chk_recv_show.TabIndex = 9;
            this.chk_recv_show.Text = "显示接收数据";
            this.chk_recv_show.UseVisualStyleBackColor = true;
            this.chk_recv_show.CheckedChanged += new System.EventHandler(this.Chk_recv_show_CheckedChanged);
            // 
            // chk_recv_hex
            // 
            this.chk_recv_hex.AutoSize = true;
            this.chk_recv_hex.Location = new System.Drawing.Point(6, 26);
            this.chk_recv_hex.Name = "chk_recv_hex";
            this.chk_recv_hex.Size = new System.Drawing.Size(98, 19);
            this.chk_recv_hex.TabIndex = 8;
            this.chk_recv_hex.Text = "显示十六进制";
            this.chk_recv_hex.UseVisualStyleBackColor = true;
            // 
            // lbl_recv_clear
            // 
            this.lbl_recv_clear.AutoSize = true;
            this.lbl_recv_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_recv_clear.Font = new System.Drawing.Font("宋体", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_recv_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_recv_clear.Location = new System.Drawing.Point(6, 83);
            this.lbl_recv_clear.Name = "lbl_recv_clear";
            this.lbl_recv_clear.Size = new System.Drawing.Size(67, 14);
            this.lbl_recv_clear.TabIndex = 7;
            this.lbl_recv_clear.Text = "清除显示";
            this.lbl_recv_clear.Click += new System.EventHandler(this.Lbl_recv_clear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboBox_dfu_SerialPortSelect);
            this.groupBox2.Controls.Add(this.ComboBox_dfu_SerialBuateSelect);
            this.groupBox2.Controls.Add(this.button_open_serial);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口设置";
            // 
            // ComboBox_dfu_SerialPortSelect
            // 
            this.ComboBox_dfu_SerialPortSelect.FormattingEnabled = true;
            this.ComboBox_dfu_SerialPortSelect.Location = new System.Drawing.Point(9, 18);
            this.ComboBox_dfu_SerialPortSelect.Name = "ComboBox_dfu_SerialPortSelect";
            this.ComboBox_dfu_SerialPortSelect.Size = new System.Drawing.Size(88, 23);
            this.ComboBox_dfu_SerialPortSelect.TabIndex = 3;
            this.ComboBox_dfu_SerialPortSelect.DropDown += new System.EventHandler(this.ComboBox_dfu_SerialPortSelect_DropDown);
            this.ComboBox_dfu_SerialPortSelect.SelectedIndexChanged += new System.EventHandler(this.ComboBox_dfu_SerialPortSelect_SelectedIndexChanged);
            // 
            // ComboBox_dfu_SerialBuateSelect
            // 
            this.ComboBox_dfu_SerialBuateSelect.FormattingEnabled = true;
            this.ComboBox_dfu_SerialBuateSelect.Items.AddRange(new object[] {
            "19200",
            "115200",
            "9600"});
            this.ComboBox_dfu_SerialBuateSelect.Location = new System.Drawing.Point(9, 47);
            this.ComboBox_dfu_SerialBuateSelect.Name = "ComboBox_dfu_SerialBuateSelect";
            this.ComboBox_dfu_SerialBuateSelect.Size = new System.Drawing.Size(88, 23);
            this.ComboBox_dfu_SerialBuateSelect.TabIndex = 5;
            // 
            // button_open_serial
            // 
            this.button_open_serial.Location = new System.Drawing.Point(9, 76);
            this.button_open_serial.Name = "button_open_serial";
            this.button_open_serial.Size = new System.Drawing.Size(83, 28);
            this.button_open_serial.TabIndex = 4;
            this.button_open_serial.Text = "打开串口";
            this.button_open_serial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_open_serial.UseVisualStyleBackColor = true;
            this.button_open_serial.Click += new System.EventHandler(this.Button_open_serial_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox_txt_show_recv);
            this.groupBox4.Location = new System.Drawing.Point(1, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(656, 324);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收数据";
            // 
            // textBox_txt_show_recv
            // 
            this.textBox_txt_show_recv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_txt_show_recv.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_txt_show_recv.ForeColor = System.Drawing.Color.Yellow;
            this.textBox_txt_show_recv.Location = new System.Drawing.Point(-3, 20);
            this.textBox_txt_show_recv.Multiline = true;
            this.textBox_txt_show_recv.Name = "textBox_txt_show_recv";
            this.textBox_txt_show_recv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_txt_show_recv.Size = new System.Drawing.Size(659, 304);
            this.textBox_txt_show_recv.TabIndex = 8;
            this.textBox_txt_show_recv.Text = "qq";
            this.textBox_txt_show_recv.TextChanged += new System.EventHandler(this.TextBox_txt_show_recv_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Location = new System.Drawing.Point(3, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 332);
            this.panel1.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBox_send);
            this.groupBox5.Controls.Add(this.button_test);
            this.groupBox5.Location = new System.Drawing.Point(0, 267);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(651, 62);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送数据";
            // 
            // textBox_send
            // 
            this.textBox_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_send.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_send.ForeColor = System.Drawing.Color.Black;
            this.textBox_send.Location = new System.Drawing.Point(-3, 20);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_send.Size = new System.Drawing.Size(515, 42);
            this.textBox_send.TabIndex = 8;
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_test.Location = new System.Drawing.Point(538, 28);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(78, 28);
            this.button_test.TabIndex = 7;
            this.button_test.Text = "发送";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.Button_test_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_UpGrade);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.button_start_transform);
            this.groupBox1.Controls.Add(this.comboBox_PathAndFile);
            this.groupBox1.Controls.Add(this.button_open_file);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "代码升级";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Lime;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(15, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(396, 23);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // dfu_serialPort
            // 
            this.dfu_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Dfu_serialPort_DataReceived);
            // 
            // Label_UpGrade
            // 
            this.Label_UpGrade.AutoSize = true;
            this.Label_UpGrade.BackColor = System.Drawing.Color.Transparent;
            this.Label_UpGrade.BorderColor = System.Drawing.Color.White;
            this.Label_UpGrade.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_UpGrade.Location = new System.Drawing.Point(420, 47);
            this.Label_UpGrade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_UpGrade.Name = "Label_UpGrade";
            this.Label_UpGrade.Size = new System.Drawing.Size(0, 25);
            this.Label_UpGrade.TabIndex = 36;
            // 
            // dfu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(831, 498);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "dfu_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DFU tool (for JIAYZ only)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_PathAndFile;
        private System.Windows.Forms.Button button_open_file;
        private System.Windows.Forms.Button button_start_transform;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox ComboBox_dfu_SerialPortSelect;
        private System.Windows.Forms.Button button_open_serial;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.IO.Ports.SerialPort dfu_serialPort;
        private System.Windows.Forms.ComboBox ComboBox_dfu_SerialBuateSelect;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.TextBox textBox_txt_show_recv;
        private System.Windows.Forms.Label lbl_recv_clear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_recv_hex;
        private System.Windows.Forms.CheckBox chk_recv_show;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinLabel Label_UpGrade;
    }
}

