using System;
using System.Windows.Forms;
using DeviceDll.Device;

namespace WindowMake
{
    public partial class MainWindow : Form
    {
        private int FormCount;
        private FormView m_CurrentView;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu_New_Click(object sender, EventArgs e)
        {
            FormView frmTemp = new FormView(); //新建一个窗体对象，可根据需要新建自己设计的窗体 
            frmTemp.MdiParent = this; //设置窗口的MdiParent属性为当前主窗口，成为MDI子窗体 
            frmTemp.Text = "画面" + FormCount.ToString(); //设定MDI窗体的标题 
            frmTemp.SelectChanged += new System.EventHandler<SelectEventArgs>(this.FormView_ObjectSelectChanged);
            FormCount++; //FormCount是定义在主程序中的一个变量来记录产生的子窗口个数
            m_CurrentView = frmTemp;
            frmTemp.Show(); //把此MDI窗体显示出来

        }
        private void CreateView()
        {
            FormView frmTemp = new FormView(); //新建一个窗体对象，可根据需要新建自己设计的窗体 
            frmTemp.MdiParent = this; //设置窗口的MdiParent属性为当前主窗口，成为MDI子窗体 
            frmTemp.Text = "画面" + FormCount.ToString(); //设定MDI窗体的标题 
            frmTemp.SelectChanged += new System.EventHandler<SelectEventArgs>(this.FormView_ObjectSelectChanged);
            FormCount++; //FormCount是定义在主程序中的一个变量来记录产生的子窗口个数
            m_CurrentView = frmTemp;
            frmTemp.Show(); //把此MDI窗体显示出来
        }
        
        private void FormView_ObjectSelectChanged(object sender,SelectEventArgs e)
        {
            if (e.bSelect)
            {
                this.toolStripButton4.Enabled = true; 
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
                this.toolStripButton10.Enabled = true;
                this.toolStripButton11.Enabled = true;
                this.toolStripButton12.Enabled = true;
                this.toolStripButton13.Enabled = true;
                this.toolStripButton14.Enabled = true;
                this.toolStripButton15.Enabled = true;
                this.toolStripButton16.Enabled = true;
                this.toolStripButton17.Enabled = true;
                this.toolStripButton18.Enabled = true;
                this.CopyToolStripMenuItem.Enabled = true;
            }
            else 
            {
                this.toolStripButton4.Enabled = false;
                this.toolStripButton5.Enabled = false;
                this.toolStripButton6.Enabled = false;
                this.toolStripButton7.Enabled = false;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                this.toolStripButton10.Enabled = false;
                this.toolStripButton11.Enabled = false;
                this.toolStripButton12.Enabled = false;
                this.toolStripButton13.Enabled = false;
                this.toolStripButton14.Enabled = false;
                this.toolStripButton15.Enabled = false;
                this.toolStripButton16.Enabled = false;
                this.toolStripButton17.Enabled = false;
                this.toolStripButton18.Enabled = false;
                this.CopyToolStripMenuItem.Enabled = false;
            }
            if (e.bCopy)
                this.PasteToolStripMenuItem.Enabled = true;
            else
                this.PasteToolStripMenuItem.Enabled = false;
        }
        private void Menu_Cascade_Click(object sender, EventArgs e)// MDI窗体的层叠操作
        {
            this.LayoutMdi(MdiLayout.Cascade); 
        }

        private void Menu_TileH_Click(object sender, EventArgs e)// MDI窗体的水平平铺操作
        {
            this.LayoutMdi(MdiLayout.TileHorizontal); 
        }

