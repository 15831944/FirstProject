using Enum.OwerControl;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Enum.Helper
{
    public class StyleAndCss
    {
        #region 定义全局变量
        public int indexImage = 0;
        public readonly string gifPath = System.Windows.Forms.Application.StartupPath;
        public readonly string imagePath = System.Windows.Forms.Application.StartupPath;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnumClass));
        static EnumSpace.EnumClass fm = null;
        Image gif = null;
        #endregion
        #region 重载构造方法
        public StyleAndCss() {
            fm = PubulicData.em;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string frmBacgroundName=config.AppSettings.Settings["frmBacgroundName"].Value;
            string btnBacgroundName = config.AppSettings.Settings["btnBacgroundName"].Value;
            gifPath += @"\" + frmBacgroundName;
            imagePath += @"\" + btnBacgroundName;

        }
        #endregion
        #region 设置窗体背景图片
        public void setFromImage()
        {
            if (File.Exists(gifPath))
            {
                Timer giftimer = new Timer();
                giftimer.Interval = 100;
                giftimer.Tick += new EventHandler(PlayBackImage);
                giftimer.Start();
            }
            else
            {
                fm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("XYDT")));
                fm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }
        #endregion
        #region 播放动态背景
        public void PlayBackImage(object sender, EventArgs e)
        {
            if (gif == null) {gif = Image.FromFile(gifPath); }
            System.Drawing.Imaging.FrameDimension fd = new System.Drawing.Imaging.FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd); //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
            Image bgImg = null;
            if (indexImage >= count) { indexImage = 0; }
            gif.SelectActiveFrame(fd, indexImage);
            System.IO.Stream stream = new System.IO.MemoryStream();
            gif.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (bgImg != null) { bgImg.Dispose(); }
            bgImg = Image.FromStream(stream);
            fm.BackgroundImage = bgImg;
            fm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            indexImage++;
        }
        #endregion
        #region 绘制背景
        public void setCss(Control.ControlCollection cs)
        {
            if (cs == null || cs.Count < 1) { return; }
            foreach (Control item in cs)
            {
                if (item is TTPanel)
                {
                    //TTPanel pl = item as TTPanel;
                    //pl.Paint += Pl_Paint;
                }
                if (item is TTGroupBox)
                {
                    //TTGroupBox gb = item as TTGroupBox;
                    //gb.Paint += Pl_Paint;
                }
                if (!(item is TTTextBox) && !(item is TTVScrollBar))
                {
                    item.BackColor = Color.Transparent;
                }
                if (item is TTVScrollBar)
                {
                    TTVScrollBar vb = item as TTVScrollBar;
                    vb.ValueChanged += myScroll;
                    vb.SmallChange = 10;
                    vb.Width = 1;
                }
                if (item is TTTextBox) {
                    //TTTextBox tb = item as TTTextBox;
                }
                if (item is TTButton)
                {
                    var bt = item as TTButton;
                    setButtonColor(bt);
                    if (bt.Parent is Form)
                    {
                         setButtonImage(bt);
                    }
                }
                setCss(item.Controls);
            }
        }
        #region 控件的滚动位置
        /// <summary>
        /// 控件的滚动位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void myScroll(object sender, EventArgs e)
        {
            VScrollBar vsb = sender as VScrollBar;
            if (vsb != null)
            {
                switch (vsb.Name.ToLower())
                {
                    case "websb":
                        foreach (Control gbox in PubulicData.GCFN("panWeb").Controls)
                        {
                            if (gbox is VScrollBar) continue;
                            gbox.Location = new Point(gbox.Location.X, (int)gbox.Tag - vsb.Value);
                        }
                        break;
                    case "appsb":
                        foreach (Control gbox in PubulicData.GCFN("panApp").Controls)
                        {
                            if (gbox is VScrollBar) continue;
                            gbox.Location = new Point(gbox.Location.X, (int)gbox.Tag - vsb.Value);
                        }
                        break;
                    case "hfsb":
                        foreach (Control gbox in PubulicData.GCFN("panHF").Controls)
                        {
                            if (gbox is VScrollBar) continue;
                            gbox.Location = new Point(gbox.Location.X, (int)gbox.Tag - vsb.Value);
                        }
                        break;
                }
            }

        }
        #endregion
        public void Pl_Paint(object sender, PaintEventArgs e)
        {
           // Rectangle rtl = new Rectangle();
            // if (sender is Panel) { Panel p = sender as Panel; rtl = p.ClientRectangle; }
            if (sender is GroupBox)
            {
                GroupBox g = sender as GroupBox;
                e.Graphics.Clear(Color.Transparent);
                //Image gif = Image.FromFile(gifPath);
                //e.Graphics.DrawImage(gif, default(Point));
                //GroupBox g = sender as GroupBox; rtl = g.ClientRectangle;
                //ControlPaint.DrawBorder(e.Graphics,
                //                    rtl,
                //                    Color.Black,//7f9db9
                //                    1,
                //                    ButtonBorderStyle.Dashed,
                //                    Color.Black,
                //                    0,
                //                    ButtonBorderStyle.Dashed,
                //                    Color.Black,
                //                    1,
                //                    ButtonBorderStyle.Dashed,
                //                    Color.Black,
                //                    0,
                //                    ButtonBorderStyle.Dashed);

            }
        }
        #endregion
        #region 设置按钮样式
        public void setButtonColor(TTButton bt)
        {
            bt.FlatStyle = FlatStyle.Flat;//样式
            bt.FlatAppearance.BorderSize = 0;//去边线
            bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromName("red");//鼠标经过
            bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;//鼠标按下
            bt.ForeColor = Color.Transparent;//前景
            bt.BackColor = Color.Transparent;//去背景
            bt.ForeColor = Color.FromName("purple");
            bt.Font = new Font("行书", 10.2f);
        }
        #endregion
        #region 设置按钮背景图片
        public void setButtonImage(TTButton bt)
        {
            bt.ForeColor = Color.FromName("black");
            bt.Font = new Font("行书", 10.2f,FontStyle.Bold);
            //bt.BackgroundImage = Image.FromFile(imagePath);
            //bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //bt.FlatAppearance.BorderSize = 0;
        }
        #endregion
    }
}
