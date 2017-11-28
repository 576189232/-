namespace DataReport
{
    partial class DataReportForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataReportForm));
            this.pushPanel1 = new CSharpWin.PushPanel();
            this.pushPanelItem2 = new CSharpWin.PushPanelItem();
            this.btn_gzjl = new System.Windows.Forms.RadioButton();
            this.btn_lsjl = new System.Windows.Forms.RadioButton();
            this.pushPanelItem1 = new CSharpWin.PushPanelItem();
            this.pushPanelItem3 = new CSharpWin.PushPanelItem();
            this.pushPanelItem4 = new CSharpWin.PushPanelItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uselog1 = new DataReport.Uselog();
            this.loginContrl1 = new DataReport.LoginContrl();
            this.EnvDataCtl = new DataReport.EnvironmentDataControl();
            this.ReportFormCtl = new DataReport.ReportFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).BeginInit();
            this.pushPanel1.SuspendLayout();
            this.pushPanelItem2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pushPanel1
            // 
            this.pushPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.pushPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pushPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pushPanel1.Items.AddRange(new CSharpWin.PushPanelItem[] {
            this.pushPanelItem2,
            this.pushPanelItem1,
            this.pushPanelItem3,
            this.pushPanelItem4});
            this.pushPanel1.Location = new System.Drawing.Point(0, 0);
            this.pushPanel1.Name = "pushPanel1";
            this.pushPanel1.Size = new System.Drawing.Size(157, 457);
            this.pushPanel1.TabIndex = 0;
            // 
            // pushPanelItem2
            // 
            this.pushPanelItem2.CaptionFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold);
            this.pushPanelItem2.Controls.Add(this.btn_gzjl);
            this.pushPanelItem2.Controls.Add(this.btn_lsjl);
            this.pushPanelItem2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pushPanelItem2.Name = "pushPanelItem2";
            this.pushPanelItem2.Text = "气象仪";
            // 
            // btn_gzjl
            // 
            this.btn_gzjl.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_gzjl.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_gzjl.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_gzjl.Image = ((System.Drawing.Image)(resources.GetObject("btn_gzjl.Image")));
            this.btn_gzjl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gzjl.Location = new System.Drawing.Point(2, 57);
            this.btn_gzjl.Name = "btn_gzjl";
            this.btn_gzjl.Size = new System.Drawing.Size(149, 33);
            this.btn_gzjl.TabIndex = 10;
            this.btn_gzjl.Text = "故障记录";
            this.btn_gzjl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_gzjl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_gzjl.UseVisualStyleBackColor = true;
            this.btn_gzjl.Click += new System.EventHandler(this.btn_gzjl_Click);
            // 
            // btn_lsjl
            // 
            this.btn_lsjl.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_lsjl.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_lsjl.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_lsjl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_lsjl.Image = ((System.Drawing.Image)(resources.GetObject("btn_lsjl.Image")));
            this.btn_lsjl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lsjl.Location = new System.Drawing.Point(2, 24);
            this.btn_lsjl.Name = "btn_lsjl";
            this.btn_lsjl.Size = new System.Drawing.Size(149, 33);
            this.btn_lsjl.TabIndex = 8;
            this.btn_lsjl.Text = "历史记录";
            this.btn_lsjl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_lsjl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_lsjl.UseVisualStyleBackColor = true;
            this.btn_lsjl.Click += new System.EventHandler(this.btn_lsjl_Click);
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold);
            this.pushPanelItem1.Name = "pushPanelItem1";
            this.pushPanelItem1.Text = "情报板";
            // 
            // pushPanelItem3
            // 
            this.pushPanelItem3.CaptionFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold);
            this.pushPanelItem3.Name = "pushPanelItem3";
            this.pushPanelItem3.Text = "超限检测";
            // 
            // pushPanelItem4
            // 
            this.pushPanelItem4.CaptionFont = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold);
            this.pushPanelItem4.Name = "pushPanelItem4";
            this.pushPanelItem4.Text = "诱导屏";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.uselog1);
            this.panel1.Controls.Add(this.loginContrl1);
            this.panel1.Controls.Add(this.EnvDataCtl);
            this.panel1.Controls.Add(this.ReportFormCtl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(157, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 457);
            this.panel1.TabIndex = 2;
            // 
            // uselog1
            // 
            this.uselog1.Location = new System.Drawing.Point(386, 26);
            this.uselog1.Name = "uselog1";
            this.uselog1.Size = new System.Drawing.Size(366, 232);
            this.uselog1.TabIndex = 1;
            this.uselog1.Visible = false;
            // 
            // loginContrl1
            // 
            this.loginContrl1.BackColor = System.Drawing.Color.Transparent;
            this.loginContrl1.Location = new System.Drawing.Point(129, 12);
            this.loginContrl1.Name = "loginContrl1";
            this.loginContrl1.Size = new System.Drawing.Size(816, 303);
            this.loginContrl1.TabIndex = 0;
            // 
            // EnvDataCtl
            // 
            this.EnvDataCtl.Location = new System.Drawing.Point(260, 252);
            this.EnvDataCtl.Name = "EnvDataCtl";
            this.EnvDataCtl.Size = new System.Drawing.Size(378, 193);
            this.EnvDataCtl.TabIndex = 2;
            this.EnvDataCtl.Visible = false;
            // 
            // ReportFormCtl
            // 
            this.ReportFormCtl.Location = new System.Drawing.Point(3, 261);
            this.ReportFormCtl.Name = "ReportFormCtl";
            this.ReportFormCtl.Size = new System.Drawing.Size(251, 191);
            this.ReportFormCtl.TabIndex = 3;
            this.ReportFormCtl.Visible = false;
            // 
            // DataReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pushPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataReportForm";
            this.Text = "数据查询平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).EndInit();
            this.pushPanel1.ResumeLayout(false);
            this.pushPanelItem2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpWin.PushPanel pushPanel1;
        private CSharpWin.PushPanelItem pushPanelItem2;
        private System.Windows.Forms.Panel panel1;
        private LoginContrl loginContrl1;
        private Uselog uselog1;
        private EnvironmentDataControl EnvDataCtl;
        private ReportFormControl ReportFormCtl;
        private System.Windows.Forms.RadioButton btn_lsjl;
        private System.Windows.Forms.RadioButton btn_gzjl;
        private CSharpWin.PushPanelItem pushPanelItem1;
        private CSharpWin.PushPanelItem pushPanelItem3;
        private CSharpWin.PushPanelItem pushPanelItem4;
        
    }
}

