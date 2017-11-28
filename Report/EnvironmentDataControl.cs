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
    public partial class EnvironmentDataControl : UserControl
    {
        public string tableName;
        public string TitleName;
        private ReportFormTemp m_reportForm = new ReportFormTemp();
        private int iCurrentLine;
        private int[] columnsWidth = new int[20];//得到所有列的个数
        private int[] columnsLeft = new int[20]; //
        private int iLinePerPage = 40;//设置每页打印记录条数
        private int nCount = 0;
        private int iColCount = 0;

        delegate void DelegateMaskForm();//委托 用委托的方式显示加载提示画面
        DelegateMaskForm handleDelegate;
        Thread td;

        public EnvironmentDataControl()
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            textBox_upline.Text = "0";
            textBox_downline.Text = "0";
            string startDT, endDT, searchObject;
            startDT = DateTime_Start.Text;
            endDT = DateTime_End.Text;
            searchObject = Combo_SearchObj.SelectedValue.ToString();
            if (tableName == "车检器VIEW")
            {
                panel_linesum.Show();
                DataSet dssum = new DataSet();
                dssum = gAppData.getTotalflow(startDT, endDT, "全部类型", searchObject);
                textBox_upline.Text = "0";
                textBox_downline.Text = "0";
                textBox_leftline.Text = "0";
                textBox_rightline.Text = "0";
                if (dssum.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < dssum.Tables[0].Rows.Count; i++)
                        {
                            string linename = dssum.Tables[0].Rows[i]["行车方向"].ToString().Trim();
                            switch (linename)
                            {
                                case "上行":
                                    textBox_upline.Text = dssum.Tables[0].Rows[i]["总车流量"].ToString();
                                    break;
                                case "下行":
                                    textBox_downline.Text = dssum.Tables[0].Rows[i]["总车流量"].ToString();
                                    break;
                                case "左线":
                                    textBox_leftline.Text = dssum.Tables[0].Rows[i]["总车流量"].ToString();
                                    break;
                                case "右线":
                                    textBox_rightline.Text = dssum.Tables[0].Rows[i]["总车流量"].ToString();
                                    break;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }
            else
            {
                panel_linesum.Hide();
            }
            dg_hjsj.DataSource = null;
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            DataSet ds = new DataSet();
            
            ds = gAppData.getdataset(tableName, startDT, endDT, "全部类型", searchObject);
            m_reportForm.m_ds = ds;
            m_reportForm.m_TableName = tableName;
            
            dg_hjsj.DataSource = ds.Tables[0].DefaultView;
            td.Abort();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            gAppData.DataGridViewExport(dg_hjsj, tableName, true, "  ");
        }

        private void tabControl_EnvSeting_VisibleChanged(object sender, EventArgs e)
        {
            dg_hjsj.DataSource = null;
            Combo_SearchObj.SelectedIndex = -1;
            DateTime_Start.Value = DateTime.Now;
            DateTime_End.Value = DateTime.Now;
            string sql = "";
            DataRow dr;
            DataSet ds1;

            switch (tableName)
            {
                case "COVIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = 'CO检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case "气象仪VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = '气象检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case "车检器VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = '车辆检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case "光检VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = '光强检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case "VIVIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = 'VI检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                case "风速VIEW":
                    sql = "select 对象名 from 设备对象表 where 对象类型 = '风向/风速检测仪'";
                    ds1 = gAppData.GetDS(sql);
                    dr = ds1.Tables[0].NewRow();
                    dr["对象名"] = "全部对象";
                    ds1.Tables[0].Rows.InsertAt(dr, 0);
                    Combo_SearchObj.DataSource = ds1.Tables[0].DefaultView;
                    Combo_SearchObj.DisplayMember = "对象名";
                    Combo_SearchObj.ValueMember = "对象名";
                    break;
                default:
                    break;
            }
        }

        private void btn_SQL_Search_Click(object sender, EventArgs e)
        {
            string sqlText = richTextBox_SQL.Text;
            if (sqlText.Trim() == "")
            {
                MessageBox.Show("你还没有输入sql语句，请输入!");
                return;
            }
            //this.Invoke(handleDelegate);
            td = new Thread(MaskForm);
            td.Start();
            DataSet ds = new DataSet();
            ds = gAppData.GetDS(sqlText);
            if (ds != null)
            {
                dg_hjsj.DataSource = ds.Tables[0].DefaultView;
            }
            td.Abort();
            //else
            //{
            //    dg_hjsj.DataSource = null;
            //}
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            iCurrentLine = 0;
            nCount = dg_hjsj.Rows.Count - 1;
            iColCount = dg_hjsj.Columns.Count;
            printDocument1.DocumentName = (nCount / iLinePerPage + (nCount % iLinePerPage > 0 ? 1 : 0)).ToString();
            //switch (tableName)
            //{
            //    case "COVIEW":
            //        TitleName = "CO检测值查询";
            //        break;
            //    case "气象仪VIEW":
            //        TitleName = "气象仪检测值查询";
            //        break;
            //    case "车检器VIEW":
            //        TitleName = "车检仪检测值查询";
            //        break;
            //    case "光检VIEW":
            //        TitleName = "光强检测值查询";
            //        break;
            //    case "VIVIEW":
            //        TitleName = "VI检测值查询";
            //        break;
            //    case "风速VIEW":
            //        TitleName = "风速检测值查询";
            //        break;
            //}
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dg_hjsj.DataBindings != null)
            {
                System.Drawing.Font TitleFont = new System.Drawing.Font("隶书", 25, FontStyle.Bold);
                System.Drawing.Font HeaderFont = new System.Drawing.Font("宋体", 10);
                System.Drawing.Font ContentFont = new System.Drawing.Font("宋体", 10);

                System.Drawing.Point currentPoint = new System.Drawing.Point();
                System.Drawing.Point currentPoint2 = new System.Drawing.Point();
                
                //int[] columnsWidth = new int[dg_userlog.Columns.Count];//得到所有列的个数
                //int[] columnsLeft = new int[dg_userlog.Columns.Count]; //
                if (iCurrentLine == 0)
                {
                    for (int c = 0; c < iColCount; c++)//得到列标题的宽度          
                    {
                        columnsWidth[c] = (int)e.Graphics.MeasureString(dg_hjsj.Columns[c].HeaderText, HeaderFont).Width;
                    }

                    for (int rowIndex = 0; rowIndex < nCount; rowIndex++)//rowindex当前行
                    {
                        for (int columnIndex = 0; columnIndex < iColCount; columnIndex++)//当前列
                        {
                            int w = (int)e.Graphics.MeasureString(dg_hjsj.Rows[rowIndex].Cells[columnIndex].Value.ToString(), ContentFont
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
                    e.Graphics.DrawString(dg_hjsj.Columns[c].HeaderText, HeaderFont, Brushes.Black, currentPoint);


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
                    for (int columnIndex = 0; columnIndex < dg_hjsj.Columns.Count; columnIndex++)
                    {
                        currentPoint.X = columnsLeft[columnIndex];
                        currentPoint.Y = tableTop +(int)(rowHidth * (rowIndex + 2));
                        string str = dg_hjsj.Rows[iCurrentLine].Cells[columnIndex].Value.ToString();
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
                e.Graphics.DrawString("打印时间:" + DateTime.Now.ToString(), HeaderFont, Brushes.Black, columnsLeft[0] + 10, currentPoint2.Y + 20);
                int iPagenum = (iCurrentLine / iLinePerPage);
                if (iCurrentLine % iLinePerPage > 0)
                {
                    iPagenum++;
                }
                e.Graphics.DrawString("页号:" + iPagenum.ToString(), HeaderFont, Brushes.Black, e.PageBounds.Width - 150, currentPoint2.Y + 20);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dg_hjsj.Rows.Count<=1)
            {
    //            MessageBox.Show("没有数据可以打印，请重新选择查询条件！");
                return;
            }
            m_reportForm.ShowDialog();
            /*
            //printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
             * */
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

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            AddItemToCombobox(0);
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

        private void EnvironmentDataControl_Load(object sender, EventArgs e)
        {
            UpdateComboBoxs();
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
            dg_hjsj.DataSource = ds.Tables[0].DefaultView;
            td.Abort();
        }

        public void InitCheckListBox()
        {
            DataSet ds = new DataSet();
            checkedListBox1.DataSource = null;
            ds = gAppData.GetDS("select   列名=name   from   syscolumns   where   id=object_id(N'" + tableName + "')");
            checkedListBox1.DataSource = ds.Tables[0].DefaultView;
            checkedListBox1.DisplayMember = "列名";
            checkedListBox1.ValueMember = "列名";

            DataSet ds2 = new DataSet();
            ds2 = gAppData.GetDS("select   列名=name   from   syscolumns   where   id=object_id(N'" + tableName + "')" + ";select   列名=name   from   syscolumns   where   id=object_id(N'" + tableName + "')");
            DataRow dr;
            dr = ds2.Tables[0].NewRow();
            dr["列名"] = "无";
            ds2.Tables[0].Rows.InsertAt(dr, 0);
            dr = ds2.Tables[1].NewRow();
            dr["列名"] = "无";
            ds2.Tables[1].Rows.InsertAt(dr, 0);

            comboBox_orderCol1.DataSource = ds2.Tables[0].DefaultView;
            comboBox_orderCol1.DisplayMember = "列名";
            comboBox_orderCol1.ValueMember = "列名";

            comboBox_orderCol2.DataSource = ds2.Tables[1].DefaultView;
            comboBox_orderCol2.DisplayMember = "列名";
            comboBox_orderCol2.ValueMember = "列名";
            AddItemToCombobox(1);
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

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //int i = checkedListBox1.SelectedIndex;
            //checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
        }

    }
}
