namespace DataReport
{
    partial class Uselog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uselog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_userlog = new System.Windows.Forms.DataGridView();
            this.but_Export = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.DateTime_End = new System.Windows.Forms.DateTimePicker();
            this.DateTime_Start = new System.Windows.Forms.DateTimePicker();
            this.Combo_ObjName = new System.Windows.Forms.ComboBox();
            this.Combo_Objtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_QuickSearch = new System.Windows.Forms.TabPage();
            this.bt_search = new System.Windows.Forms.Button();
            this.tabPage_ExpertSearch = new System.Windows.Forms.TabPage();
            this.button_export_expert = new System.Windows.Forms.Button();
            this.button_print_expert = new System.Windows.Forms.Button();
            this.button_search_expert = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.comboBox_value3 = new System.Windows.Forms.ComboBox();
            this.comboBox_value2 = new System.Windows.Forms.ComboBox();
            this.comboBox_value1 = new System.Windows.Forms.ComboBox();
            this.comboBox_criteria3 = new System.Windows.Forms.ComboBox();
            this.comboBox_orderType2 = new System.Windows.Forms.ComboBox();
            this.comboBox_orderCol2 = new System.Windows.Forms.ComboBox();
            this.comboBox_ralation2 = new System.Windows.Forms.ComboBox();
            this.comboBox_orderType1 = new System.Windows.Forms.ComboBox();
            this.comboBox_orderCol1 = new System.Windows.Forms.ComboBox();
            this.comboBox_ralation1 = new System.Windows.Forms.ComboBox();
            this.comboBox_criteria2 = new System.Windows.Forms.ComboBox();
            this.comboBox_criteria1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Column3 = new System.Windows.Forms.ComboBox();
            this.comboBox_Column2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Column1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip_Search_Condition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全部选择XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部取消YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_SQLSearch = new System.Windows.Forms.TabPage();
            this.richTextBox_SQL = new System.Windows.Forms.RichTextBox();
            this.button_SQLexport = new System.Windows.Forms.Button();
            this.button_SQLPrint = new System.Windows.Forms.Button();
            this.button_SQLSearch = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_userlog)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_QuickSearch.SuspendLayout();
            this.tabPage_ExpertSearch.SuspendLayout();
            this.contextMenuStrip_Search_Condition.SuspendLayout();
            this.tabPage_SQLSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dg_userlog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 186);
            this.panel1.TabIndex = 0;
            // 
            // dg_userlog
            // 
            this.dg_userlog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_userlog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_userlog.BackgroundColor = System.Drawing.Color.White;
            this.dg_userlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_userlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_userlog.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dg_userlog.Location = new System.Drawing.Point(0, 0);
            this.dg_userlog.Name = "dg_userlog";
            this.dg_userlog.RowTemplate.Height = 23;
            this.dg_userlog.Size = new System.Drawing.Size(654, 186);
            this.dg_userlog.TabIndex = 1;
            // 
            // but_Export
            // 
            this.but_Export.Location = new System.Drawing.Point(280, 88);
            this.but_Export.Name = "but_Export";
            this.but_Export.Size = new System.Drawing.Size(79, 25);
            this.but_Export.TabIndex = 8;
            this.but_Export.Text = "导出";
            this.but_Export.UseVisualStyleBackColor = true;
            this.but_Export.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(183, 88);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(79, 25);
            this.btn_print.TabIndex = 8;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // DateTime_End
            // 
            this.DateTime_End.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DateTime_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTime_End.Location = new System.Drawing.Point(93, 59);
            this.DateTime_End.Name = "DateTime_End";
            this.DateTime_End.Size = new System.Drawing.Size(139, 21);
            this.DateTime_End.TabIndex = 7;
            // 
            // DateTime_Start
            // 
            this.DateTime_Start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DateTime_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTime_Start.Location = new System.Drawing.Point(93, 33);
            this.DateTime_Start.Name = "DateTime_Start";
            this.DateTime_Start.Size = new System.Drawing.Size(139, 21);
            this.DateTime_Start.TabIndex = 6;
            this.DateTime_Start.Value = new System.DateTime(2011, 8, 3, 15, 19, 47, 0);
            // 
            // Combo_ObjName
            // 
            this.Combo_ObjName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_ObjName.FormattingEnabled = true;
            this.Combo_ObjName.Location = new System.Drawing.Point(324, 5);
            this.Combo_ObjName.Name = "Combo_ObjName";
            this.Combo_ObjName.Size = new System.Drawing.Size(124, 20);
            this.Combo_ObjName.TabIndex = 5;
            // 
            // Combo_Objtype
            // 
            this.Combo_Objtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Objtype.FormattingEnabled = true;
            this.Combo_Objtype.Location = new System.Drawing.Point(93, 6);
            this.Combo_Objtype.Name = "Combo_Objtype";
            this.Combo_Objtype.Size = new System.Drawing.Size(139, 20);
            this.Combo_Objtype.TabIndex = 4;
            this.Combo_Objtype.SelectedValueChanged += new System.EventHandler(this.Object_Type_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询对象";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "开始时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "对象类型";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_QuickSearch);
            this.tabControl1.Controls.Add(this.tabPage_ExpertSearch);
            this.tabControl1.Controls.Add(this.tabPage_SQLSearch);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 144);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tabPage_QuickSearch
            // 
            this.tabPage_QuickSearch.Controls.Add(this.but_Export);
            this.tabPage_QuickSearch.Controls.Add(this.Combo_Objtype);
            this.tabPage_QuickSearch.Controls.Add(this.btn_print);
            this.tabPage_QuickSearch.Controls.Add(this.label1);
            this.tabPage_QuickSearch.Controls.Add(this.bt_search);
            this.tabPage_QuickSearch.Controls.Add(this.label2);
            this.tabPage_QuickSearch.Controls.Add(this.DateTime_End);
            this.tabPage_QuickSearch.Controls.Add(this.label3);
            this.tabPage_QuickSearch.Controls.Add(this.DateTime_Start);
            this.tabPage_QuickSearch.Controls.Add(this.label4);
            this.tabPage_QuickSearch.Controls.Add(this.Combo_ObjName);
            this.tabPage_QuickSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPage_QuickSearch.Name = "tabPage_QuickSearch";
            this.tabPage_QuickSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_QuickSearch.Size = new System.Drawing.Size(646, 118);
            this.tabPage_QuickSearch.TabIndex = 0;
            this.tabPage_QuickSearch.Text = "快速查询";
            this.tabPage_QuickSearch.UseVisualStyleBackColor = true;
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(84, 88);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(79, 25);
            this.bt_search.TabIndex = 8;
            this.bt_search.Text = "查询";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // tabPage_ExpertSearch
            // 
            this.tabPage_ExpertSearch.Controls.Add(this.button_export_expert);
            this.tabPage_ExpertSearch.Controls.Add(this.button_print_expert);
            this.tabPage_ExpertSearch.Controls.Add(this.button_search_expert);
            this.tabPage_ExpertSearch.Controls.Add(this.label15);
            this.tabPage_ExpertSearch.Controls.Add(this.dateTimePicker_end);
            this.tabPage_ExpertSearch.Controls.Add(this.dateTimePicker_start);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_value3);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_value2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_value1);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_criteria3);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_orderType2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_orderCol2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_ralation2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_orderType1);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_orderCol1);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_ralation1);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_criteria2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_criteria1);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_Column3);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_Column2);
            this.tabPage_ExpertSearch.Controls.Add(this.comboBox_Column1);
            this.tabPage_ExpertSearch.Controls.Add(this.label10);
            this.tabPage_ExpertSearch.Controls.Add(this.label9);
            this.tabPage_ExpertSearch.Controls.Add(this.label8);
            this.tabPage_ExpertSearch.Controls.Add(this.label7);
            this.tabPage_ExpertSearch.Controls.Add(this.label6);
            this.tabPage_ExpertSearch.Controls.Add(this.label14);
            this.tabPage_ExpertSearch.Controls.Add(this.label13);
            this.tabPage_ExpertSearch.Controls.Add(this.label12);
            this.tabPage_ExpertSearch.Controls.Add(this.label11);
            this.tabPage_ExpertSearch.Controls.Add(this.label5);
            this.tabPage_ExpertSearch.Controls.Add(this.checkedListBox1);
            this.tabPage_ExpertSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ExpertSearch.Name = "tabPage_ExpertSearch";
            this.tabPage_ExpertSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ExpertSearch.Size = new System.Drawing.Size(646, 118);
            this.tabPage_ExpertSearch.TabIndex = 1;
            this.tabPage_ExpertSearch.Text = "高级查询";
            this.tabPage_ExpertSearch.UseVisualStyleBackColor = true;
            // 
            // button_export_expert
            // 
            this.button_export_expert.Location = new System.Drawing.Point(602, 85);
            this.button_export_expert.Name = "button_export_expert";
            this.button_export_expert.Size = new System.Drawing.Size(38, 25);
            this.button_export_expert.TabIndex = 14;
            this.button_export_expert.Text = "导出";
            this.button_export_expert.UseVisualStyleBackColor = true;
            this.button_export_expert.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // button_print_expert
            // 
            this.button_print_expert.Location = new System.Drawing.Point(544, 85);
            this.button_print_expert.Name = "button_print_expert";
            this.button_print_expert.Size = new System.Drawing.Size(38, 25);
            this.button_print_expert.TabIndex = 13;
            this.button_print_expert.Text = "打印";
            this.button_print_expert.UseVisualStyleBackColor = true;
            this.button_print_expert.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // button_search_expert
            // 
            this.button_search_expert.Location = new System.Drawing.Point(485, 85);
            this.button_search_expert.Name = "button_search_expert";
            this.button_search_expert.Size = new System.Drawing.Size(38, 25);
            this.button_search_expert.TabIndex = 12;
            this.button_search_expert.Text = "查询";
            this.button_search_expert.UseVisualStyleBackColor = true;
            this.button_search_expert.Click += new System.EventHandler(this.button_search_expert_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(314, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "至";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_end.Location = new System.Drawing.Point(337, 88);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(135, 21);
            this.dateTimePicker_end.TabIndex = 8;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_start.Location = new System.Drawing.Point(173, 88);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(135, 21);
            this.dateTimePicker_start.TabIndex = 8;
            // 
            // comboBox_value3
            // 
            this.comboBox_value3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_value3.FormattingEnabled = true;
            this.comboBox_value3.Location = new System.Drawing.Point(315, 63);
            this.comboBox_value3.Name = "comboBox_value3";
            this.comboBox_value3.Size = new System.Drawing.Size(86, 20);
            this.comboBox_value3.TabIndex = 7;
            // 
            // comboBox_value2
            // 
            this.comboBox_value2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_value2.FormattingEnabled = true;
            this.comboBox_value2.Location = new System.Drawing.Point(315, 43);
            this.comboBox_value2.Name = "comboBox_value2";
            this.comboBox_value2.Size = new System.Drawing.Size(86, 20);
            this.comboBox_value2.TabIndex = 7;
            // 
            // comboBox_value1
            // 
            this.comboBox_value1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_value1.FormattingEnabled = true;
            this.comboBox_value1.Location = new System.Drawing.Point(315, 22);
            this.comboBox_value1.Name = "comboBox_value1";
            this.comboBox_value1.Size = new System.Drawing.Size(86, 20);
            this.comboBox_value1.TabIndex = 7;
            // 
            // comboBox_criteria3
            // 
            this.comboBox_criteria3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_criteria3.FormattingEnabled = true;
            this.comboBox_criteria3.Items.AddRange(new object[] {
            "=",
            "!="});
            this.comboBox_criteria3.Location = new System.Drawing.Point(257, 64);
            this.comboBox_criteria3.Name = "comboBox_criteria3";
            this.comboBox_criteria3.Size = new System.Drawing.Size(51, 20);
            this.comboBox_criteria3.TabIndex = 7;
            // 
            // comboBox_orderType2
            // 
            this.comboBox_orderType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderType2.FormattingEnabled = true;
            this.comboBox_orderType2.Items.AddRange(new object[] {
            "升序",
            "降序"});
            this.comboBox_orderType2.Location = new System.Drawing.Point(589, 45);
            this.comboBox_orderType2.Name = "comboBox_orderType2";
            this.comboBox_orderType2.Size = new System.Drawing.Size(51, 20);
            this.comboBox_orderType2.TabIndex = 7;
            // 
            // comboBox_orderCol2
            // 
            this.comboBox_orderCol2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderCol2.FormattingEnabled = true;
            this.comboBox_orderCol2.Items.AddRange(new object[] {
            "无"});
            this.comboBox_orderCol2.Location = new System.Drawing.Point(485, 44);
            this.comboBox_orderCol2.Name = "comboBox_orderCol2";
            this.comboBox_orderCol2.Size = new System.Drawing.Size(83, 20);
            this.comboBox_orderCol2.TabIndex = 7;
            // 
            // comboBox_ralation2
            // 
            this.comboBox_ralation2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ralation2.FormattingEnabled = true;
            this.comboBox_ralation2.Items.AddRange(new object[] {
            "无",
            "且",
            "或"});
            this.comboBox_ralation2.Location = new System.Drawing.Point(407, 43);
            this.comboBox_ralation2.Name = "comboBox_ralation2";
            this.comboBox_ralation2.Size = new System.Drawing.Size(51, 20);
            this.comboBox_ralation2.TabIndex = 7;
            this.comboBox_ralation2.SelectedValueChanged += new System.EventHandler(this.comboBox_ralation2_SelectedValueChanged);
            // 
            // comboBox_orderType1
            // 
            this.comboBox_orderType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderType1.FormattingEnabled = true;
            this.comboBox_orderType1.Items.AddRange(new object[] {
            "升序",
            "降序"});
            this.comboBox_orderType1.Location = new System.Drawing.Point(589, 23);
            this.comboBox_orderType1.Name = "comboBox_orderType1";
            this.comboBox_orderType1.Size = new System.Drawing.Size(51, 20);
            this.comboBox_orderType1.TabIndex = 7;
            // 
            // comboBox_orderCol1
            // 
            this.comboBox_orderCol1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_orderCol1.FormattingEnabled = true;
            this.comboBox_orderCol1.Items.AddRange(new object[] {
            "无"});
            this.comboBox_orderCol1.Location = new System.Drawing.Point(485, 23);
            this.comboBox_orderCol1.Name = "comboBox_orderCol1";
            this.comboBox_orderCol1.Size = new System.Drawing.Size(83, 20);
            this.comboBox_orderCol1.TabIndex = 7;
            // 
            // comboBox_ralation1
            // 
            this.comboBox_ralation1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ralation1.FormattingEnabled = true;
            this.comboBox_ralation1.Items.AddRange(new object[] {
            "无",
            "且",
            "或"});
            this.comboBox_ralation1.Location = new System.Drawing.Point(407, 22);
            this.comboBox_ralation1.Name = "comboBox_ralation1";
            this.comboBox_ralation1.Size = new System.Drawing.Size(51, 20);
            this.comboBox_ralation1.TabIndex = 7;
            this.comboBox_ralation1.SelectedValueChanged += new System.EventHandler(this.comboBox_ralation1_SelectedValueChanged);
            // 
            // comboBox_criteria2
            // 
            this.comboBox_criteria2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_criteria2.FormattingEnabled = true;
            this.comboBox_criteria2.Items.AddRange(new object[] {
            "=",
            "!="});
            this.comboBox_criteria2.Location = new System.Drawing.Point(257, 42);
            this.comboBox_criteria2.Name = "comboBox_criteria2";
            this.comboBox_criteria2.Size = new System.Drawing.Size(51, 20);
            this.comboBox_criteria2.TabIndex = 7;
            // 
            // comboBox_criteria1
            // 
            this.comboBox_criteria1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_criteria1.FormattingEnabled = true;
            this.comboBox_criteria1.Items.AddRange(new object[] {
            "=",
            "!="});
            this.comboBox_criteria1.Location = new System.Drawing.Point(257, 21);
            this.comboBox_criteria1.Name = "comboBox_criteria1";
            this.comboBox_criteria1.Size = new System.Drawing.Size(51, 20);
            this.comboBox_criteria1.TabIndex = 7;
            // 
            // comboBox_Column3
            // 
            this.comboBox_Column3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Column3.FormattingEnabled = true;
            this.comboBox_Column3.Location = new System.Drawing.Point(162, 62);
            this.comboBox_Column3.Name = "comboBox_Column3";
            this.comboBox_Column3.Size = new System.Drawing.Size(90, 20);
            this.comboBox_Column3.TabIndex = 7;
            this.comboBox_Column3.SelectedValueChanged += new System.EventHandler(this.comboBox_Column3_SelectedValueChanged);
            // 
            // comboBox_Column2
            // 
            this.comboBox_Column2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Column2.FormattingEnabled = true;
            this.comboBox_Column2.Location = new System.Drawing.Point(162, 42);
            this.comboBox_Column2.Name = "comboBox_Column2";
            this.comboBox_Column2.Size = new System.Drawing.Size(90, 20);
            this.comboBox_Column2.TabIndex = 7;
            this.comboBox_Column2.SelectedValueChanged += new System.EventHandler(this.comboBox_Column2_SelectedValueChanged);
            // 
            // comboBox_Column1
            // 
            this.comboBox_Column1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Column1.FormattingEnabled = true;
            this.comboBox_Column1.Location = new System.Drawing.Point(162, 21);
            this.comboBox_Column1.Name = "comboBox_Column1";
            this.comboBox_Column1.Size = new System.Drawing.Size(90, 20);
            this.comboBox_Column1.TabIndex = 7;
            this.comboBox_Column1.SelectedValueChanged += new System.EventHandler(this.comboBox_Column1_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(587, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "排序方式";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "排序字段";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "组合关系";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "查询值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "查询条件";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "时间段";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "条件3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "条件2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(121, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "条件1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "查询字段";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip_Search_Condition;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(109, 100);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck_1);
            // 
            // contextMenuStrip_Search_Condition
            // 
            this.contextMenuStrip_Search_Condition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部选择XToolStripMenuItem,
            this.全部取消YToolStripMenuItem,
            this.反选ZToolStripMenuItem});
            this.contextMenuStrip_Search_Condition.Name = "contextMenuStrip_Search_Condition";
            this.contextMenuStrip_Search_Condition.Size = new System.Drawing.Size(141, 70);
            // 
            // 全部选择XToolStripMenuItem
            // 
            this.全部选择XToolStripMenuItem.Name = "全部选择XToolStripMenuItem";
            this.全部选择XToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.全部选择XToolStripMenuItem.Text = "全部选择(X)";
            this.全部选择XToolStripMenuItem.Click += new System.EventHandler(this.全部选择XToolStripMenuItem_Click);
            // 
            // 全部取消YToolStripMenuItem
            // 
            this.全部取消YToolStripMenuItem.Name = "全部取消YToolStripMenuItem";
            this.全部取消YToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.全部取消YToolStripMenuItem.Text = "全部取消(Y)";
            this.全部取消YToolStripMenuItem.Click += new System.EventHandler(this.全部取消YToolStripMenuItem_Click);
            // 
            // 反选ZToolStripMenuItem
            // 
            this.反选ZToolStripMenuItem.Name = "反选ZToolStripMenuItem";
            this.反选ZToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.反选ZToolStripMenuItem.Text = "反选(Z)";
            this.反选ZToolStripMenuItem.Click += new System.EventHandler(this.反选ZToolStripMenuItem_Click);
            // 
            // tabPage_SQLSearch
            // 
            this.tabPage_SQLSearch.Controls.Add(this.richTextBox_SQL);
            this.tabPage_SQLSearch.Controls.Add(this.button_SQLexport);
            this.tabPage_SQLSearch.Controls.Add(this.button_SQLPrint);
            this.tabPage_SQLSearch.Controls.Add(this.button_SQLSearch);
            this.tabPage_SQLSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SQLSearch.Name = "tabPage_SQLSearch";
            this.tabPage_SQLSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SQLSearch.Size = new System.Drawing.Size(646, 118);
            this.tabPage_SQLSearch.TabIndex = 2;
            this.tabPage_SQLSearch.Text = "SQL语句查询";
            this.tabPage_SQLSearch.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SQL
            // 
            this.richTextBox_SQL.Location = new System.Drawing.Point(6, 6);
            this.richTextBox_SQL.Name = "richTextBox_SQL";
            this.richTextBox_SQL.Size = new System.Drawing.Size(523, 80);
            this.richTextBox_SQL.TabIndex = 12;
            this.richTextBox_SQL.Text = "";
            // 
            // button_SQLexport
            // 
            this.button_SQLexport.Location = new System.Drawing.Point(258, 90);
            this.button_SQLexport.Name = "button_SQLexport";
            this.button_SQLexport.Size = new System.Drawing.Size(79, 25);
            this.button_SQLexport.TabIndex = 11;
            this.button_SQLexport.Text = "导出";
            this.button_SQLexport.UseVisualStyleBackColor = true;
            this.button_SQLexport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // button_SQLPrint
            // 
            this.button_SQLPrint.Location = new System.Drawing.Point(161, 90);
            this.button_SQLPrint.Name = "button_SQLPrint";
            this.button_SQLPrint.Size = new System.Drawing.Size(79, 25);
            this.button_SQLPrint.TabIndex = 10;
            this.button_SQLPrint.Text = "打印";
            this.button_SQLPrint.UseVisualStyleBackColor = true;
            this.button_SQLPrint.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // button_SQLSearch
            // 
            this.button_SQLSearch.Location = new System.Drawing.Point(62, 90);
            this.button_SQLSearch.Name = "button_SQLSearch";
            this.button_SQLSearch.Size = new System.Drawing.Size(79, 25);
            this.button_SQLSearch.TabIndex = 9;
            this.button_SQLSearch.Text = "查询";
            this.button_SQLSearch.UseVisualStyleBackColor = true;
            this.button_SQLSearch.Click += new System.EventHandler(this.button_SQLSearch_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Uselog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Uselog";
            this.Size = new System.Drawing.Size(654, 330);
            this.Load += new System.EventHandler(this.Uselog_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_userlog)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_QuickSearch.ResumeLayout(false);
            this.tabPage_QuickSearch.PerformLayout();
            this.tabPage_ExpertSearch.ResumeLayout(false);
            this.tabPage_ExpertSearch.PerformLayout();
            this.contextMenuStrip_Search_Condition.ResumeLayout(false);
            this.tabPage_SQLSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Combo_ObjName;
        private System.Windows.Forms.ComboBox Combo_Objtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_Export;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DateTimePicker DateTime_End;
        private System.Windows.Forms.DateTimePicker DateTime_Start;
        private System.Windows.Forms.DataGridView dg_userlog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_QuickSearch;
        private System.Windows.Forms.TabPage tabPage_ExpertSearch;
        private System.Windows.Forms.TabPage tabPage_SQLSearch;
        private System.Windows.Forms.Button button_SQLexport;
        private System.Windows.Forms.Button button_SQLPrint;
        private System.Windows.Forms.Button button_SQLSearch;
        private System.Windows.Forms.RichTextBox richTextBox_SQL;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_value3;
        private System.Windows.Forms.ComboBox comboBox_value2;
        private System.Windows.Forms.ComboBox comboBox_value1;
        private System.Windows.Forms.ComboBox comboBox_criteria3;
        private System.Windows.Forms.ComboBox comboBox_orderCol2;
        private System.Windows.Forms.ComboBox comboBox_ralation2;
        private System.Windows.Forms.ComboBox comboBox_orderCol1;
        private System.Windows.Forms.ComboBox comboBox_ralation1;
        private System.Windows.Forms.ComboBox comboBox_criteria2;
        private System.Windows.Forms.ComboBox comboBox_criteria1;
        private System.Windows.Forms.ComboBox comboBox_Column3;
        private System.Windows.Forms.ComboBox comboBox_Column2;
        private System.Windows.Forms.ComboBox comboBox_Column1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_export_expert;
        private System.Windows.Forms.Button button_print_expert;
        private System.Windows.Forms.Button button_search_expert;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.ComboBox comboBox_orderType2;
        private System.Windows.Forms.ComboBox comboBox_orderType1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Search_Condition;
        private System.Windows.Forms.ToolStripMenuItem 全部选择XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部取消YToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反选ZToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button bt_search;
    }
}
