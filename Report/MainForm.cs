using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DataReport
{
    public partial class DataReportForm : Form
    {
        public DataReportForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            gAppData.dataconn = ConfigurationManager.AppSettings["sqlconn"].ToString(); ;
            loginContrl1.SetUserToCombobox();//初始化用户名列表
            loginContrl1.Dock = DockStyle.Fill;
            uselog1.Dock = DockStyle.Fill;
            qiehuan();
            loginContrl1.Show();
/*
            StringBuilder temp = new StringBuilder(100);
            //MessageBox.Show(Environment.CurrentDirectory + "/Config.DLL");
            gAppData.GetPrivateProfileString("DATA CONFIG", "SQL SERVER NAME1", "10.100.15.4", temp, 100, Environment.CurrentDirectory + "/Config.DLL");
            gAppData.server1 = temp.ToString();
            gAppData.GetPrivateProfileString("DATA CONFIG", "SQL SERVER NAME2", "10.100.15.4", temp, 100, Environment.CurrentDirectory + "/Config.DLL");
            gAppData.server2 = temp.ToString();
            gAppData.GetPrivateProfileString("DATA CONFIG", "USER NAME", "sa", temp, 100, Environment.CurrentDirectory + "/Config.DLL");
            gAppData.user = temp.ToString();
            gAppData.GetPrivateProfileString("DATA CONFIG", "PASSWORD", "sa", temp, 100, Environment.CurrentDirectory + "/Config.DLL");
            gAppData.pwd = temp.ToString();
            gAppData.dataconn = "Data Source="+gAppData.server1+";User id="+gAppData.user+";password="+gAppData.pwd+";Initial Catalog=";
            
            gAppData.GetSystemDataBase();
            
            initSHMeun();//初始化隧道单选按钮

            SetTitle("登录界面");
            EnvDataCtl.Dock = DockStyle.Fill;
            ReportFormCtl.Dock = DockStyle.Fill;
            qiehuan();
            loginContrl1.Show();*/
        }
        private void but_loginForm_Click(object sender, EventArgs e)
        {
            qiehuan();
            SetTitle("用户登录界面");
            if (gAppData.isLogin)
            {
                loginContrl1.isLogin();
                loginContrl1.Show();
            }
            else
            {
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }            
        }
        private void qiehuan()
        {
            loginContrl1.Hide();            
            uselog1.Hide();
            EnvDataCtl.Hide();
            ReportFormCtl.Hide();
        }

        private void loginContrl1_VisibleChanged(object sender, EventArgs e)
        {

        }

     
       

        private void button4_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("操作记录查询");
                uselog1.tableName = "操作记录表VIEW";
                uselog1.TitleName = "操作记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("设备运行状态查询");
                uselog1.tableName = "设备运行状态VIEW";
                uselog1.TitleName = "设备运行状态查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("模式更改记录查询");
                uselog1.tableName = "模式更改记录表";
                uselog1.TitleName = "模式更改记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("预案操作记录查询");
                uselog1.tableName = "预案操作VIEW";
                uselog1.TitleName = "预案操作记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }    
        }

        private void button8_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("策略操作记录查询");
                uselog1.tableName = "策略操作VIEW";
                uselog1.TitleName = "策略操作记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }   
        }

        private void button9_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("情报板记录查询");
                uselog1.tableName = "情报板下发记录VIEW";
                uselog1.TitleName = "情报板下发记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("诱导屏下发记录查询");
                uselog1.tableName = "诱导屏下发记录VIEW";
                uselog1.TitleName = "诱导屏下发记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            qiehuan();
            SetTitle("用户注销界面");
            loginContrl1.Logout();
            loginContrl1.Show();
        }

        private void btnalarm_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("报警记录查询");
                uselog1.tableName = "报警记录表";
                uselog1.TitleName = "报警记录查询";
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //co检测数据
        private void button11_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("CO检测值查询");
                EnvDataCtl.tableName = "COVIEW";
                EnvDataCtl.TitleName = "CO检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //VI检测数据
        private void button12_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("VI检测值查询");
                EnvDataCtl.tableName = "VIVIEW";
                EnvDataCtl.TitleName = "VI检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //风速检测数据
        private void button13_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("风速检测值查询");
                EnvDataCtl.tableName = "风速VIEW";
                EnvDataCtl.TitleName = "风速检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //光强监测数据
        private void button14_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("光强检测值查询");
                EnvDataCtl.tableName = "光检VIEW";
                EnvDataCtl.TitleName = "光强检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //车检仪检测数据
        private void button15_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("车检仪检测值查询");
                EnvDataCtl.tableName = "车检器VIEW";
                EnvDataCtl.TitleName = "车检仪检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //气象仪检测数据
        private void button16_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("气象仪检测值查询");
                EnvDataCtl.tableName = "气象仪VIEW";
                EnvDataCtl.TitleName = "气象仪检测值查询";
                EnvDataCtl.InitCheckListBox();
                EnvDataCtl.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //日报表
        private void button17_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("日报表查询");
                ReportFormCtl.ReportFormType = "日报表";
                ReportFormCtl.Show();
                ReportFormCtl.InitCombobox();
                ReportFormCtl.UpdateControls();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //月报
        private void button18_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("月报表查询");
                ReportFormCtl.ReportFormType = "月报表";
                ReportFormCtl.Show();
                ReportFormCtl.InitCombobox();
                ReportFormCtl.UpdateControls();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }
        //年报
        private void button19_Click(object sender, EventArgs e)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle("年报表查询");
                ReportFormCtl.ReportFormType = "年报表";
                ReportFormCtl.Show();
                ReportFormCtl.InitCombobox();
                ReportFormCtl.UpdateControls();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            } 
        }

        public void SetTitle(string Title)
        {
            if (Title=="")
            {
                string[] title = this.Text.Split(new char[]{'-'});
                this.Text = gAppData.baseTitle + "-" + gAppData.SHName[gAppData.iCurrentSH] + "-" + title[2];
            }
            else
            {
                this.Text = gAppData.baseTitle + "-" + gAppData.SHName[gAppData.iCurrentSH] + "-" + Title;
            }            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);
            this.Close();
        }

        private void btn_lsjl_Click(object sender, EventArgs e)
        {
            InitSearchForm("Vid_Data_View", "历史记录查询");
        }
        public void InitSearchForm(string tableName,string TitleName)
        {
            qiehuan();
            if (gAppData.isLogin)
            {
                SetTitle(TitleName);
                uselog1.tableName = tableName;
                uselog1.TitleName = TitleName;
                uselog1.InitCobombox();
                uselog1.InitCheckListBox();
                uselog1.Show();
            }
            else
            {
                SetTitle("登陆界面");
                loginContrl1.ShowControls();
                loginContrl1.Show();
            }
        }
        private void btn_gzjl_Click(object sender, EventArgs e)
        {
            InitSearchForm("Alarm_Data_View", "报警记录查询");
        }


    }
}
