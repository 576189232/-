using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DataReport
{
    public partial class ReportFormTemp : Form
    {
        public ReportFormTemp()
        {
            InitializeComponent();
        }
        public DataSet m_ds = new DataSet();
        public string m_TableName = "";//表明
        public string m_Title = "";//报表标题
        public string m_DateTime = "";//统计时间段
        public string m_Object = "";//统计对象
        public string m_Type = "";//检测数据类型
        public string m_ReportType = "";
        private void ReportFormTemp_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            switch (m_TableName)
            {
                case "情报板下发记录VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.情报板下发记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("情报板下发记录集", m_ds.Tables[0]));
                    break;
                case "诱导屏下发记录VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.诱导屏下发记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("诱导屏下发记录集", m_ds.Tables[0]));
                    break;
                case "策略操作VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.策略操作记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("策略操作记录集", m_ds.Tables[0]));
                    break;
                case "预案操作VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.预案操作记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("预案操作记录集", m_ds.Tables[0]));
                    break;
                case "模式更改记录表":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.模式更改记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("模式更改记录集", m_ds.Tables[0]));
                    break;
                case "设备运行状态VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.设备运行状态表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("设备运行状态集", m_ds.Tables[0]));
                    break;
                case "操作记录表VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.操作记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("操作记录集", m_ds.Tables[0]));
                    break;
                case "上下班登录表":
                    //为报表浏览器指定报表文件
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.值班记录表.rdlc";
                    //指定数据集,数据集名称后为表,不是DataSet类型的数据集
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("值班记录集", m_ds.Tables[0]));
                    break;
                case "报警记录表":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.报警记录表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("报警记录集", m_ds.Tables[0]));
                    break;
                case "COVIEW":
                    if (m_ReportType != "")
                    {

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.CO-VI-风速-光检日月年报表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("COVI风速光检日月年报表集", m_ds.Tables[0]));
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.CO检测数据表.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CO检测数据集", m_ds.Tables[0]));
                    }
                    break;
                case "气象仪VIEW":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.气象仪检测数据表.rdlc";
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("气象仪检测数据集", m_ds.Tables[0]));
                    break;
                case "车检器VIEW":
                    if (m_ReportType != "")
                    {

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.车检数据表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("车检数据集", m_ds.Tables[0]));
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.车检仪检测数据表.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("车检仪检测数据集", m_ds.Tables[0]));
                    }
                   
                    break;
                case "光检VIEW":
                    if (m_ReportType != "")
                    {

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.CO-VI-风速-光检日月年报表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("COVI风速光检日月年报表集", m_ds.Tables[0]));
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.光强检测数据表.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("光强检测数据集", m_ds.Tables[0]));
                    }
                    
                    break;
                case "VIVIEW":
                    if (m_ReportType != "")
                    {

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.CO-VI-风速-光检日月年报表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("COVI风速光检日月年报表集", m_ds.Tables[0]));
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.VI检测数据表.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("VI检测数据集", m_ds.Tables[0]));
                    }
                    
                    break;
                case "风速VIEW":
                    if (m_ReportType != "")
                    {

                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.CO-VI-风速-光检日月年报表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("COVI风速光检日月年报表集", m_ds.Tables[0]));
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.风速检测数据表.rdlc";
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("风速检测数据集", m_ds.Tables[0]));
                    }
                   
                    break;
                case "风机运行VIEW":
                    if (m_ReportType != "")
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.风机数据表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("风机数据集", m_ds.Tables[0]));
                    }                    
                    break;
                case "照明VIEW":
                    if (m_ReportType!="")
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "DataReport.报表.照明数据表.rdlc";
                        ReportParameter p1 = new ReportParameter("Title", m_Title);
                        ReportParameter p2 = new ReportParameter("Object", "统计对象：" + m_Object);
                        ReportParameter p3 = new ReportParameter("Datetime", "统计时间：" + m_DateTime);
                        ReportParameter p4 = new ReportParameter("Type", m_Type);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 }); //传递页眉文本框的参数值
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("照明数据集", m_ds.Tables[0]));
                    }
                    break;
                default:
                    break;
            }
            //显示报表
            this.reportViewer1.RefreshReport();
        }
    }
}
