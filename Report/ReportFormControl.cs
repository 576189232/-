using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DataReport
{
    public partial class ReportFormControl : UserControl
    {
        public string ReportFormType;
        private int iCurrentLine;
        private ReportFormTemp m_reportForm = new ReportFormTemp();
        private string strTypetitle;//报表类型(日、月、年)
        private string TitleName;//统计项目
        private string strStatsTime;//统计时间
        private string strStatsObject;//统计对象
        private string strTabulateTime;//制表时间
        int[] columnsWidth = new int[20];//得到所有列的个数
        int[] columnsLeft = new int[20]; //
        int iLinePerPage = 32;//设置每页打印记录条数
        string tableName = "";
        private int iFreeSpace;
        private int tableLeft;
        delegate void DelegateMaskForm();//委托 用委托的方式显示加载提示画面
        DelegateMaskForm handleDelegate;
        Thread td;

        public ReportFormControl()
        {
            InitializeComponent();
            handleDelegate = new DelegateMaskForm(StarPro);
        }

        public void StarPro()
        {
            td = new Thread(MaskForm);
            td.Start();
        }

        private void MaskForm()
        {
            try
            {
                waitFrm frm = new waitFrm();
                frm.ShowDialog();
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //查询报表数据 CO-VI-风速-光检
        private void btn_search_Click(object sender, EventArgs e)
        {
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            string[] strsql = new string[31];
            string strTotal = "";
            string strSQL = "";
            int num = 0;
            int year = 2010;
            int month = 1;
            string stattime = "";
            string strDatetime = "";
            string strStartDatetime = "";
            string strEndDatetime = "";
            string objectName = "";
            string temptime = "";
            
            if (ReportFormType == "日报表")
            {
                num = 24;
                if (tabControl.SelectedIndex == 0)
                {
                    tableName = "COVIEW";                    
                    objectName = Combo_SearchObj.SelectedValue.ToString();
                    temptime = dateTimePicker0.Text;
                    stattime = temptime;
                }
                if (tabControl.SelectedIndex == 1)
                {
                    tableName = "VIVIEW";
                    objectName = Combo_SearchObj1.SelectedValue.ToString();
                    temptime = dateTimePicker1.Text;
                    stattime = temptime;
                }
                if (tabControl.SelectedIndex == 2)
                {
                    tableName = "风速VIEW";
                    objectName = Combo_SearchObj2.SelectedValue.ToString();
                    temptime = dateTimePicker2.Text;
                    stattime = temptime;
                }
                if (tabControl.SelectedIndex == 3)
                {
                    tableName = "光检VIEW";
                    objectName = Combo_SearchObj3.SelectedValue.ToString();
                    temptime = dateTimePicker3.Text;
                    stattime = temptime;
                }
            }

            if (ReportFormType == "月报表")
            {
                if (tabControl.SelectedIndex == 0)
                {
                    tableName = "COVIEW";
                    if (comboBox_month.SelectedItem == null || comboBox_year.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        return;
                    }
                    objectName = Combo_SearchObj.SelectedValue.ToString();
                    month = Convert.ToInt32(comboBox_month.SelectedItem.ToString());
                    year = Convert.ToInt32(comboBox_year.SelectedItem.ToString());
                    temptime = comboBox_year.SelectedItem.ToString() + "-" + comboBox_month.SelectedItem.ToString();
                    stattime = comboBox_year.SelectedItem.ToString() + "年" + comboBox_month.SelectedItem.ToString() + "月";
                }
                if (tabControl.SelectedIndex == 1)
                {
                    tableName = "VIVIEW";
                    if (comboBox_month1.SelectedItem == null || comboBox_year1.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");                        
                        return;
                    }
                    objectName = Combo_SearchObj1.SelectedValue.ToString();
                    month = Convert.ToInt32(comboBox_month1.SelectedItem.ToString());
                    year = Convert.ToInt32(comboBox_year1.SelectedItem.ToString());
                    temptime = comboBox_year1.SelectedItem.ToString() + "-" + comboBox_month1.SelectedItem.ToString();
                    stattime = comboBox_year1.SelectedItem.ToString() + "年" + comboBox_month1.SelectedItem.ToString() + "月";
                }
                if (tabControl.SelectedIndex == 2)
                {
                    tableName = "风速VIEW";
                    if (comboBox_month2.SelectedItem == null || comboBox_year2.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        return;
                    }
                    objectName = Combo_SearchObj2.SelectedValue.ToString();
                    month = Convert.ToInt32(comboBox_month2.SelectedItem.ToString());
                    year = Convert.ToInt32(comboBox_year2.SelectedItem.ToString());
                    temptime = comboBox_year2.SelectedItem.ToString() + "-" + comboBox_month2.SelectedItem.ToString();
                    stattime = comboBox_year2.SelectedItem.ToString() + "年" + comboBox_month2.SelectedItem.ToString() + "月";
                }
                if (tabControl.SelectedIndex == 3)
                {
                    tableName = "光检VIEW";
                    objectName = Combo_SearchObj3.SelectedValue.ToString();
                    if (comboBox_month3.SelectedItem == null || comboBox_year3.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        //td.Abort();
                        return;
                    }
                    month = Convert.ToInt32(comboBox_month3.SelectedItem.ToString());
                    year = Convert.ToInt32(comboBox_year3.SelectedItem.ToString());
                    temptime = comboBox_year3.SelectedItem.ToString() + "-" + comboBox_month3.SelectedItem.ToString();
                    stattime = comboBox_year3.SelectedItem.ToString() + "年" + comboBox_month3.SelectedItem.ToString() + "月";
                }
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    num = 31;
                }
                else if (month == 2 && year % 4 == 0)
                {
                    num = 29;
                }
                else if (month == 2)
                {
                    num = 28;
                }
                else
                {
                    num = 30;
                }
            }

            if (ReportFormType == "年报表")
            {
                if (tabControl.SelectedIndex == 0)
                {
                    tableName = "COVIEW";
                    if (comboBox_year.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        //td.Abort();
                        return;
                    }
                    objectName = Combo_SearchObj.SelectedValue.ToString();
                    year = Convert.ToInt32(comboBox_year.SelectedItem.ToString());
                    temptime = comboBox_year.SelectedItem.ToString();
                    stattime = comboBox_year.SelectedItem.ToString() + "年";
                }
                if (tabControl.SelectedIndex == 1)
                {
                    tableName = "VIVIEW";
                    if (comboBox_year1.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        //td.Abort();
                        return;
                    }
                    objectName = Combo_SearchObj1.SelectedValue.ToString();
                    year = Convert.ToInt32(comboBox_year1.SelectedItem.ToString());
                    temptime = comboBox_year1.SelectedItem.ToString();
                    stattime = comboBox_year1.SelectedItem.ToString() + "年";
                }
                if (tabControl.SelectedIndex == 2)
                {
                    tableName = "风速VIEW";
                    if (comboBox_year2.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        //td.Abort();
                        return;
                    }
                    objectName = Combo_SearchObj2.SelectedValue.ToString();
                    year = Convert.ToInt32(comboBox_year2.SelectedItem.ToString());
                    temptime = comboBox_year2.SelectedItem.ToString();
                    stattime = comboBox_year2.SelectedItem.ToString() + "年";
                }
                if (tabControl.SelectedIndex == 3)
                {
                    tableName = "光检VIEW";
                    if (comboBox_year3.SelectedItem == null)
                    {
                        td.Abort();
                        MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                        //td.Abort();
                        return;
                    }
                    objectName = Combo_SearchObj3.SelectedValue.ToString();
                    year = Convert.ToInt32(comboBox_year3.SelectedItem.ToString());
                    temptime = comboBox_year3.SelectedItem.ToString();
                    stattime = comboBox_year3.SelectedItem.ToString() + "年";
                }
                num = 12;
            }

            if (objectName == "")
            {
                td.Abort();
                MessageBox.Show("你还没有选择查询对象，请选择！");
                //td.Abort();
                return;
            }
            for (int i = 0; i < num; i++)
            {
                strStartDatetime = strEndDatetime = temptime;
                if (ReportFormType == "日报表")
                {
                    strDatetime = i.ToString() + "点";
                    strStartDatetime = temptime + " " + i.ToString() + ":00:00";
                    strEndDatetime = temptime + " " + i.ToString() + ":59:59";
                }
                if (ReportFormType == "月报表")
                {
                    strDatetime = (i+1).ToString() + "日";
                    strStartDatetime = temptime + "-" + (i + 1).ToString() + " 00:00:00";
                    strEndDatetime = temptime + "-" + (i + 1).ToString() + " 23:59:59";
                }
                if (ReportFormType == "年报表")
                {
                    strDatetime = (i+1).ToString() + "月";
                    if (i + 1 == 1 || i + 1 == 3 || i + 1 == 5 || i + 1 == 7 || i + 1 == 8 || i + 1 == 10 || i + 1 == 12)
                    {
                        month = 31;
                    }
                    else if (i + 1 == 2 && year % 4 == 0)
                    {
                        month = 29;
                    }
                    else if (i + 1 == 2)
                    {
                        month = 28;
                    }
                    else
                    {
                        month = 30;
                    }
                    strStartDatetime = temptime + "-" + (i + 1).ToString() + "-01 00:00:00";
                    strEndDatetime = temptime + "-" + (i + 1).ToString() + "-" + month.ToString() + " 23:59:59";
                }
                if (objectName =="全部对象")
                {
                    strsql[i] = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(检测值)), 最小值= min(abs(检测值)),平均值=avg(abs(检测值)) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "'";
                }
                else
                {
                    strsql[i] = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(检测值)), 最小值= min(abs(检测值)),平均值=avg(abs(检测值)) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 对象名 = '" + objectName + "'";
                }
            }

            strStartDatetime = strEndDatetime = temptime;
            if (ReportFormType == "日报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + " 00:00:00";
                strEndDatetime = temptime + " 23:59:59";
            }
            if (ReportFormType == "月报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + "-01 00:00:00";
                strEndDatetime = temptime + "-" + num.ToString() + " 23:59:59";
            }
            if (ReportFormType == "年报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + "-01-01 00:00:00";
                strEndDatetime = temptime + "-12-31 23:59:59";
            }
            //strTotal = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(最大值)), 最小值= min(abs(最小值)),平均值=avg(abs(平均值)) from 遥测临时表 ";

            if (objectName == "全部对象")
            {
                strTotal = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(检测值)), 最小值= min(abs(检测值)),平均值=avg(abs(检测值)) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "'";
            }
            else
            {
                strTotal = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(检测值)), 最小值= min(abs(检测值)),平均值=avg(abs(检测值)) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 对象名 = '" + objectName + "'";
            }
            gAppData.RunSql("delete from 遥测临时表");
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                    strSQL += strsql[i];
                else
                    strSQL += ";" + strsql[i];
            }            
            int nCount = gAppData.RunSql(strSQL);
            nCount = gAppData.RunSql(strTotal);
            DataSet ds1 = new DataSet();
            ds1 = gAppData.GetDS("select * from 遥测临时表");
            
            dg_ReportForm.DataSource = ds1.Tables[0];
           
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    //重命名列头
                    dg_ReportForm.Columns[0].HeaderCell.Value = "日期时间";
                    dg_ReportForm.Columns[1].HeaderCell.Value = "最大值(ppm)";
                    dg_ReportForm.Columns[2].HeaderCell.Value = "最小值(ppm)";
                    dg_ReportForm.Columns[3].HeaderCell.Value = "平均值(ppm)";
                    break;
                case 1:
                    //重命名列头
                    dg_ReportForm.Columns[0].HeaderCell.Value = "日期时间";
                    dg_ReportForm.Columns[1].HeaderCell.Value = "最大值(1/km)";
                    dg_ReportForm.Columns[2].HeaderCell.Value = "最小值(1/km)";
                    dg_ReportForm.Columns[3].HeaderCell.Value = "平均值(1/km)";
                    break;
                case 2:
                    //重命名列头
                    dg_ReportForm.Columns[0].HeaderCell.Value = "日期时间";
                    dg_ReportForm.Columns[1].HeaderCell.Value = "最大值(m/s)";
                    dg_ReportForm.Columns[2].HeaderCell.Value = "最小值(m/s)";
                    dg_ReportForm.Columns[3].HeaderCell.Value = "平均值(m/s)";
                    //dg_ReportForm.Columns[4].HeaderCell.Value = "平均车头时距(s)";
                    break;
                case 3:
                    //重命名列头
                    dg_ReportForm.Columns[0].HeaderCell.Value = "日期时间";
                    dg_ReportForm.Columns[1].HeaderCell.Value = "最大值(cd/m2)";
                    dg_ReportForm.Columns[2].HeaderCell.Value = "最小值(cd/m2)";
                    dg_ReportForm.Columns[3].HeaderCell.Value = "平均值(cd/m2)";
                    //dg_ReportForm.Columns[4].HeaderCell.Value = "平均车头时距(s)";
                    break;
            }
            printDocument1_BeginPrint(null,null);//设置一些打印报表时的标题等参数
            m_reportForm.m_ds = ds1;
            m_reportForm.m_TableName = tableName;
            m_reportForm.m_ReportType = ReportFormType;
            m_reportForm.m_Object = objectName;
            m_reportForm.m_Title = strTypetitle;
            m_reportForm.m_DateTime = strStatsTime;
            m_reportForm.m_Type = TitleName;
            td.Abort();
        }

        //车检仪报表
        private void btn_search4_Click(object sender, EventArgs e)
        {
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            string[] strsql = new string[31];
            string strTotal = "";
            string strSQL = "";
            int num = 0;
            int year = 2010;
            int month = 1;
            string stattime = "";
            string strDatetime = "";
            string strStartDatetime = "";
            string strEndDatetime = "";
            string objectName = "";
            string temptime = "";
            string tableName = "";
            string way = "";
            if (comboBox_Line.SelectedItem == null)
            {
                td.Abort();
                MessageBox.Show("你还没有选择行车方向，请选择！");
                return;
            }
            way = comboBox_Line.SelectedItem.ToString();
            if (ReportFormType == "日报表")
            {
                num = 24;
                tableName = "车检器VIEW";
                objectName = Combo_SearchObj4.SelectedValue.ToString();
                temptime = dateTimePicker4.Text;
                stattime = temptime;
            }
            if (ReportFormType == "月报表")
            {
                tableName = "车检器VIEW";
                objectName = Combo_SearchObj4.SelectedValue.ToString();
                if (comboBox_year4.SelectedItem == null || comboBox_month4.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    return;
                }
                month = Convert.ToInt32(comboBox_month4.SelectedItem.ToString());
                year = Convert.ToInt32(comboBox_year4.SelectedItem.ToString());
                temptime = year.ToString() + "-" + month.ToString();
                stattime = year.ToString() + "年" + month.ToString() + "月";
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    num = 31;
                }
                else if (month == 2 && year % 4 == 0)
                {
                    num = 29;
                }
                else if (month == 2)
                {
                    num = 28;
                }
                else
                {
                    num = 30;
                }
            }
            if (ReportFormType == "年报表")
            {
                num = 12;
                tableName = "车检器VIEW";
                if (comboBox_year4.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    //td.Abort();
                    return;
                }
                objectName = Combo_SearchObj4.SelectedValue.ToString();
                year = Convert.ToInt32(comboBox_year4.SelectedItem.ToString());
                temptime = comboBox_year4.SelectedItem.ToString();
                stattime = comboBox_year4.SelectedItem.ToString() + "年";
            }
            if (objectName == "")
            {
                td.Abort();
                MessageBox.Show("你还没有选择查询对象，请选择！");
                return;
            }
            if (way == "")
            {
                td.Abort();
                MessageBox.Show("你还没有选择行车方向，请选择！");
                return;
            }
            for (int i = 0; i < num; i++)
            {
                strStartDatetime = strEndDatetime = temptime;
                if (ReportFormType == "日报表")
                {
                    strDatetime = i.ToString() + "点";
                    strStartDatetime = temptime + " " + i.ToString() + ":00:00";
                    strEndDatetime = temptime + " " + i.ToString() + ":59:59";
                }
                if (ReportFormType == "月报表")
                {
                    strDatetime = (i + 1).ToString() + "日";
                    strStartDatetime = temptime + "-" + (i + 1).ToString() + " 00:00:00";
                    strEndDatetime = temptime + "-" + (i + 1).ToString() + " 23:59:59";
                }
                if (ReportFormType == "年报表")
                {
                    strDatetime = (i + 1).ToString() + "月";
                    if (i + 1 == 1 || i + 1 == 3 || i + 1 == 5 || i + 1 == 7 || i + 1 == 8 || i + 1 == 10 || i + 1 == 12)
                    {
                        month = 31;
                    }
                    else if (i + 1 == 2 && year % 4 == 0)
                    {
                        month = 29;
                    }
                    else if (i + 1 == 2)
                    {
                        month = 28;
                    }
                    else
                    {
                        month = 30;
                    }
                    strStartDatetime = temptime + "-" + (i + 1).ToString() + "-01 00:00:00";
                    strEndDatetime = temptime + "-" + (i + 1).ToString() + "-" + month.ToString() + " 23:59:59";
                }
                if (objectName == "全部对象")
                {
                    strsql[i] = "insert into 车检报表临时表 select '日期时间' = '" + strDatetime + "',总车流量=sum(总车流量), 平均速度= avg(总平均车速),平均占有率=avg(总平均占有率),平均车头时距=avg(总平均车头时距) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 行车方向= '" + way + "'";
                }
                else
                {
                    strsql[i] = "insert into 车检报表临时表 select '日期时间' = '" + strDatetime + "',总车流量=sum(总车流量), 平均速度= avg(总平均车速),平均占有率=avg(总平均占有率),平均车头时距=avg(总平均车头时距) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 行车方向='" + way
+ "' and 对象名 = '" + objectName + "'";
                }
            }

            strStartDatetime = strEndDatetime = temptime;
            if (ReportFormType == "日报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + " 00:00:00";
                strEndDatetime = temptime + " 23:59:59";
            }
            if (ReportFormType == "月报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + "-01 00:00:00";
                strEndDatetime = temptime + "-" + num.ToString() + " 23:59:59";
            }
            if (ReportFormType == "年报表")
            {
                strDatetime = "总计";
                strStartDatetime = temptime + "-01-01 00:00:00";
                strEndDatetime = temptime + "-12-31 23:59:59";
            }
            //strTotal = "insert into 遥测临时表 select '日期时间' = '" + strDatetime + "',最大值=max(abs(最大值)), 最小值= min(abs(最小值)),平均值=avg(abs(平均值)) from 遥测临时表 ";

            if (objectName == "全部对象")
            {
                strTotal = "insert into 车检报表临时表 select '日期时间' = '" + strDatetime + "',总车流量=sum(总车流量), 平均速度= avg(总平均车速),平均占有率=avg(总平均占有率),平均车头时距=avg(总平均车头时距) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 行车方向= '" + way + "'";
            }
            else
            {
                strTotal = "insert into 车检报表临时表 select '日期时间' = '" + strDatetime + "',总车流量=sum(总车流量), 平均速度= avg(总平均车速),平均占有率=avg(总平均占有率),平均车头时距=avg(总平均车头时距) from " + tableName + " where 时间日期 between '" + strStartDatetime + "' and '" + strEndDatetime + "' and 行车方向='" + way
+ "' and 对象名 = '" + objectName + "'";
            }
            gAppData.RunSql("delete from 车检报表临时表");
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                    strSQL += strsql[i];
                else
                    strSQL += ";" + strsql[i];
            }
            if (way == "左线" || way == "右线")
            {

                string tempsql = "select count(1) from 车检遥测表 where 行车方向 in ('左线','右线')";
                int iRownum = gAppData.returnCount(tempsql);
                if (iRownum <= 0)//如果车检仪view中没有行车方向为左线或右线的数据，则将左线改为上行，右线改为下行再查询过
                {
                    strSQL = strSQL.Replace("左线", "上行");
                    strSQL = strSQL.Replace("右线", "下行");
                    strTotal = strTotal.Replace("左线", "上行");
                    strTotal = strTotal.Replace("右线", "下行");
                }
            }
            if (way == "上行" || way == "下行")
            {

                string tempsql = "select count(1) from 车检遥测表 where 行车方向 in ('上行','下行')";
                int iRownum = gAppData.returnCount(tempsql);
                if (iRownum <= 0)//如果车检仪view中没有行车方向为左线或右线的数据，则将左线改为上行，右线改为下行再查询过
                {
                    strSQL = strSQL.Replace("上行", "左线");
                    strSQL = strSQL.Replace("下行", "右线");
                    strTotal = strTotal.Replace("上行", "左线");
                    strTotal = strTotal.Replace("下行", "右线");
                }
            }
            int nCount = gAppData.RunSql(strSQL);
            nCount = gAppData.RunSql(strTotal);

            DataSet ds1 = new DataSet();
            ds1 = gAppData.GetDS("select * from 车检报表临时表");
            td.Abort();
            dg_ReportForm.DataSource = ds1.Tables[0];
            printDocument1_BeginPrint(null, null);//设置一些打印报表时的标题等参数
            m_reportForm.m_ds = ds1;
            m_reportForm.m_TableName = tableName;
            m_reportForm.m_ReportType = ReportFormType;
            m_reportForm.m_Object = objectName;
            m_reportForm.m_Title = strTypetitle;
            m_reportForm.m_DateTime = strStatsTime;
            m_reportForm.m_Type = TitleName;
            //重命名列头
            dg_ReportForm.Columns[0].HeaderCell.Value = "日期时间";
            dg_ReportForm.Columns[1].HeaderCell.Value = "总车流量(辆)";
            dg_ReportForm.Columns[2].HeaderCell.Value = "平均速度(km/h)";
            dg_ReportForm.Columns[3].HeaderCell.Value = "平均占有率(%)";
            dg_ReportForm.Columns[4].HeaderCell.Value = "平均车头时距(s)";
        }

        //风机报表查询
        private void btn_search5_Click(object sender, EventArgs e)
        {
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            string [] strsql = new string [120];
            string strtotal = "";
            string stattime = "";
            int num = 0;
            int year = 0;
            int month = 0;
            string tableName = "";
            string strFJStartDateTime = "";
            string strFJEndDateTime = "";
            string temptime = "";
            string FJCourseTime = "";
            string objectName = "";

            tableName = "风机运行VIEW";
            objectName = Combo_SearchObj5.SelectedValue.ToString();
            if (objectName == "")
            {
                td.Abort();
                MessageBox.Show("你还没有选择正确的查询对象，请选择！");
                return;
            }

            if (ReportFormType == "月报表")
            {
                //tableName = "风机运行VIEW";
                //objectName = Combo_SearchObj5.SelectedValue.ToString();
                //if (objectName == "")
                //{
                //    MessageBox.Show("你还没有选择正确的查询对象，请选择！");
                //    label_Wait.Visible = false;
                //    return;
                //}
                if (comboBox_year_fj1.SelectedItem == null || comboBox_year_fj2.SelectedItem == null || comboBox_month_fj1.SelectedItem == null || comboBox_month_fj2.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    return;
                }
                int FJStartTime =Convert.ToInt32(comboBox_year_fj1.SelectedItem.ToString()) * 12 + Convert.ToInt32(comboBox_month_fj1.SelectedItem.ToString());
                int FJEndTime = Convert.ToInt32(comboBox_year_fj2.SelectedItem.ToString()) * 12 + Convert.ToInt32(comboBox_month_fj2.SelectedItem.ToString());
                if (FJStartTime > FJEndTime)
                {
                    td.Abort();
                    MessageBox.Show("请输入正确的查询时间，请选择！");
                    return;
                }
                month = Convert.ToInt32(comboBox_month_fj1.SelectedItem.ToString());
                year = Convert.ToInt32(comboBox_year_fj1.SelectedItem.ToString());
                temptime = year.ToString() + "-" + month.ToString();
                stattime = year.ToString() + "年" + month.ToString() + "月";

                num = FJEndTime - FJStartTime +1;
                if (num >120)
                {
                    td.Abort();
                    MessageBox.Show("你选择的时间范围太大，请重新选择！");
                    return;
                }
                string stryear = year.ToString();
                string strmonth = month.ToString();
                int FJCurrentNum = FJStartTime;
                for (int i = 0; i < num;i++ )
                {
                    stryear = year.ToString();
                    strmonth = month.ToString();
                    strFJStartDateTime = strFJEndDateTime = temptime;
                    if (month <10)
                    {
                        strmonth = "0" + month.ToString();
                    }
                    FJCourseTime = stryear + "-" + strmonth;
                    if (objectName =="全部对象")
                    {
                        strsql[i] = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + FJCurrentNum + "')";
                    }
                    else
                    {
                        strsql[i] = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + FJCurrentNum + "') and 对象名='" + objectName + "'";
                    }
                    month++;
                    FJCurrentNum++;                 
                    if (month > 12)
                    {
                        year++;
                        month = 1;
                    }
                    
                }
                FJCourseTime = "总计";
                if (objectName == "全部对象")
                {
                    strtotal = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + FJStartTime + "' and '" + FJEndTime + "')";
                }
                else
                {
                    strtotal = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + FJStartTime + "' and '" + FJEndTime + "') and 对象名='" + objectName + "'";
                }
            }
                //if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                //{
                //    num = 31;
                //}
                //else if (month == 2 && year % 4 == 0)
                //{
                //    num = 29;
                //}
                //else if (month == 2)
                //{
                //    num = 28;
                //}
                //else
                //{
                //    num = 30;
                //}
                
           
            if (ReportFormType == "年报表")
            {                
                if (comboBox_year_fj1.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    return;
                }
                year = Convert.ToInt32(comboBox_year_fj1.SelectedItem.ToString());
                temptime = comboBox_year_fj1.SelectedItem.ToString();
                stattime = comboBox_year_fj1.SelectedItem.ToString() + "年";
                num = 12;
                for (int i = 0; i < num;i++ )
                {
                    month = i + 1;
                    string strmonth = month.ToString();
                    int FJCurrentNum = year * 12 + month;
                    if (month<10)
                    {
                        strmonth = "0" + month.ToString();
                    }
                    FJCourseTime = strmonth + "月";
                    if (objectName == "全部对象")
                    {
                        strsql[i] = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + FJCurrentNum + "')";
                    }
                    else
                    {
                        strsql[i] = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + FJCurrentNum + "') and 对象名='" + objectName + "'";
                    } 
                }
                FJCourseTime = "总计";
                if (objectName == "全部对象")
                {
                    strtotal = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between'" + year * 12 + "' and '" + (year + 1) * 12 + "')";
                }
                else
                {
                    strtotal = "insert into 风机运行临时表 select 日期 ='" + FJCourseTime + "',正转次数=sum(正转次数),反转次数=sum(反转次数),运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + year * 12 + 1 + "' and '" + (year + 1) * 12 + "') and 对象名='" + objectName + "'";
                } 
            }
            string strSQL = "";
            gAppData.RunSql("delete from 风机运行临时表");
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                    strSQL += strsql[i];
                else
                    strSQL += ";" + strsql[i];
            }
            int nCount = gAppData.RunSql(strSQL);
            nCount = gAppData.RunSql(strtotal);
            DataSet ds1 = new DataSet();
            ds1 = gAppData.GetDS("select * from 风机运行临时表");
            //风机
            printDocument1_BeginPrint(null, null);//设置一些打印报表时的标题等参数
            m_reportForm.m_ds = ds1;
            m_reportForm.m_TableName = tableName;
            m_reportForm.m_ReportType = ReportFormType;
            m_reportForm.m_Object = objectName;
            m_reportForm.m_Title = strTypetitle;
            m_reportForm.m_DateTime = strStatsTime;
            m_reportForm.m_Type = TitleName;

            td.Abort();
            dg_ReportForm.DataSource = ds1.Tables[0];
            //重命名列头
            dg_ReportForm.Columns[0].HeaderCell.Value = "日期";
            dg_ReportForm.Columns[1].HeaderCell.Value = "正转次数";
            dg_ReportForm.Columns[2].HeaderCell.Value = "反转次数";
            dg_ReportForm.Columns[3].HeaderCell.Value = "运行时间(小时)";
            dg_ReportForm.Columns[4].HeaderCell.Value = "耗电量(千瓦)";
        }
        //照明报表
        private void btn_search6_Click(object sender, EventArgs e)
        {
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            string[] strsql = new string[120];
            string strtotal = "";
            string stattime = "";
            int num = 0;
            int year = 0;
            int month = 0;
            string tableName = "";
            string strZMStartDateTime = "";
            string strZMEndDateTime = "";
            string temptime = "";
            string ZMCourseTime = "";
            string objectName = "";

            tableName = "照明VIEW";
            objectName = Combo_SearchObj6.SelectedValue.ToString();
            if (objectName == "")
            {
                td.Abort();
                MessageBox.Show("你还没有选择正确的查询对象，请选择！");
                return;
            }

            if (ReportFormType == "月报表")
            {
                if (comboBox_year_zm1.SelectedItem == null || comboBox_year_zm2.SelectedItem == null || comboBox_month_zm1.SelectedItem == null || comboBox_month_zm2.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    return;
                }
                int ZMStartTime = Convert.ToInt32(comboBox_year_zm1.SelectedItem.ToString()) * 12 + Convert.ToInt32(comboBox_month_zm1.SelectedItem.ToString());
                int ZMEndTime = Convert.ToInt32(comboBox_year_zm2.SelectedItem.ToString()) * 12 + Convert.ToInt32(comboBox_month_zm2.SelectedItem.ToString());
                if (ZMStartTime > ZMEndTime)
                {
                    td.Abort();
                    MessageBox.Show("请输入正确的查询时间，请选择！");
                    return;
                }
                month = Convert.ToInt32(comboBox_month_zm1.SelectedItem.ToString());
                year = Convert.ToInt32(comboBox_year_zm1.SelectedItem.ToString());
                temptime = year.ToString() + "-" + month.ToString();
                stattime = year.ToString() + "年" + month.ToString() + "月";

                num = ZMEndTime - ZMStartTime + 1;
                if (num > 120)
                {
                    td.Abort();
                    MessageBox.Show("你选择的时间范围太大，请重新选择！");
                    return;
                }

                string stryear = year.ToString();
                string strmonth = month.ToString();
                int ZMCurrentNum = ZMStartTime;
                for (int i = 0; i < num; i++)
                {
                    stryear = year.ToString();
                    strmonth = month.ToString();
                    strZMStartDateTime = strZMEndDateTime = temptime;
                    if (month < 10)
                    {
                        strmonth = "0" + month.ToString();
                    }
                    ZMCourseTime = stryear + "-" + strmonth;
                    if (objectName == "全部对象")
                    {
                        strsql[i] = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + ZMCurrentNum + "')";
                    }
                    else
                    {
                        strsql[i] = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + ZMCurrentNum + "') and 对象名='" + objectName + "'";
                    }
                    month++;
                    ZMCurrentNum++;
                    if (month > 12)
                    {
                        year++;
                        month = 1;
                    }

                }
                ZMCourseTime = "总计";
                if (objectName == "全部对象")
                {
                    strtotal = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + ZMStartTime + "' and '" + ZMEndTime + "')";
                }
                else
                {
                    strtotal = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + ZMStartTime + "' and '" + ZMEndTime + "') and 对象名='" + objectName + "'";
                }
            }
            if (ReportFormType == "年报表")
            {
                if (comboBox_year_zm1.SelectedItem == null)
                {
                    td.Abort();
                    MessageBox.Show("你还没有选择正确的查询时间，请选择！");
                    return;
                }
                year = Convert.ToInt32(comboBox_year_zm1.SelectedItem.ToString());
                temptime = comboBox_year_zm1.SelectedItem.ToString();
                stattime = comboBox_year_zm1.SelectedItem.ToString() + "年";
                num = 12;
                for (int i = 0; i < num; i++)
                {
                    month = i + 1;
                    string strmonth = month.ToString();
                    int ZMCurrentNum = year * 12 + month;
                    if (month < 10)
                    {
                        strmonth = "0" + month.ToString();
                    }
                    ZMCourseTime = strmonth + "月";
                    if (objectName == "全部对象")
                    {
                        strsql[i] = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + ZMCurrentNum + "')";
                    }
                    else
                    {
                        strsql[i] = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',,运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月='" + ZMCurrentNum + "') and 对象名='" + objectName + "'";
                    }
                }
                ZMCourseTime = "总计";
                if (objectName == "全部对象")
                {
                    strtotal = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between'" + year * 12 + "' and '" + (year + 1) * 12 + "')";
                }
                else
                {
                    strtotal = "insert into 照明临时表 select 日期 ='" + ZMCourseTime + "',运行时间=sum(运行时间/3600),耗电量=sum(运行时间*备注/3600) from " + tableName + " where (年*12+月 between '" + year * 12 + 1 + "' and '" + (year + 1) * 12 + "') and 对象名='" + objectName + "'";
                }
            }
            string strSQL = "";
            gAppData.RunSql("delete from 照明临时表");
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                    strSQL += strsql[i];
                else
                    strSQL += ";" + strsql[i];
            }
            int nCount = gAppData.RunSql(strSQL);
            nCount = gAppData.RunSql(strtotal);
            DataSet ds1 = new DataSet();
            ds1 = gAppData.GetDS("select * from 照明临时表");
            dg_ReportForm.DataSource = ds1.Tables[0];
            printDocument1_BeginPrint(null, null);//设置一些打印报表时的标题等参数
            m_reportForm.m_ds = ds1;
            m_reportForm.m_TableName = tableName;
            m_reportForm.m_ReportType = ReportFormType;
            m_reportForm.m_Object = objectName;
            m_reportForm.m_Title = strTypetitle;
            m_reportForm.m_DateTime = strStatsTime;
            m_reportForm.m_Type = TitleName;
            //重命名列头
            dg_ReportForm.Columns[0].HeaderCell.Value = "日期";
            dg_ReportForm.Columns[1].HeaderCell.Value = "运行时间(小时)";
            dg_ReportForm.Columns[2].HeaderCell.Value = "耗电量(千瓦)";
            td.Abort();
        }   
        private void tabControl_VisibleChanged(object sender, EventArgs e)
        {
   //         InitCombobox();
            switch (ReportFormType)
            {
                case "日报表":
                    //隐藏后面两项
                    this.tabControl.Controls.Remove(tabPage_fengji);
                    this.tabControl.Controls.Remove(tabPage_zhaoming);
                    break;
                case "月报表":
                case "年报表":
                    //恢复后面两项
                    if (tabControl.TabCount==5)
                    {
                        this.tabControl.Controls.Add(tabPage_fengji);
                        this.tabControl.Controls.Add(tabPage_zhaoming);
                    }                    
                    break;
            }            
        }

        //更新显示控件
        public void UpdateControls()
        {
            switch (ReportFormType)
            {
                case "日报表":
                    dateTimePicker0.Visible = true;
                    dateTimePicker4.Visible = true;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    dateTimePicker3.Visible = true;
                    dateTimePicker5.Visible = true;
                    dateTimePicker6.Visible = true;

                    comboBox_year.Visible = false;
                    comboBox_month.Visible = false;
                    label_year.Visible = false;
                    label_month.Visible = false;

                    comboBox_year1.Visible = false;
                    comboBox_month1.Visible = false;
                    label_year1.Visible = false;
                    label_month1.Visible = false;

                    comboBox_year2.Visible = false;
                    comboBox_month2.Visible = false;
                    label_year2.Visible = false;
                    label_month2.Visible = false;

                    comboBox_year3.Visible = false;
                    comboBox_month3.Visible = false;
                    label_year3.Visible = false;
                    label_month3.Visible = false;

                    comboBox_year4.Visible = false;
                    comboBox_month4.Visible = false;
                    label_year4.Visible = false;
                    label_month4.Visible = false;

                    comboBox_year_fj1.Visible = false;
                    comboBox_month_fj1.Visible = false;
                    label_year5.Visible = false;
                    label_month5.Visible = false;

                    comboBox_year_zm1.Visible = false;
                    comboBox_month_zm1.Visible = false;
                    label_year_zm1.Visible = false;
                    label_month_zm1.Visible = false;

                    tabPage_fengji.Hide();
                    tabPage_zhaoming.Hide();
                    break;
                case "月报表":
                    dateTimePicker0.Visible = false;
                    dateTimePicker4.Visible = false;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    dateTimePicker3.Visible = false;
                    dateTimePicker5.Visible = false;
                    dateTimePicker6.Visible = false;

                    comboBox_year.Visible = true;
                    comboBox_month.Visible = true;
                    label_year.Visible = true;
                    label_month.Visible = true;

                    comboBox_year1.Visible = true;
                    comboBox_month1.Visible = true;
                    label_year1.Visible = true;
                    label_month1.Visible = true;

                    comboBox_year2.Visible = true;
                    comboBox_month2.Visible = true;
                    label_year2.Visible = true;
                    label_month2.Visible = true;

                    comboBox_year3.Visible = true;
                    comboBox_month3.Visible = true;
                    label_year3.Visible = true;
                    label_month3.Visible = true;

                    comboBox_year4.Visible = true;
                    comboBox_month4.Visible = true;
                    label_year4.Visible = true;
                    label_month4.Visible = true;

                    comboBox_year_fj1.Visible = true;
                    comboBox_month_fj1.Visible = true;
                    comboBox_year_fj2.Visible = true;
                    comboBox_month_fj2.Visible = true;
                    label_month_fj2.Visible = true;
                    label_year_fj2.Visible = true;
                    label_toDate.Visible = true;
                    label_year5.Visible = true;
                    label_month5.Visible = true;

                    comboBox_year_zm1.Visible = true;
                    comboBox_month_zm1.Visible = true;
                    label_year_zm1.Visible = true;
                    label_month_zm1.Visible = true;
                    comboBox_year_zm2.Visible = true;
                    comboBox_month_zm2.Visible = true;
                    label_year_zm2.Visible = true;
                    label_month_zm2.Visible = true;
                    label_zm.Visible = true;

                    break;
                case "年报表":
                    dateTimePicker0.Visible = false;
                    dateTimePicker4.Visible = false;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    dateTimePicker3.Visible = false;
                    dateTimePicker5.Visible = false;
                    dateTimePicker6.Visible = false;

                    comboBox_year.Visible = true;
                    comboBox_month.Visible = false;
                    label_year.Visible = true;
                    label_month.Visible = false;

                    comboBox_year1.Visible = true;
                    comboBox_month1.Visible = false;
                    label_year1.Visible = true;
                    label_month1.Visible = false;

                    comboBox_year2.Visible = true;
                    comboBox_month2.Visible = false;
                    label_year2.Visible = true;
                    label_month2.Visible = false;

                    comboBox_year3.Visible = true;
                    comboBox_month3.Visible = false;
                    label_year3.Visible = true;
                    label_month3.Visible = false;

                    comboBox_year4.Visible = true;
                    comboBox_month4.Visible = false;
                    label_year4.Visible = true;
                    label_month4.Visible = false;

                    comboBox_year_fj1.Visible = true;
                    comboBox_month_fj1.Visible = false;
                    comboBox_year_fj2.Visible = false;
                    comboBox_month_fj2.Visible = false;
                    label_year_fj2.Visible = false;
                    label_month_fj2.Visible = false;
                    label_toDate.Visible = false;
                    label_year5.Visible = true;
                    label_month5.Visible = false;

                    comboBox_year_zm1.Visible = true;
                    comboBox_month_zm1.Visible = false;
                    label_year_zm1.Visible = true;
                    label_month_zm1.Visible = false;
                    comboBox_year_zm2.Visible = false;
                    comboBox_month_zm2.Visible = false;
                    label_year_zm2.Visible = false;
                    label_month_zm2.Visible = false;
                    label_zm.Visible = false;

                    tabPage_fengji.Show();
                    tabPage_zhaoming.Show();
                    break;
            }
        }
        public void InitCombobox()
        {
            DataSet ds;
            DataRow dr;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    ds = gAppData.GetDS("COVIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case 1:
                    ds = gAppData.GetDS("VIVIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj1.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj1.DisplayMember = "对象名";
                    Combo_SearchObj1.ValueMember = "对象名";
                    break;
                case 2:
                    ds = gAppData.GetDS("风速VIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj2.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj2.DisplayMember = "对象名";
                    Combo_SearchObj2.ValueMember = "对象名";
                    break;
                case 3:
                    ds = gAppData.GetDS("光检VIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj3.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj3.DisplayMember = "对象名";
                    Combo_SearchObj3.ValueMember = "对象名";
                    break;
                case 4:
                    ds = gAppData.GetDS("车检器VIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj4.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj4.DisplayMember = "对象名";
                    Combo_SearchObj4.ValueMember = "对象名";
                    break;
                case 5:
                    ds = gAppData.GetDS("风机运行VIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj5.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj5.DisplayMember = "对象名";
                    Combo_SearchObj5.ValueMember = "对象名";
                    break;
                case 6:
                    ds = gAppData.GetDS("照明VIEW", "对象名");
                    dr = ds.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj6.DataSource = ds.Tables[0].DefaultView;
                    Combo_SearchObj6.DisplayMember = "对象名";
                    Combo_SearchObj6.ValueMember = "对象名";
                    break;
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            UpdateControls();
            InitCombobox();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string excelName = "";
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    excelName = "CO" + ReportFormType;
                    break;
                case 1:
                    excelName = "VI" + ReportFormType;
                    break;
                case 2:
                    excelName = "风速风向" + ReportFormType;
                    break;
                case 3:
                    excelName = "光强" + ReportFormType;
                    break;
                case 4:
                    excelName = "车检仪" + ReportFormType;
                    break;
                case 5:
                    excelName = "风机" + ReportFormType;
                    break;
                case 6:
                    excelName = "照明" + ReportFormType;

                    break;
            }
            gAppData.DataGridViewExport(dg_ReportForm, excelName, true, "  ");
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            m_reportForm.ShowDialog();
            /*
            printPreviewDialog1.Document = printDocument1;
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iCurrentLine = 0;
            iFreeSpace = 20;
            switch (ReportFormType)
            {
                case "日报表":
                    strTypetitle = gAppData.SHName[gAppData.iCurrentSH] + "日报表查询";                    
                    break;
                case "月报表":
                    strTypetitle = gAppData.SHName[gAppData.iCurrentSH] + "月报表查询";
                    break;
                case "年报表":
                    strTypetitle = gAppData.SHName[gAppData.iCurrentSH] + "年报表查询";
                    break;
            }
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    TitleName = "CO检测值";
                    strStatsObject = Combo_SearchObj.Text;
                    tableLeft = 150;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker0.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year.Text + "年" + comboBox_month.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year.Text + "年";
                            break;
                    }                   
                    break;
                case 1:
                    TitleName = "VI检测值";
                    tableLeft = 150;
                    strStatsObject = Combo_SearchObj1.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker1.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year1.Text + "年" + comboBox_month1.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year1.Text + "年";
                            break;
                    }
                    break;
                case 2:
                    TitleName = "风速风向检测值";
                    tableLeft = 150;
                    strStatsObject = Combo_SearchObj2.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker2.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year2.Text + "年" + comboBox_month2.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year2.Text + "年";
                            break;
                    }
                    break;
                case 3:
                    TitleName = "光强检测值";
                    tableLeft = 150;
                    strStatsObject = Combo_SearchObj3.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker3.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year3.Text + "年" + comboBox_month3.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year3.Text + "年";
                            break;
                    }
                    break;
                case 4:
                    TitleName = "车检器检测值";
                    tableLeft = 100;
                    strStatsObject = Combo_SearchObj4.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker4.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year4.Text + "年" + comboBox_month4.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year4.Text + "年";
                            break;
                    }
                    break;
                case 5:
                    TitleName = "风机检测值";
                    tableLeft = 150;
                    strStatsObject = Combo_SearchObj5.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker6.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year_fj1.Text + "年" + comboBox_month_fj1.Text + "月 至 " + comboBox_year_fj2.Text + "年" + comboBox_month_fj2.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year_fj1.Text + "年";
                            break;
                    }
                    break;
                case 6:
                    TitleName = "照明检测值";
                    tableLeft = 150;
                    strStatsObject = Combo_SearchObj6.Text;
                    switch (ReportFormType)
                    {
                        case "日报表":
                            strStatsTime = dateTimePicker6.Value.ToString();
                            break;
                        case "月报表":
                            strStatsTime = comboBox_year_zm1.Text + "年" + comboBox_month_zm1.Text + "月 至 " + comboBox_year_zm2.Text + "年" + comboBox_month_zm2.Text + "月";
                            break;
                        case "年报表":
                            strStatsTime = comboBox_year_zm1.Text + "年";
                            break;
                    }   
                    break;
            }
            strTabulateTime = DateTime.Now.ToString();  //制表时间            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dg_ReportForm.DataBindings != null)
            {
                System.Drawing.Font TitleFont = new System.Drawing.Font("隶书", 25, FontStyle.Bold);
                System.Drawing.Font TableFont = new System.Drawing.Font("宋体", 15, FontStyle.Italic|FontStyle.Bold);
                System.Drawing.Font font = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                System.Drawing.Font HeaderFont = new System.Drawing.Font("宋体", 12, FontStyle.Bold);
                System.Drawing.Font ContentFont = new System.Drawing.Font("宋体", 12);

                System.Drawing.Point currentPoint = new System.Drawing.Point();
                System.Drawing.Point currentPoint2 = new System.Drawing.Point();

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;//居中打印
                
                int nCount = dg_ReportForm.Rows.Count - 1;
                int iColCount = dg_ReportForm.Columns.Count;
                //int[] columnsWidth = new int[dg_userlog.Columns.Count];//得到所有列的个数
                //int[] columnsLeft = new int[dg_userlog.Columns.Count]; //
                if (iCurrentLine == 0)
                {
                    for (int c = 0; c < iColCount; c++)//得到列标题的宽度          
                    {
                        columnsWidth[c] = (int)e.Graphics.MeasureString(dg_ReportForm.Columns[c].HeaderText, HeaderFont).Width;
                    }

                    for (int rowIndex = 0; rowIndex < nCount; rowIndex++)//rowindex当前行
                    {
                        for (int columnIndex = 0; columnIndex < iColCount; columnIndex++)//当前列
                        {
                            int w = (int)e.Graphics.MeasureString(dg_ReportForm.Rows[rowIndex].Cells[columnIndex].Value.ToString(), ContentFont
                                ).Width;
                            columnsWidth[columnIndex] = w > columnsWidth[columnIndex] ? w : columnsWidth[columnIndex];
                        }
                    }
                }
                for (int i = 0; i < iColCount; i++)
                {
                    columnsWidth[i] += iFreeSpace;//留下一些空余空间
                }
                int rowHidth = 25;                
                int tableTop = 120;

                columnsLeft[0] = tableLeft;
                for (int i = 1; i <= iColCount - 1; i++)
                {
                    columnsLeft[i] = columnsLeft[i - 1] + columnsWidth[i - 1];
                }

                //打印大标题 
                e.Graphics.DrawString(strTypetitle, TitleFont, System.Drawing.Brushes.Black, new System.Drawing.Point(e.PageBounds.Width / 2, 25), sf);

                //打印具体统计类型
                e.Graphics.DrawString(TitleName, TableFont, System.Drawing.Brushes.Black, new System.Drawing.Point(e.PageBounds.Width / 2, 60), sf);

                //打印统计时间和统计对象
                e.Graphics.DrawString("统计时间:" + strStatsTime, font, System.Drawing.Brushes.Black, tableLeft, 90);
                e.Graphics.DrawString("统计对象:" + strStatsObject, font, System.Drawing.Brushes.Black, columnsLeft[iColCount-1], 90);

                //打印表中的列名
                for (int c = 0; c < iColCount; c++)
                {
                    //起点
                    currentPoint.X = columnsLeft[c];
                    currentPoint.Y = tableTop;
                    //终点
                    currentPoint2.X = columnsLeft[c] + columnsWidth[c];
                    currentPoint2.Y = tableTop + rowHidth;

                    e.Graphics.DrawString(dg_ReportForm.Columns[c].HeaderText, HeaderFont, Brushes.Black, currentPoint.X+columnsWidth[c]/2,tableTop+5,sf);

                    e.Graphics.DrawLine(Pens.Black, currentPoint.X,currentPoint.Y,currentPoint2.X,currentPoint.Y );//上面横线
                    e.Graphics.DrawLine(Pens.Black, currentPoint.X, currentPoint.Y, currentPoint.X, currentPoint2.Y);//左边竖线
                    e.Graphics.DrawLine(Pens.Black, currentPoint.X, currentPoint2.Y, currentPoint2.X, currentPoint2.Y);//下面横线
                    e.Graphics.DrawLine(Pens.Black, currentPoint2.X, currentPoint.Y, currentPoint2.X, currentPoint2.Y);//右边竖线
                   
                }
                //打印表中的内容         
                if (nCount - iCurrentLine > iLinePerPage)
                {
                    e.HasMorePages = true;
                    nCount = iLinePerPage;
                }
                else
                {
                    e.HasMorePages = false;
                    nCount = nCount - iCurrentLine;
                }
                nCount = nCount + iCurrentLine;
                //打印内容
                for (int rowIndex = iCurrentLine; iCurrentLine < nCount; iCurrentLine++)
                {
                    for (int columnIndex = 0; columnIndex < dg_ReportForm.Columns.Count; columnIndex++)
                    {
                        //起点
                        currentPoint.X = columnsLeft[columnIndex];
                        currentPoint.Y = tableTop + (int)(rowHidth * (iCurrentLine - rowIndex + 1)); ;
                        //终点
                        currentPoint2.X = columnsLeft[columnIndex] + columnsWidth[columnIndex];
                        currentPoint2.Y = currentPoint.Y + rowHidth;

                        string str = dg_ReportForm.Rows[iCurrentLine].Cells[columnIndex].Value.ToString();
                        e.Graphics.DrawString(str, HeaderFont, Brushes.Black, currentPoint.X + columnsWidth[columnIndex] / 2, currentPoint.Y + 5, sf);

                        e.Graphics.DrawLine(Pens.Black, currentPoint.X, currentPoint.Y, currentPoint2.X, currentPoint.Y);//上面横线
                        e.Graphics.DrawLine(Pens.Black, currentPoint.X, currentPoint.Y, currentPoint.X, currentPoint2.Y);//左边竖线
                        e.Graphics.DrawLine(Pens.Black, currentPoint.X, currentPoint2.Y, currentPoint2.X, currentPoint2.Y);//下面横线
                        e.Graphics.DrawLine(Pens.Black, currentPoint2.X, currentPoint.Y, currentPoint2.X, currentPoint2.Y);//右边竖线

                        //currentPoint.X = columnsLeft[columnIndex];
                        //currentPoint.Y = tableTop + (int)(rowHidth * (iCurrentLine - rowIndex + 2));
                        //string str = dg_ReportForm.Rows[iCurrentLine].Cells[columnIndex].Value.ToString();
                        //e.Graphics.DrawString(str, ContentFont, System.Drawing.Brushes.Black, currentPoint);
                    }
                }
                //for (int d = 0; d < 4; d++)
                //{
                //    currentPoint.Y = e.PageBounds.Height - 120 + d;
                //    currentPoint2.Y = e.PageBounds.Height - 120 + d;
                //    //Pen pen = new Pen(Brushes.Black);
                //    e.Graphics.DrawLine(Pens.Black, currentPoint, currentPoint2);
                //}
                e.Graphics.DrawString("制表时间:" + strTabulateTime, HeaderFont, Brushes.Black, columnsLeft[0], currentPoint2.Y + 10);
                //int iPagenum = (iCurrentLine / iLinePerPage);
                //if (iCurrentLine % iLinePerPage > 0)
                //{
                //    iPagenum++;
                //}
                //e.Graphics.DrawString("页号:" + iPagenum.ToString(), HeaderFont, Brushes.Black, e.PageBounds.Width - 150, currentPoint2.Y + 16);
            }
        }

        private void ReportFormControl_Load(object sender, EventArgs e)
        {
            comboBox_Line.SelectedIndex = 0;
        }
    }
}
