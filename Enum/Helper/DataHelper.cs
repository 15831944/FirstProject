using Enum.ButtonLogic;
using Enum.OwerControl;
using EnumSpace;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.ExcelEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using T4ConsoleApplication.Entities;
using Action = System.Action;
namespace Enum.Helper
{
    public class DataHelper
    {
        #region 全局变量
        private static Dictionary<string, int> location = new Dictionary<string, int>();
        static EnumSpace.EnumClass fm = null;
        static FormHelper _formHelper = null;
        #endregion
        #region 重载构造方法
        public DataHelper()
        {
            fm = PubulicData.em;
            _formHelper = new FormHelper();
        }
        #endregion
        #region 新建数据库
        public static void CreateDB(Action act)
        {
            DataHelper dh = new DataHelper();
            dh.DeleteRep();
            dh.setFile();
            dh.setLoaction();
            dh.setData(act);
            dh.setPasswordDictionary();
        }
        #endregion
        #region 数据库生成文件
        public void setFile()
        {
            using (EnumDBContext ec = new EnumDBContext())
            {
                var dateall = ec.Set<ButtonDate>();
                if (dateall.Count() < 1) { return; }
                ExcelEdit excel = new ExcelEdit();
                string str = System.Windows.Forms.Application.StartupPath;
                Worksheet ws = null;
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                if (!File.Exists(str + @"\EnumSource.xlsx"))
                {
                    excel.mFilename = str + @"\EnumSource.xlsx";
                    excel.Create();
                    excel.AddSheet("EnumData");
                }
                else
                {
                    excel.Open(str + @"\EnumSource.xlsx");
                }
                if (excel.GetSheet("EnumData") == null)
                {
                    ws = excel.AddSheet("EnumData");
                }
                else
                {
                    ws = excel.GetSheet("EnumData");
                }
                int y = 2;
                foreach (ButtonDate item in dateall)
                {
                    int x = 1;
                    foreach (PropertyInfo obj in item.GetType().GetProperties())
                    {
                        object value = null;
                        if (y == 2)
                        {
                            value = obj.Name.ToString();
                            excel.SetCellValue(ws, 1, x, value);
                        }
                        value = item.GetType().GetProperty(obj.Name.ToString()).GetValue(item);
                        Range titleRange = ws.Range[ws.Cells[y, x],
                        ws.Cells[y, x]];//选中标题  
                        titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter; //水平居中  
                        if (titleRange.Value != null && value != null && value.Equals(titleRange.Value))
                        {
                            x++;
                            continue;
                        }
                        else
                        {
                            excel.SetCellValue(ws, y, x, value);
                            x++;
                        }
                    }
                    y++;
                }
                excel.wb.RefreshAll();
                if (File.Exists(str + @"\EnumSource.xlsx"))
                {
                    excel.Save();
                }
                else
                {
                    excel.SaveAs(str + @"\EnumSource.xlsx");
                }
                excel.Close();
            }
        }
        #endregion
        #region 删除重复和空数据
        public void DeleteRep()
        {
            using (EnumDBContext ec = new EnumDBContext())
            {
                var dateall = ec.Set<ButtonDate>();
                if (dateall.Count() < 1) { return; }
                List<ButtonDate> btnList = dateall.ToList();
                List<string> btnListTwo = new List<string>();
                foreach (ButtonDate item in btnList)
                {
                    if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Url))
                    {
                        dateall.Remove(item);
                    }
                    if (btnListTwo.Contains(item.Name))
                    {
                        dateall.Remove(item);
                    }
                    else
                    {
                        btnListTwo.Add(item.Name);
                    }
                }
                ec.SaveChanges();
            }
        }
        #endregion

        #region 文件同步到数据库
        public void setData(Action act)
        {
            using (EnumDBContext ec = new EnumDBContext())
            {
                var dateall = ec.Set<ButtonDate>();
                if (dateall.Count() > 1) { return; }
                ExcelEdit excel = new ExcelEdit();

                string str = System.Windows.Forms.Application.StartupPath;
                if (!File.Exists(str + @"\EnumSource.xlsx")) { return; }
                excel.Open(str + @"\EnumSource.xlsx");
                excel.ws = excel.GetSheet("EnumData");
                int rows = excel.ws.UsedRange.CurrentRegion.Rows.Count;
                for (int i = 2; i < rows + 1; i++)
                {
                    ButtonDate bd = new ButtonDate();
                    foreach (string j in location.Keys)
                    {
                        Range titleRange = excel.ws.Range[excel.ws.Cells[i, location[j]], excel.ws.Cells[i, location[j]]];//选中标题 
                        if (titleRange.Value2 != null)
                        {
                            var gpt = typeof(ButtonDate).GetProperties();
                            var mt = gpt.FirstOrDefault(c => c.Name == j);
                            if (mt != null)
                            {
                                object obj = new object();
                                if (titleRange.Value != null)
                                {
                                    Type tp = mt.PropertyType;
                                    dynamic value = titleRange.Value;
                                    switch (j)
                                    {
                                        case "CreateDate":
                                            tp = typeof(DateTime);
                                            value = DateTime.Now;
                                            break;
                                        case "ID":
                                            value = 0;
                                            break;
                                        case "CreateIP":
                                            value = LoacationHelper.GetLocalIP();
                                            break;
                                        case "CreateMac":
                                            value = LoacationHelper.GetMac();
                                            break;
                                    }

                                    obj = Convert.ChangeType(value, tp);
                                }
                                else
                                {
                                    obj = titleRange.Value;
                                }
                                mt.SetValue(bd, obj);
                            }
                        }
                    }
                    dateall.Add(bd);
                }
                if (dateall.Count() < 1)
                {
                    DateTime dt = DateTime.Now;
                    string nm = dt.Ticks.ToString();
                    ButtonDate bd = new ButtonDate();
                    bd.Name = nm;
                    dateall.Add(bd);
                    ec.SaveChanges();
                    var dtr = ec.Set<ButtonDate>().FirstOrDefault(c => c.Name == nm);
                    dateall.Remove(dtr);
                }
                excel.Close();
                ec.SaveChanges();
                act();
            }
        }
        #endregion
        #region 获取列的位置
        public void setLoaction()
        {
            var gpt = typeof(ButtonDate).GetProperties();
            int i = 2;
            foreach (PropertyInfo item in gpt)
            {
                if (item.Name != "ID")
                {
                    location.Add(item.Name, i);
                    i++;
                }
            }
        }
        #endregion
        #region 加载页面数据
        public void MainInit()
        {
            ClearBuntton();
            List<ButtonDate> allbtn = new List<ButtonDate>();
            List<ButtonDate> hfbtn = new List<ButtonDate>();
            using (EnumDBContext ec = new EnumDBContext())
            {
                var list = ec.Set<ButtonDate>().ToList();
                allbtn = list.Where(c => c.State == "show").OrderBy(c => c.Index).ToList();
                hfbtn = list.Where(c => c.State == "hiden").ToList();
                int i = 0;
                int j = 0;
                int z = 0;
                foreach (ButtonDate item in allbtn)
                {
                    TTButton modle = new TTButton();
                    modle.Size = new System.Drawing.Size(120, 30);
                    modle.TabIndex = (int)item.Index + 1;
                    modle.UseVisualStyleBackColor = true;
                    modle.Text = item.Name;
                    modle.MouseDown += _formHelper.ClikeButton;
                    if (item.Type == "网站")
                    {
                        modle.Name = "wbe" + item.ID;
                        modle.Location = new System.Drawing.Point(21, 20 + i * 40);
                        PubulicData.GCFN("panWeb").Controls.Add(modle);
                        i++;
                    }
                    else
                    {
                        if (item.CreateMac == LoacationHelper.GetMac())
                        {
                            modle.Name = "app" + item.ID;
                            modle.Location = new System.Drawing.Point(21, 20 + j * 40);
                            PubulicData.GCFN("panApp").Controls.Add(modle);
                            j++;
                        }
                    }
                }
                foreach (ButtonDate item in hfbtn)
                {
                    TTButton modle = new TTButton();
                    modle.Name = "hf" + item.ID;
                    modle.Location = new System.Drawing.Point(21, 20 + z * 40);
                    modle.Size = new System.Drawing.Size(120, 30);
                    modle.TabIndex = (int)item.Index + 1;
                    modle.UseVisualStyleBackColor = true;
                    modle.Text = item.Name;
                    modle.MouseDown += _formHelper.hfClike;
                    PubulicData.GCFN("panHF").Controls.Add(modle);
                    z++;
                }
            }
        }
        #endregion
        #region 清除页面按钮
        public void ClearBuntton()
        {
            var Wsb = PubulicData.GCFN("WebSB");
            var Asb = PubulicData.GCFN("AppSB");
            var Hsb = PubulicData.GCFN("HfSB");
            Dictionary<string, Control> str = new Dictionary<string, Control>();
            str.Add("panWeb", Wsb);
            str.Add("panApp", Asb);
            str.Add("panHF", Hsb);
            foreach (string item in str.Keys)
            {
                PubulicData.GCFN(item).Controls.Clear();
                PubulicData.GCFN(item).Controls.Add(str[item]);
            }
        }
        #endregion
        #region 上传附件事件
        /// <summary>
        /// 上传附件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadVideo(object sender, EventArgs e)
        {
            UploadFile();
        }
        #endregion
        #region 上传附件
        /// <summary>
        /// 上传附件
        /// </summary>
        public void UploadFile()
        {
            //var filePath = string.Empty;
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "视频文件|*.mp4|所有文件|*.*";
            //    openFileDialog.FilterIndex = 0;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        filePath = openFileDialog.FileName;
            //        FileInfo fi = new FileInfo(filePath);
            //        long size = fi.Length;
            //        var fileStream = openFileDialog.OpenFile();
            //        byte[] bytes = new byte[size];
            //        fileStream.Read(bytes, 0, bytes.Length);
            //        string dtn = fi.DirectoryName;
            //        string fn = fi.Name;
            //        string path = "";
            //        string url = "Video/" + fi.Name;
            //        if (dtn.Substring(dtn.Length - 2, 2) == "\\")
            //        {
            //            path = fi.DirectoryName + fi.Name;
            //        }
            //        else
            //        {
            //            path = fi.DirectoryName + "\\" + fi.Name;
            //        }
            //        this.BeginInvoke(new Action(delegate ()
            //        {
            //            saveFiles(fi, bytes);
            //            uploadfiles(url, path);
            //        }));
            //    }
            //}
        }
        #endregion
        #region 保存文件
        /// <summary>
        /// 保存文件到数据库
        /// </summary>
        /// <param name="file"></param>
        /// <param name="bt"></param>
        //public void saveFiles(FileInfo file, byte[] bt)
        //{
        //    using (EnumDBContext ec = new EnumDBContext())
        //    {
        //        var list = ec.Set<videolist>();
        //        videolist model = new videolist()
        //        {
        //            VideoName = file.Name,
        //            Type = (file.Name).Split('.')[(file.Name).Split('.').Length - 1],
        //            Size = file.Length,
        //            CreateTime = DateTime.Now,
        //            Worker = GetLocalIP()


        //        };
        //        list.Add(model);
        //        ec.SaveChanges();
        //    }
        //}
        #endregion
        #region 上传文件到阿里云
        public void uploadfiles(string objectName, string localFilename)
        {
            //try
            //{
            //    // 上传文件。
            //    client.PutObject(bucketName, objectName, localFilename);
            //    MessageBox.Show("文件上传成功！");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Put object failed, {0}", ex.Message);
            //}
        }
        #endregion

        #region 设置常用密码字典到数据库
        /// <summary>
        /// 设置常用密码字典到数据库
        /// </summary>
        public void setPasswordDictionary()
        {
            EnumDBContext ec = new EnumDBContext();
            var dateall = ec.Set<DictionaryPassword>();
            if (dateall.Count() > 1) { return; }
            ec.Dispose();
            BackgroundWorker backworker = new BackgroundWorker();
            backworker.DoWork += new DoWorkEventHandler(setNumber);
            backworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(saveDic);
            backworker.RunWorkerAsync();

        }
        #endregion
        #region 设置纯数字密码字典到数据库
        public void setNumber(object sender, DoWorkEventArgs e)
        {
            int len = 6;
            string strNum = "";
            long SourceNumber = 0;
            List<DictionaryPassword> ldic = new List<DictionaryPassword>();
            for (int i = 0; i < len; i++)
            {
                strNum += "9";
            }
            if (!string.IsNullOrEmpty(strNum))
            {
                SourceNumber = Convert.ToInt64(strNum);
            }
            if (SourceNumber == 0) { return; }

            for (int i = 0; i <= SourceNumber; i++)
            {
                string sn = i.ToString();
                string pwd = PasswordHelper.HashPasswordForStoringInConfigFile(sn, "md5");
                ldic.Add(new DictionaryPassword() { Password = pwd, Plaintext = sn, CreateDate = DateTime.Now, PwdType = "md5" });
                for (int j = sn.Length + 1; j <= len; j++)
                {
                    string spwd = PasswordHelper.HashPasswordForStoringInConfigFile(sn.PadLeft(j, '0'), "md5");
                    ldic.Add(new DictionaryPassword() { Password = spwd, Plaintext = sn.PadLeft(j, '0'), CreateDate = DateTime.Now, PwdType = "md5" });
                }
            }
            e.Result = ldic;
        }
        #endregion
        #region 保存密码字典
        /// <summary>
        /// 保存密码字典
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void saveDic(object sender, RunWorkerCompletedEventArgs e)
        {
          
            List<DictionaryPassword> ldic = e.Result as List<DictionaryPassword>;
            foreach (DictionaryPassword item in ldic)
            {
                EnumDBContext ec = new EnumDBContext();
                var db = ec.Set<DictionaryPassword>();
                db.Add(item);
                ec.SaveChanges();
                ec.Dispose();
            }
          
        }
        #endregion

        #region 设置字母和数字四位密码字典
        public void setCharAndNumber(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backworker = new BackgroundWorker();
            backworker.DoWork += new DoWorkEventHandler(DoworkCreatCharFour);
            backworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedCreatCharFour);
        }

        private void CompletedCreatCharFour(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DictionaryPassword> ldic = e.Result as List<DictionaryPassword>;
            foreach (DictionaryPassword item in ldic)
            {
                EnumDBContext ec = new EnumDBContext();
                var db = ec.Set<DictionaryPassword>();
                if (db.FirstOrDefault(c => c.Password == item.Password && c.Plaintext == item.Plaintext) == null)
                {
                    db.Add(item);
                }
                ec.SaveChanges();
                ec.Dispose();
            }
           
        }

        private void DoworkCreatCharFour(object sender, DoWorkEventArgs e)
        {
            List<string> StrList = new List<string>();
            List<DictionaryPassword> ldic = new List<DictionaryPassword>();
            int[] at = new int[] { 140, 176, 41, 100, 43, 44, 45, 136, 46, 52, 50, 51, 137, 53, 55, 75, 173, 133, 135, 175, 174, 134, 72, 73, 42, 47, 74, 54, 76, 56, 77, 57, 40 };
            int[] ar = new int[62];
            for (int i = 0; i < ar.Length; i++)
            {
                if (i < 10)
                {
                    ar[i] = i + 48;
                }
                else if (i < 36)
                {
                    ar[i] = i + 55;
                }
                else
                {
                    ar[i] = i + 61;
                }
            }
            int[] allr = new int[at.Length + ar.Length];
            at.CopyTo(allr, 0);
            ar.CopyTo(allr, at.Length);
            getChars(allr, "", ref StrList);
            foreach (string item in StrList)
            {
                string pwd = PasswordHelper.HashPasswordForStoringInConfigFile(item, "md5");
                ldic.Add(new DictionaryPassword() { Password = pwd, Plaintext = item, CreateDate = DateTime.Now, PwdType = "md5" });
            }
            e.Result = ldic;
        }
        #endregion
        #region 组装4位密码
        /// <summary>
        /// 组装4位密码
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="str"></param>
        /// <param name="StrList"></param>
        public void getChars(int[] ar, string str, ref List<string> StrList)
        {
            if (str.Length > 4) { return; }
            foreach (int item in ar)
            {
                char c = (char)item;
                string strC = c.ToString();
                StrList.Add(strC);
                str += strC;
                getChars(ar, str, ref StrList);
            }
        }

        #endregion
    }
}
