using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Splash.IO.PORTS;
using System.Management;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;

namespace H6
{
    public partial class frmMain : Form
    {
        USB ezUSB = new USB();
        public static string AAA = string.Empty;
        public static string IDCode = string.Empty; //执法仪识别码
        public static int H6Init_Device_iRet = -1; //H6 初始化返回值
        public static int H8Init_Device_iRet = -1; //H8 初始化返回值
        public static int G8Init_Device_iRet = -1; //G8 初始化返回值
                    //设置密码
        public static string DevicePassword = string.Empty;
            //设备初始化返回值
           // int Init_Device_iRet = -1;
            //IDCode = "";
            //执法仪电量读取返回值
        private string DestinFolder = string.Empty;//目的文件夹
        private System.Threading.Thread thdAddFile; //创建一个线程
        private string str = "";
        FileStream FormerOpen;//实例化FileStream类
        FileStream ToFileOpen;//实例化FileStream类



        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;




        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //禁止Form窗口调整大小方法：
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //不能使用最大化窗口： 
            this.MaximizeBox = false;
            //this.Width = 940;
            //this.Height = 540;

            this.Location = new Point(
            (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
            (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
             );
            
            //MessageBox.Show(this.Width.ToString() + "X" + this.Height.ToString());

            //groupBox7
            //updateMessage(lb_StateInfo, "状态命令框" + gb_StatusCommand.Width.ToString()+"X"+gb_StatusCommand.Height.ToString());
            //updateMessage(lb_StateInfo, "无线信息" + gb_Wireless.Location.X.ToString() + "X" + gb_Wireless.Location.Y.ToString());

            //隐藏无线参数框
            gb_Wireless.Visible = false;
            //设定状态显示窗体大小
            gb_StatusCommand.Width = 458;
            gb_StatusCommand.Height = 475;
            //设定状态显示窗口位置
            //gb_StatusCommand.Location = new Point(453,11);
            gb_StatusCommand.Location = new Point(453, 90);
            //状态命令大小
            lb_StateInfo.Width = 440;
            lb_StateInfo.Height = 450;

            //LibBodycam.log
            //删除文件
            string FileName = Application.StartupPath + "\\" + "LibBodycam.log";
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            //不能使用最小化窗口： 
            this.MinimizeBox = false;
            //私版
            this.Text = "恒安警用执法记录仪管理软件,Ver:" + Application.ProductVersion; 
            //公版
            //this.Text = "执法仪上位机 V1.0.4";
            ezUSB.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 3));
            InitUI();

          
        }

