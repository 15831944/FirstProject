﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EnumProject.ButtonLogic;

namespace EnumProject.Helper
{

    public static class PubulicData
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        public static EnumSpace.EnumClass em { get; set; }
        /// <summary>
        /// 窗体图标
        /// </summary>
        public static NotifyIcon icon { get; set; }
        /// <summary>
        /// 是否从数据库获取数据
        /// </summary>
        public static bool isDataFromSql { get; set; }
        /// <summary>
        /// 初始话数据
        /// </summary>
        public static Dictionary<string, object> sourceData { get; set; }
        /// <summary>
        /// 数据字典是否加载成功
        /// </summary>
        public static bool isDicPWD { get; set; }
        /// <summary>
        /// 图标选项
        /// </summary>
        public static Dictionary<string, ToolStripMenuItem> item { get; set; }
        /// <summary>
        /// 获取控件
        /// </summary>
        /// <param name="Name">控件名称</param>
        /// <returns></returns>
        public static Control GCFN(string Name)
        {
            Control ct = null;
            if (em.Controls.Find(Name, true) != null && em.Controls.Find(Name, true).Count() > 0)
            {
                ct = em.Controls.Find(Name, true)[0];
            }
            return ct;
        }
        public enum BtnType {
            [Description("web")]
            网站,
            [Description("app")]
            链接
        }
        public enum ClassName
        {
            [Description("按钮信息表")]
            ButtonDate,
            [Description("密码字典表")]
            DictionaryPassword
        }
    }
}
