using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace H6
{
    #region 执法仪SDK
    /// <summary>
    /// 恒安单机执法仪H8,忆志方案,"LibBodycam.dll"
    /// </summary>
    class BODYCAMDLL_API_YZ
    {
        //执法仪信息结构体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ZFY_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] cSerial;               /*执法记录仪产品序号，不可为空*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] userNo;                /*执法记录仪使用者警号，不可为空*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] userName;              /*执法记录仪使用者姓名，管理系统使用警号关联时可为空*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public byte[] unitNo;                /*执法记录仪使用者单位编号，管理系统使用警号关联时可为空*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] unitName;              /*执法记录仪使用者单位名称，管理系统使用警号关联时可为空*/
        };

        /********************************************************************************************************
       *
       *  以下为公安部的相关函数，非公安部的采集站可以不用
       *
       *********************************************************************************************************/

        ////初始化连接
        [DllImport("LibBodycam.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Init_Device(string IDCode, ref int iRet);
        //获取生产厂代码及产品型号代码
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetIDCode(ref IntPtr IDCode, ref int iRet);
        // 设置为移动磁盘模式
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMSDC(string sPwd, ref int iRet);
        // 同步执法记录仪时间
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SyncDevTime(string sPwd, ref int iRet);
        //读取当前录像分辨率
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceResolution(ref int Width, ref int Height, string sPwd, ref int iRet);
        //读取电量 百分比
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceBatteryDumpEnergy(ref int Battery, string sPwd, ref int iRet);
        //获取记录仪信息
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);
        //写入记录仪信息
        [DllImport("LibBodycam.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);


    }

    /// <summary>
    /// 恒安单机执法仪H6,茂诚方案,"zfyMC.dll"
    /// </summary>
    class ZFYDLL_API_MC
    {
        //执法仪信息结构体
        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        [StructLayout(LayoutKind.Sequential,CharSet =CharSet.Ansi, Pack = 1)]
        public struct ZFY_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst =8)]
            public byte[] cSerial;               //执法记录仪产品序号，不可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] userNo;                //执法记录仪使用者警号，不可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] userName;              //执法记录仪使用者姓名，管理系统使用警号关联时可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public byte[] unitNo;                //执法记录仪使用者单位编号，管理系统使用警号关联时可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] unitName;              //执法记录仪使用者单位名称，管理系统使用警号关联时可为空
      
        
        };


        /********************************************************************************************************
        *
        *  以下为公安部的相关函数，非公安部的采集站可以不用
        *
        *********************************************************************************************************/

        //取厂家IDCODE，标识设备
        [DllImport("zfyMC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetIDCode(ref string IDCode, ref int iRet);
        //初始化设备连接
        [DllImport("zfyMC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Init_Device(string IDCode, ref int iRet);
        // 设置为移动磁盘模式
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMSDC(string sPwd, ref int iRet);
        // 同步执法记录仪时间
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SyncDevTime(string sPwd, ref int iRet);
        //读取当前录像分辨率
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceResolution(ref int Width, ref int Height, string sPwd, ref int iRet);
        //读取电量 百分比
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceBatteryDumpEnergy(ref int Battery, string sPwd, ref int iRet);
        //获取记录仪信息
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);
        //写入记录仪信息
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);
        //释放设备
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnInit_Device(ref int iRet);
         //传入UserPwd sPwd,传出 iRet，设置用户密码
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetUserPassWord(string UserPwd, string sPwd, ref int iRet);
        //传入AdminPwd sPwd,传出 iRet，设置管理员密码
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetAdminPassWord(string AdminPwd, string sPwd, ref int iRet);





        //WiFi 4G
        //传入WifiMode sPwd,传出 iRet，设置WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiMode(int WifiMode, string sPwd, ref int iRet);
        //传出sPwd,传出 WifiMode  iRet，读取WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiMode(ref int WifiMode, string sPwd, ref int iRet);


        //传入WifiSSID sPwd,传出iRet，设置wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiSSID(byte[] WifiSSID, string sPwd, ref int iRet);
        //传出 sPwd,传出WifiSSID iRet，读取wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int ReadWifiSSID(ref string WifiSSID, string sPwd, ref int iRet);
        public static extern int ReadWifiSSID(ref byte WifiSSID, string sPwd, ref int iRet);

        //传入 WifiPSW sPwd,传出iRet，设置wifi密码，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiPSW(byte[] WifiPSW, string sPwd, ref int iRet);
        //传入  sPwd,传出WifiPSW iRet，读取wifi密码，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiPSW(ref byte WifiPSW, string sPwd, ref int iRet);







        //传入APN  sPwd,传出iRet，设置4G网络APN，最长不超过32字节，为空则默认不启用
        //[DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Set4GAPN(string APN, string sPwd, ref int iRet);
        //传出sPwd,传出APN   iRet，读取4G网络APN，最长不超过32字节，为空则默认不启用
        //[DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Read4GAPN(ref byte APN, string sPwd, ref int iRet);

        //传入PIN sPwd,传出iRet，设置4G网络PIN 码，最长不超过32字节，为空则默认不启用
        //[DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Set4GPIN(string PIN, string sPwd, ref int iRet);
        //传入sPwd,传出PIN  iRet，读取4G网络PIN 码，最长不超过4字节，为空则默认不启用
        //[DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Read4GPIN(ref byte PIN, string sPwd, ref int iRet);

        //ref ZFY_INFO info



        //传入IP sPwd,传出iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerIP(byte[] IP, string sPwd, ref int iRet);
        //public static extern int SetServerIP(byte IP, string sPwd, ref int iRet);
        //传入sPwd,传出IP iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerIP(ref byte IP, string sPwd, ref int iRet);

        //传入PORT sPwd,传出iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerPort(byte[] Port, string sPwd, ref int iRet);
        //传入sPwd,传出PORT iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerPort(ref byte Port, string sPwd, ref int iRet);

        //传入sPwd,传出SDCapacity iRet，获取tf卡剩余容量
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadSDCapacity(ref byte SDCapacity, string sPwd, ref int iRet);

    }

    /// <summary>
    /// 恒安4G执法仪G8,茂诚方案,"zfyMC.dll"
    /// </summary>
    class ZFYDLL_API_MC_4G
    {
        //执法仪信息结构体
        //[StructLayout(LayoutKind.Sequential, Pack = 1)]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ZFY_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] cSerial;               //执法记录仪产品序号，不可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] userNo;                //执法记录仪使用者警号，不可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] userName;              //执法记录仪使用者姓名，管理系统使用警号关联时可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public byte[] unitNo;                //执法记录仪使用者单位编号，管理系统使用警号关联时可为空
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] unitName;              //执法记录仪使用者单位名称，管理系统使用警号关联时可为空


        };

        /********************************************************************************************************
        *
        *  以下为公安部的相关函数，非公安部的采集站可以不用
        *
        *********************************************************************************************************/

        //取厂家IDCODE，标识设备
        [DllImport("zfyMC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetIDCode(ref string IDCode, ref int iRet);
        //初始化设备连接
        [DllImport("zfyMC.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Init_Device(string IDCode, ref int iRet);
        //释放设备
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnInit_Device(ref int iRet);
        //获取记录仪信息
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);
        //写入记录仪信息
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteZFYInfo(ref ZFY_INFO info, string sPwd, ref int iRet);
        // 同步执法记录仪时间
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SyncDevTime(string sPwd, ref int iRet);
        // 设置为移动磁盘模式
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMSDC(string sPwd, ref int iRet);
        //读取当前录像分辨率
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceResolution(ref int Width, ref int Height, string sPwd, ref int iRet);
        //读取电量 百分比
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceBatteryDumpEnergy(ref int Battery, string sPwd, ref int iRet);
        
        //传入UserPwd sPwd,传出 iRet，设置用户密码
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetUserPassWord(string UserPwd, string sPwd, ref int iRet);
        //传入AdminPwd sPwd,传出 iRet，设置管理员密码
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetAdminPassWord(string AdminPwd, string sPwd, ref int iRet);

        //WiFi 4G
        //传入WifiMode sPwd,传出 iRet，设置WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiMode(int WifiMode,string sPwd,ref int iRet);
        //传出sPwd,传出 WifiMode  iRet，读取WIFI工作模式，WifiMode=1，为ap，WifiMode=2，为sta
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
         public static extern int ReadWifiMode(ref int WifiMode,string sPwd,ref int iRet);
        //传入WifiSSID sPwd,传出iRet，设置wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiSSID(string WifiSSID,string sPwd,ref int iRet);
        //传出 sPwd,传出WifiSSID iRet，读取wifi的SSID，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiSSID(ref string WifiSSID,string sPwd,ref int iRet);
        //传入 WifiPSW sPwd,传出iRet，设置wifi密码，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWifiPSW(string WifiPSW, string sPwd, ref int iRet);
        //传入  sPwd,传出WifiPSW iRet，读取wifi密码，最长不超过32字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadWifiPSW(ref string WifiPSW, string sPwd, ref int iRet);
        //传入APN  sPwd,传出iRet，设置4G网络APN，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Set4GAPN(string APN,string sPwd,ref int iRet);
        //传出sPwd,传出APN   iRet，读取4G网络APN，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Read4GAPN(ref string APN,string sPwd,ref int iRet);
        //传入PIN sPwd,传出iRet，设置4G网络PIN 码，最长不超过32字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Set4GPIN(string PIN,string sPwd,ref int iRet);
        //传入sPwd,传出PIN  iRet，读取4G网络PIN 码，最长不超过4字节，为空则默认不启用
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Read4GPIN(ref string PIN,string sPwd,ref int iRet);
        //传入IP sPwd,传出iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerIP(string IP,string sPwd,ref int iRet);
        //传入sPwd,传出IP iRet，读取设备上传服务器IP，最长不超过20字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerIP(ref string IP,string sPwd,ref int iRet);
        //传入PORT sPwd,传出iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetServerPort(string Port,string sPwd,ref int iRet);
        //传入sPwd,传出PORT iRet，设置设备上传服务器port，最长不超过4字节
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadServerPort(ref string Port,string sPwd,ref int iRet);
        //传入sPwd,传出SDCapacity iRet，获取tf卡剩余容量
        [DllImport("zfyMC.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadSDCapacity(ref string SDCapacity,string sPwd,ref int iRet);

    }


    #endregion

}
