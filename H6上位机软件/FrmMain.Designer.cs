namespace H6
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btn_CheckDev = new System.Windows.Forms.Button();
            this.btn_Logon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_Battery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Resolution = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.tb_UnitName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_UnitID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_UserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_DevID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_StateInfo = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_UpdataFile = new System.Windows.Forms.Button();
            this.pg_Updata = new System.Windows.Forms.ProgressBar();
            this.btn_FilePathChose = new System.Windows.Forms.Button();
            this.tb_FilePath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gb_StatusCommand = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_ChangePWd = new System.Windows.Forms.Button();
            this.btn_4G = new System.Windows.Forms.Button();
            this.btn_EcjetSD = new System.Windows.Forms.Button();
            this.btn_SyncDevTime = new System.Windows.Forms.Button();
            this.btn_SetMSDC = new System.Windows.Forms.Button();
            this.gb_Wireless = new System.Windows.Forms.GroupBox();
            this.btnRefreshWifi = new System.Windows.Forms.Button();
            this.comboWifiName = new System.Windows.Forms.ComboBox();
            this.btn_Wireless = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_Wireles_Edit = new System.Windows.Forms.Button();
            this.Lb_WifiMode = new System.Windows.Forms.ComboBox();
            this.tb_ServerIP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_ServerPort = new System.Windows.Forms.TextBox();
            this.lb_WifiPassWord = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_WifiName = new System.Windows.Forms.TextBox();
            this.tb_4GAPN = new System.Windows.Forms.TextBox();
            this.tb_4GPIN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReadDeviceInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gb_StatusCommand.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gb_Wireless.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CheckDev
            // 
            this.btn_CheckDev.Location = new System.Drawing.Point(18, 55);
            this.btn_CheckDev.Name = "btn_CheckDev";
            this.btn_CheckDev.Size = new System.Drawing.Size(131, 37);
            this.btn_CheckDev.TabIndex = 0;
            this.btn_CheckDev.Text = "检查设备";
            this.btn_CheckDev.UseVisualStyleBackColor = true;
            this.btn_CheckDev.Click += new System.EventHandler(this.btn_CheckDev_Click);
            // 
            // btn_Logon
            // 
            this.btn_Logon.Location = new System.Drawing.Point(166, 14);
            this.btn_Logon.Name = "btn_Logon";
            this.btn_Logon.Size = new System.Drawing.Size(75, 35);
            this.btn_Logon.TabIndex = 1;
            this.btn_Logon.Text = "登录";
            this.btn_Logon.UseVisualStyleBackColor = true;
            this.btn_Logon.Click += new System.EventHandler(this.btn_Logon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "登录密码";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(79, 20);
            this.tb_Password.MaxLength = 6;
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(70, 21);
            this.tb_Password.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_CheckDev);
            this.groupBox1.Controls.Add(this.btn_Logon);
            this.groupBox1.Controls.Add(this.tb_Password);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 97);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(166, 55);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(73, 37);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tb_Battery);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_Resolution);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(279, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 97);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // tb_Battery
            // 
            this.tb_Battery.Location = new System.Drawing.Point(63, 15);
            this.tb_Battery.Name = "tb_Battery";
            this.tb_Battery.ReadOnly = true;
            this.tb_Battery.Size = new System.Drawing.Size(94, 21);
            this.tb_Battery.TabIndex = 5;
            this.tb_Battery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "电量";
            // 
            // tb_Resolution
            // 
            this.tb_Resolution.Location = new System.Drawing.Point(63, 56);
            this.tb_Resolution.Name = "tb_Resolution";
            this.tb_Resolution.ReadOnly = true;
            this.tb_Resolution.Size = new System.Drawing.Size(94, 21);
            this.tb_Resolution.TabIndex = 3;
            this.tb_Resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "分辨率";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnReadDeviceInfo);
            this.groupBox3.Controls.Add(this.btn_OK);
            this.groupBox3.Controls.Add(this.tb_UnitName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btn_Edit);
            this.groupBox3.Controls.Add(this.tb_UserName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tb_UnitID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tb_UserID);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tb_DevID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(27, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 126);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "执法仪信息";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(356, 50);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(61, 35);
            this.btn_OK.TabIndex = 17;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(356, 14);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(61, 35);
            this.btn_Edit.TabIndex = 16;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // tb_UnitName
            // 
            this.tb_UnitName.Location = new System.Drawing.Point(65, 92);
            this.tb_UnitName.MaxLength = 32;
            this.tb_UnitName.Name = "tb_UnitName";
            this.tb_UnitName.Size = new System.Drawing.Size(278, 21);
            this.tb_UnitName.TabIndex = 15;
            this.tb_UnitName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "单位名称";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(238, 57);
            this.tb_UserName.MaxLength = 32;
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(105, 21);
            this.tb_UserName.TabIndex = 13;
            this.tb_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(179, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "用户名称";
            // 
            // tb_UnitID
            // 
            this.tb_UnitID.Location = new System.Drawing.Point(75, 58);
            this.tb_UnitID.MaxLength = 12;
            this.tb_UnitID.Name = "tb_UnitID";
            this.tb_UnitID.Size = new System.Drawing.Size(94, 21);
            this.tb_UnitID.TabIndex = 11;
            this.tb_UnitID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "单位编号";
            // 
            // tb_UserID
            // 
            this.tb_UserID.Location = new System.Drawing.Point(238, 22);
            this.tb_UserID.MaxLength = 6;
            this.tb_UserID.Name = "tb_UserID";
            this.tb_UserID.Size = new System.Drawing.Size(105, 21);
            this.tb_UserID.TabIndex = 9;
            this.tb_UserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "用户编号";
            // 
            // tb_DevID
            // 
            this.tb_DevID.Location = new System.Drawing.Point(75, 25);
            this.tb_DevID.MaxLength = 7;
            this.tb_DevID.Name = "tb_DevID";
            this.tb_DevID.Size = new System.Drawing.Size(94, 21);
            this.tb_DevID.TabIndex = 7;
            this.tb_DevID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "设备编号";
            // 
            // lb_StateInfo
            // 
            this.lb_StateInfo.FormattingEnabled = true;
            this.lb_StateInfo.ItemHeight = 12;
            this.lb_StateInfo.Location = new System.Drawing.Point(6, 21);
            this.lb_StateInfo.Name = "lb_StateInfo";
            this.lb_StateInfo.Size = new System.Drawing.Size(443, 592);
            this.lb_StateInfo.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btn_UpdataFile);
            this.groupBox5.Controls.Add(this.pg_Updata);
            this.groupBox5.Controls.Add(this.btn_FilePathChose);
            this.groupBox5.Controls.Add(this.tb_FilePath);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(27, 620);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(423, 99);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "系统升级";
            // 
            // btn_UpdataFile
            // 
            this.btn_UpdataFile.Location = new System.Drawing.Point(335, 54);
            this.btn_UpdataFile.Name = "btn_UpdataFile";
            this.btn_UpdataFile.Size = new System.Drawing.Size(75, 35);
            this.btn_UpdataFile.TabIndex = 26;
            this.btn_UpdataFile.Text = "升级";
            this.btn_UpdataFile.UseVisualStyleBackColor = true;
            this.btn_UpdataFile.Click += new System.EventHandler(this.btn_UpdataFile_Click);
            // 
            // pg_Updata
            // 
            this.pg_Updata.Location = new System.Drawing.Point(79, 58);
            this.pg_Updata.Name = "pg_Updata";
            this.pg_Updata.Size = new System.Drawing.Size(244, 23);
            this.pg_Updata.TabIndex = 25;
            // 
            // btn_FilePathChose
            // 
            this.btn_FilePathChose.Location = new System.Drawing.Point(335, 13);
            this.btn_FilePathChose.Name = "btn_FilePathChose";
            this.btn_FilePathChose.Size = new System.Drawing.Size(75, 35);
            this.btn_FilePathChose.TabIndex = 2;
            this.btn_FilePathChose.Text = "选择";
            this.btn_FilePathChose.UseVisualStyleBackColor = true;
            this.btn_FilePathChose.Click += new System.EventHandler(this.btn_FilePathChose_Click);
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.Location = new System.Drawing.Point(79, 21);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.ReadOnly = true;
            this.tb_FilePath.Size = new System.Drawing.Size(244, 21);
            this.tb_FilePath.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "下载进度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "文件路径";
            // 
            // gb_StatusCommand
            // 
            this.gb_StatusCommand.BackColor = System.Drawing.Color.Transparent;
            this.gb_StatusCommand.Controls.Add(this.lb_StateInfo);
            this.gb_StatusCommand.Location = new System.Drawing.Point(456, 92);
            this.gb_StatusCommand.Name = "gb_StatusCommand";
            this.gb_StatusCommand.Size = new System.Drawing.Size(458, 627);
            this.gb_StatusCommand.TabIndex = 11;
            this.gb_StatusCommand.TabStop = false;
            this.gb_StatusCommand.Text = "状态信息";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.btn_ChangePWd);
            this.groupBox6.Controls.Add(this.btn_EcjetSD);
            this.groupBox6.Controls.Add(this.btn_SyncDevTime);
            this.groupBox6.Controls.Add(this.btn_SetMSDC);
            this.groupBox6.Location = new System.Drawing.Point(26, 550);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(423, 64);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // btn_ChangePWd
            // 
            this.btn_ChangePWd.Location = new System.Drawing.Point(260, 20);
            this.btn_ChangePWd.Name = "btn_ChangePWd";
            this.btn_ChangePWd.Size = new System.Drawing.Size(61, 35);
            this.btn_ChangePWd.TabIndex = 4;
            this.btn_ChangePWd.Text = "修改密码";
            this.btn_ChangePWd.UseVisualStyleBackColor = true;
            // 
            // btn_4G
            // 
            this.btn_4G.Location = new System.Drawing.Point(1028, 459);
            this.btn_4G.Name = "btn_4G";
            this.btn_4G.Size = new System.Drawing.Size(61, 35);
            this.btn_4G.TabIndex = 3;
            this.btn_4G.Text = "4G模式";
            this.btn_4G.UseVisualStyleBackColor = true;
            this.btn_4G.Click += new System.EventHandler(this.btn_4G_Click);
            // 
            // btn_EcjetSD
            // 
            this.btn_EcjetSD.Location = new System.Drawing.Point(183, 20);
            this.btn_EcjetSD.Name = "btn_EcjetSD";
            this.btn_EcjetSD.Size = new System.Drawing.Size(61, 35);
            this.btn_EcjetSD.TabIndex = 2;
            this.btn_EcjetSD.Text = "打开磁盘";
            this.btn_EcjetSD.UseVisualStyleBackColor = true;
            this.btn_EcjetSD.Click += new System.EventHandler(this.btn_EcjetSD_Click);
            // 
            // btn_SyncDevTime
            // 
            this.btn_SyncDevTime.Location = new System.Drawing.Point(18, 20);
            this.btn_SyncDevTime.Name = "btn_SyncDevTime";
            this.btn_SyncDevTime.Size = new System.Drawing.Size(61, 35);
            this.btn_SyncDevTime.TabIndex = 0;
            this.btn_SyncDevTime.Text = "时间同步";
            this.btn_SyncDevTime.UseVisualStyleBackColor = true;
            this.btn_SyncDevTime.Click += new System.EventHandler(this.btn_SyncDevTime_Click);
            // 
            // btn_SetMSDC
            // 
            this.btn_SetMSDC.Location = new System.Drawing.Point(100, 20);
            this.btn_SetMSDC.Name = "btn_SetMSDC";
            this.btn_SetMSDC.Size = new System.Drawing.Size(61, 35);
            this.btn_SetMSDC.TabIndex = 1;
            this.btn_SetMSDC.Text = "U盘使能";
            this.btn_SetMSDC.UseVisualStyleBackColor = true;
            this.btn_SetMSDC.Click += new System.EventHandler(this.btn_SetMSDC_Click);
            // 
            // gb_Wireless
            // 
            this.gb_Wireless.BackColor = System.Drawing.Color.Transparent;
            this.gb_Wireless.Controls.Add(this.button1);
            this.gb_Wireless.Controls.Add(this.btnRefreshWifi);
            this.gb_Wireless.Controls.Add(this.comboWifiName);
            this.gb_Wireless.Controls.Add(this.btn_Wireless);
            this.gb_Wireless.Controls.Add(this.label18);
            this.gb_Wireless.Controls.Add(this.btn_Wireles_Edit);
            this.gb_Wireless.Controls.Add(this.Lb_WifiMode);
            this.gb_Wireless.Controls.Add(this.tb_4GPIN);
            this.gb_Wireless.Controls.Add(this.tb_ServerIP);
            this.gb_Wireless.Controls.Add(this.label17);
            this.gb_Wireless.Controls.Add(this.tb_4GAPN);
            this.gb_Wireless.Controls.Add(this.tb_ServerPort);
            this.gb_Wireless.Controls.Add(this.label16);
            this.gb_Wireless.Controls.Add(this.lb_WifiPassWord);
            this.gb_Wireless.Controls.Add(this.label14);
            this.gb_Wireless.Controls.Add(this.label11);
            this.gb_Wireless.Controls.Add(this.label10);
            this.gb_Wireless.Controls.Add(this.label15);
            this.gb_Wireless.Controls.Add(this.label2);
            this.gb_Wireless.Location = new System.Drawing.Point(24, 329);
            this.gb_Wireless.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Wireless.Name = "gb_Wireless";
            this.gb_Wireless.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Wireless.Size = new System.Drawing.Size(423, 216);
            this.gb_Wireless.TabIndex = 12;
            this.gb_Wireless.TabStop = false;
            this.gb_Wireless.Text = "无线通信";
            // 
            // btnRefreshWifi
            // 
            this.btnRefreshWifi.Enabled = false;
            this.btnRefreshWifi.Location = new System.Drawing.Point(92, 141);
            this.btnRefreshWifi.Name = "btnRefreshWifi";
            this.btnRefreshWifi.Size = new System.Drawing.Size(68, 35);
            this.btnRefreshWifi.TabIndex = 23;
            this.btnRefreshWifi.Text = "刷新WiFi";
            this.btnRefreshWifi.UseVisualStyleBackColor = true;
            this.btnRefreshWifi.Click += new System.EventHandler(this.btnRefreshWifi_Click);
            // 
            // comboWifiName
            // 
            this.comboWifiName.FormattingEnabled = true;
            this.comboWifiName.Location = new System.Drawing.Point(65, 47);
            this.comboWifiName.Name = "comboWifiName";
            this.comboWifiName.Size = new System.Drawing.Size(119, 20);
            this.comboWifiName.TabIndex = 15;
            // 
            // btn_Wireless
            // 
            this.btn_Wireless.Location = new System.Drawing.Point(166, 141);
            this.btn_Wireless.Name = "btn_Wireless";
            this.btn_Wireless.Size = new System.Drawing.Size(68, 35);
            this.btn_Wireless.TabIndex = 22;
            this.btn_Wireless.Text = "确定";
            this.btn_Wireless.UseVisualStyleBackColor = true;
            this.btn_Wireless.Click += new System.EventHandler(this.btn_Wireless_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(39, 188);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(202, 22);
            this.label18.TabIndex = 20;
            this.label18.Text = "无需设置的参数，保持空白";
            // 
            // btn_Wireles_Edit
            // 
            this.btn_Wireles_Edit.Location = new System.Drawing.Point(18, 141);
            this.btn_Wireles_Edit.Name = "btn_Wireles_Edit";
            this.btn_Wireles_Edit.Size = new System.Drawing.Size(68, 35);
            this.btn_Wireles_Edit.TabIndex = 18;
            this.btn_Wireles_Edit.Text = "编辑";
            this.btn_Wireles_Edit.UseVisualStyleBackColor = true;
            this.btn_Wireles_Edit.Click += new System.EventHandler(this.btn_Wireles_Edit_Click);
            // 
            // Lb_WifiMode
            // 
            this.Lb_WifiMode.FormattingEnabled = true;
            this.Lb_WifiMode.Items.AddRange(new object[] {
            "AP（无线接入）",
            "STA（无线终端）"});
            this.Lb_WifiMode.Location = new System.Drawing.Point(67, 18);
            this.Lb_WifiMode.Margin = new System.Windows.Forms.Padding(2);
            this.Lb_WifiMode.Name = "Lb_WifiMode";
            this.Lb_WifiMode.Size = new System.Drawing.Size(117, 20);
            this.Lb_WifiMode.TabIndex = 13;
            // 
            // tb_ServerIP
            // 
            this.tb_ServerIP.Location = new System.Drawing.Point(69, 113);
            this.tb_ServerIP.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ServerIP.MaxLength = 15;
            this.tb_ServerIP.Name = "tb_ServerIP";
            this.tb_ServerIP.Size = new System.Drawing.Size(117, 21);
            this.tb_ServerIP.TabIndex = 10;
            this.tb_ServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 116);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "服务器IP";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_ServerPort
            // 
            this.tb_ServerPort.Location = new System.Drawing.Point(276, 111);
            this.tb_ServerPort.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ServerPort.Name = "tb_ServerPort";
            this.tb_ServerPort.Size = new System.Drawing.Size(94, 21);
            this.tb_ServerPort.TabIndex = 6;
            this.tb_ServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_WifiPassWord
            // 
            this.lb_WifiPassWord.Location = new System.Drawing.Point(65, 76);
            this.lb_WifiPassWord.Margin = new System.Windows.Forms.Padding(2);
            this.lb_WifiPassWord.Name = "lb_WifiPassWord";
            this.lb_WifiPassWord.Size = new System.Drawing.Size(117, 21);
            this.lb_WifiPassWord.TabIndex = 5;
            this.lb_WifiPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(204, 115);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "服务器端口";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 83);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "WiFi密码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 49);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "WiFi名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "WiFi模式";
            // 
            // lb_WifiName
            // 
            this.lb_WifiName.Location = new System.Drawing.Point(1007, 168);
            this.lb_WifiName.Margin = new System.Windows.Forms.Padding(2);
            this.lb_WifiName.Name = "lb_WifiName";
            this.lb_WifiName.Size = new System.Drawing.Size(117, 21);
            this.lb_WifiName.TabIndex = 4;
            this.lb_WifiName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_4GAPN
            // 
            this.tb_4GAPN.Location = new System.Drawing.Point(253, 18);
            this.tb_4GAPN.Margin = new System.Windows.Forms.Padding(2);
            this.tb_4GAPN.Name = "tb_4GAPN";
            this.tb_4GAPN.Size = new System.Drawing.Size(117, 21);
            this.tb_4GAPN.TabIndex = 12;
            this.tb_4GAPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_4GAPN.Visible = false;
            // 
            // tb_4GPIN
            // 
            this.tb_4GPIN.Location = new System.Drawing.Point(255, 50);
            this.tb_4GPIN.Margin = new System.Windows.Forms.Padding(2);
            this.tb_4GPIN.Name = "tb_4GPIN";
            this.tb_4GPIN.Size = new System.Drawing.Size(115, 21);
            this.tb_4GPIN.TabIndex = 11;
            this.tb_4GPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_4GPIN.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(208, 54);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 8;
            this.label16.Text = "4G PIN";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(208, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "4G APN";
            this.label15.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(279, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 46);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "警用执法记录仪管理软件";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(198, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnReadDeviceInfo
            // 
            this.btnReadDeviceInfo.Location = new System.Drawing.Point(356, 88);
            this.btnReadDeviceInfo.Name = "btnReadDeviceInfo";
            this.btnReadDeviceInfo.Size = new System.Drawing.Size(59, 31);
            this.btnReadDeviceInfo.TabIndex = 18;
            this.btnReadDeviceInfo.Text = "读取";
            this.btnReadDeviceInfo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 35);
            this.button1.TabIndex = 24;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::H6.Properties.Resources.b;
            this.ClientSize = new System.Drawing.Size(1240, 739);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btn_4G);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_Wireless);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.gb_StatusCommand);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lb_WifiName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "HAC H6 Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gb_StatusCommand.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.gb_Wireless.ResumeLayout(false);
            this.gb_Wireless.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckDev;
        private System.Windows.Forms.Button btn_Logon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_Battery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Resolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.TextBox tb_UnitName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_UnitID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_UserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_DevID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_StateInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_UpdataFile;
        private System.Windows.Forms.ProgressBar pg_Updata;
        private System.Windows.Forms.Button btn_FilePathChose;
        private System.Windows.Forms.TextBox tb_FilePath;
        private System.Windows.Forms.GroupBox gb_StatusCommand;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_SyncDevTime;
        private System.Windows.Forms.Button btn_SetMSDC;
        private System.Windows.Forms.Button btn_EcjetSD;
        private System.Windows.Forms.Button btn_4G;
        private System.Windows.Forms.GroupBox gb_Wireless;
        private System.Windows.Forms.ComboBox Lb_WifiMode;
        private System.Windows.Forms.TextBox tb_4GAPN;
        private System.Windows.Forms.TextBox tb_4GPIN;
        private System.Windows.Forms.TextBox tb_ServerIP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tb_ServerPort;
        private System.Windows.Forms.TextBox lb_WifiPassWord;
        private System.Windows.Forms.TextBox lb_WifiName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Wireles_Edit;
        private System.Windows.Forms.Button btn_Wireless;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_ChangePWd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboWifiName;
        private System.Windows.Forms.Button btnRefreshWifi;
        private System.Windows.Forms.Button btnReadDeviceInfo;
        private System.Windows.Forms.Button button1;
    }
}

