namespace DataReport
{
    partial class LoginContrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginContrl));
            this.label1 = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.label_pwd = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.combo_UserName = new System.Windows.Forms.ComboBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lab_note = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(125, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 106);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据查询平台";
            // 
            // label_user
            // 
            this.label_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_user.Location = new System.Drawing.Point(159, 189);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(93, 27);
            this.label_user.TabIndex = 2;
            this.label_user.Text = "姓名：";
            // 
            // label_pwd
            // 
            this.label_pwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_pwd.AutoSize = true;
            this.label_pwd.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_pwd.Location = new System.Drawing.Point(159, 228);
            this.label_pwd.Name = "label_pwd";
            this.label_pwd.Size = new System.Drawing.Size(93, 27);
            this.label_pwd.TabIndex = 3;
            this.label_pwd.Text = "密码：";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Password.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.Location = new System.Drawing.Point(257, 228);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(226, 38);
            this.txt_Password.TabIndex = 4;
            this.txt_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginContrl_KeyDown);
            // 
            // combo_UserName
            // 
            this.combo_UserName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_UserName.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combo_UserName.FormattingEnabled = true;
            this.combo_UserName.Location = new System.Drawing.Point(257, 189);
            this.combo_UserName.Name = "combo_UserName";
            this.combo_UserName.Size = new System.Drawing.Size(226, 35);
            this.combo_UserName.TabIndex = 5;
            this.combo_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginContrl_KeyDown);
            // 
            // bt_login
            // 
            this.bt_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bt_login.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_login.Location = new System.Drawing.Point(311, 295);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(91, 29);
            this.bt_login.TabIndex = 6;
            this.bt_login.Text = "登录";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.but_login_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.Image = ((System.Drawing.Image)(resources.GetObject("btn_logout.Image")));
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(408, 295);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 29);
            this.btn_logout.TabIndex = 7;
            this.btn_logout.Text = "注销";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Visible = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // lab_note
            // 
            this.lab_note.AutoSize = true;
            this.lab_note.Location = new System.Drawing.Point(182, 143);
            this.lab_note.Name = "lab_note";
            this.lab_note.Size = new System.Drawing.Size(41, 12);
            this.lab_note.TabIndex = 8;
            this.lab_note.Text = "label2";
            // 
            // LoginContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lab_note);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.combo_UserName);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label_pwd);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "LoginContrl";
            this.Size = new System.Drawing.Size(756, 377);
            this.VisibleChanged += new System.EventHandler(this.LoginContrl_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginContrl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_pwd;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.ComboBox combo_UserName;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label lab_note;
    }
}
