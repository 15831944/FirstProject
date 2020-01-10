using EnumSpace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnumProject.ButtonLogic;
using EnumProject.OwerControl;
using System.Threading.Tasks;
using static EnumProject.Helper.PubulicData;
using EnumProject.HelpForm;

namespace EnumProject.Helper
{
    public class FormHelper
    {
        #region 定义全局变量
        //鼠标拖动窗体时坐标点
        Point mouseOff;
        //鼠标是否在拖动窗体
        bool leftFlag = false;
        //选择按钮ID
        static int id = 0;
        //主窗体
        static EnumSpace.EnumClass fm = null;
        private NotifyIcon Notify = null;
        private Dictionary<string, ToolStripMenuItem> item = null;
        //鼠标状态 true为进入窗体 false为离开窗体
        public static bool IsHide = false;
        //计时器 通过win32api实时获取鼠标位置
        private static bool IsMouseEnter = false;
        private Timer timer;
        #endregion
        #region 窗体按钮事件注册
        public void ReLoad()
        {
            Task.Run(() =>
            {
                reSetIndex();
            });
            fm = PubulicData.em;
            Notify = PubulicData.icon;
            item = PubulicData.item;
            fm.FormClosing += frmMain_FormClosing;
            Notify.MouseDown += ClickIcon;
            item["ItemOne"].MouseDown += ShowForm;
            item["ItemTwo"].MouseDown += CloseForm;
            PubulicData.GCFN("hfan").Visible = false;
            PubulicData.GCFN("scan").Visible = false;
            setButtonClick(new string[] { "hf", "sc", "ycxs", "btnWebClear", "btnAppCreate", "btnWebCreate", "btnAppClear", "btnClose", "btnWebTop", "btnAppTop", "btnWebUp", "btnAppUp", "btnWebDown", "btnAppDown", "btnPT" });
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        #endregion
        #region 点击方法统一调用
        public void setButtonClick(string[] btnName)
        {
            foreach (string item in btnName)
            {
                PubulicData.GCFN(item).Click += onClick;
            }
        }
        private void onClick(object sender, EventArgs e)
        {
            if (sender is TTButton)
            {
                TTButton btn = sender as TTButton;
                switch (btn.Name)
                {
                    case "hf":
                        RestoreButton();
                        break;
                    case "sc":
                        DeleteButton();
                        break;
                    case "ycxs":
                        ycxs_Click();
                        break;
                    case "btnWebClear":
                    case "btnAppClear":
                        EmptButton(btn);
                        break;
                    case "btnWebCreate":
                    case "btnAppCreate":
                        CreateButton(btn);
                        break;
                    case "btnClose":
                        formClose();
                        break;
                    case "btnWebTop":
                        setButtonTop(BtnType.网站);
                        break;
                    case "btnAppTop":
                        setButtonTop(BtnType.链接);
                        break;
                    case "btnWebUp":
                        setButtonUpOrDown(BtnType.网站, "上移");
                        break;
                    case "btnAppUp":
                        setButtonUpOrDown(BtnType.链接, "上移");
                        break;
                    case "btnWebDown":
                        setButtonUpOrDown(BtnType.网站, "下移");
                        break;
                    case "btnAppDown":
                        setButtonUpOrDown(BtnType.链接, "下移");
                        break;
                    case "btnPT":
                        frmOtherFormMain pro = new frmOtherFormMain(showF);
                        frmClosing();
                        pro.Show();
                        break;
                }
            }
        }
        #endregion
        #region 按钮上移下移
        public void setButtonUpOrDown(BtnType bt, string Cls)
        {
            if (id == 0) { return; }
            List<ButtonDate> btndate = PubulicData.sourceData[PubulicData.ClassName.ButtonDate.ToString()] as List<ButtonDate>;
            ButtonDate btnd = btndate.FirstOrDefault(c => c.ID == id);
            if (btnd == null) { return; }
            int NewIndex = btnd.Index;
            int NexIndex = 0;
            if (Cls == "上移" && NewIndex > btndate.Where(c => c.Type == bt.ToString() && c.State == "show").Min(c => c.Index))
            {
                NexIndex = btndate.Where(c => c.Type == bt.ToString() && c.Index < NewIndex && c.State == "show").Max(c => c.Index);
            }
            else if (Cls == "下移" && NewIndex < btndate.Where(c => c.Type == bt.ToString() && c.State == "show").Max(c => c.Index))
            {
                NexIndex = btndate.Where(c => c.Type == bt.ToString() && c.Index > NewIndex && c.State == "show").Min(c => c.Index);
            }
            if (NexIndex != 0)
            {
                var model = btndate.FirstOrDefault(c => c.Index == NexIndex && c.Type == bt.ToString());
                btnd.Index = NexIndex;
                model.Index = NewIndex;
            }
            PubulicData.sourceData[PubulicData.ClassName.ButtonDate.ToString()] = btndate;
            SX();
        }
        #endregion
        #region 设置按钮顺序
        public void reSetIndex()
        {
            EnumDBContext dbc = new EnumDBContext();
            var btndate = dbc.Set<ButtonDate>();
            var btnWeb = btndate.Where(c => c.Type == BtnType.网站.ToString()).OrderBy(c => c.Index);
            var btnApp = btndate.Where(c => c.Type == BtnType.链接.ToString()).OrderBy(c => c.Index);
            int index = 1;
            foreach (ButtonDate item in btnWeb)
            {
                item.Index = index;
                index++;
            }
            index = 1;
            foreach (ButtonDate item in btnApp)
            {
                item.Index = index;
                index++;
            }
            dbc.SaveChanges();
            dbc.Dispose();
        }
        #endregion
        #region 按钮置顶
        /// <summary>
        /// 当前选择按钮置顶
        /// </summary>
        public void setButtonTop(BtnType tp)
        {
            if (id == 0) { return; }

            List<ButtonDate> btndate = PubulicData.sourceData[PubulicData.ClassName.ButtonDate.ToString()] as List<ButtonDate>;
            ButtonDate btnd = btndate.FirstOrDefault(c => c.ID == id);
            if (btnd == null) { return; }
            if (btndate.FirstOrDefault(c => c.Index == 1 && c.Type == tp.ToString()) == null) { btnd.Index = 1; }
            else
            {
                var dbty = btndate.Where(c => c.Type == tp.ToString());
                List<int> index = dbty.Select(c => c.Index).ToList();
                foreach (ButtonDate item in dbty)
                {
                    if (item.Index == 1) { item.Index++; }
                    else
                    {
                        if (index.Contains(item.Index - 1))
                        {
                            item.Index++;
                        }
                    }
                }
            }
            PubulicData.sourceData[PubulicData.ClassName.ButtonDate.ToString()] = btndate;
            SX();
        }
        #endregion
        #region 页面主体拖动
        public void FormMove()
        {
            fm.MouseDown += mouseDown;
            fm.MouseMove += mouseMove;
            fm.MouseUp += mouseUp;
            fm.MouseEnter += onMouseEnter;
            fm.MouseLeave += onMouseLeave;
        }

        private void onMouseLeave(object sender, EventArgs e)
        {
            if (sender is TTTextBox)
            {
                TTTextBox ttb = sender as TTTextBox;
                ttb.BackColor = Color.Transparent;
            }
        }

        public void mouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = false;
            }
        }
        public void mouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                fm.Location = mouseSet;
            }

        }
        public void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);
            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
            if (sender is TTTextBox)
            {
                TTTextBox ttb = sender as TTTextBox;
                ttb.BackColor = Color.BlueViolet;
            }
        }
        #endregion
        #region 重置页面
        public void ResetForm()
        {

            VScrollBar vba = PubulicData.GCFN("panApp").Controls.Find("AppSB", true)[0] as VScrollBar;
            VScrollBar vbw = PubulicData.GCFN("panWeb").Controls.Find("WebSB", true)[0] as VScrollBar;
            VScrollBar vbh = PubulicData.GCFN("panHF").Controls.Find("HfSB", true)[0] as VScrollBar;
            PubulicData.GCFN("panApp").Controls.Clear();
            PubulicData.GCFN("panWeb").Controls.Clear();
            PubulicData.GCFN("panHF").Controls.Clear();
            PubulicData.GCFN("panApp").Controls.Add(vba);
            PubulicData.GCFN("panWeb").Controls.Add(vbw);
            PubulicData.GCFN("panHF").Controls.Add(vbh);

        }
        #endregion
        #region 重算页面上滚动条的大小写
        /// <summary>
        /// 重算页面上滚动条的大小写PubulicData.GCFN("panApp")
        /// </summary>              PubulicData.GCFN("panWeb")
        public void ReVS()
        {
            int webht = 0;
            int appht = 0;
            int hfht = 0;
            foreach (Control gbox in PubulicData.GCFN("panApp").Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Tag = PubulicData.GCFN("AppSB").Location.Y + gbox.Location.Y;
                appht += gbox.Height;
            }
            foreach (Control gbox in PubulicData.GCFN("panWeb").Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Tag = PubulicData.GCFN("WebSB").Location.Y + gbox.Location.Y;
                webht += gbox.Height;
            }
            foreach (Control gbox in PubulicData.GCFN("panHF").Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Tag = PubulicData.GCFN("HfSB").Location.Y + gbox.Location.Y;
                hfht += gbox.Height;
            }
            ((VScrollBar)PubulicData.GCFN("WebSB")).Minimum = 0;
            ((VScrollBar)PubulicData.GCFN("AppSB")).Minimum = 0;
            ((VScrollBar)PubulicData.GCFN("HfSB")).Minimum = 0;
            ((VScrollBar)PubulicData.GCFN("WebSB")).Maximum = webht;
            ((VScrollBar)PubulicData.GCFN("AppSB")).Maximum = appht;
            ((VScrollBar)PubulicData.GCFN("HfSB")).Maximum = hfht;
        }
        #endregion
        #region 点击按钮方法
        /// <summary>
        /// 点击按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClikeButton(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenLink(sender);
            }
            if (e.Button == MouseButtons.Right)
            {
                SelectButton(sender);
            }

        }
        #endregion
        #region 左击按钮方法
        /// <summary>
        /// 左击按钮方法
        /// </summary>
        /// <param name="sender"></param>
        public void OpenLink(object sender)
        {

            TTButton btnow = sender as TTButton;
            if (btnow != null)
            {
                string name = btnow.Name;
                string sid = name.Substring(3, name.Length - 3);
                int id = Convert.ToInt32(sid);
                ButtonDate item = ActionHelper.getInfo<ButtonDate>(new KeyValuePair<string, object>("ID", id));
                if (item == null) { return; }
                if (item.Type == "网站")
                {
                    OpenBrowser(item);
                }
                if (item.Type == "链接")
                {
                    OpenFiles(item);
                }
            }
        }
        #endregion
        #region 右击选中按钮
        /// <summary>
        /// 右击选中按钮
        /// </summary>
        /// <param name="sender"></param>
        public void SelectButton(object sender)
        {
            TTButton btnow = sender as TTButton;
            if (btnow != null)
            {
                string name = btnow.Name;
                string sid = name.Substring(3, name.Length - 3);
                int id = Convert.ToInt32(sid);
                ButtonDate item = ActionHelper.getInfo<ButtonDate>(new KeyValuePair<string, object>("ID", id));
                if (item == null) { return; }
                if (item.Type == "网站")
                {
                    SelectWebShow(item);
                }
                if (item.Type == "链接")
                {
                    SelectAppShow(item);
                }
            }
        }
        #endregion
        #region 右击选中浏览器按钮
        /// <summary>
        /// 右击选中浏览器按钮
        /// </summary>
        /// <param name="bd"></param>
        public void SelectWebShow(ButtonDate bd)
        {
            PubulicData.GCFN("webbtn").Text = bd.Name;
            PubulicData.GCFN("webllq").Text = bd.Browser;
            PubulicData.GCFN("weburl").Text = bd.Url;
            id = bd.ID;
        }
        #endregion
        #region 右击选中程序按钮
        /// <summary>
        /// 右击选中程序按钮
        /// </summary>
        /// <param name="bd"></param>
        public void SelectAppShow(ButtonDate bd)
        {
            PubulicData.GCFN("appname").Text = bd.Name;
            PubulicData.GCFN("appurl").Text = bd.Url;
            id = bd.ID;
        }
        #endregion
        #region 浏览器打开文件
        /// <summary>
        /// 浏览器打开文件
        /// </summary>
        /// <param name="bd"></param>
        public void OpenBrowser(ButtonDate bd)
        {
            string bw = bd.Browser;
            string bwnew = "";
            string bwurl = bd.Url;
            var url = ActionHelper.getInfo<ButtonDate>(new KeyValuePair<string, object>("Name", bw));
            if (url != null && !string.IsNullOrEmpty(bw))
            {
                bwnew = url.Url;
                switch (bw.ToLower())
                {
                    case "ie":
                    case "iexplore":
                        bwnew = "iexplore.exe";
                        break;
                    case "火狐":
                    case "firefox":
                        bwnew = "firefox.exe";
                        break;
                    case "谷歌":
                    case "chrome":
                        bwnew = "chrome.exe";
                        break;
                }
                if (!string.IsNullOrEmpty(bwnew))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(bwnew, bwurl);
                    }
                    catch
                    {
                        OpenFormBrowser(bwurl);
                    }
                }
                else
                {
                    OpenFormBrowser(bwurl);
                }
            }
            else
            {
                OpenFormBrowser(bwurl);
            }
        }
        #endregion
        #region 用嵌入浏览器打开
        public void OpenFormBrowser(string url)
        {
            EnumSpace.FormBrowser bw = new EnumSpace.FormBrowser(url);
            bw.Show();
            if (bw.DialogResult == DialogResult.OK)
            {
                bw.Dispose();
            }
        }
        #endregion
        #region 打开本地文件
        /// <summary>
        /// 打开本地文件
        /// </summary>
        /// <param name="bd"></param>
        public void OpenFiles(ButtonDate bd)
        {
            string bwurl = bd.Url;
            System.Diagnostics.Process.Start(bwurl);
        }
        #endregion
        #region 清空按钮
        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EmptButton(TTButton btnow)
        {
            id = 0;
            if (btnow != null)
            {
                string name = btnow.Name;
                if (name == "btnWebClear")
                {
                    PubulicData.GCFN("webbtn").Text = "";
                    PubulicData.GCFN("webllq").Text = "";
                    PubulicData.GCFN("weburl").Text = "";
                }
                if (name == "btnAppClear")
                {
                    PubulicData.GCFN("appname").Text = "";
                    PubulicData.GCFN("appurl").Text = "";
                }
            }
            // reSetData();
        }
        #endregion
        #region 删除按钮
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteButton()
        {
            if (id != 0)
            {
                ActionHelper.ModifyButton(id, "hiden");
                SX();
            }
        }
        #endregion
        #region 隐藏显示恢复按钮页面
        /// <summary>
        /// 隐藏显示恢复按钮页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RestoreButton()
        {
            PubulicData.GCFN("scan").Visible = false;
            if (PubulicData.GCFN("hfan").Visible == true)
            {
                PubulicData.GCFN("hfan").Visible = false;
                fm.Width = 520;
            }
            else
            {
                PubulicData.GCFN("hfan").Visible = true;
                fm.Width = 780;
            }
        }
        #endregion
        #region 恢复按钮点击事件
        public void hfClike(object sender, EventArgs e)
        {

            TTButton btnow = sender as TTButton;
            if (btnow != null)
            {
                string name = btnow.Name;
                int id = 0;
                string sid = name.Substring(2, name.Length - 2);
                if (Int32.TryParse(sid, out id))
                {
                    ActionHelper.ModifyButton(id, "show");
                    SX();
                }
            }
        }
        #endregion
        #region 隐藏显示添加按钮页面
        /// <summary>
        /// 隐藏显示添加按钮页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ycxs_Click()
        {
            PubulicData.GCFN("hfan").Visible = false;
            if (PubulicData.GCFN("scan").Visible == true)
            {
                PubulicData.GCFN("scan").Visible = false;
                fm.Width = 520;

            }
            else
            {
                PubulicData.GCFN("scan").Visible = true;
                fm.Width = 1100;
            }
        }
        #endregion
        #region 添加按钮
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CreateButton(TTButton nowbt)
        {
            if (nowbt != null)
            {
                string name = nowbt.Name;
                string btnname = "";
                string btnllq = "";
                string btnurl = "";
                ButtonDate bd = new ButtonDate();
                bd.ID = id;
                if (name == "btnWebCreate")
                {
                    string url = PubulicData.GCFN("weburl").Text;
                    url = url.Trim('"');
                    btnname = PubulicData.GCFN("webbtn").Text;
                    btnllq = PubulicData.GCFN("webllq").Text;
                    btnurl = url;
                    bd.Name = btnname;
                    bd.Url = btnurl;
                    bd.Browser = btnllq;
                    bd.Type = "网站";
                    bd.State = "show";
                    bd.CreateDate = DateTime.Now;
                    bd.CreateIP = LoacationHelper.GetLocalIP();
                    bd.CreateMac = LoacationHelper.GetMac();
                }
                if (name == "btnAppCreate")
                {
                    string url = PubulicData.GCFN("appurl").Text;
                    url = url.Trim('"');
                    btnname = PubulicData.GCFN("appname").Text;
                    btnurl = url;
                    bd.Name = btnname;
                    bd.Url = btnurl;
                    bd.Type = "链接";
                    bd.State = "show";
                    bd.CreateDate = DateTime.Now;
                    bd.CreateIP = LoacationHelper.GetLocalIP();
                    bd.CreateMac = LoacationHelper.GetMac();
                }
                ActionHelper.saveInfo<ButtonDate>(bd);
                SX();
            }
        }
        #endregion
        #region 显示隐藏页面
        /// <summary>
        /// 显示隐藏页面
        /// </summary>
        /// <param name="bj"></param>
        public void SX()
        {
            bool scan = PubulicData.GCFN("scan").Visible;
            bool hfan = PubulicData.GCFN("hfan").Visible;
            fm.reSetData();
            if (scan)
            {
                PubulicData.GCFN("scan").Visible = true;
                fm.Width = 1100;
            }
            else if (hfan)
            {
                PubulicData.GCFN("hfan").Visible = true;
                fm.Width = 780;
            }
        }
        #endregion
        #region 显示窗体事件
        /// <summary>
        /// 显示窗体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowForm(object sender, EventArgs e)
        {
            showF();
        }
        #endregion
        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        public void showF()
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(fm);
            var left = ScreenArea.Width / 2 - fm.Width / 2;
            fm.Top = 25;//显示窗体
            fm.Left = left;
            IsHide = false;
            fm.Show();//把窗体状态设置为显示
            fm.WindowState = FormWindowState.Normal;
            fm.Activate();
            fm.TopMost = true;
        }
        #endregion
        #region 退出窗体
        /// <summary>
        /// 退出窗体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CloseForm(object sender, EventArgs e)
        {
            Notify.Dispose();
            fm.Close();
            fm.Dispose();
            Application.Exit();
        }
        #endregion
        #region 关闭窗体
        private void formClose()
        {
            fm.Close();
        }
        #endregion
        #region 关闭窗体事件
        /// <summary>
        /// 关闭窗体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            frmClosing();
        }
        #endregion
        #region 假装关闭
        public void frmClosing()
        {
            IsHide = true;
            fm.Hide();
        }
        #endregion
        #region 点击图标
        /// <summary>
        /// 点击图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickIcon(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (IsHide)
                {
                    showF();
                }
                else
                {
                    IsHide = true;
                    fm.Hide();
                }
            }
            //else if (e.Button == MouseButtons.Right) {
            //    this.CMS.Show();
            //}
        }
        #endregion
        #region 根据当前焦点获取Bar条
        /// <summary>
        /// 根据当前焦点获取Bar条
        /// </summary>
        /// <returns></returns>
        public VScrollBar getFBar()
        {
            var focus = LoacationHelper.GetFocusedControl();
            TTVScrollBar sb = null;
            if (focus != null)
            {
                foreach (Control gbox in PubulicData.GCFN("appan").Controls)
                {
                    if (gbox.Name == focus.Name)
                    {
                        sb = (TTVScrollBar)PubulicData.GCFN("AppSB");
                    }
                }
                foreach (Control gbox in PubulicData.GCFN("weban").Controls)
                {
                    if (gbox.Name == focus.Name)
                    {
                        sb = (TTVScrollBar)PubulicData.GCFN("WebSB");
                    }
                }
                foreach (Control gbox in PubulicData.GCFN("hfan").Controls)
                {
                    if (gbox.Name == focus.Name)
                    {
                        sb = (TTVScrollBar)PubulicData.GCFN("HfSB");
                    }
                }
            }
            return sb;

        }
        #endregion
        #region 根据鼠标位置获取Bar条
        /// <summary>
        /// 根据鼠标位置获取Bar条
        /// </summary>
        /// <returns></returns>
        public VScrollBar getPBar()
        {
            Point Mp = LoacationHelper.GetPoint();
            TTVScrollBar sb = null;
            if (Mp.X > 519)
            {
                sb = (TTVScrollBar)PubulicData.GCFN("HfSB");
            }
            else if (Mp.X > 208)
            {
                sb = (TTVScrollBar)PubulicData.GCFN("AppSB");
            }
            else
            {
                sb = (TTVScrollBar)PubulicData.GCFN("WebSB");
            }
            //if (sb != null) {
            //    sb.Focus();
            //}
            return sb;
        }
        #endregion
        #region 打开播放页面
        /// <summary>
        /// 打开播放页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void playerVideo(object sender, EventArgs e)
        //{
        //    if (fv == null)
        //    {
        //        fv = new frmVideo(this);
        //    }
        //    else if (fv.DialogResult == DialogResult.OK)
        //    {
        //        fv = new frmVideo(this);
        //    }
        //    fv.Show();
        //    fv.Activate();
        //    fv.TopMost = true;
        //    this.TopMost = false;
        //}
        #endregion
        #region 隐藏显示计时器
        /// <summary>
        /// 隐藏显示计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            Point point = Control.MousePosition;
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(fm);
            //判断鼠标是否进入窗体
            if (point.X >= fm.Left && point.X <= fm.Left + fm.Width && point.Y >= fm.Top && point.Y <= fm.Top + fm.Height)
            {
                //鼠标在窗体内部
                IsMouseEnter = true;
            }
            else
            {
                //鼠标离开窗体
                IsMouseEnter = false;
            }

            //判断窗体是否在隐藏状态
            if (IsHide)
            {
                var left = ScreenArea.Width / 2 - fm.Width / 2;
                if (point.Y <= 50 && point.X > ScreenArea.Width - 350 && point.X < ScreenArea.Width - 300)
                {
                    showF();
                }
            }
            else
            {
                //如果在显示状态 且纵坐标小于等于20 切鼠标不在窗体内 则隐藏窗体
                if (fm.Top <= 20 && !IsMouseEnter)
                {
                    //this.Top =-this.Height;//隐藏窗体
                    //this.Left = ScreenArea.Width / 2 - this.Width / 2;
                    IsHide = true;
                    fm.Hide();
                }
                else
                {
                    if (point.Y <= 20 && point.X <= 100)
                    {
                        fm.Activate();
                        fm.TopMost = true;
                    }
                }
            }

        }
        #endregion

    }
}
