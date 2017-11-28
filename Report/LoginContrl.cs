using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataReport
{
    public partial class LoginContrl : UserControl
    {
        public LoginContrl()
        {
            InitializeComponent();
            initLogin();
        }

        private void but_login_Click(object sender, EventArgs e)
        {
            if (combo_UserName.Text != "请选择" && txt_Password.Text != "")
            {
                if (HasUser(combo_UserName.Text,txt_Password.Text))
                {//登录成功
                    gAppData.user = combo_UserName.Text;
                    gAppData.pwd = txt_Password.Text;
                    gAppData.isLogin = true;

                    lab_note.Text = "用户" + gAppData.user + "登录成功";
                    //隐藏控件
                    combo_UserName.Hide();
                    txt_Password.Hide();
                    label_user.Hide();
                    label_pwd.Hide();
                    bt_login.Hide();

                }
                else
                {
                    MessageBox.Show("密码不正确");
                    gAppData.isLogin = false;
                }
            }
            else
            {
                MessageBox.Show("请选择用户并输入密码");
                gAppData.isLogin = false;
            }
        }
        private bool HasUser(string user, string pwd)
        {
            if (gAppData.HasUser(user, pwd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
        private void initLogin()
        {
            if (gAppData.isLogin)
                lab_note.Text = "用户" + gAppData.user + "登录成功";
            else
                lab_note.Text = "你还没有登录,请输入用户名、密码";
        }
        //初始化用户列表
        public void SetUserToCombobox()
        {
            DataSet ds = new DataSet();
            ds = gAppData.AddUserToCombobox();
            combo_UserName.DataSource = ds.Tables[0].DefaultView;
            combo_UserName.DisplayMember = "USER_ID";
            combo_UserName.ValueMember = "USER_ID";
        }
        public void ShowControls()
        {            
            lab_note.Text = "你还未登录，请输入用户名、密码";
            combo_UserName.Show();
            txt_Password.Show();
            label_user.Show();
            label_pwd.Show();
            bt_login.Show();
            
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            lab_note.Text = "用户成功注销";
            gAppData.isLogin = false;
            btn_logout.Hide();
        }

        public void ChangeSH()
        {
            //隐藏控件
            combo_UserName.Hide();
            txt_Password.Hide();
            label_user.Hide();
            label_pwd.Hide();
            bt_login.Hide();
            lab_note.Text = gAppData.SHName[gAppData.iCurrentSH] + "数据库切换成功";

        }
        public void Logout()
        { 
            //隐藏控件
            combo_UserName.Hide();
            txt_Password.Hide();
            label_user.Hide();
            label_pwd.Hide();
            bt_login.Hide();
            if (gAppData.isLogin)
            {
                lab_note.Text = "你确定要退出登录吗？";
                //显示注销按钮
                btn_logout.Show();
            }
            else
            {
                lab_note.Text = "你还未登录。";
            }
        }

        public void isLogin()
        {
            lab_note.Text = "用户" + gAppData.user + "登录成功";
            btn_logout.Hide();
        }

        private void LoginContrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                but_login_Click(sender, e);
            }
        }

        private void LoginContrl_VisibleChanged(object sender, EventArgs e)
        {
            txt_Password.Focus();
        }
    }
}
