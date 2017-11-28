using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace DataReport
{
    public class ConnCollection : CollectionBase
    {
        public SqlConnection this[int index]
        {
            get
            {
                return ((SqlConnection)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(SqlConnection value)
        {
            //base.InnerList.Add(value);
            return (List.Add(value));
        }

        public int IndexOf(SqlConnection value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, SqlConnection value)
        {
            List.Insert(index, value);
        }

        public void Remove(SqlConnection value)
        {
            List.Remove(value);
        }

        public bool Contains(SqlConnection value)
        {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(SqlConnection))
                throw new ArgumentException("value must be of type Int16.", "value");
        }
    }

    class gAppData
    {
        public static int iSHCount = 0;
        public static int iCurrentSH = 0;
        public static string dataconn = "";
        public static string server1 = "";
        public static string server2 = "";
        public static bool isLogin = false;
        public static string user = "";
        public static string pwd = "";
        public static string[] SHName = new string[50];
        public static ConnCollection pConn = new ConnCollection();
        public static string baseTitle = "数据分析查询器";


        //申明INI文件的写操作函数WritePrivateProfileString()
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //申明INI文件的读操作函数GetPrivateProfileString()
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static DataSet getdataset(string tablename, string StartDate, string EndDate, string objectType, string searchobject)
        {
            string sql = "";
            switch (tablename)
            {
                case "Alarm_Data_View":
                case "Vid_Data_View":
                    if (searchobject == "全部对象")
                    {
                        sql = "select * from " + tablename + " where 采集时间 between '" + StartDate + "' and '" + EndDate + "'" + " order by [采集时间] desc";
                    }
                    else
                    {
                        sql = "select * from " + tablename + " where 采集时间 between '" + StartDate + "' and '" + EndDate + "' and 设备名称 = '" + searchobject + "'" + " order by [采集时间] desc";
                    }
                    break;
                default:
                    break;
            }
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql,dataconn);                
                da.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
            return ds;
        }

        //绑定combobox获取某列值
        public static DataSet GetDS(string tablename, string columnname)
        {
            string sql = "";
            switch(tablename)
            {
                case "车检器VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='车辆检测仪'";
                    break;
                case "COVIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='CO检测仪'";
                    break;
                case "VIVIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='VI检测仪'";
                    break;
                case "风速VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='风向/风速检测仪'";
                    break;
                case "光检VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='光强检测仪'";
                    break;
                case "风机运行VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='风机'";
                    break;
                case "照明VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 ='灯'";
                    break;
                default:
                    sql = "select distinct " + columnname + " form " + tablename;
                    break;
            }
            
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
               
                da.Fill(ds, tablename);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
            return ds;
        }
        //输入表名和列名从system表中查询数据集
        public static DataSet Getds(string tablename, string columnname)
        {
            string conn_str = dataconn;
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            string sql = "select distinct " + columnname + " from " + tablename;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //输入sql语句获取数据集
        public static DataSet GetDS(string sql)
        {
            string order = sql.Substring(0, 6);
            order = order.ToLower();
            if (order != "select")
            {
                MessageBox.Show("你输入的sql语句不是正确的查询语句，请重新输入！");
                return null;
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, dataconn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        public static DataSet GetDS(string tablename, string columnname1, string columnname2, string col2Value)
        {
            string sql;
            if (col2Value == "全部对象")
            {
                sql = "select distinct " + columnname1 + " from " + tablename;
            }
            else
            {
                sql = "select distinct " + columnname1 + " from " + tablename + " where " + columnname2 + " = '" + col2Value + "'";
            }
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, dataconn);
                
                da.Fill(ds, tablename);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
            return ds;
        }
        public static bool GetSystemDataBase()
        {
            if (gAppData.dataconn == "")
                return false;
            string str_conn, str_sql;
            str_conn = gAppData.dataconn;
            SqlConnection sqlconn = new SqlConnection(str_conn);
            sqlconn.Open();
            str_sql = "select * from 主机地址表 where 身份描述='本地' order by 身份ID ASC";
            SqlCommand cmd = new SqlCommand(str_sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            iSHCount = 0;
            if (!dr.HasRows)
                return false;
            while (dr.Read())
            {
                SHName[iSHCount] = dr["身份备注"].ToString();
                iSHCount++;
                //dr.NextResult();
            }
            return true;
        }
        //初始化用户列表
        public static DataSet AddUserToCombobox()
        {
            DataSet ds = new DataSet();
            string sql = "select distinct USER_ID from UserInfo";
            string str_conn = gAppData.dataconn;
            SqlDataAdapter da = new SqlDataAdapter(sql, str_conn);
            da.Fill(ds);
            return ds;
        }
        //判断用户是否存在
        public static int HasUser(string user, string pwd)
        {
            int count = 0;
            string sql = "select count(*) from UserInfo where USER_ID='" + user + "' and PWD = '" + pwd + "'";
            string str_conn = gAppData.dataconn;
            SqlConnection sqlconn = new SqlConnection(str_conn);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            count = (int)cmd.ExecuteScalar();
            return count;
        }
        //返回查询条数
        public static int returnCount(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, pConn[iCurrentSH]);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }
        //输入sql语句执行
        public static int RunSql(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, pConn[iCurrentSH]);
                return (int)cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 1;
        }

        public static void DataGridViewExport(DataGridView dataGridView1, string sFileName, bool bTitle, string sDefaultFGF)
        {
            if ((dataGridView1 != null) && (dataGridView1.Rows.Count != 0))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.DefaultExt = "Excel Document";
                dialog.Filter = "Excel Document|*.xls|TXT文件|*.txt";
                dialog.FileName = sFileName;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //验证以fileNameString命名的文件是否存在，如果存在删除它   
                    FileInfo file = new FileInfo(dialog.FileName);
                    if (file.Exists)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (dialog.FilterIndex == 1)
                        DataGridViewToExcel(dataGridView1, dialog.FileName, bTitle, sDefaultFGF);
                    else if (dialog.FilterIndex == 2)
                        DataGridViewExportTXT(dataGridView1, dialog.FileName, bTitle, sDefaultFGF);
                    else
                        MessageBox.Show("未选择合适的文件格式!");
                }
            }
            else
                MessageBox.Show("请先执行查询操作！");

        }
        private static void DataGridViewToExcel(DataGridView dgv, string path, bool bTitle, string sDefaultFGF)
        {
            Stream myStream;
            myStream = File.Open(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string columnTitle = "";
            try
            {
                //写入列标题  
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgv.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容  
                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgv.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        if (dgv.Rows[j].Cells[k].Value == null)
                            columnValue += "";
                        else
                            columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                    }
                    sw.WriteLine(columnValue);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        private static void DataGridViewExportTXT(DataGridView dataGridView1, string path, bool bTitle, string sDefaultFGF)
        {
            string text2;
            int num4;
            int count = dataGridView1.Rows.Count;
            int num2 = dataGridView1.Columns.Count;
            if (bTitle)
            {
                text2 = "";
                for (num4 = 0; num4 < num2; num4++)
                {
                    if (dataGridView1.Columns[num4].Visible)
                    {
                        text2 = text2 + dataGridView1.Columns[num4].HeaderText + sDefaultFGF;
                    }
                }
                if (text2 != "")
                {
                    File.AppendAllText(path, text2 + "\r\n");
                }
            }
            for (int i = 0; i < (count - 1); i++)
            {
                text2 = "";
                for (num4 = 0; num4 < num2; num4++)
                {
                    if (dataGridView1.Columns[num4].Visible)
                    {
                        if (dataGridView1.Columns[num4].ValueType == Type.GetType("System.DateTime"))
                        {
                            text2 = text2 + Convert.ToDateTime(dataGridView1.Rows[i].Cells[num4].Value).ToString("yyyy\u5e74MM\u6708dd\u65e5") + sDefaultFGF;
                        }
                        else
                        {
                            text2 = text2 + dataGridView1.Rows[i].Cells[num4].Value.ToString() + sDefaultFGF;
                        }
                    }
                }
                if (text2 != "")
                {
                    File.AppendAllText(path, text2 + "\r\n");
                }
            }
            MessageBox.Show(path + "\u6587\u4ef6\u5bfc\u51fa\u6210\u529f\uff01", "\u7cfb\u7edf\u63d0\u793a", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        //高级查询调用的查询方法

        /// <summary>
        /// 只有条件1的情况
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colName">查询字段</param>
        /// <param name="criteria">查询条件</param>
        /// <param name="value">查询值</param>
        /// <param name="starttime">起始时间</param>
        /// <param name="endtime">终止时间</param>
        /// <param name="ordercol1">排序列1</param>
        /// <param name="orderType1">排序类型1</param>
        /// <param name="ordercol2">排序列2</param>
        /// <param name="orderType2">排序类型2</param>
        /// <returns></returns>
        public static DataSet GetExpertSearch(string tablename, string colName, string criteria, string value, string starttime, string endtime, string ordercol1, string orderType1, string ordercol2, string orderType2)
        {
            string sql = "";
            DataSet ds = new DataSet();
            if (ordercol1 == "无")
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where " + colName + criteria + "'" + value + "' and 时间日期 between '" + starttime + " 'and '" + endtime + "'";
                }
                else
                {
                    sql = "select * from " + tablename + " where " + colName + criteria + "'" + value + "' and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol2 + " " + orderType2;
                }
            }
            else
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where " + colName + criteria + "'" + value + "' and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1;
                }
                else
                {
                    sql = "select * from " + tablename + " where " + colName + criteria + "'" + value + "' and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1 + "," + ordercol2 + " " + orderType2;
                }
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
                da.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        public static DataSet GetExpertSearch(string tablename, string colName, string criteria, string value, string colName2, string criteria2, string value2, string starttime, string endtime, string ordercol1, string orderType1, string ordercol2, string orderType2,string relation)
        {
            DataSet ds = new DataSet();
            string sql = "";
            if (ordercol1 == "无")
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where (" + colName + criteria + "'" + value + "' "+relation+" "+colName2 + criteria2 +"'"+value2+"') and 时间日期 between '" + starttime + " 'and '" + endtime + "'";
                }
                else
                {
                    sql = "select * from " + tablename + " where (" + colName + criteria + "'" + value + "' and " + colName2 + criteria2 + "'" + value2 + "') and 时间日期 between '" + starttime + "' " + relation + " " + endtime + "' order by " + ordercol2 + " " + orderType2;
                }
            }
            else
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where (" + colName + criteria + "'" + value + "' " + relation + " " + colName2 + criteria2 + "'" + value2 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1;
                }
                else
                {
                    sql = "select * from " + tablename + " where (" + colName + criteria + "'" + value + "' " + relation + " " + colName2 + criteria2 + "'" + value2 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1 + "," + ordercol2 + " " + orderType2;
                }
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
                da.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        public static DataSet GetExpertSearch(string tablename, string colName, string criteria, string value, string colName2, string criteria2, string value2, string colName3, string criteria3, string value3, string starttime, string endtime, string ordercol1, string orderType1, string ordercol2, string orderType2,string relation1,string relation2)
        {
            DataSet ds = new DataSet();
            string sql = "";
            if (ordercol1 == "无")
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where ((" + colName + criteria + "'" + value + "' " + relation1 + " " + colName2 + criteria2 + "'" + value2 + "') " + relation2 + " " + colName3 + criteria3 + "'" + value3 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "'";
                }
                else
                {
                    sql = "select * from " + tablename + " where ((" + colName + criteria + "'" + value + "' " + relation1 + " " + colName2 + criteria2 + "'" + value2 + "') " + relation2 + " " + colName3 + criteria3 + "'" + value3 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol2 + " " + orderType2;
                }
            }
            else
            {
                if (ordercol2 == "无")
                {
                    sql = "select * from " + tablename + " where ((" + colName + criteria + "'" + value + "' " + relation1 + " " + colName2 + criteria2 + "'" + value2 + "') " + relation2 + " " + colName3 + criteria3 + "'" + value3 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1;
                }
                else
                {
                    sql = "select * from " + tablename + " where ((" + colName + criteria + "'" + value + "' " + relation1 + " " + colName2 + criteria2 + "'" + value2 + "') " + relation2 + " " + colName3 + criteria3 + "'" + value3 + "') and 时间日期 between '" + starttime + " 'and '" + endtime + "' order by " + ordercol1 + " " + orderType1 + "," + ordercol2 + " " + orderType2;
                }
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
                da.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public static DataSet getTotalflow(string StartDate, string EndDate, string objectType, string searchobject)
        {
            DataSet ds = new DataSet();
            string sql = "";
            if (searchobject == "全部对象")
            {
                sql = "select sum(总车流量) 总车流量,行车方向 from 车检器VIEW where 行车方向 in ('左线','右线') and  时间日期>='" + StartDate + "' and 时间日期<='" + EndDate + "' group by 行车方向";
                if (gAppData.SHName[iCurrentSH] == "中梁山隧道")
                {
                    sql = "select sum(总车流量) 总车流量,行车方向 from 车检器VIEW where ((行车方向='左线' and 对象名 not in ('西口微波车检','东口微波车检')) or (行车方向 in ('左线','右线') and 对象名 in('西口微波车检','东口微波车检'))) and  时间日期>='" + StartDate + "' and 时间日期<='" + EndDate + "' group by 行车方向";
                }
            }
            else
            {
                sql = "select sum(总车流量) 总车流量,行车方向 from 车检器VIEW where  行车方向 in ('左线','右线') and 对象名 = '" + searchobject + "' and 时间日期>='" + StartDate + "' and 时间日期<='" + EndDate + "' group by 行车方向";
                if (gAppData.SHName[iCurrentSH] == "中梁山隧道")
                {
                    if (searchobject == "西口微波车检" || searchobject == "东口微波车检")
                    {
                        sql = "select sum(总车流量) 总车流量,行车方向 from 车检器VIEW where 对象名 = '" + searchobject + "' and 行车方向 in('左线','右线') and 时间日期>='" + StartDate + "' and 时间日期<='" + EndDate + "' group by 行车方向";
                    }
                    else
                    {
                        sql = "select sum(总车流量) 总车流量,行车方向 from 车检器VIEW where 对象名 = '" + searchobject + "' and 行车方向 ='左线' and 时间日期>='" + StartDate + "' and 时间日期<='" + EndDate + "' group by 行车方向";
                    }
                }
            }
                SqlDataAdapter da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
                da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sql = sql.Replace("左线", "上行");
                sql = sql.Replace("右线", "下行");
                da = new SqlDataAdapter(sql, pConn[iCurrentSH]);
                da.Fill(ds);
            }
            return ds;
        }
    }  
}
