using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace H6
{
    //https://wenku.baidu.com/view/7f969207f12d2af90242e674.html
    //https://download.csdn.net/download/hjq86510/2865767

    class wifi
    {
        /// <summary>
        /// 打开一个wifi句柄
        /// </summary>
        /// <param name="dwClientVersion">版本号</param>
        /// <param name="pReserved">保留</param>
        /// <param name="pdwNegotiatedVersion">支持的最高版本(输出)</param>
        /// <param name="ClientHandle">句柄(要得到的)以后的句柄一般都是这个</param>
        /// <returns></returns>
        [DllImport("Wlanapi", EntryPoint = "WlanOpenHandle")]
        public static extern uint WlanOpenHandle(uint dwClientVersion, IntPtr pReserved, [Out] out uint pdwNegotiatedVersion, ref IntPtr ClientHandle);


        /// <summary>
        /// 关闭打开的句柄
        /// </summary>
        /// <param name="hClientHandle">句柄</param>
        /// <param name="pReserved">保留</param>
        /// <returns></returns>
        [DllImport("Wlanapi", EntryPoint = "WlanCloseHandle")]
        public static extern uint WlanCloseHandle([In] IntPtr hClientHandle, IntPtr pReserved);


        /// <summary>
        /// 列举无线网络适配器
        /// </summary>
        /// <param name="hClientHandle">句柄</param>
        /// <param name="pReserved">保留</param>
        /// <param name="ppInterfaceList">数据指针(非托管)</param>
        /// <returns></returns>
        [DllImport("Wlanapi", EntryPoint = "WlanEnumInterfaces")]
        public static extern uint WlanEnumInterfaces([In] IntPtr hClientHandle, IntPtr pReserved, ref IntPtr ppInterfaceList);


        /// <summary>
        /// 释放内存
        /// </summary>
        /// <param name="pMemory">要释放的内存起始地址</param>
        [DllImport("Wlanapi", EntryPoint = "WlanFreeMemory")]
        public static extern void WlanFreeMemory([In] IntPtr pMemory);


        /// <summary>
        /// 获得可见的无线网络
        /// </summary>
        /// <param name="hClientHandle">句柄</param>
        /// <param name="pInterfaceGuid">适配器的guid号</param>
        /// <param name="dwFlags">标志位</param>
        /// <param name="pReserved">保留</param>
        /// <param name="ppAvailableNetworkList">无线网络的内存起始地址(非托管)</param>
        /// <returns></returns>
        [DllImport("Wlanapi", EntryPoint = "WlanGetAvailableNetworkList")]
        public static extern uint WlanGetAvailableNetworkList(IntPtr hClientHandle, ref Guid pInterfaceGuid, uint dwFlags, IntPtr pReserved, ref IntPtr ppAvailableNetworkList);



        /// <summary>
        /// 网络适配器的状态
        /// </summary>
        public enum WLAN_INTERFACE_STATE
        {
            WLAN_INTERFACE_STATE_NOT_READY = 0,
            WLAN_INTERFACE_STATE_CONNECTED = 1,
            WLAN_INTERFACE_STATE_AD_HOC_NETWORK_FORMED =2,
            WLAN_INTERFACE_STATE_DISCONNECTING =3,
            WLAN_INTERFACE_STATE_DISCONNECTED = 4,
            WLAN_INTERFACE_STATE_ASSOCIATING =5,
            WLAN_INTERFACE_STATE_DISCOVERING =6,
            WLAN_INTERFACE_STATE_AUTHENTICATING = 7
        }



        /// <summary>
        /// 一个适配器的信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_INTERFACE_INFO
        {
            ///GUID->_GUID
            public Guid InterfaceGuid;//Guid自动生成代码
            ///WCHAR[256]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strInterfaceDescription;
            ///WLAN_INTERFACE_STATE
            public WLAN_INTERFACE_STATE isState;
        }


        /// <summary>
        /// 包含所有适配器
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_INTERFACE_INFO_LIST //struct结构
        {
            public Int32 dwNumberOfItems;
            public Int32 dwIndex;
            public WLAN_INTERFACE_INFO[] InterfaceInfo;
            public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
            {
                dwNumberOfItems = Marshal.ReadInt32 (pList,0);
                dwIndex = Marshal.ReadInt32(pList, 4);
                InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];
                for (int i = 0; i < dwNumberOfItems; i++)
                {
                    IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);
                    WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                    wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                    InterfaceInfo[i] = wii;

                }
            }
        }


        /// <summary>
        /// 服务器标志(子网络标志号)
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DOT11_SSID
        {
            public uint uSSIDLength;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string ucSSID;
        }


        /// <summary>
        /// BSS类型
        /// </summary>
        public enum DOT11_BSS_TYPE
        {
            DOT11_BSS_TYPE_INFRASTRUCTURE = 1,
            DOT11_BSS_TYPE_INDEPENDENT =2,
            DOT11_BSS_TYPE_ANY=3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DOT11_PHY_TYPE
        {
            DOT11_PHY_TYPE_UNKNOWN =1,
            DOT11_PHY_TYPE_ANY,
            DOT11_PHY_TYPE_FHSS,
            DOT11_PHY_TYPE_DSSS,
            DOT11_PHY_TYPE_IRBASEHAND,
            DOT11_PHY_TYPE_OFDM,
            DOT11_PHY_TYPE_HRDSSS,
            DOT11_PHY_TYPE_ERP,
            DOT11_PHY_TYPE_HT,
            DOT11_PHY_TYPE_IHV_START,
            DOT11_PHY_TYPE_IHV_END

        }


        public enum DOT11_AUTH_ALGORITHM
        {
            DOT11_AUTH_ALGO_80211_OPEN = 1,
            DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,
            DOT11_AUTH_ALGO_WPA = 3,
            DOT11_AUTH_ALGO_WPA_PSK=4,
            DOT11_AUTH_ALGO_WPA_NONE=5,
            DOT11_AUTH_ALOG_RSNA = 6,
            DOT11_AUTH_ALOG_RSNA_PSK = 7,
            DOT11_AUTH_ALOG_IHV_START = -2147483648,
            DOT11_AUTH_ALOG_IHV_END = -1

        }

        public enum DOT11_CHIPER_ALGORITHM
        {
            DOT11_CHIPER_ALGO_NONE = 0,
            DOT11_CHIPER_ALGO_WEP40 = 1,
            DOT11_CHIPER_ALGO_TKIP =2,
            DOT11_CHIPER_ALGO_CCMP = 4,            

        }
    }
}
