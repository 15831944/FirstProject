using System;
using System.Drawing;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace EnumProject.Helper
{
    public class LoacationHelper
    {
        #region 定义全局变量
        [DllImport("user32.dll")]
        private static extern IntPtr GetFocus();
        #endregion
        #region 获取本机IP地址
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns>本机IP地址</returns>
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
        #region 获取本机的Mac地址
        public static string GetMac()
        {
            string mac = null;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return (mac);
        }

        #endregion
        #region 获取当前鼠标位置
        /// <summary>
        /// 获取当前鼠标位置
        /// </summary>
        /// <returns></returns>
        public static Point GetPoint()
        {
            Point P = Control.MousePosition;
            Point Ptc =PubulicData.em.PointToClient(P);
            return Ptc;
        }
        #endregion
        #region 获取当前焦点
        /// <summary>
        /// 获取当前焦点
        /// </summary>
        /// <returns></returns>
        public static Control GetFocusedControl()
        {
            IntPtr hwnd = GetFocus();
            Control ctl = Control.FromHandle(hwnd);
            return ctl;
        }
        #endregion
    }
}
