using System;
using System.Windows.Forms;
using DeviceDll.Device;

namespace WindowMake.Propert
{
    public partial class ObjectPro : Form
    {
        public DevicePropert m_pro;
        public string obj_id;
        public string obj_name;
        public DeviceObject m_obj;
        public ObjectPro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obj_id = Convert.ToInt32(this.textBox1.Text);
            checkBox1.Checked = false;
            IntORHex(groupBox1);
            IntORHex(groupBox2);
            obj_name = this.tb_equname.Text;
            m_pro.m_location = this.tb_pileno.Text;
            if (this.Station1_Txt.Text.Length > 0)
                m_pro.m_PLCStation = Convert.ToUInt16(this.Station1_Txt.Text);
            m_pro.m_note = this.tb_note.Text;
            if (this.Vendor_Txt.Text.Length > 0)
                m_pro.Vendor = this.Vendor_Txt.Text;
            if (this.cb_RunMode.SelectedItem != null)
                m_pro.RunMode = this.cb_RunMode.SelectedItem.ToString();
            if (this.YX1_TXT.Text.Length > 0)
                m_pro.m_YX[0] = Convert.ToUInt16(this.YX1_TXT.Text);
            if (this.YX2_TXT.Text.Length > 0)
                m_pro.m_YX[1] = Convert.ToUInt16(this.YX2_TXT.Text);
            if (this.YX3_TXT.Text.Length > 0)
                m_pro.m_YX[2] = Convert.ToUInt16(this.YX3_TXT.Text);
            if (this.YX4_TXT.Text.Length > 0)
                m_pro.m_YX[3] = Convert.ToUInt16(this.YX4_TXT.Text);
            if (this.YX5_TXT.Text.Length > 0)
                m_pro.m_YX[4] = Convert.ToUInt16(this.YX5_TXT.Text);
            if (this.YX6_TXT.Text.Length > 0)
                m_pro.m_YX[5] = Convert.ToUInt16(this.YX6_TXT.Text);
            if (this.YX_Fault1_TXT.Text.Length > 0)
                m_pro.m_YX[6] = Convert.ToUInt16(this.YX_Fault1_TXT.Text);
            if (this.YX_Fault2_TXT.Text.Length > 0)
                m_pro.m_YX[7] = Convert.ToUInt16(this.YX_Fault2_TXT.Text);
            if (this.YX1_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[0] = Convert.ToUInt16(this.YX1_TXT_P.Text);
            if (this.YX2_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[1] = Convert.ToUInt16(this.YX2_TXT_P.Text);
            if (this.YX3_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[2] = Convert.ToUInt16(this.YX3_TXT_P.Text);
            if (this.YX4_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[3] = Convert.ToUInt16(this.YX4_TXT_P.Text);
            if (this.YX5_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[4] = Convert.ToUInt16(this.YX5_TXT_P.Text);
            if (this.YX6_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[5] = Convert.ToUInt16(this.YX6_TXT_P.Text);
            if (this.YX_Fault1_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[6] = Convert.ToUInt16(this.YX_Fault1_TXT_P.Text);
            if (this.YX_Fault2_TXT_P.Text.Length > 0)
                m_pro.m_YX_P[7] = Convert.ToUInt16(this.YX_Fault2_TXT_P.Text);
            if (this.YK1_TXT.Text.Length > 0)
                m_pro.m_YK[0] = Convert.ToUInt16(this.YK1_TXT.Text);
            if (this.YK2_TXT.Text.Length > 0)
                m_pro.m_YK[1] = Convert.ToUInt16(this.YK2_TXT.Text);
            if (this.YK3_TXT.Text.Length > 0)
                m_pro.m_YK[2] = Convert.ToUInt16(this.YK3_TXT.Text);
            if (this.YK4_TXT.Text.Length > 0)
                m_pro.m_YK[3] = Convert.ToUInt16(this.YK4_TXT.Text);
            if (this.YK5_TXT.Text.Length > 0)
                m_pro.m_YK[4] = Convert.ToUInt16(this.YK5_TXT.Text);
            if (this.YK6_TXT.Text.Length > 0)
                m_pro.m_YK[5] = Convert.ToUInt16(this.YK6_TXT.Text);
            if (this.YK7_TXT.Text.Length > 0)
                m_pro.m_YK[6] = Convert.ToUInt16(this.YK7_TXT.Text);
            if (this.YK8_TXT.Text.Length > 0)
                m_pro.m_YK[7] = Convert.ToUInt16(this.YK8_TXT.Text);
            if (this.YK1_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[0] = Convert.ToUInt16(this.YK1_TXT_P.Text);
            if (this.YK2_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[1] = Convert.ToUInt16(this.YK2_TXT_P.Text);
            if (this.YK3_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[2] = Convert.ToUInt16(this.YK3_TXT_P.Text);
            if (this.YK4_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[3] = Convert.ToUInt16(this.YK4_TXT_P.Text);
            if (this.YK5_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[4] = Convert.ToUInt16(this.YK5_TXT_P.Text);
            if (this.YK6_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[5] = Convert.ToUInt16(this.YK6_TXT_P.Text);
            if (this.YK7_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[6] = Convert.ToUInt16(this.YK7_TXT_P.Text);
            if (this.YK8_TXT_P.Text.Length > 0)
                m_pro.m_YK_P[7] = Convert.ToUInt16(this.YK8_TXT_P.Text);
            if (this.YC1_TXT.Text.Length > 0)
                m_pro.m_YC[0] = Convert.ToUInt16(this.YC1_TXT.Text);
            if (this.YC2_TXT.Text.Length > 0)
                m_pro.m_YC[1] = Convert.ToUInt16(this.YC2_TXT.Text);
            if (this.YC3_TXT.Text.Length > 0)
                m_pro.m_YC[2] = Convert.ToUInt16(this.YC3_TXT.Text);
            if (this.YC4_TXT.Text.Length > 0)
                m_pro.m_YC[3] = Convert.ToUInt16(this.YC4_TXT.Text);
            if (this.YC5_TXT.Text.Length > 0)
                m_pro.m_YC[4] = Convert.ToUInt16(this.YC5_TXT.Text);
            if (this.YC6_TXT.Text.Length > 0)
                m_pro.m_YC[5] = Convert.ToUInt16(this.YC6_TXT.Text);
            if (this.YC7_TXT.Text.Length > 0)
                m_pro.m_YC[6] = Convert.ToUInt16(this.YC7_TXT.Text);
            if (this.YC8_TXT.Text.Length > 0)
                m_pro.m_YC[7] = Convert.ToUInt16(this.YC8_TXT.Text);

            if (true == radio_up.Checked)
                m_pro.m_Postion = 0;
            else
                m_pro.m_Postion = 1;
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 在winform中查找控件
        /// </summary>
        /// <param ></param>
        /// <param ></param>
        /// <returns></returns>
        private System.Windows.Forms.Control findControl(System.Windows.Forms.Control control, string controlName)
        {
            Control c1;
            foreach (Control c in control.Controls)
            {
                if (c.Name == controlName)
                {
                    return c;
                }
                else if (c.Controls.Count > 0)
                {
                    c1 = findControl(c, controlName);
                    if (c1 != null)
                    {
                        return c1;
                    }
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ObjectPro_Load(object sender, EventArgs e)
        {
            this.tb_equid.Text = obj_id.ToString();
            this.tb_equname.Text = obj_name;
            this.tb_pileno.Text = m_obj.m_pro.m_location;
            //string[] installs;
            //switch(m_obj.equtype)
            //{
            //    case MyObject.ObjectType.Fire:
            //        installs = new string[]{"手报", "感温", "警灯"};
            //        break;
            //    case MyObject.ObjectType.LanesLight:
            //        installs = new string[] { "双显车道指示", "单显车道指示" };
            //        break;
            //    default:
            //        installs = new string[] { m_obj.obj_ClassName };
            //        break;
            //}
            //this.ChildClassCombo.Items.AddRange(installs);
            this.pictureBox1.Image = m_obj.image;
            this.ChildClassCombo.SelectedText = m_obj.equName;
            if (m_obj.m_pro.m_PLCStation != 0xffff)
                this.Station1_Txt.Text = m_obj.m_pro.m_PLCStation.ToString();
            if (!string.IsNullOrEmpty(m_obj.m_pro.m_note))
                this.tb_note.Text = m_obj.m_pro.m_note.ToString();
            if (!string.IsNullOrEmpty(m_obj.m_pro.Vendor))
                this.Vendor_Txt.Text = m_obj.m_pro.Vendor.ToString();
            this.cb_RunMode.SelectedItem = "server";
            if (!string.IsNullOrEmpty(m_obj.m_pro.RunMode))
                this.cb_RunMode.SelectedItem = m_obj.m_pro.RunMode.ToString();
            #region yx yk yc
            if (m_obj.m_pro.m_YX[0] != 0xffff)
                this.YX1_TXT.Text = m_obj.m_pro.m_YX[0].ToString();
            if (m_obj.m_pro.m_YX[1] != 0xffff)
                this.YX2_TXT.Text = m_obj.m_pro.m_YX[1].ToString();
            if (m_obj.m_pro.m_YX[2] != 0xffff)
                this.YX3_TXT.Text = m_obj.m_pro.m_YX[2].ToString();
            if (m_obj.m_pro.m_YX[3] != 0xffff)
                this.YX4_TXT.Text = m_obj.m_pro.m_YX[3].ToString();
            if (m_obj.m_pro.m_YX[4] != 0xffff)
                this.YX5_TXT.Text = m_obj.m_pro.m_YX[4].ToString();
            if (m_obj.m_pro.m_YX[5] != 0xffff)
                this.YX6_TXT.Text = m_obj.m_pro.m_YX[5].ToString();
            if (m_obj.m_pro.m_YX[6] != 0xffff)
                this.YX_Fault1_TXT.Text = m_obj.m_pro.m_YX[6].ToString();
            if (m_obj.m_pro.m_YX[7] != 0xffff)
                this.YX_Fault2_TXT.Text = m_obj.m_pro.m_YX[7].ToString();
            if (m_obj.m_pro.m_YX_P[0] != 0xff)
                this.YX1_TXT_P.Text = m_obj.m_pro.m_YX_P[0].ToString();
            if (m_obj.m_pro.m_YX_P[1] != 0xff)
                this.YX2_TXT_P.Text = m_obj.m_pro.m_YX_P[1].ToString();
            if (m_obj.m_pro.m_YX_P[2] != 0xff)
                this.YX3_TXT_P.Text = m_obj.m_pro.m_YX_P[2].ToString();
            if (m_obj.m_pro.m_YX_P[3] != 0xff)
                this.YX4_TXT_P.Text = m_obj.m_pro.m_YX_P[3].ToString();
            if (m_obj.m_pro.m_YX_P[4] != 0xff)
                this.YX5_TXT_P.Text = m_obj.m_pro.m_YX_P[4].ToString();
            if (m_obj.m_pro.m_YX_P[5] != 0xff)
                this.YX6_TXT_P.Text = m_obj.m_pro.m_YX_P[5].ToString();
            if (m_obj.m_pro.m_YX_P[6] != 0xff)
                this.YX_Fault1_TXT_P.Text = m_obj.m_pro.m_YX_P[6].ToString();
            if (m_obj.m_pro.m_YX_P[7] != 0xff)
                this.YX_Fault2_TXT_P.Text = m_obj.m_pro.m_YX_P[7].ToString();
            if (m_obj.m_pro.m_YK[0] != 0xffff)
                this.YK1_TXT.Text = m_obj.m_pro.m_YK[0].ToString();
            if (m_obj.m_pro.m_YK[1] != 0xffff)
                this.YK2_TXT.Text = m_obj.m_pro.m_YK[1].ToString();
            if (m_obj.m_pro.m_YK[2] != 0xffff)
                this.YK3_TXT.Text = m_obj.m_pro.m_YK[2].ToString();
            if (m_obj.m_pro.m_YK[3] != 0xffff)
                this.YK4_TXT.Text = m_obj.m_pro.m_YK[3].ToString();
            if (m_obj.m_pro.m_YK[4] != 0xffff)
                this.YK5_TXT.Text = m_obj.m_pro.m_YK[4].ToString();
            if (m_obj.m_pro.m_YK[5] != 0xffff)
                this.YK6_TXT.Text = m_obj.m_pro.m_YK[5].ToString();
            if (m_obj.m_pro.m_YK[6] != 0xffff)
                this.YK7_TXT.Text = m_obj.m_pro.m_YK[6].ToString();
            if (m_obj.m_pro.m_YK[7] != 0xffff)
                this.YK8_TXT.Text = m_obj.m_pro.m_YK[7].ToString();
            if (m_obj.m_pro.m_YK_P[0] != 0xff)
                this.YK1_TXT_P.Text = m_obj.m_pro.m_YK_P[0].ToString();
            if (m_obj.m_pro.m_YK_P[1] != 0xff)
                this.YK2_TXT_P.Text = m_obj.m_pro.m_YK_P[1].ToString();
            if (m_obj.m_pro.m_YK_P[2] != 0xff)
                this.YK3_TXT_P.Text = m_obj.m_pro.m_YK_P[2].ToString();
            if (m_obj.m_pro.m_YK_P[3] != 0xff)
                this.YK4_TXT_P.Text = m_obj.m_pro.m_YK_P[3].ToString();
            if (m_obj.m_pro.m_YK_P[4] != 0xff)
                this.YK5_TXT_P.Text = m_obj.m_pro.m_YK_P[4].ToString();
            if (m_obj.m_pro.m_YK_P[5] != 0xff)
                this.YK6_TXT_P.Text = m_obj.m_pro.m_YK_P[5].ToString();
            if (m_obj.m_pro.m_YK_P[6] != 0xff)
                this.YK7_TXT_P.Text = m_obj.m_pro.m_YK_P[6].ToString();
            if (m_obj.m_pro.m_YK_P[7] != 0xff)
                this.YK8_TXT_P.Text = m_obj.m_pro.m_YK_P[7].ToString();
            if (m_obj.m_pro.m_YC[0] != 0xffff)
                this.YC1_TXT.Text = m_obj.m_pro.m_YC[0].ToString();
            if (m_obj.m_pro.m_YC[1] != 0xffff)
                this.YC2_TXT.Text = m_obj.m_pro.m_YC[1].ToString();
            if (m_obj.m_pro.m_YC[2] != 0xffff)
                this.YC3_TXT.Text = m_obj.m_pro.m_YC[2].ToString();
            if (m_obj.m_pro.m_YC[3] != 0xffff)
                this.YC4_TXT.Text = m_obj.m_pro.m_YC[3].ToString();
            if (m_obj.m_pro.m_YC[4] != 0xffff)
                this.YC5_TXT.Text = m_obj.m_pro.m_YC[4].ToString();
            if (m_obj.m_pro.m_YC[5] != 0xffff)
                this.YC6_TXT.Text = m_obj.m_pro.m_YC[5].ToString();
            if (m_obj.m_pro.m_YC[6] != 0xffff)
                this.YC7_TXT.Text = m_obj.m_pro.m_YC[6].ToString();
            if (m_obj.m_pro.m_YC[7] != 0xffff)
                this.YC8_TXT.Text = m_obj.m_pro.m_YC[7].ToString();
            #endregion
            #region 设备状态控制字符
            //照明
            switch (m_obj.equtype)
            {
                case MyObject.ObjectType.UnKnow:
                    break;
                case MyObject.ObjectType.A:
                    break;
                case MyObject.ObjectType.CF:
                    break;
                case MyObject.ObjectType.CL:
                    break;
                case MyObject.ObjectType.CM:
                    break;
                case MyObject.ObjectType.E:
                    break;
                case MyObject.ObjectType.EP:
                    break;
                case MyObject.ObjectType.EP_R:
                    break;
                case MyObject.ObjectType.EP_T:
                    break;
                case MyObject.ObjectType.F:
                    break;
                case MyObject.ObjectType.F_L:
                    break;
                case MyObject.ObjectType.F_SB:
                    break;
                case MyObject.ObjectType.F_YG:
                    break;
                case MyObject.ObjectType.I:
                    break;
                case MyObject.ObjectType.P:
                    break;
                case MyObject.ObjectType.P_AF:
                    break;
                case MyObject.ObjectType.P_CL:
                    break;
                case MyObject.ObjectType.P_HL://交通灯
                case MyObject.ObjectType.P_HL2:
                    this.YX1_label.Text = "红";
                    this.YX2_label.Text = "黄";
                    this.YX3_label.Text = "绿";
                    this.YX4_label.Text = "箭头";
                    this.YK1_label.Text = "红";
                    this.YK2_label.Text = "黄";
                    this.YK3_label.Text = "绿";
                    this.YK4_label.Text = "箭头";
                    break;
                case MyObject.ObjectType.P_JF://风机
                    this.YX1_label.Text = "正转";
                    this.YX2_label.Text = "反转";
                    this.YX3_label.Text = "停止";
                    this.YX4_label.Text = "本/远";
                    this.YK1_label.Text = "正转";
                    this.YK2_label.Text = "反转";
                    this.YK3_label.Text = "停止";
                    break;
                case MyObject.ObjectType.P_L://照明
                case MyObject.ObjectType.P_LJQ:
                case MyObject.ObjectType.P_LYJ:
                    this.YX1_label.Text = "开";
                    this.YX2_label.Text = "关";
                    this.YX3_label.Text = "本/远";
                    this.YK1_label.Text = "开";
                    this.YK2_label.Text = "关";
                    break;
                case MyObject.ObjectType.P_TD://横通门 上升 上升到位 下降 下降到位 停止
                    this.YX1_label.Text = "上升";
                    this.YX2_label.Text = "下降";
                    this.YX3_label.Text = "上升到位";
                    this.YX4_label.Text = "下降到位";
                    this.YK1_label.Text = "上升";
                    this.YK2_label.Text = "下降";
                    this.YK3_label.Text = "停止";
                    break;
                case MyObject.ObjectType.P_TL2_Close://车道指示器 开/关
                case MyObject.ObjectType.P_TL2_Down:
                case MyObject.ObjectType.P_TL2_Left:
                case MyObject.ObjectType.P_TL2_Right:
                case MyObject.ObjectType.P_TL2_UP:
                case MyObject.ObjectType.P_TL_Down:
                case MyObject.ObjectType.P_TL_Left:
                case MyObject.ObjectType.P_TL_Right:
                case MyObject.ObjectType.P_TL_UP:
                    this.YX1_label.Text = "开启";
                    this.YX2_label.Text = "关闭";
                    this.YK1_label.Text = "开启";
                    this.YK2_label.Text = "关闭";
                    break;
                case MyObject.ObjectType.P_TL3_Down:
                case MyObject.ObjectType.P_TL3_Left:
                case MyObject.ObjectType.P_TL3_Right:
                case MyObject.ObjectType.P_TL3_UP:
                case MyObject.ObjectType.P_TL4_Down:
                case MyObject.ObjectType.P_TL4_Left:
                case MyObject.ObjectType.P_TL4_Right:
                case MyObject.ObjectType.P_TL4_UP:
                case MyObject.ObjectType.P_TL5_Down://车道指示器 通行 禁止 关闭
                case MyObject.ObjectType.P_TL5_Left:
                case MyObject.ObjectType.P_TL5_Right:
                case MyObject.ObjectType.P_TL5_UP:
                    this.YX1_label.Text = "通行";
                    this.YX2_label.Text = "禁止";
                    this.YX3_label.Text = "关闭";
                    this.YK1_label.Text = "通行";
                    this.YK2_label.Text = "禁止";
                    break;
                case MyObject.ObjectType.P_TW:
                    break;
                case MyObject.ObjectType.P_VI:
                    break;
                case MyObject.ObjectType.VI:
                    break;
                case MyObject.ObjectType.P_LLDI:
                    break;
                case MyObject.ObjectType.P_P:
                    break;
                case MyObject.ObjectType.P_CO:
                    break;
                case MyObject.ObjectType.P_GJ:
                    break;
                case MyObject.ObjectType.S:
                    break;
                case MyObject.ObjectType.TV:
                    break;
                case MyObject.ObjectType.TV_CCTV_Ball:
                    break;
                case MyObject.ObjectType.TV_CCTV_E:
                    break;
                case MyObject.ObjectType.TV_CCTV_Gun:
                    break;
                case MyObject.ObjectType.VC:
                    break;
                default:
                    break;
            }
            #endregion
            if (0 == m_obj.m_pro.m_Postion)
            {
                this.radio_up.Checked = true;
                this.radio_down.Checked = false;
            }
            else
            {
                this.radio_up.Checked = false;
                this.radio_down.Checked = true;
            }
        }

        private void ChildClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeviceObject tempobj;
            //switch (m_obj.equtype)
            //{
            //    case MyObject.ObjectType.Fire:
            //        tempobj = m_obj as DeviceObject;
            //        if(0 == this.ChildClassCombo.SelectedIndex)
            //        {
            //            tempobj.obj_ClassName = "手报";
            //            tempobj.obj_PicName = "fire.png";
            //        }
            //        else if (1 == this.ChildClassCombo.SelectedIndex)
            //        {
            //            tempobj.obj_ClassName = "感温";
            //            tempobj.obj_PicName = "autofire.png";
            //        }
            //        else if(2 == this.ChildClassCombo.SelectedIndex)
            //        {
            //            tempobj.obj_ClassName = "警灯";
            //            tempobj.obj_PicName = "firealarm.png";
            //        }
            //        break;
            //    case MyObject.ObjectType.LanesLight:
            //        tempobj = m_obj as DeviceObject;
            //        if (0 == this.ChildClassCombo.SelectedIndex)
            //        {
            //            tempobj.obj_ClassName = "双显车道指示";
            //            tempobj.obj_PicName = "LanesLight_open1.png";
            //        }
            //        else if (1 == this.ChildClassCombo.SelectedIndex)
            //        {
            //            tempobj.obj_ClassName = "单显车道指示";
            //            tempobj.obj_PicName = "LanesLight_close.png";
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 勾选转换16进制，取消转换10进制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IntORHex(groupBox1);//遥信
            IntORHex(groupBox2);//遥控
        }

        /// <summary>
        /// 10进制与16进制相互转换
        /// </summary>
        /// <param name="groupBox"></param>
        private void IntORHex(GroupBox groupBox)
        {
            foreach (Control c in groupBox.Controls)
            {
                if (c.GetType().Name == "TextBox" && !string.IsNullOrEmpty(c.Text))
                {
                    if (checkBox1.Checked)
                    {
                        c.Text = Convert.ToInt32(c.Text).ToString("X");//转换成16进制
                    }
                    else
                    {
                        c.Text = Convert.ToInt32(c.Text, 16).ToString();//10进制
                    }
                }
            }
        }
    }
}