        private void Menu_TileV_Click(object sender, EventArgs e)// MDI窗体的垂直平铺操作
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void Menu_ArrangeIcon_Click(object sender, EventArgs e)// MDI窗体的垂直平铺操作
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons); 
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        /// <summary>
        /// 选择设备类型后点击画面生成设备控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (1 < e.Node.Level)
            {
                switch (e.Node.Name)
                {
                    case "CF":
                        gMain.drawType = MyObject.ObjectType.CF;
                        break;
                    case "VC":
                        gMain.drawType = MyObject.ObjectType.VC;
                        break;
                    case "CL":
                        gMain.drawType = MyObject.ObjectType.CL;
                        break;
                    case "CM":
                        gMain.drawType = MyObject.ObjectType.CM;
                        break;
                    case "E":
                        gMain.drawType = MyObject.ObjectType.E;
                        break;
                    case "EP":
                        gMain.drawType = MyObject.ObjectType.EP;
                        break;
                    case "EP_R":
                        gMain.drawType = MyObject.ObjectType.EP_R;
                        break;
                    case "EP_T":
                        gMain.drawType = MyObject.ObjectType.EP_T;
                        break;
                    case "F_L":
                        gMain.drawType = MyObject.ObjectType.F_L;
                        break;
                    case "F_SB":
                        gMain.drawType = MyObject.ObjectType.F_SB;
                        break;
                    case "F_YG":
                        gMain.drawType = MyObject.ObjectType.F_YG;
                        break;
                    case "I":
                        gMain.drawType = MyObject.ObjectType.I;
                        break;
                    case "P_AF":
                        gMain.drawType = MyObject.ObjectType.P_AF;
                        break;
                    case "P_CL":
                        gMain.drawType = MyObject.ObjectType.P_CL;
                        break;
                    case "P_CO":
                        gMain.drawType = MyObject.ObjectType.P_CO;
                        break;
                    case "P_GJ":
                        gMain.drawType = MyObject.ObjectType.P_GJ;
                        break;
                    case "P_HL2":
                        gMain.drawType = MyObject.ObjectType.P_HL2;
                        break;
                    case "P_HL":
                        gMain.drawType = MyObject.ObjectType.P_HL;
                        break;
                    case "P_JF":
                        gMain.drawType = MyObject.ObjectType.P_JF;
                        break;
                    case "P_LJQ":
                        gMain.drawType = MyObject.ObjectType.P_LJQ;
                        break;
                    case "P_LLDI":
                        gMain.drawType = MyObject.ObjectType.P_LLDI;
                        break;
                    case "P_L":
                        gMain.drawType = MyObject.ObjectType.P_L;
                        break;
                    case "P_LYJ":
                        gMain.drawType = MyObject.ObjectType.P_LYJ;
                        break;
                    case "P":
                        gMain.drawType = MyObject.ObjectType.P;
                        break;
                    case "P_P":
                        gMain.drawType = MyObject.ObjectType.P_P;
                        break;
                    case "P_TD":
                        gMain.drawType = MyObject.ObjectType.P_TD;
                        break;
                    case "P_TL2_Close":
                        gMain.drawType = MyObject.ObjectType.P_TL2_Close;
                        break;
                    case "P_TL2_Down":
                        gMain.drawType = MyObject.ObjectType.P_TL2_Down;
                        break;
                    case "P_TL2_UP":
                        gMain.drawType = MyObject.ObjectType.P_TL2_UP;
                        break;
                    case "P_TL5_Left":
                        gMain.drawType = MyObject.ObjectType.P_TL5_Left;
                        break;
                    case "P_TL5_Right":
                        gMain.drawType = MyObject.ObjectType.P_TL5_Right;
                        break;
                    case "P_TW":
                        gMain.drawType = MyObject.ObjectType.P_TW;
                        break;
                    case "P_VI":
                        gMain.drawType = MyObject.ObjectType.P_VI;
                        break;
                    case "S":
                        gMain.drawType = MyObject.ObjectType.S;
                        break;
                    case "TV_CCTV_Ball":
                        gMain.drawType = MyObject.ObjectType.TV_CCTV_Ball;
                        break;
                    case "TV_CCTV_E":
                        gMain.drawType = MyObject.ObjectType.TV_CCTV_E;
                        break;
                    case "TV_CCTV_Gun":
                        gMain.drawType = MyObject.ObjectType.TV_CCTV_Gun;
                        break;
                    case "TV":
                        gMain.drawType = MyObject.ObjectType.TV;
                        break;
                    case "VI":
                        gMain.drawType = MyObject.ObjectType.VI;
                        break;
                    default:
                        break;
                }
            }
            else
                gMain.drawType = MyObject.ObjectType.UnKnow;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CreateView();
            this.treeView1.ExpandAll();
        }
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolStripStatusLabel1.Text = e.Location.ToString();
        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            if (m_CurrentView != null)
            {
                if (m_CurrentView.fileName.Length < 1)
                {
                    SaveFileDialog savedialog = new SaveFileDialog();
                    savedialog.Filter = "wm files (*.wm)|*.wm|All files (*.*)|*.*";
                    savedialog.FilterIndex = 1;
                    savedialog.RestoreDirectory = true;
                    savedialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                    if (savedialog.ShowDialog() == DialogResult.OK)
                    {
                        m_CurrentView.SaveDocument(savedialog.FileName);
                    }
                }
                else
                    m_CurrentView.SaveDocument(m_CurrentView.fileName);
            }
        }

        private void Menu_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Filter = "wm files (*.wm)|*.wm|All files (*.*)|*.*";
            opendialog.FilterIndex = 1;
            opendialog.RestoreDirectory = true;
            opendialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                CreateView();
                if (m_CurrentView != null)
                {
                    m_CurrentView.OpenDocument(opendialog.FileName);
                    m_CurrentView.fileName = opendialog.FileName;
                }
            }
        }
        private void Menu_SaveAs_Click(object sender, EventArgs e)
        {
            if (m_CurrentView != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Filter = "wm files (*.wm)|*.wm|All files (*.*)|*.*";
                savedialog.FilterIndex = 1;
                savedialog.RestoreDirectory = true;
                savedialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    m_CurrentView.SaveDocument(savedialog.FileName);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {//左对齐
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(4);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {//水平居中
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(5);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {//右对齐
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(6);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {//顶对齐
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(7);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {//垂直居中
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(8);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {//底对齐
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(9);
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {//宽度相等
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(10);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {//高度相等
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(11);
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {//大小相等
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(12);
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {//水平间距相等
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(13);
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {//增加水平间距
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(14);
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {//减少水平间距
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(15);
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {//垂直间距相等
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(16);
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {//增加垂直间距
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(17);
            }
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {//减少垂直间距
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(18);
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {//复制对象
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(50);
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {//粘贴对象
            if (m_CurrentView != null)
            {
                m_CurrentView.MultiObjectSet(51);
            }
        }

    }
}
