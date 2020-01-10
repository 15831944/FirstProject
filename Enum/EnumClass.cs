using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Point = System.Drawing.Point;
using Action = System.Action;
using EnumProject.Helper;
using System.Configuration;
using EnumProject.Helper;

namespace EnumSpace
{
    public partial class EnumClass : Form
    {
        #region 自定义属性


        //隐藏显示定时器

        FormHelper _formHelper = null;
        DataHelper _dataHelper = null;
        StyleAndCss _styleAndCss = null;
        //单例打开播放页面
        //public frmVideo fv = null;



        //导入导出Excel的列名位置


        #endregion
        #region 开始方法
        /// <summary>
        /// 开始方法
        /// </summary>
        public EnumClass()
        {
            InitializeComponent();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string strIsDataToSql = config.AppSettings.Settings["isDataFromSql"].Value;
            bool isDataToSql = true;
            if (!string.IsNullOrEmpty(strIsDataToSql)) {
                bool.TryParse(strIsDataToSql, out isDataToSql);
            }
            PubulicData.isDataFromSql = isDataToSql;
            PubulicData.em = this;
            PubulicData.icon = Nicon;
            Dictionary<string, ToolStripMenuItem> item = new Dictionary<string, ToolStripMenuItem>();
            item.Add(ItemOne.Name, ItemOne);
            item.Add(ItemTwo.Name, ItemTwo);
            PubulicData.item = item;
            _dataHelper = new DataHelper();
            _formHelper = new FormHelper();
            _styleAndCss = new StyleAndCss();
            Task.Run(() => ActionHelper.setSourse()).Wait();
            //设置全局数据源
            _formHelper.ReLoad();
            Task.Run(() => DataHelper.CreateDB(() => Invoke((Action)reSetData)));
            reSetData();




        }

        #endregion
        #region 重新加载页面
        public void reSetData()
        {
            _dataHelper.MainInit();
            _styleAndCss.setCss(this.Controls);
            _formHelper.ReVS();
            _styleAndCss.setFromImage();
            PubulicData.em = this;
        }
        #endregion
        #region 窗体初始位置
        /// <summary>
        /// 窗体初始位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myLoad(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);
            this.Size = new Size(520,550);
            scan.Location= (Point)new Size(530, 20);
            scan.Size = new Size(540, 330);
            hfan.Location = (Point)new Size(530, 20);
            hfan.Size = new Size(170, 460);
            _formHelper.FormMove();
        }
        #endregion
        #region 鼠标滚轮事件
        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {

            VScrollBar sb = _formHelper.getPBar();
            var Delta = sb.LargeChange*20;
            if (sb != null)
            {
                if (e.Delta < 0)
                {
                    var vl = sb.Value + Delta;
                    if (vl < sb.Minimum) { vl = sb.Minimum; }
                    if (vl > sb.Maximum) { vl = sb.Maximum; }
                    sb.Value = vl;
                }
                else
                {
                    var vl = sb.Value - Delta;
                    if (vl < sb.Minimum) { vl = sb.Minimum; }
                    if (vl > sb.Maximum) { vl = sb.Maximum; }
                    sb.Value = vl;
                }
            }
        }
        #endregion
        #region 解决窗口刷新图像闪烁
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 重载基类的背景擦除函数，
            // 解决窗口刷新，放大，图像闪烁
            return;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // 使用双缓冲
            this.DoubleBuffered = true;
            // 背景重绘移动到此
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(
                this.BackgroundImage,
                new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                0,
                0,
                this.BackgroundImage.Width,
                this.BackgroundImage.Height,
                System.Drawing.GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }


        #endregion
    }
}
