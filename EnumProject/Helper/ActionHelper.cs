using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EnumProject.ButtonLogic;
using EnumSpace;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.ExcelEdit;
using EnumProject.ButtonLogic;
using EnumProject.Helper;

namespace EnumProject.Helper
{
    public class ActionHelper
    {

        #region 从一个对象复制到另一个对象
        /// <summary>
        /// 从一个对象复制到另一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="f">源对象</param>
        /// <param name="t">输出对象</param>
        /// <returns></returns>
        public static void cltocl<T>(T f, ref T t, List<string> param)
        {
            var ps = typeof(T).GetProperties();
            foreach (PropertyInfo item in ps)
            {
                object obj = item.GetValue(f, null);
                if (param.Contains(item.Name)) { continue; }
                Type tp = item.GetType();
                item.SetValue(t, obj, null);
            }
        }
        #endregion
        #region 从文件获取数据集合
        /// <summary>
        /// 从文件获取数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static void getListFromFile<T>()
        {
            string className = typeof(T).Name;
            Dictionary<string, string> fileinfo = getFileInfo<T>();
            string fileName = fileinfo["ExcelName"];
            string sheetName = fileinfo["SheetName"];
            List<T> Sourcelist = new List<T>();
            if (!PubulicData.sourceData.Keys.Contains(className))
            {
                PubulicData.sourceData.Add(className, Sourcelist);
            }
            else {
                PubulicData.sourceData[className] = Sourcelist;
            }
            ExcelEdit excel = new ExcelEdit();
            Dictionary<string, int> location = getColumn<T>();
            string str = System.Windows.Forms.Application.StartupPath;
            if (!File.Exists(str + @"\" + fileName)) { return; }
            excel.Open(str + @"\" + fileName);
            excel.ws = excel.GetSheet(sheetName);
            int rows = excel.ws.UsedRange.CurrentRegion.Rows.Count;
            for (int i = 2; i < rows + 1; i++)
            {
                T bd = Activator.CreateInstance<T>(); ;
                foreach (string j in location.Keys)
                {
                    Range titleRange = excel.ws.Range[excel.ws.Cells[i, location[j]], excel.ws.Cells[i, location[j]]];//选中标题 
                    if (titleRange.Value2 != null)
                    {
                        var gpt = typeof(T).GetProperties();
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
                Sourcelist.Add(bd);
            }
            excel.Close();

        }
        #endregion 
        #region 获取数据所在excel 中的条数
        public static int getDataInRow<T>(KeyValuePair<string, object> param)
        {
            Dictionary<string, string> fileinfo = getFileInfo<T>();
            ExcelEdit excel = new ExcelEdit();
            Dictionary<string, int> location = getColumn<T>();
            string fileName = fileinfo["ExcelName"];
            string sheetName = fileinfo["SheetName"];
            string str = System.Windows.Forms.Application.StartupPath;
            if (!File.Exists(str + @"\" + fileName)) { return 0; }
            excel.Open(str + @"\" + fileName);
            excel.ws = excel.GetSheet(sheetName);
            int rows = excel.ws.UsedRange.CurrentRegion.Rows.Count;
            int crow = 0;
            for (int i = 2; i < rows + 1; i++)
            {
                Range titleRange = excel.ws.Range[excel.ws.Cells[i, location[param.Key]], excel.ws.Cells[i, location[param.Key]]];//选中标题 
                if (titleRange.Value2 != null)
                {
                    var gpt = typeof(T).GetProperties();
                    var mt = gpt.FirstOrDefault(c => c.Name == param.Key);
                    if (mt != null)
                    {
                        object obj = new object();
                        if (titleRange.Value != null)
                        {
                            Type tp = mt.PropertyType;
                            dynamic value = titleRange.Value;
                            switch (param.Key)
                            {
                                case "CreateDate":
                                    tp = typeof(DateTime);
                                    value = DateTime.Now;
                                    break;
                            }
                            obj = Convert.ChangeType(value, tp);
                        }
                        else
                        {
                            obj = titleRange.Value;
                        }
                        if (obj.Equals(param.Value))
                        {
                            crow = i;
                            break;
                        }
                    }
                }
            }
            excel.Close();
            return crow;
        }

        #endregion

        #region 通过类名获取文件名称
        /// <summary>
        /// 通过类名获取文件名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> getFileInfo<T>()
        {
            Dictionary<string, string> ns = new Dictionary<string, string>();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string cname = typeof(T).Name;
            string ExcelName = config.AppSettings.Settings[cname + "Excel"].Value;
            string SheetName = config.AppSettings.Settings[cname + "Sheet"].Value;
            ns.Add("ExcelName", ExcelName);
            ns.Add("SheetName", SheetName);
            return ns;
        }
        #endregion
        #region 获取数据集合
        /// <summary>
        /// 获取所有数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static void getData<T>() where T : class
        {
            if (PubulicData.isDataFromSql)
            {
                getListFromSQL<T>();
            }
            else
            {
                getListFromFile<T>();
            }

        }
        #endregion
        #region 获取列的位置
        public static Dictionary<string, int> getColumn<T>()
        {
            Dictionary<string, int> location = new Dictionary<string, int>();
            var gpt = typeof(T).GetProperties();
            int i = 1;
            foreach (PropertyInfo item in gpt)
            {
                location.Add(item.Name, i);
                i++;
            }
            return location;
        }
        #endregion
        #region 修改按钮状态
        /// <summary>
        /// 修改按钮状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="State"></param>
        public static void ModifyButton(int id, string State)
        {
            var model = getInfo<ButtonDate>(new KeyValuePair<string, object>("ID", id));
            if (model == null) { return; }
            model.State = State;
            saveInfo<ButtonDate>(model);
        }
        #endregion
        #region 新增密码字典到数据库
        /// <summary>
        /// 修改按钮状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="State"></param>
        public static void ModifyPWDToSQL(DictionaryPassword PWD)
        {
            using (EnumDBContext ec = new EnumDBContext())
            {
                var dataAll = ec.Set<DictionaryPassword>();
                var model = dataAll.FirstOrDefault(c => c.Plaintext == PWD.Plaintext && c.Password == PWD.Password);
                if (model == null)
                {
                    dataAll.Add(PWD);
                }
                ec.SaveChanges();

            }
        }
        #endregion
        #region 从数据库获取数据集合
        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> getListFromSQL<T>() where T : class
        {
            EnumDBContext ec = new EnumDBContext();
            var Sourcelist = ec.Set<T>().ToList();
            ec.Dispose();
            string className = typeof(T).Name;
            if (!PubulicData.sourceData.Keys.Contains(className))
            {
                PubulicData.sourceData.Add(className, Sourcelist);
            }
            else
            {
                PubulicData.sourceData[className] = Sourcelist;
            }
            return Sourcelist;
        }
        #endregion
        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceData"></param>
        public static void saveData<T>(List<T> sourceData) where T : class
        {
            if (PubulicData.isDataFromSql)
            {
                saveDataToSql<T>(sourceData);
            }
            else
            {
                saveDataToFile<T>(sourceData);
            }

        }
        #endregion
        #region 保存数据到文件
        /// <summary>
        /// 保存数据到文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceData"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        public static void saveDataToFile<T>(List<T> sourceData)
        {
            Dictionary<string, string> fileinfo = getFileInfo<T>();
            string fileName = fileinfo["ExcelName"];
            string sheetName = fileinfo["SheetName"];
            ExcelEdit excel = new ExcelEdit();
            string str = System.Windows.Forms.Application.StartupPath;
            Worksheet ws = null;
            if (!Directory.Exists(str))
            {
                Directory.CreateDirectory(str);
            }
            if (!File.Exists(str + @"\" + fileName))
            {
                excel.mFilename = str + @"\" + fileName;
                excel.Create();
                excel.AddSheet(sheetName);
            }
            else
            {
                excel.Open(str + @"\" + fileName);
            }
            if (excel.GetSheet(sheetName) == null)
            {
                ws = excel.AddSheet(sheetName);
            }
            else
            {
                ws = excel.GetSheet(sheetName);
            }
            int y = 2;
            foreach (T item in sourceData)
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
            if (File.Exists(str + @"\" + fileName))
            {
                excel.Save();
            }
            else
            {
                excel.SaveAs(str + @"\" + fileName);
            }
            excel.Close();
        }
        #endregion
        #region 保存数据到数据库
        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public static void saveDataToSql<T>(List<T> a) where T : class
        {
            if (a.Count < 1) { return; }
            EnumDBContext db = new EnumDBContext();
            var lt = db.Set<T>();
            var ps = typeof(T).GetProperties();
            PropertyInfo pi = ps.FirstOrDefault(c => c.Name == "ID");
            foreach (T item in a)
            {
                T m = lt.FirstOrDefault(c => (Int32)pi.GetValue(item) == (Int32)pi.GetValue(c));
                if (m == null)
                {
                    lt.Add(item);
                }
                else
                {
                    cltocl<T>(item, ref m, new List<string>() { "ID" });
                }
            }
            db.SaveChanges();
            db.Dispose();

        }
        #endregion
        #region 保存一条数据
        /// <summary>
        /// 修改新增对象
        /// </summary>
        public static void saveInfo<T>(T A) where T : class
        {
            string cname = typeof(T).Name;
            var dataAll = PubulicData.sourceData[cname] as List<T>;
            var ps = typeof(T).GetProperties();
            PropertyInfo pi = ps.FirstOrDefault(c => c.Name == "ID");
            PropertyInfo piindex = ps.FirstOrDefault(c => c.Name == "Index");
            PropertyInfo pitype = ps.FirstOrDefault(c => c.Name == "Type");
            PropertyInfo pistate = ps.FirstOrDefault(c => c.Name == "State");
            List<string> param = new List<string>();
            param.Add("ID");
            if (piindex != null)
            {
                param.Add("Index");
            }
            var model = dataAll.FirstOrDefault(c => pi.GetValue(c).Equals(pi.GetValue(A)));
            if (model != null)
            {
                cltocl(A, ref model, param);
            }
            else
            {
                int mid = 0;
                int mindex = 0;
                if (pi != null)
                {
                    object objId = dataAll.Max(c => pi.GetValue(c));
                    if (objId != null)
                    {
                        int.TryParse(dataAll.Max(c => objId.ToString()), out mid);
                        mid++;
                        pi.SetValue(A, mid);
                    }
                }
                if (pitype != null && piindex != null && pistate != null)
                {
                    object objIndex = dataAll.Where(c => pitype.GetValue(c).Equals(pitype.GetValue(A)) && pistate.GetValue(c).ToString() == "show").Max(c => piindex.GetValue(c));
                    if (objIndex != null)
                    {
                        int.TryParse(dataAll.Max(c => objIndex.ToString()), out mindex);
                        mindex++;
                        piindex.SetValue(A, mindex);
                    }
                }
                dataAll.Add(A);
            }
            PubulicData.sourceData[cname] = dataAll;
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public static void Delete<T>(Dictionary<string, object> param) where T : class
        {
            if (param.Keys.Count < 1) { return; }
            using (EnumDBContext ec = new EnumDBContext())
            {
                var dataAll = ec.Set<T>();
                var ps = typeof(T).GetProperties();
                List<T> lt = new List<T>();
                foreach (string item in param.Keys)
                {
                    PropertyInfo pi = ps.FirstOrDefault(c => c.Name == item);
                    if (pi != null)
                    {
                        Type ty = pi.PropertyType;
                        lt.AddRange(dataAll.Where(c => Convert.ChangeType(pi.GetValue(c), ty) == Convert.ChangeType(param[item], ty)).ToList());
                    }
                }
                if (lt.Count < 1) { return; }
                dataAll.RemoveRange(lt);
                ec.SaveChanges();
            }
        }
        #endregion
        #region 获取数据实例
        /// <summary>
        /// 获取数据实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T getInfo<T>(KeyValuePair<string, object> param) where T : class
        {
            T A = (T)Activator.CreateInstance(typeof(T));
            if (string.IsNullOrEmpty(param.Key)) { return A; }
            var ps = typeof(T).GetProperties();
            PropertyInfo pi = ps.FirstOrDefault(c => c.Name == param.Key);
            if (pi == null) { return A; }
            Type ty = pi.PropertyType;
            string className = typeof(T).Name;
            var dataAll = PubulicData.sourceData[className] as List<T>;
            A = dataAll.FirstOrDefault(c => pi.GetValue(c).Equals(param.Value));
            return A;
        }
        #endregion
        #region 设置全局数据源
        /// <summary>
        /// 设置全局数据源
        /// </summary>
        public static void setSourse()
        {
            if (PubulicData.sourceData == null)
            {
                PubulicData.sourceData = new Dictionary<string, object>();
            }
            foreach (string item in Enum.GetNames(typeof(PubulicData.ClassName)))
            {
                //string assmName =Assembly.GetExecutingAssembly().GetName().Name;
                //Assembly assembly = Assembly.Load(assmName); 
                //Type type = assembly.GetType(assmName+ ".ButtonLogic." + item);
                //Object obj = type.Assembly.CreateInstance(type.ToString());
                switch (item) {
                    case "ButtonDate":
                        getData<ButtonDate>();
                        break;
                    case "DictionaryPassword":
                        Task.Run(() =>
                        {
                            getData<DictionaryPassword>();
                            PubulicData.isDicPWD = true;
                        });
                        break;
                }
               
            }
        }

        #endregion
        #region 保存全局数据源
        /// <summary>
        /// 保存全局数据源
        /// </summary>
        public static void saveSource()
        {
            if (PubulicData.sourceData.Keys.Contains(PubulicData.ClassName.ButtonDate.ToString()))
            {
                saveData(PubulicData.sourceData[PubulicData.ClassName.ButtonDate.ToString()] as List<ButtonDate>);
            }
            if (PubulicData.sourceData.Keys.Contains(PubulicData.ClassName.DictionaryPassword.ToString()))
            {
                saveData(PubulicData.sourceData[PubulicData.ClassName.DictionaryPassword.ToString()] as List<DictionaryPassword>);
            }
        }
        #endregion
    }
}