        private void USBEventHandler(Object sender, EventArrivedEventArgs e)
        {
            /*

            this.SetText("" + "\r\n");
            this.SetText("*******************************************************" + "\r\n");
            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                this.SetText("USB插入时间：" + DateTime.Now + "\r\n");
                //init();
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                this.SetText("USB拔出时间：" + DateTime.Now + "\r\n");
                //init();
            }

            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                this.SetText("\tAntecedent：" + Device.Antecedent + "\r\n");
                this.SetText("\tDependent：" + Device.Dependent + "\r\n");
                AAA += Device.Dependent + ";" + Device.Antecedent;
                //init();
            }


            */
            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                //this.SetListText("USB设备插入时间：" + DateTime.Now + "\r\n");
                //init();
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                //this.SetListText("USB设备拔出时间：" + DateTime.Now + "\r\n");
                //init();
            }
            /*
            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                this.SetListText("\tAntecedent：" + Device.Antecedent + "\r\n");
                this.SetListText("\tDependent：" + Device.Dependent + "\r\n");
                AAA += Device.Dependent + ";" + Device.Antecedent;
                //init();
            }
            */
        }


        #region 更新信息
        /// <summary>
        /// 更新信息到listbox中
        /// </summary>
        /// <param name="listbox">listbox name</param>
        /// <param name="message">message</param>
        public static void updateMessage(ListBox listbox, string message)
        {
            if (listbox.Items.Count > 1000)
                listbox.Items.RemoveAt(0);

            string item = string.Empty;
            //listbox.Items.Add("");
            item = DateTime.Now.ToString("HH:mm:ss") + " " + @message;
            listbox.Items.Add(item);
            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }
        }
        #endregion


        /// <summary>
        /// 延時子程序
        /// </summary>
        /// <param name="interval">延時的時間，单位毫秒</param>
        private void Delay(double interval)
        {
            DateTime time = DateTime.Now;
            double span = interval * 10000;
            while (DateTime.Now.Ticks - time.Ticks < span)
            {
                Application.DoEvents();
            }

        }





        // 对 Windows 窗体控件进行线程安全调用
        private void SetText(String text)
        {
            if (this.tb_DevID.InvokeRequired)
            {
                this.tb_DevID.BeginInvoke(new Action<String>((msg) =>
                {
                    this.tb_DevID.AppendText(msg);
                }), text);
            }
            else
            {
                this.tb_DevID.AppendText(text);
            }
        }


        // 对 Windows 窗体控件进行线程安全调用
        private void SetListText(String text)
        {
            if (this.lb_StateInfo.InvokeRequired)
            {
                this.lb_StateInfo.BeginInvoke(new Action<String>((msg) =>
                {
                    //this.tb_DevID.AppendText(msg);
                    this.lb_StateInfo.Items.Add(msg);
                }), text);
            }
            else
            {
                //this.tb_DevID.AppendText(text);
                this.lb_StateInfo.Items.Add(text);
            }
        }


        public delegate void AddFile();//定度委托
        /// <summary>
        /// 在线程上执行委托
        /// </summary>
        public void SetAddFile()
        {
            this.Invoke(new AddFile(RunAddFile));//在线程上执行指定的委托
        }

        /// <summary>
        /// 对文件进行复制，并在复制完成后关闭线程
        /// </summary>
        public void RunAddFile()
        {
            str = tb_FilePath.Text;//记录源文件的路径
            str = "\\" + str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1);//获取源文件的名称

            //MessageBox.Show(DestinFolder + str);

            string ToFile = string.Empty;
            ToFile = DestinFolder + str;

            if (File.Exists(@tb_FilePath.Text))
            {
                CopyFile(tb_FilePath.Text, ToFile, 1024, pg_Updata);//复制文件
            }
            else
            {
                updateMessage(lb_StateInfo, "文件不存在.");
                //lb_StateInfo.Items.Add("");
                //lb_StateInfo.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " 文件不存在.");
            }

            thdAddFile.Abort();//关闭线程
        }

        /// <summary>
        /// 文件的复制
        /// </summary>
        /// <param FormerFile="string">源文件路径</param>
        /// <param toFile="string">目的文件路径</param> 
        /// <param SectSize="int">传输大小</param> 
        /// <param progressBar="ProgressBar">ProgressBar控件</param> 
        public void CopyFile(string FormerFile, string toFile, int SectSize, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;//设置进度栏的当前位置为0
            progressBar1.Minimum = 0;//设置进度栏的最小值为0
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();//关闭所有资源
            fileToCreate.Dispose();//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);//以写方式打开目的文件
            int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length / (double)SectSize));//根据一次传输的大小，计算传输的个数
            progressBar1.Maximum = max;//设置进度栏的最大值
            int FileSize;//要拷贝的文件的大小
            if (SectSize < FormerOpen.Length)//如果分段拷贝，即每次拷贝内容小于文件总长度
            {
                byte[] buffer = new byte[SectSize];//根据传输的大小，定义一个字节数组
                int copied = 0;//记录传输的大小
                int tem_n = 1;//设置进度栏中进度块的增加个数
                while (copied <= ((int)FormerOpen.Length - SectSize))//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);//向目的文件写入字节
                    ToFileOpen.Flush();//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;//使源文件和目的文件流的位置相同
                    copied += FileSize;//记录已拷贝的大小
                    progressBar1.Value = progressBar1.Value + tem_n;//增加进度栏的进度块
                }
                int left = (int)FormerOpen.Length - copied;//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);//读取剩余的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, left);//写入剩余的部分
                ToFileOpen.Flush();//清空缓存
            }
            else//如果整体拷贝，即每次拷贝内容大于文件总长度
            {
                byte[] buffer = new byte[FormerOpen.Length];//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);//读取源文件的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);//写放字节
                ToFileOpen.Flush();//清空缓存
            }
            FormerOpen.Close();//释放所有资源
            ToFileOpen.Close();//释放所有资源


            //progressBar1.Value = 0;//设置进度栏的当有位置为0
            //tb_FilePath.Clear();//清空文本
            //DestinFolder = string.Empty;
            //str = "";
            updateMessage(lb_StateInfo, "升级文件拷贝完成.....");
            updateMessage(lb_StateInfo, "请拔掉USB数据线，静待系统自动升级.....");

 

            /*
            if (MessageBox.Show("复制完成") == DialogResult.OK)//显示"复制完成"提示对话框
            {
                progressBar1.Value = 0;//设置进度栏的当有位置为0
                tb_FilePath.Clear();//清空文本
                DestinFolder=string.Empty;
                str = "";
            }
            */
        }


        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {

                                    updateMessage(lb_StateInfo, "U盘已插入，盘符为:" + drive.Name.ToString());
                                    this.btn_EcjetSD.Enabled = true;
                                    Thread.Sleep(1000);
                                    //DestinFolder = @"D:\";
                                    DestinFolder = drive.Name.ToString();
                                    ///lb_StateInfo.Items.Add(DestinFolder);
                                    /*
                                    if (!isCopyEnd)
                                    {
                                        isCopy = true;
                                        CopyFile(drive.Name + ConfigurationManager.AppSettings["sourcedir"].ToString());
                                    }
                                    */
                                    break;
                                }
                            }
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                            updateMessage(lb_StateInfo, "U盘已卸载！");
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                updateMessage(lb_StateInfo, "Error:" + ex.Message);

            }
            base.WndProc(ref m);
        }



        //4G 支付单记录仪操作
        public void WirelessInfo()
        {
            /*
            try
            {

                DevicePassword = tb_Password.Text;


                //获取无线信息
                //获取tf卡剩余容量
                string ssss = string.Empty;
                int sdsd = -1;
                //ZFYDLL_API_MC.ReadSDCapacity(ref ssss, DevicePassword,ref sdsd);
                ZFYDLL_API_MC.ReadWifiSSID(ref ssss, DevicePassword, ref sdsd);

                updateMessage(lb_StateInfo, "设备剩余容量：" + ssss);
                updateMessage(lb_StateInfo, "返回值：" + sdsd.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            */



            /*
                //WiFi 4G
        //传入WifiMode sPwd,传出 iRet，设置WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiMode(int WifiMode, string sPwd, ref int iRet);
        //传出sPwd,传出 WifiMode  iRet，读取WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiMode(ref int WifiMode, string sPwd, ref int iRet);
        //传入WifiSSID sPwd,传出iRet，设置wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiSSID(string WifiSSID, string sPwd, ref int iRet);
        //传出 sPwd,传出WifiSSID iRet，读取wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiSSID(ref string WifiSSID, string sPwd, ref int iRet);
        //传入APN  sPwd,传出iRet，设置4G网络APN，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Set4GAPN(string APN, string sPwd, ref int iRet);
        //传出sPwd,传出APN   iRet，读取4G网络APN，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Read4GAPN(ref string APN, string sPwd, ref int iRet);
        //传入PIN sPwd,传出iRet，设置4G网络PIN 码，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Set4GPIN(string PIN, string sPwd, ref int iRet);
        //传入sPwd,传出PIN  iRet，读取4G网络PIN 码，最长不超过4字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Read4GPIN(ref string PIN, string sPwd, ref int iRet);
        //传入IP sPwd,传出iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerIP(string IP, string sPwd, ref int iRet);
        //传入sPwd,传出IP iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerIP(ref string IP, string sPwd, ref int iRet);
        //传入PORT sPwd,传出iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerPort(string Port, string sPwd, ref int iRet);
        //传入sPwd,传出PORT iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerPort(ref string Port, string sPwd, ref int iRet);
        //传入sPwd,传出SDCapacity iRet，获取tf卡剩余容量
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadSDCapacity(ref string SDCapacity, string sPwd, ref int iRet);
             
             
             */


        }





        #region 按钮操作
        private void btn_CheckDev_Click(object sender, EventArgs e)
        {
            H6Init_Device_iRet = -1; //H6 初始化返回值
            H8Init_Device_iRet = -1; //H8 初始化返回值
            G8Init_Device_iRet = -1; //G8 初始化返回值
            //System.Diagnostics.Process.Start(@"C:\Windows\Fonts");
            //System.Diagnostics.Process.Start("C:\\window");
            try
            {
                //H6
                ZFYDLL_API_MC.Init_Device(IDCode, ref  H6Init_Device_iRet);
                //H8
                BODYCAMDLL_API_YZ.Init_Device("HACH8", ref  H8Init_Device_iRet);
                //G8
                ZFYDLL_API_MC_4G.Init_Device(IDCode, ref  H6Init_Device_iRet);
                //lb_StateInfo.Items.Add("H8=" + H8Init_Device_iRet.ToString());
                if (H6Init_Device_iRet == 1 || H8Init_Device_iRet ==1)
                {
 
                    updateMessage(lb_StateInfo, "初始化设备成功.");
                    this.btn_Logon.Enabled = true;
                    this.btn_CheckDev.Enabled = false;
                    this.tb_Password.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btn_Logon_Click(object sender, EventArgs e)
        {

            DevicePassword = tb_Password.Text;


           


            // H6电量返回参数
            int H6Battery_iRet = -1;
            //H6电池电量
            int H6BatteryLevel = -1;

            // H8电量返回参数
            int H8Battery_iRet = -1;
            //H8电池电量
            int H8BatteryLevel = -1;

            ZFYDLL_API_MC.ReadDeviceBatteryDumpEnergy(ref H6BatteryLevel, DevicePassword, ref  H6Battery_iRet);



            //updateMessage(lb_StateInfo, "H6BatteryLevel = " + H6BatteryLevel+" ;DevicePassword = " + DevicePassword+" ;H6Battery_iRet = " + H6Battery_iRet);

            BODYCAMDLL_API_YZ.ReadDeviceBatteryDumpEnergy(ref H8BatteryLevel, DevicePassword, ref  H8Battery_iRet);
               
            Delay(1000);
            
            //H6
            if (H6Battery_iRet == 1)
            {
                if (DevicePassword == "000000")
                {

                    LogonInitUI();
                    //初始化成功

                   // WirelessInfo();

                    /*
                    try
                    {

                        DevicePassword = tb_Password.Text;

                        //读取Wifi SSID
                        Byte[] WifiSSID = new Byte[100]; //新建字节数组
                        int iRet_ReadWifiSSID = -1;
                        ZFYDLL_API_MC.ReadWifiSSID(ref WifiSSID[0], DevicePassword, ref iRet_ReadWifiSSID);
                        lb_WifiName.Text = System.Text.Encoding.Default.GetString(WifiSSID, 0, WifiSSID.Length);    //将字节数组转换为字符串

                        //读取Wifi 密码
                        Byte[] WifiPSW = new Byte[100];
                        int iRet_ReadWifiPSW = -1;
                        ZFYDLL_API_MC.ReadWifiPSW(ref WifiPSW[0], DevicePassword, ref iRet_ReadWifiPSW);
                        lb_WifiPassWord.Text = System.Text.Encoding.Default.GetString(WifiPSW, 0, WifiPSW.Length);    //将字节数组转换为字符串

                        //读取Wifi模式 0:AP;1:STA
                        int mode =-1;
                        int iRet_ReadWifiMode = -1;
                        ZFYDLL_API_MC.ReadWifiMode(ref mode, DevicePassword, ref iRet_ReadWifiMode);
                        
                        MessageBox.Show(mode.ToString());
                       
                        if (mode == 0)
                        {
                            Lb_WifiMode.Text = "AP（无线接入）";
                        }
                        else if (mode == 1)
                        {
                            Lb_WifiMode.Text = "STA（无线终端）";
                        }


                        //获取服务器IP地址
                        Byte[] IP = new Byte[100];
                        int iRet_ReadServerIP = -1;
                        ZFYDLL_API_MC.ReadServerIP(ref IP[0], DevicePassword, ref iRet_ReadServerIP);
                        tb_ServerIP.Text = System.Text.Encoding.Default.GetString(IP, 0, IP.Length);    //将字节数组转换为字符串

                        //获取服务器端口
                        Byte[] Port = new Byte[100];
                        int iRet_ReadServerPort = -1;
                        ZFYDLL_API_MC.ReadServerPort(ref Port[0], DevicePassword, ref iRet_ReadServerPort);
                        tb_ServerPort.Text = System.Text.Encoding.Default.GetString(Port, 0, Port.Length);    //将字节数组转换为字符串

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }

                    */

                    updateMessage(lb_StateInfo, "H6 登录成功.");
                    this.btn_Logon.Enabled = false;
                    this.tb_Password.Enabled = false;
                    this.btn_exit.Enabled = true;
                    //////////////////////////////////////////////////////////////////////////////
                    //执法仪电量
                    this.tb_Battery.Text = H6BatteryLevel.ToString() + " %";

                    updateMessage(lb_StateInfo, "获取电量值 成功.");
                    /////////////////////////////////////////////////////////////////////////////
                    //执法仪分辨率宽值
                    int Resolution_Width = -1;
                    //执法仪分辨率宽值
                    int Resolution_Height = -1;
                    //返回值
                    int ReadDeviceResolution_iRet = -1;
                    //获取执法仪当前分辨率
                    Thread.Sleep(1000);
                    ZFYDLL_API_MC.ReadDeviceResolution(ref  Resolution_Width, ref  Resolution_Height, DevicePassword, ref ReadDeviceResolution_iRet);
                    if (ReadDeviceResolution_iRet == 1)
                    {
                        this.tb_Resolution.Text = Resolution_Width.ToString() + " X " + Resolution_Height.ToString();

                        updateMessage(lb_StateInfo, "获取视频分辨率参数 成功.");
                    }
                    /////////////////////////////////////////////////////////////////////////////
                    //执法仪信息读取返回值
                    int GetZFYInfo_iRet = -1;


                    ZFYDLL_API_MC.ZFY_INFO uuH6 = new ZFYDLL_API_MC.ZFY_INFO();//执法仪结构信息定义
                    ZFYDLL_API_MC.GetZFYInfo(ref uuH6, DevicePassword, ref GetZFYInfo_iRet);
                    if (GetZFYInfo_iRet == 1)
                    {
                        this.tb_DevID.Text = System.Text.Encoding.Default.GetString(uuH6.cSerial);
                        this.tb_DevID.Enabled = false;
                        this.tb_UserID.Text = System.Text.Encoding.Default.GetString(uuH6.userNo);
                        this.tb_UserID.Enabled = false;
                        this.tb_UserName.Text = System.Text.Encoding.Default.GetString(uuH6.userName);
                        this.tb_UserName.Enabled = false;
                        this.tb_UnitID.Text = System.Text.Encoding.Default.GetString(uuH6.unitNo);
                        this.tb_UnitID.Enabled = false;
                        this.tb_UnitName.Text = System.Text.Encoding.Default.GetString(uuH6.unitName);
                        this.tb_UnitName.Enabled = false;

                        updateMessage(lb_StateInfo, "获取执法仪本机信息 成功.");
                    }
                    int H6SyncDevTime_iRet = -1;
                    ZFYDLL_API_MC.SyncDevTime(DevicePassword, ref H6SyncDevTime_iRet);

                    if (H6SyncDevTime_iRet == 5)
                    {
                        updateMessage(lb_StateInfo, "自动同步设备时间成功.（" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")");
                    }
                    else
                    {
                        updateMessage(lb_StateInfo, "自动设备时间失败.");
                    }

                    this.btn_OK.Enabled = false;
                }
                else
                {
                   updateMessage(lb_StateInfo, "密码错误，登录失败.");
                }
            }
  
            //H8
            if (H8Battery_iRet == 1)
            {
                if (DevicePassword == "888888")
                {
                    LogonInitUI();
                    //初始化成功
                    updateMessage(lb_StateInfo, "H8 登录成功.");
                    this.btn_4G.Enabled = false;
                    this.btn_Logon.Enabled = false;
                    this.tb_Password.Enabled = false;
                    this.btn_exit.Enabled = true;
                    //////////////////////////////////////////////////////////////////////////////
                    //执法仪电量
                    this.tb_Battery.Text = H8BatteryLevel.ToString() + " %";
                    updateMessage(lb_StateInfo, "获取电量值 成功.");
                    /////////////////////////////////////////////////////////////////////////////
                    //执法仪分辨率宽值
                    int Resolution_Width = -1;
                    //执法仪分辨率宽值
                    int Resolution_Height = -1;
                    //返回值
                    int ReadDeviceResolution_iRet = -1;
                    //获取执法仪当前分辨率
                    BODYCAMDLL_API_YZ.ReadDeviceResolution(ref  Resolution_Width, ref  Resolution_Height, DevicePassword, ref ReadDeviceResolution_iRet);
                    if (ReadDeviceResolution_iRet == 1)
                    {
                        this.tb_Resolution.Text = Resolution_Width.ToString() + " X " + Resolution_Height.ToString();
                        updateMessage(lb_StateInfo, "获取视频分辨率参数 成功.");
                    }
                    /////////////////////////////////////////////////////////////////////////////
                    //执法仪信息读取返回值
                    int GetZFYInfo_iRet = -1;

                    BODYCAMDLL_API_YZ.ZFY_INFO uuH8 = new BODYCAMDLL_API_YZ.ZFY_INFO();//执法仪结构信息定义
                    BODYCAMDLL_API_YZ.GetZFYInfo(ref uuH8, DevicePassword, ref GetZFYInfo_iRet);
                    if (GetZFYInfo_iRet == 1)
                    {
                        this.tb_DevID.Text = System.Text.Encoding.Default.GetString(uuH8.cSerial);
                        this.tb_DevID.Enabled = false;
                        this.tb_UserID.Text = System.Text.Encoding.Default.GetString(uuH8.userNo);
                        this.tb_UserID.Enabled = false;
                        this.tb_UserName.Text = System.Text.Encoding.Default.GetString(uuH8.userName);
                        this.tb_UserName.Enabled = false;
                        this.tb_UnitID.Text = System.Text.Encoding.Default.GetString(uuH8.unitNo);
                        this.tb_UnitID.Enabled = false;
                        this.tb_UnitName.Text = System.Text.Encoding.Default.GetString(uuH8.unitName);
                        this.tb_UnitName.Enabled = false;

                        updateMessage(lb_StateInfo, "获取执法仪本机信息 成功.");
                    }
                    int H8SyncDevTime_iRet = -1;
                    BODYCAMDLL_API_YZ.SyncDevTime(DevicePassword, ref H8SyncDevTime_iRet);

                    if (H8SyncDevTime_iRet == 5)
                    {
                        updateMessage(lb_StateInfo, "自动同步设备时间成功.（"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+")");
                    }
                    else
                    {
                        updateMessage(lb_StateInfo, "自动同步设备时间失败.");
                    }
                    this.btn_OK.Enabled = false;
                }
            }

            bool aa = H8Battery_iRet == 1 && DevicePassword == "888888";//H8登录成功
            aa = H6Battery_iRet == 1 || aa;//H8或H6登录成功

            if (!aa)
            {
                updateMessage(lb_StateInfo, "密码错误，登录失败.");
            }
  
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.btn_Edit.Text == "编辑")
            {
                this.btn_Edit.Enabled = true;
                this.btn_Edit.Text = "取消";
                this.tb_DevID.Enabled = false;
                this.tb_UserID.Enabled = true;
                this.tb_UserName.Enabled = true;
                this.tb_UnitID.Enabled = true;
                this.tb_UnitName.Enabled = true;
                this.btn_OK.Enabled = true;
            }
            else if(this.btn_Edit.Text == "取消")
            {
                this.tb_DevID.Enabled = false;
                this.tb_UserID.Enabled = false;
                this.tb_UserName.Enabled = false;
                this.tb_UnitID.Enabled = false;
                this.tb_UnitName.Enabled = false;
                this.btn_Edit.Text = "编辑";
                this.btn_OK.Enabled = false;
            }




        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.tb_DevID.Enabled = false;
            this.tb_UserID.Enabled = false;
            this.tb_UserName.Enabled = false;
            this.tb_UnitID.Enabled = false;
            this.tb_UnitName.Enabled = false;
            this.btn_OK.Enabled = false;
            this.btn_Edit.Text = "编辑";


            ZFYDLL_API_MC.Init_Device(IDCode, ref  H6Init_Device_iRet);
            BODYCAMDLL_API_YZ.Init_Device("HACH8", ref  H8Init_Device_iRet);

            //lb_StateInfo.Items.Add("H6 = " + H6Init_Device_iRet.ToString() + " ; " + "H8 = " + H8Init_Device_iRet.ToString());

            try
            {     //设置密码
                string DevicePassword = tb_Password.Text;
                //H6
                if (H6Init_Device_iRet == 1)
                {
                    int H6WriteZFYInfo_iRet = -1;
                    // public static extern int WriteZFYInfo(ZFY_INFO info, string sPwd, ref int iRet);
                    ZFYDLL_API_MC.ZFY_INFO ddH6 = new ZFYDLL_API_MC.ZFY_INFO();//执法仪结构信息定义
                    ddH6.cSerial = Encoding.Default.GetBytes(this.tb_DevID.Text.PadRight(8, '\0').ToArray());
                    ddH6.userNo = Encoding.Default.GetBytes(this.tb_UserID.Text.PadRight(7, '\0').ToArray());
                    ddH6.userName = Encoding.Default.GetBytes(this.tb_UserName.Text.PadRight(33, '\0').ToArray());
                    ddH6.unitNo = Encoding.Default.GetBytes(this.tb_UnitID.Text.PadRight(13, '\0').ToArray());
                    ddH6.unitName = Encoding.Default.GetBytes(this.tb_UnitName.Text.PadRight(33, '\0').ToArray());
                    ZFYDLL_API_MC.WriteZFYInfo(ref ddH6, DevicePassword, ref H6WriteZFYInfo_iRet);

                    updateMessage(lb_StateInfo, "向执法仪写入信息成功.");
                }
                //H8
                if (H8Init_Device_iRet == 1)
                {
                    int H8WriteZFYInfo_iRet = -1;
                    // public static extern int WriteZFYInfo(ZFY_INFO info, string sPwd, ref int iRet);
                    BODYCAMDLL_API_YZ.ZFY_INFO ddH8 = new BODYCAMDLL_API_YZ.ZFY_INFO();//执法仪结构信息定义
                    ddH8.cSerial = Encoding.Default.GetBytes(this.tb_DevID.Text.PadRight(8, '\0').ToArray());
                    ddH8.userNo = Encoding.Default.GetBytes(this.tb_UserID.Text.PadRight(7, '\0').ToArray());
                    ddH8.userName = Encoding.Default.GetBytes(this.tb_UserName.Text.PadRight(33, '\0').ToArray());
                    ddH8.unitNo = Encoding.Default.GetBytes(this.tb_UnitID.Text.PadRight(13, '\0').ToArray());
                    ddH8.unitName = Encoding.Default.GetBytes(this.tb_UnitName.Text.PadRight(33, '\0').ToArray());
                    BODYCAMDLL_API_YZ.WriteZFYInfo(ref ddH8, DevicePassword, ref H8WriteZFYInfo_iRet);

                    updateMessage(lb_StateInfo, "向执法仪写入信息成功.");
                }
            
            }
            catch (Exception ex)
            {

                updateMessage(lb_StateInfo, "Error: = " + ex.Message);
            }

        }

        private void btn_Format_Click(object sender, EventArgs e)
        {

        }

        private void btn_SyncDevTime_Click(object sender, EventArgs e)
        {
            DevicePassword = tb_Password.Text;
            int H6SyncDevTime_iRet=-1;
            ZFYDLL_API_MC.Init_Device(IDCode, ref  H6Init_Device_iRet);
            int H8SyncDevTime_iRet = -1;
            BODYCAMDLL_API_YZ.Init_Device("HACH8", ref  H8Init_Device_iRet);
            if (H6Init_Device_iRet == 1)
            {
                ZFYDLL_API_MC.SyncDevTime(DevicePassword, ref H6SyncDevTime_iRet);
               
                if (H6SyncDevTime_iRet == 5)
                {
                    updateMessage(lb_StateInfo, "手动同步设备时间成功.（" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")");
                }
                else
                {
                    updateMessage(lb_StateInfo, "手动同步设备时间失败.");
                }
            }
            if (H8Init_Device_iRet == 1)
            {
                BODYCAMDLL_API_YZ.SyncDevTime(DevicePassword, ref H8SyncDevTime_iRet);

                if (H8SyncDevTime_iRet == 5)
                {
                    updateMessage(lb_StateInfo, "手动同步设备时间成功.（" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")");
                }
                else
                {
                    updateMessage(lb_StateInfo, "手动同步设备时间失败.");
                }
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            //string UserPwd = this.tb_NewPassword.Text;
            DevicePassword = tb_Password.Text;
            //int SetUserPassWord_iRet =-1;


          // ZFYDLL_API_MC.SetUserPassWord(UserPwd, DevicePassword, ref SetUserPassWord_iRet);

         //  lb_StateInfo.Items.Add("");
           //lb_StateInfo.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " SetUserPassWord_iRet = " + SetUserPassWord_iRet.ToString());

           //updateMessage(lb_StateInfo, "向执法仪写入信息成功.");

        }

        private void btn_SetMSDC_Click(object sender, EventArgs e)
        {


             //DestinFolder = string.Empty;
            //this.btn_Format.Enabled = true;

            int H6SetMSDC_iRet = -1;
            ZFYDLL_API_MC.Init_Device(IDCode, ref  H6Init_Device_iRet);

            int H8SetMSDC_iRet = -1;
            BODYCAMDLL_API_YZ.Init_Device("HACH8", ref  H8Init_Device_iRet);
            if (H6Init_Device_iRet == 1)
            {

                ZFYDLL_API_MC.SetMSDC(DevicePassword, ref  H6SetMSDC_iRet);
                //MessageBox.Show(SetMSDC_iRet.ToString());
                if (H6SetMSDC_iRet == 7)
                {
                    this.btn_Edit.Enabled = false;
                    //this.btn_ChangePassword.Enabled = false;
                    this.btn_SyncDevTime.Enabled = false;
                    //this.tb_NewPassword.Enabled = false;
                    //this.cb_FileType.Enabled = true; 
                    this.btn_FilePathChose.Enabled = true;
                    this.btn_UpdataFile.Enabled = true;
                    this.btn_SetMSDC.Enabled = false;
                    this.btn_4G.Enabled = false;
                    updateMessage(lb_StateInfo, "执法仪已进入U盘模式.");
                }
                else
                {
                    updateMessage(lb_StateInfo, "执法仪进入U盘模式失败.");
                }
              

            }

            if (H8Init_Device_iRet == 1)
            {

                BODYCAMDLL_API_YZ.SetMSDC(DevicePassword, ref  H8SetMSDC_iRet);
                //MessageBox.Show(SetMSDC_iRet.ToString());
                if (H8SetMSDC_iRet == 7)
                {
                    this.btn_Edit.Enabled = false;
                    //this.btn_ChangePassword.Enabled = false;
                    this.btn_SyncDevTime.Enabled = false;
                    //this.tb_NewPassword.Enabled = false;
                    //this.cb_FileType.Enabled = true; 
                    this.btn_FilePathChose.Enabled = true;
                    this.btn_UpdataFile.Enabled = true;
                    this.btn_SetMSDC.Enabled = false;
                   
                    updateMessage(lb_StateInfo, "执法仪已进入U盘模式.");
                }
                else
                {
                    updateMessage(lb_StateInfo, "执法仪进入U盘模式失败.");
                }

            }


        }

        private void btn_FilePathChose_Click(object sender, EventArgs e)
        {
            //pg_Updata.Value = 0;//设置进度栏的当有位置为0
            //tb_FilePath.Clear();//清空文本
            //DestinFolder = string.Empty;
            //str = "";
/*
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
            }

*/



             OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "升级文件(*.Bin)|*.Bin";
            if (ofg.ShowDialog() == DialogResult.OK)//打开文件对话框
            {
                tb_FilePath.Text = ofg.FileName;//获取源文件的路径
            }
        }

        private void btn_UpdataFile_Click(object sender, EventArgs e)
        {

            str = tb_FilePath.Text;//记录源文件的路径
            str = "\\" + str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1);//获取源文件的名称
            
            if (str != "")
            {
                //MessageBox.Show(str);
                thdAddFile = new Thread(new ThreadStart(SetAddFile));//创建一个线程
                thdAddFile.Start();//执行当前线程
            }
            else
            {
                updateMessage(lb_StateInfo, "未选择目的文件，当前不能升级！");
            }


        }
        //关闭按钮
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ezUSB.RemoveUSBEventWatcher();
        }

        //UI初始化设置
        public void InitUI()
        {
            //按钮
            this.btn_Logon.Enabled = false;
            this.btn_exit.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_OK.Enabled = false;
            this.btn_EcjetSD.Enabled = false;
            this.btn_4G.Enabled = false;
           //this.btn_4G.Enabled = true;
            //this.btn_ChangePassword.Enabled = false;
            this.btn_FilePathChose.Enabled = false;
            //this.btn_Format.Enabled = false;
            this.btn_OK.Enabled = false;
            this.btn_SyncDevTime.Enabled = false;
            this.btn_SetMSDC.Enabled = false;
            //this.btn_UpdataFile.Enabled = false;
            //文本编辑框
            this.tb_Password.Enabled = false;
            this.tb_FilePath.Enabled = false;
            //this.tb_NewPassword.Enabled = false;
            //this.tb_SDCapacity.Enabled = false;
            this.tb_UnitID.Enabled = false;
            this.tb_UnitName.Enabled = false;
            this.tb_UserID.Enabled = false;
            this.tb_UserName.Enabled = false;
            this.tb_DevID.Enabled = false;

            this.pg_Updata.Enabled = false;
            this.btn_UpdataFile.Enabled = false;
        }


        //登陆后UI初始化设置
        public void LogonInitUI()
        {
            //按钮
            this.btn_4G.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_OK.Enabled = true;
            //this.btn_ChangePassword.Enabled = true;
            this.btn_FilePathChose.Enabled = false;
            //this.btn_Format.Enabled = false;
            this.btn_OK.Enabled = true;
            this.btn_SyncDevTime.Enabled = true;
            this.btn_SetMSDC.Enabled = true;
            //this.btn_UpdataFile.Enabled = true;
            //文本编辑框
            this.tb_FilePath.Enabled = true;
            //this.tb_NewPassword.Enabled = true;
            //this.tb_SDCapacity.Enabled = true;
            this.tb_UnitID.Enabled = true;
            this.tb_UnitName.Enabled = true;
            this.tb_UserID.Enabled = true;
            this.tb_UserName.Enabled = true;
            this.tb_DevID.Enabled = true;

            //this.cb_FileType.Enabled = false; 

            this.pg_Updata.Enabled = true;
            //this.cb_FileType.Text = "FAT32";
        }


        #endregion

        private void btn_exit_Click(object sender, EventArgs e)
        {

                updateMessage(lb_StateInfo, "恢复初始状态.");
                InitUI();

                this.btn_CheckDev.Enabled = true;
                this.tb_Password.Text = "";
                this.tb_Resolution.Text = "";
                this.tb_Battery.Text = "";
                this.tb_DevID.Text = "";
                this.tb_UnitID.Text = "";
                this.tb_UserID.Text = "";
                this.tb_UnitName.Text = "";
                this.tb_UserName.Text = "";
                //this.cb_FileType.Text = "";
                //this.tb_NewPassword.Text = "";
                this.tb_FilePath.Text = "";

                H6Init_Device_iRet = -1; //H6 初始化返回值
                H8Init_Device_iRet = -1; //H8 初始化返回值
                    //设置密码
                pg_Updata.Value = 0;//设置进度栏的当有位置为0
                tb_FilePath.Clear();//清空文本
                DestinFolder = string.Empty;
                str = "";


                //4G
                gb_Wireless.Visible = false;
                //设定状态显示窗体大小
                gb_StatusCommand.Width = 458;
                gb_StatusCommand.Height = 475;
                //设定状态显示窗口位置
                gb_StatusCommand.Location = new Point(453, 11);
                //状态命令大小
                lb_StateInfo.Width = 440;
                lb_StateInfo.Height = 450;

                //内容清空
                lb_WifiName.Text = "";
                lb_WifiPassWord.Text = "";
                Lb_WifiMode.Text = "";
                tb_ServerIP.Text = "";
                tb_ServerPort.Text = "";
                btn_Wireless.Text = "";

        }

        private void btn_EcjetSD_Click(object sender, EventArgs e)
        {
            if (DestinFolder != "")
            {
                //lb_StateInfo.Items.Add(@DestinFolder);
                System.Diagnostics.Process.Start( @DestinFolder);
            }
            else
            {
                updateMessage(lb_StateInfo, "打开磁盘无效.");
            }
        }

        private void btn_Wireless_Click(object sender, EventArgs e)
        {
            //不可编辑状态
            lb_WifiName.Enabled = false;
            lb_WifiPassWord.Enabled = false;
            Lb_WifiMode.Enabled = false;
            tb_ServerIP.Enabled = false;
            tb_ServerPort.Enabled = false;

            this.btn_Wireless.Enabled = false;


             DevicePassword = tb_Password.Text;
             byte[] IP = new byte[50];
             int iRet_ReadServerIP = -1;
             IP = Encoding.Default.GetBytes(this.tb_ServerIP.Text.PadRight(50, '\0').ToArray());
             ZFYDLL_API_MC.SetServerIP(IP, DevicePassword, ref iRet_ReadServerIP);
             
             byte[] Port = new byte[50];
             int iRet_SetServerPort =-1;
             Port = Encoding.Default.GetBytes(this.tb_ServerPort.Text.PadRight(50, '\0').ToArray());
             ZFYDLL_API_MC.SetServerPort(Port, DevicePassword, ref iRet_SetServerPort);

             byte[] WifiSSID = new byte[50];
             int iRet_SetWifiSSID = -1;
            // WifiSSID = Encoding.Default.GetBytes(this.lb_WifiName.Text.PadRight(50, '\0').ToArray());
             WifiSSID = Encoding.Default.GetBytes(this.comboWifiName.Text.PadRight(50, '\0').ToArray());
             ZFYDLL_API_MC.SetWifiSSID(WifiSSID, DevicePassword, ref iRet_SetWifiSSID);

             byte[] WifiPSW = new byte[50];
             int iRet_SetWifiPSW = -1;
             WifiPSW = Encoding.Default.GetBytes(this.lb_WifiPassWord.Text.PadRight(50, '\0').ToArray());
             ZFYDLL_API_MC.SetWifiPSW(WifiPSW, DevicePassword, ref iRet_SetWifiPSW);


             //设定WiFi模式,0;AP；1;STA
             string WiFiMode = this.Lb_WifiMode.Text;
             int iRet_SetWifiMode = -1;
             int mode = -1;
             if (WiFiMode.Contains("AP"))
             {
                 mode = 0;
             }
             else if (WiFiMode.Contains("STA"))
             {
                 mode = 1;
             }
             ZFYDLL_API_MC.SetWifiMode(mode, DevicePassword, ref iRet_SetWifiMode);
             updateMessage(lb_StateInfo, "无线通信参数已设定 ");
        }

        private void btn_4G_Click(object sender, EventArgs e)
        {
            int clickTimes; //按下次数
            //获取按下次数
            object tag = this.btn_4G.Tag;
            if (tag == null)
            {
                clickTimes = 0;
            }
            else
            {
                clickTimes = Convert.ToInt32(tag);
            }
            //增加并记录按下次数
            this.btn_4G.Tag = ++clickTimes;
            if ((clickTimes % 2) == 1)
            {
                //MessageBox.Show("奇数次");
                //执行你的事情1
                //隐藏无线参数框
                gb_Wireless.Visible = true;
                //设定状态显示窗体大小
                gb_StatusCommand.Width = 458;
                gb_StatusCommand.Height = 293;
                //设定状态显示窗口位置
                gb_StatusCommand.Location = new Point(453, 274);
                //状态命令大小
                lb_StateInfo.Width = 440;
                lb_StateInfo.Height = 278;

                //不可编辑状态
                lb_WifiName.Enabled = false;
                lb_WifiPassWord.Enabled = false;
                Lb_WifiMode.Enabled = false;
                tb_ServerIP.Enabled = false;
                tb_ServerPort.Enabled = false;
                btn_Wireless.Enabled = false;
                btnRefreshWifi.Enabled = false;
                comboWifiName.Enabled = false;

                //auto refresh wifi 
                wifi.EnumerateAvailableNetwork(comboWifiName, lb_StateInfo);

                try
                {

                    DevicePassword = tb_Password.Text;

                    //读取Wifi SSID
                    Byte[] WifiSSID = new Byte[20]; //新建字节数组
                    int iRet_ReadWifiSSID = -1;
                    ZFYDLL_API_MC.ReadWifiSSID(ref WifiSSID[0], DevicePassword, ref iRet_ReadWifiSSID);
                    lb_WifiName.Text = System.Text.Encoding.Default.GetString(WifiSSID, 0, WifiSSID.Length);    //将字节数组转换为字符串

                    //读取Wifi 密码
                    Byte[] WifiPSW = new Byte[20];
                    int iRet_ReadWifiPSW = -1;
                    ZFYDLL_API_MC.ReadWifiPSW(ref WifiPSW[0], DevicePassword, ref iRet_ReadWifiPSW);
                    lb_WifiPassWord.Text = System.Text.Encoding.Default.GetString(WifiPSW, 0, WifiPSW.Length);    //将字节数组转换为字符串

                    //读取Wifi模式 0:AP;1:STA
                    int mode = -1;
                    int iRet_ReadWifiMode = -1;
                    ZFYDLL_API_MC.ReadWifiMode(ref mode, DevicePassword, ref iRet_ReadWifiMode);

                    //MessageBox.Show(mode.ToString());
                    if (mode == 0)
                    {
                        Lb_WifiMode.Text = "AP（无线接入）";
                    }
                    else if (mode == 1)
                    {
                        Lb_WifiMode.Text = "STA（无线终端）";
                    }


                    //获取服务器IP地址
                    Byte[] IP = new Byte[16];
                    int iRet_ReadServerIP = -1;
                    ZFYDLL_API_MC.ReadServerIP(ref IP[0], DevicePassword, ref iRet_ReadServerIP);
                    tb_ServerIP.Text = System.Text.Encoding.Default.GetString(IP, 0, IP.Length);    //将字节数组转换为字符串

                    //获取服务器端口
                    Byte[] Port = new Byte[6];
                    int iRet_ReadServerPort = -1;
                    ZFYDLL_API_MC.ReadServerPort(ref Port[0], DevicePassword, ref iRet_ReadServerPort);
                    tb_ServerPort.Text = System.Text.Encoding.Default.GetString(Port, 0, Port.Length);    //将字节数组转换为字符串
                    updateMessage(lb_StateInfo, "获取无线通信参数");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }


 
            }
            else
            {
                //MessageBox.Show("偶数次");
                //执行你的事情2
                //MessageBox.Show("偶数次");
                //隐藏无线参数框
                gb_Wireless.Visible = false;
                //设定状态显示窗体大小
                gb_StatusCommand.Width = 458;
                gb_StatusCommand.Height = 475;
                //设定状态显示窗口位置
                //gb_StatusCommand.Location = new Point(453, 11);
                gb_StatusCommand.Location = new Point(453, 90);
                //状态命令大小
                lb_StateInfo.Width = 440;
                lb_StateInfo.Height = 450;

                /*
                lb_WifiName.Text = "";
                lb_WifiPassWord.Text = "";
                Lb_WifiMode.Text = "";
                tb_ServerIP.Text = "";
                tb_ServerPort.Text = "";
                */
            }



        }

        private void btn_Wireles_Edit_Click(object sender, EventArgs e)
        {
            if (this.btn_Wireles_Edit.Text == "编辑")
            {
                lb_WifiName.Enabled = true;
                lb_WifiPassWord.Enabled = true;
                Lb_WifiMode.Enabled = true;
                tb_ServerIP.Enabled = true;
                tb_ServerPort.Enabled = true;
                this.btn_Wireles_Edit.Text = "取消";
                comboWifiName.Enabled = true;
                btnRefreshWifi.Enabled = true;

                btn_Wireless.Enabled = true;
            }
            else if (this.btn_Wireles_Edit.Text == "取消")
            {
                lb_WifiName.Enabled = false;
                lb_WifiPassWord.Enabled = false;
                Lb_WifiMode.Enabled = false;
                tb_ServerIP.Enabled = false;
                tb_ServerPort.Enabled = false;
                this.btn_Wireles_Edit.Text = "编辑";
                comboWifiName.Enabled = false;
                btn_Wireless.Enabled = false;
                btnRefreshWifi.Enabled = true;
            }




        }

        private void btnRefreshWifi_Click(object sender, EventArgs e)
        {
            wifi.EnumerateAvailableNetwork(comboWifiName, lb_StateInfo);
        }


    }
}
