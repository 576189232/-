using DeviceDll.Device;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowMake.Propert;

namespace WindowMake
{
    public partial class FormView : Form
    {
        public MyObject m_pCurrentPic = null;
        public string fileName = "";
        public FormView()
        {
            InitializeComponent();
        }
        private void FormView_MdiChildActivate(object sender, EventArgs e)
        {
            gMain.CurrentPictrueBox = m_pCurrentPic;
        }

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.panel1.m_pCurrentObject == null)
            {
                this.objectPro.Enabled = false;
                this.Sendto.Enabled = false;
            }
            else
            {
                this.objectPro.Enabled = true;
                this.Sendto.Enabled = true;
            }
        }
        private void contextMenuStrip1_ItemClicked(object sender, EventArgs e)
        {
            if (this.panel1.m_pCurrentObject == null)
            {
                //switch (e.ClickedItem.Name)
                //{
                //    case "pictruePro"://画面属性
                //        {
                PicturePro mapinfo = new PicturePro();
                mapinfo.mapId_tb.Text = panel1.mapPro.mapId;
                mapinfo.mapName_tb.Text = panel1.mapPro.mapName;
                mapinfo.IsRoad_check.Checked = panel1.mapPro.IsRoad == 1;
                mapinfo.url_tb.Text = panel1.mapPro.mapAddress;
                mapinfo.text_filebk.Text = this.panel1.mapPro.bkfile;
                if (mapinfo.ShowDialog() == DialogResult.OK)
                {
                    this.panel1.mapPro.mapName = mapinfo.mapName_tb.Text;
                    this.panel1.mapPro.IsRoad = mapinfo.IsRoad_check.Checked == true ? 1 : 0;
                    this.panel1.mapPro.mapAddress = mapinfo.url_tb.Text;
                    this.panel1.mapPro.mapId = mapinfo.mapId_tb.Text;
                    this.panel1.mapPro.bkfile = mapinfo.text_filebk.Text;
                    this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    if (!string.IsNullOrEmpty(panel1.mapPro.bkfile))
                    {
                        this.panel1.Size = new Size(Image.FromFile(panel1.mapPro.bkfile).Width, Image.FromFile(panel1.mapPro.bkfile).Height);
                        this.panel1.BackgroundImage = Image.FromFile(panel1.mapPro.bkfile);
                    }
                    else
                        this.panel1.BackgroundImage = null;
                }
                mapinfo.Close();
                //}
                //break;
            }
            else
            {
                SetObjectPro();
            }
            //case "objectPro"://对象属性

            //break;
            //case "toTop":
            //    this.panel1.objectTop();
            //    break;
            //case "toBottom":
            //    this.panel1.objectBottom();
            //    break;
            //case "on":
            //    this.panel1.objectOn();
            //    break;
            //case "under":
            //    this.panel1.objectUnder();
            //    break;

        }

        private string InitBackground()
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = "./BK/";
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                return fdialog.SafeFileName;
            }
            return null;
        }

        /// <summary>
        /// 设置对象属性
        /// </summary>
        private void SetObjectPro()
        {
            if (this.panel1.m_pCurrentObject == null)
                return;
            this.panel1.InvalidateCurrentObject();

            ObjectPro objdialog = new ObjectPro();
            DeviceObject m_temp = (DeviceObject)this.panel1.m_pCurrentObject;
            objdialog.m_pro = m_temp.m_pro;
            objdialog.obj_id = m_temp.equid;
            objdialog.obj_name = m_temp.equName;
            objdialog.m_obj = m_temp;
            if (objdialog.ShowDialog() == DialogResult.OK)
            {
                m_temp.m_pro = objdialog.m_pro;
                m_temp.equid = objdialog.obj_id;
                m_temp.equName = objdialog.obj_name;

            }
            this.panel1.DrawCurrentObject();
        }
        //private void panel1_VisibleChanged(object sender, EventArgs e)
        //{
        //    this.panel1.mapPro.size = this.panel1.Size;
        //}
        public event EventHandler<SelectEventArgs> SelectChanged;
        private void panel1_ObjectSelectChanged(object sender, SelectEventArgs e)
        {
            if (SelectChanged != null)
                SelectChanged(this, new SelectEventArgs(e.bSelect, e.bCopy));
        }
        public void SaveDocument(string fname)
        {
            this.panel1.SaveDocument(fname);
        }
        public void OpenDocument(string fname)
        {
            this.panel1.OpenDocument(fname);
        }

        //private void Sendto_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Name)
        //    {
        //        case "objectPro"://对象属性
        //            SetObjectPro();
        //            break;
        //        case "toTop":
        //            this.panel1.objectTop();
        //            break;
        //        case "toBottom":
        //            this.panel1.objectBottom();
        //            break;
        //        case "on":
        //            this.panel1.objectOn();
        //            break;
        //        case "under":
        //            this.panel1.objectUnder();
        //            break;
        //    }
        //}
        public void MultiObjectSet(int type)
        {
            switch (type)
            {
                case 4:
                    this.panel1.toolStripButton4_Click();
                    break;
                case 5:
                    this.panel1.toolStripButton5_Click();
                    break;
                case 6:
                    this.panel1.toolStripButton6_Click();
                    break;
                case 7:
                    this.panel1.toolStripButton7_Click();
                    break;
                case 8:
                    this.panel1.toolStripButton8_Click();
                    break;
                case 9:
                    this.panel1.toolStripButton9_Click();
                    break;
                case 10:
                    this.panel1.toolStripButton10_Click();
                    break;
                case 11:
                    this.panel1.toolStripButton11_Click();
                    break;
                case 12:
                    this.panel1.toolStripButton12_Click();
                    break;
                case 13:
                    this.panel1.toolStripButton13_Click();
                    break;
                case 14:
                    this.panel1.toolStripButton14_Click();
                    break;
                case 15:
                    this.panel1.toolStripButton15_Click();
                    break;
                case 16:
                    this.panel1.toolStripButton16_Click();
                    break;
                case 17:
                    this.panel1.toolStripButton17_Click();
                    break;
                case 18:
                    this.panel1.toolStripButton18_Click();
                    break;
                case 50://复制
                    this.panel1.toolCopyObject();
                    break;
                case 51://粘贴
                    this.panel1.toolPasteObject();
                    break;
            }
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)//复制
            {
                panel1.toolCopyObject();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)//粘贴
            {
                panel1.toolPasteObject();
            }
        }
    }
}
