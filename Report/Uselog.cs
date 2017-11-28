using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace DataReport
{
    public partial class Uselog : UserControl
    {
        public string tableName;
        public string TitleName;
        private ReportFormTemp m_reportForm = new ReportFormTemp();//报表模板对话框
        private int iCurrentLine; //记录当前打印到的行号
        private int[] columnsWidth = new int[20];//得到所有列的个数
        private int[] columnsLeft = new int[20]; //
        private int iLinePerPage = 40;//设置每页打印记录条数
        private int nCount = 0;//总共条数
        private int iColCount = 0;//列数

        delegate void DelegateMaskForm();//委托
        DelegateMaskForm handleDelegate;
        Thread td;
        public Uselog()
        {
            InitializeComponent();
            //实例化委托对象
            handleDelegate = new DelegateMaskForm(StarPro);
        }

        private void Uselog_Load(object sender, EventArgs e)
        {
            UpdateComboBoxs();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            //this.Invoke(handleDelegate);//用指定的参数列表执行指定的委托
            td = new Thread(MaskForm);
            td.Start();
            //Thread.Sleep(1000);
            DataSet ds = new DataSet();
            string startDT, endDT, objectType, searchObject;
            objectType = "";
            startDT = DateTime_Start.Text;
            endDT = DateTime_End.Text;
            if (Combo_Objtype.Enabled)
            {
                objectType = Combo_Objtype.SelectedValue.ToString();
            }
            searchObject = Combo_ObjName.SelectedValue.ToString();
            ds = gAppData.getdataset(tableName, startDT, endDT, objectType, searchObject);
            m_reportForm.m_ds = ds;
            m_reportForm.m_TableName = tableName;
            dg_userlog.DataSource = ds.Tables[0].DefaultView;
            td.Abort();
        }

        //对象类型改变
        private void Object_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Combo_Objtype.SelectedValue != null)
            {
                string selected_str = Combo_Objtype.SelectedValue.ToString();
                if (selected_str == "System.Data.DataRowView")
                {
                    return;
                }
                DataSet ds1 = new DataSet();
                DataRow dr;
                switch (tableName)
                {
                    case "策略操作VIEW":
                        if (selected_str == "全部类型")
                        {
                            ds1 = gAppData.GetDS(tableName, "策略名称");
                        }
                        else
                        {
                            ds1 = gAppData.GetDS(tableName, "策略名称", "策略类型", selected_str);
                        }
                        dr = ds1.Tables[0].NewRow();
                        dr["策略名称"] = "全部对象";
                        ds1.Tables[0].Rows.InsertAt(dr, 0);
                        Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                        Combo_ObjName.DisplayMember = "策略名称";
                        Combo_ObjName.ValueMember = "策略名称";
                        break;
                    case "预案操作VIEW":
                        if (selected_str == "全部类型")
                        {
                            ds1 = gAppData.GetDS(tableName, "预案名称");
                        }
                        else
                        {
                            ds1 = gAppData.GetDS(tableName, "预案名称", "预案类型", selected_str);
                        }
                        dr = ds1.Tables[0].NewRow();
                        dr["预案名称"] = "全部对象";
                        ds1.Tables[0].Rows.InsertAt(dr, 0);
                        Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                        Combo_ObjName.DisplayMember = "预案名称";
                        Combo_ObjName.ValueMember = "预案名称";
                        break;
                    case "设备运行状态VIEW":
                        if (selected_str == "全部类型")
                        {
                            ds1 = gAppData.GetDS("设备对象表", "对象名");
                        }
                        else
                        {
                            ds1 = gAppData.GetDS("设备对象表", "对象名", "对象类型", selected_str);
                        }
                        dr = ds1.Tables[0].NewRow();
                        dr["对象名"] = "全部对象";
                        ds1.Tables[0].Rows.InsertAt(dr, 0);
                        Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                        Combo_ObjName.DisplayMember = "对象名";
                        Combo_ObjName.ValueMember = "对象名";
                        break;
                    case "操作记录表VIEW"://表结构不一样
                        if (selected_str == "全部类型")
                        {
                            ds1 = gAppData.GetDS("设备对象表", "对象名");
                        }
                        else
                        {
                            ds1 = gAppData.GetDS(tableName, "对象名", "对象类型", selected_str);
                        }
                        dr = ds1.Tables[0].NewRow();
                        dr["对象名"] = "全部对象";
                        ds1.Tables[0].Rows.InsertAt(dr, 0);
                        Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                        Combo_ObjName.DisplayMember = "对象名";
                        Combo_ObjName.ValueMember = "对象名";
                        break;
                    case "报警记录表"://原程序是固定选项，不是从数据库绑定的
                        if (selected_str == "全部类型")
                        {
                            ds1 = gAppData.GetDS(tableName, "报警标识");
                        }
                        else
                        {
                            ds1 = gAppData.GetDS(tableName, "报警标识", "报警类型", selected_str);
                        }
                        dr = ds1.Tables[0].NewRow();
                        dr["报警标识"] = "全部对象";
                        ds1.Tables[0].Rows.InsertAt(dr, 0);
                        Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                        Combo_ObjName.DisplayMember = "报警标识";
                        Combo_ObjName.ValueMember = "报警标识";
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            gAppData.DataGridViewExport(dg_userlog, tableName, true, "  ");
        }

        public void InitCobombox()
        {
            dg_userlog.DataSource = null;
            Combo_Objtype.SelectedIndex = -1;
            DateTime_Start.Value = DateTime.Now;
            DateTime_End.Value = DateTime.Now;
            string sql = "";
            DataRow dr;
            DataSet ds1;

            switch (tableName)
            {
                case "Vid_Data_View":
                    Combo_Objtype.Enabled = false;
                    Combo_Objtype.SelectedText = "";
                    ds1 = new DataSet();
                    sql = "select DeviceName from DeviceConfig where Type = 'VID'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["DeviceName"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                    Combo_ObjName.DisplayMember = "DeviceName";
                    Combo_ObjName.ValueMember = "DeviceName";
                    break;
                case "Alarm_Data_View":
                    Combo_Objtype.Enabled = false;
                    Combo_Objtype.SelectedText = "";
                    ds1 = new DataSet();
                    sql = "select DeviceName from DeviceConfig where Type = 'VID'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["DeviceName"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_ObjName.DataSource = ds1.Tables[0].DefaultView;
                    Combo_ObjName.DisplayMember = "DeviceName";
                    Combo_ObjName.ValueMember = "DeviceName";
                    break;
                default:
                    break;
            }
        }

        private void button_SQLSearch_Click(object sender, EventArgs e)
        {
            string sqlText = richTextBox_SQL.Text;
            if (sqlText.Trim() == "")
            {
                MessageBox.Show("你还没有输入sql语句，请输入!");
                return;
            }
            DataSet ds = new DataSet();
            ds = gAppData.GetDS(sqlText);
            if (ds != null)
            {
                dg_userlog.DataSource = ds.Tables[0].DefaultView;
            }
            //else
            //{
            //    dg_userlog.DataSource = null;
            //}
        }

        private void 全部选择XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
                AddItemToCombobox(1);
            }
        }

        private void 全部取消YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                AddItemToCombobox(1);
            }
        }

        private void 反选ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
                AddItemToCombobox(1);
            }
        }
        
        public void InitCheckListBox()
        {
           
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            //          UpdateComboBoxs();
        }

        public void UpdateComboBoxs()
        {
            comboBox_orderCol1.SelectedIndex = 0;
            comboBox_orderCol2.SelectedIndex = 0;
            comboBox_ralation1.SelectedIndex = 0;
            comboBox_ralation2.SelectedIndex = 0;
            comboBox_orderType1.SelectedIndex = 0;
            comboBox_orderType2.SelectedIndex = 0;

            comboBox_ralation2.Enabled = false;
            comboBox_value2.Enabled = false;
            comboBox_value3.Enabled = false;
            comboBox_Column2.Enabled = false;
            comboBox_Column3.Enabled = false;
            comboBox_criteria2.Enabled = false;
            comboBox_criteria3.Enabled = false;
            //comboBox_orderType2.Enabled = false;
            //comboBox_orderCol2.Enabled = false;

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //AddItemToCombobox();            
        }
        private void AddItemToCombobox(int bMenu)
        {
            int nCount = comboBox_Column1.Items.Count;
            for (int i = 0; i < nCount; i++)
            {
                comboBox_Column1.Items.RemoveAt(0);
                comboBox_Column2.Items.RemoveAt(0);
                comboBox_Column3.Items.RemoveAt(0);
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string str = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                switch (bMenu)
                {
                    case 0://手动选择
                        if ((checkedListBox1.GetItemChecked(i) && checkedListBox1.SelectedIndex != i)
                    || (checkedListBox1.SelectedIndex == i && !checkedListBox1.GetItemChecked(i)))
                        {
                            comboBox_Column1.Items.Add(str);
                            comboBox_Column2.Items.Add(str);
                            comboBox_Column3.Items.Add(str);
                        }   
                        break;
                    case 1://菜单选择
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            comboBox_Column1.Items.Add(str);
                            comboBox_Column2.Items.Add(str);
                            comboBox_Column3.Items.Add(str);
                        }   
                        break;
                }                         
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //AddItemToCombobox();
        }

        private void comboBox_Column1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_value1.DataSource = null;
            DataSet ds = new DataSet();
            if (comboBox_Column1.Text != "")
            {
                string colName = comboBox_Column1.Text;
                ds = gAppData.GetDS(tableName, colName);
                comboBox_value1.DataSource = ds.Tables[0].DefaultView;
                comboBox_value1.DisplayMember = colName;
                comboBox_value1.ValueMember = colName;
            }
        }

        private void comboBox_Column2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_value2.DataSource = null;
            DataSet ds = new DataSet();
            if (comboBox_Column2.Text != "")
            {
                string colName = comboBox_Column2.Text;
                ds = gAppData.GetDS(tableName, colName);
                comboBox_value2.DataSource = ds.Tables[0].DefaultView;
                comboBox_value2.DisplayMember = colName;
                comboBox_value2.ValueMember = colName;
            }
        }

        private void comboBox_Column3_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_value3.DataSource = null;
            DataSet ds = new DataSet();
            if (comboBox_Column3.Text != "")
            {
                string colName = comboBox_Column3.Text;
                ds = gAppData.GetDS(tableName, colName);
                comboBox_value3.DataSource = ds.Tables[0].DefaultView;
                comboBox_value3.DisplayMember = colName;
                comboBox_value3.ValueMember = colName;
            }
        }
        private void comboBox_ralation1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_ralation1.SelectedIndex != 0)
            {
                comboBox_Column2.Enabled = true;
                comboBox_criteria2.Enabled = true;
                comboBox_value2.Enabled = true;
                comboBox_ralation2.Enabled = true;
            }
            else
            {
                comboBox_Column2.Enabled = false;
                comboBox_criteria2.Enabled = false;
                comboBox_value2.Enabled = false;
                comboBox_ralation2.Enabled = false;
                comboBox_ralation2.SelectedIndex = 0;

                comboBox_Column3.Enabled = false;
                comboBox_criteria3.Enabled = false;
                comboBox_value3.Enabled = false;
            }
        }

        private void comboBox_ralation2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_ralation2.SelectedIndex != 0)
            {
                comboBox_Column3.Enabled = true;
                comboBox_criteria3.Enabled = true;
                comboBox_value3.Enabled = true;
            }
            else
            {
                comboBox_Column3.Enabled = false;
                comboBox_criteria3.Enabled = false;
                comboBox_value3.Enabled = false;
            }
        }

        private void button_search_expert_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string relation1 = comboBox_ralation1.Text;
            string relation2 = comboBox_ralation2.Text;

            string ordertype1 = comboBox_orderType1.Text;
            string ordertype2 = comboBox_orderType2.Text;

            if (comboBox_orderCol2.Text != "无" && comboBox_orderCol1.Text == comboBox_orderCol2.Text)
            {
                MessageBox.Show("参加排序的两列不能相同，请重新选择！");
                return;
            }
            //
            switch (comboBox_ralation1.SelectedIndex)
            {
                case 1:
                    relation1 = " and ";
                    break;
                case 2:
                    relation1 = " or ";
                    break;
            }
            switch (comboBox_ralation2.SelectedIndex)
            {
                case 1:
                    relation2 = " and ";
                    break;
                case 2:
                    relation2 = " or ";
                    break;
            }
            switch (comboBox_orderType1.SelectedIndex)
            {
                case 0:
                    ordertype1 = " ASC ";
                    break;
                case 1:
                    ordertype1 = " DESC ";
                    break;
            }
            switch (comboBox_orderType2.SelectedIndex)
            {
                case 0:
                    ordertype2 = " ASC ";
                    break;
                case 1:
                    ordertype2 = " DESC ";
                    break;
            }
            if (comboBox_Column1.Text == "" || comboBox_criteria1.Text == "" || comboBox_value1.Text == "")
            {
                MessageBox.Show("请输入条件1的查询条件");
                return;
            }
            if (comboBox_ralation1.SelectedIndex != 0)
            {
                if (comboBox_Column2.Text == "" || comboBox_criteria2.Text == "" || comboBox_value2.Text == "")
                {
                    MessageBox.Show("请输入条件2的查询条件");
                    return;
                }
                if (comboBox_ralation2.SelectedIndex != 0)
                {
                    if (comboBox_Column3.Text == "" || comboBox_criteria3.Text == "" || comboBox_value3.Text == "")
                    {
                        MessageBox.Show("请输入条件3的查询条件");
                        return;
                    }
                }
            }
            //判断输入正确后，开始执行查询
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            if (comboBox_ralation1.SelectedIndex == 0)
            {
                ds = gAppData.GetExpertSearch(tableName, comboBox_Column1.Text, comboBox_criteria1.Text, comboBox_value1.Text, dateTimePicker_start.Text, dateTimePicker_end.Text, comboBox_orderCol1.Text, ordertype1, comboBox_orderCol2.Text, ordertype2);
            }
            else
            {
                if (comboBox_ralation2.SelectedIndex == 0)//两个条件
                {
                    ds = gAppData.GetExpertSearch(tableName, comboBox_Column1.Text, comboBox_criteria1.Text, comboBox_value1.Text, comboBox_Column2.Text, comboBox_criteria2.Text, comboBox_value2.Text, dateTimePicker_start.Text, dateTimePicker_end.Text, comboBox_orderCol1.Text, ordertype1, comboBox_orderCol2.Text, ordertype2, relation1);
                }
                else//三个条件
                {
                    ds = gAppData.GetExpertSearch(tableName, comboBox_Column1.Text, comboBox_criteria1.Text, comboBox_value1.Text, comboBox_Column2.Text, comboBox_criteria2.Text, comboBox_value2.Text, comboBox_Column3.Text, comboBox_criteria3.Text, comboBox_value3.Text, dateTimePicker_start.Text, dateTimePicker_end.Text, comboBox_orderCol1.Text, ordertype1, comboBox_orderCol2.Text, ordertype2, relation1, relation2);
                }
            }
            dg_userlog.DataSource = ds.Tables[0].DefaultView;
            td.Abort();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iCurrentLine = 0;
            nCount = dg_userlog.Rows.Count - 1;
            iColCount = dg_userlog.Columns.Count;
            printDocument1.DocumentName = (nCount / iLinePerPage + (nCount % iLinePerPage > 0 ? 1 : 0)).ToString();            
            //switch (tableName)
            //{
            //    case "情报板下发记录VIEW":
            //        TitleName = "情报板记录查询";
            //        break;
            //    case "策略操作VIEW":
            //        TitleName = "策略操作记录查询";
            //        break;
            //    case "预案操作VIEW":
            //        TitleName = "预案操作记录查询";
            //        break;
            //    case "模式更改记录表"://原程序是固定选项，不是从数据库绑定的
            //        TitleName = "模式更改记录查询";
            //        break;
            //    case "设备运行状态VIEW":
            //        TitleName = "设备运行状态查询";
            //        break;
            //    case "操作记录表VIEW"://表结构不一样
            //        TitleName = "操作记录查询";
            //        break;
            //    case "诱导屏下发记录VIEW":
            //        TitleName = "诱导屏下发记录查询";
            //        break;
            //    case "上下班登录表":
            //        TitleName = "值班记录查询";
            //        break;
            //    case "报警记录表"://原程序是固定选项，不是从数据库绑定的
            //        TitleName = "报警记录查询";
            //        break;
            //}
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //System.Drawing.Font tabelTextFont = new System.Drawing.Font("宋体", 10);
            if (dg_userlog.DataBindings != null)
            {
                System.Drawing.Font TitleFont = new System.Drawing.Font("隶书", 25, FontStyle.Bold);
                System.Drawing.Font HeaderFont = new System.Drawing.Font("宋体", 12);
                System.Drawing.Font ContentFont = new System.Drawing.Font("宋体", 12);

                System.Drawing.Point currentPoint = new System.Drawing.Point();
                System.Drawing.Point currentPoint2 = new System.Drawing.Point();               
                
                //int[] columnsWidth = new int[dg_userlog.Columns.Count];//得到所有列的个数
                //int[] columnsLeft = new int[dg_userlog.Columns.Count]; //
                if (iCurrentLine == 0)
                {
                    for (int c = 0; c < iColCount; c++)//得到列标题的宽度          
                    {
                        columnsWidth[c] = (int)e.Graphics.MeasureString(dg_userlog.Columns[c].HeaderText, HeaderFont).Width;
                    }

                    for (int rowIndex = 0; rowIndex < nCount; rowIndex++)//rowindex当前行
                    {
                        for (int columnIndex = 0; columnIndex < iColCount; columnIndex++)//当前列
                        {
                            int w = (int)e.Graphics.MeasureString(dg_userlog.Rows[rowIndex].Cells[columnIndex].Value.ToString(), ContentFont
                                ).Width;
                            columnsWidth[columnIndex] = w > columnsWidth[columnIndex] ? w : columnsWidth[columnIndex];
                        }
                    }
                }
                
                int rowHidth = 23;
                int tableLeft = 30;
                int tableTop = 70;

                columnsLeft[0] = tableLeft;
                for (int i = 1; i <= iColCount - 1; i++)
                {
                    columnsLeft[i] = columnsLeft[i - 1] + columnsWidth[i - 1] + 20;
                }
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;//居中打印

                e.Graphics.DrawString(gAppData.SHName[gAppData.iCurrentSH] + TitleName, TitleFont, System.Drawing.Brushes.Black, new System.Drawing.Point(e.PageBounds.Width / 2, 25), sf);//打印标题                

                for (int c = 0; c < iColCount; c++)//打印表中的列名
                {
                    currentPoint.X = columnsLeft[c];
                    currentPoint.Y = tableTop;
                    e.Graphics.DrawString(dg_userlog.Columns[c].HeaderText, HeaderFont, Brushes.Black, currentPoint);


                    currentPoint2.X = columnsLeft[c] + columnsWidth[c];
                    for (int d = 0; d < 3; d++)//
                    {
                        currentPoint.Y = tableTop + 25 + d;
                        currentPoint2.Y = tableTop + 25 + d;
                        //Pen pen = new Pen(Brushes.Black);
                        e.Graphics.DrawLine(Pens.Black, currentPoint, currentPoint2);
                    }
                }
                //打印表中的内容         
                int iTempCount = 0;
                if (nCount - iCurrentLine > iLinePerPage)
                {
                    e.HasMorePages = true;
                    iTempCount = iLinePerPage;
                }
                else
                {
                    e.HasMorePages = false;
                    iTempCount = nCount - iCurrentLine;
                }
               
                //打印内容
                for (int rowIndex = 0; rowIndex < iTempCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < dg_userlog.Columns.Count; columnIndex++)
                    {
                        currentPoint.X = columnsLeft[columnIndex];
                        currentPoint.Y = tableTop + (int)(rowHidth * (rowIndex + 2));
                        string str = dg_userlog.Rows[iCurrentLine].Cells[columnIndex].Value.ToString();
                        e.Graphics.DrawString(str, ContentFont, System.Drawing.Brushes.Black, currentPoint);
                    }
                    iCurrentLine++;
                }
                //打印结束分割线
                currentPoint.X = columnsLeft[0];
                currentPoint2.X = columnsLeft[0] + e.PageBounds.Width - 100;
                for (int d = 0; d < 3; d++)
                {
                    currentPoint.Y = e.PageBounds.Height - 120 + d;
                    currentPoint2.Y = e.PageBounds.Height - 120 + d;
                    //Pen pen = new Pen(Brushes.Black);
                    e.Graphics.DrawLine(Pens.Black, currentPoint, currentPoint2);
                }
                e.Graphics.DrawString("打印时间:" + DateTime.Now.ToString(), HeaderFont, Brushes.Black, columnsLeft[0] + 10, currentPoint2.Y + 16);
                int iPagenum = (iCurrentLine / iLinePerPage);
                if (iCurrentLine % iLinePerPage > 0)
                {
                    iPagenum++;
                }
                e.Graphics.DrawString("页号:" + iPagenum.ToString(), HeaderFont, Brushes.Black, e.PageBounds.Width - 150, currentPoint2.Y + 16);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dg_userlog.Rows.Count <= 1)
            {
             //   MessageBox.Show("没有数据可以打印，请重新选择查询条件！");
                return;
            }
            m_reportForm.ShowDialog();
            /*
            printPreviewDialog1.Document = printDocument1;
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (System.Exception ex)
            {                
                //printPreviewDialog1.Dispose();
                printPreviewDialog1.Close();
                MessageBox.Show(ex.Message);
            }   */         
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            AddItemToCombobox(0);
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
    }
}
