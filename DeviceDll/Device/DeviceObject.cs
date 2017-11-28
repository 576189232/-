using System;
using System.Drawing;
using System.Xml;

namespace DeviceDll.Device
{
    public class DeviceObject : MyObject
    {
        public DevicePropert m_pro = new DevicePropert();

        //public DeviceState m_state = new DeviceState();

        //public ControlPropert m_control = new ControlPropert();

        public bool bAlarm;
        public Image image;
        //public string Alarm_PicName;

        public int Alarm_iMaxPicNum;

        public int Alarm_iCurrentIndex;

        public DeviceObject()
        {
            equid = "10000";
            equtype = MyObject.ObjectType.UnKnow;
            picName = "\\Pic\\unkown.png";
            equName = "未知对象";
            this.bAlarm = false;
            //Alarm_PicName = "\\Pic\\unkown.png";
        }

        //public void BeginControl(ControlType iType)
        //{
        //    this.m_control.m_bControling = true;
        //    this.m_control.m_iCtlType = iType;
        //    this.m_control.m_iCtlTime = 0;
        //}

        //public void EndControl()
        //{
        //    this.m_control.m_bControling = false;
        //    this.m_control.m_iCtlType = ControlType.NONE;
        //    this.m_control.m_iCtlTime = 0;
        //}

        //public bool IsControl()
        //{
        //    return this.m_control.m_bControling;
        //}
        public override void DrawOjbect(Graphics g)
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + "\\Pic\\" + this.picName;
            image = Image.FromFile(filename);
            g.DrawImage(image, this.start.X, this.start.Y, 30, 30);
            base.DrawOjbect(g);
        }
        public virtual void WaitControl(out bool bComplete, out bool bResult)
        {
            bComplete = true;
            bResult = false;
        }

        public override XmlElement SaveObject(XmlDocument doc)
        {
            XmlElement xmlElement = base.SaveObject(doc);
            XmlElement xmlElement2 = doc.CreateElement("Device");
            xmlElement2.SetAttribute("Location", this.m_pro.m_location);
            xmlElement2.SetAttribute("PLCStation", this.m_pro.m_PLCStation.ToString());
            xmlElement2.SetAttribute("note", this.m_pro.m_note);
            xmlElement2.SetAttribute("Postion", this.m_pro.m_Postion.ToString());
            xmlElement2.SetAttribute("Vendor", this.m_pro.Vendor);
            xmlElement2.SetAttribute("RunMode", this.m_pro.RunMode);
            XmlElement xmlElement3 = doc.CreateElement("YX");
            XmlElement xmlElement4 = doc.CreateElement("YK");
            XmlElement xmlElement5 = doc.CreateElement("YC");
            for (int i = 0; i < 8; i++)
            {
                string name = "yx" + i.ToString();
                xmlElement3.SetAttribute(name, this.m_pro.m_YX[i].ToString());
                name = "yx" + i.ToString() + "_p";
                xmlElement3.SetAttribute(name, this.m_pro.m_YX_P[i].ToString());
                name = "yk" + i.ToString();
                xmlElement4.SetAttribute(name, this.m_pro.m_YK[i].ToString());
                name = "yk" + i.ToString() + "_p";
                xmlElement4.SetAttribute(name, this.m_pro.m_YK_P[i].ToString());
                name = "yc" + i.ToString();
                xmlElement5.SetAttribute(name, this.m_pro.m_YC[i].ToString());
                name = "yc" + i.ToString() + "bb";
                xmlElement5.SetAttribute(name, this.m_pro.m_Rate[i].ToString());
                //name = "yc" + i.ToString() + "_offset";
                //xmlElement5.SetAttribute(name, this.m_pro.m_OffSet[i].ToString());
            }
            xmlElement2.AppendChild(xmlElement3);
            xmlElement2.AppendChild(xmlElement4);
            xmlElement2.AppendChild(xmlElement5);
            xmlElement.AppendChild(xmlElement2);
            return xmlElement;
        }

        public override void OpenObject(XmlNode node)
        {
            base.OpenObject(node);
            XmlNode firstChild = node.FirstChild;
            if (firstChild != null && firstChild.Name == "Device")
            {
                this.m_pro.m_location = ((XmlElement)firstChild).GetAttribute("Location");
                this.m_pro.m_PLCStation = Convert.ToUInt16(((XmlElement)firstChild).GetAttribute("PLCStation"));
                this.m_pro.m_note = ((XmlElement)firstChild).GetAttribute("note");
                this.m_pro.Vendor = ((XmlElement)firstChild).GetAttribute("Vendor");
                this.m_pro.RunMode = ((XmlElement)firstChild).GetAttribute("RunMode");
                this.m_pro.m_Postion = Convert.ToUInt16(((XmlElement)firstChild).GetAttribute("Postion"));
                for (int i = 0; i < firstChild.ChildNodes.Count; i++)
                {
                    XmlNode xmlNode = firstChild.ChildNodes[i];
                    if (xmlNode.Name == "YX")
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            string name = "yx" + j.ToString();
                            this.m_pro.m_YX[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                            name = "yx" + j.ToString() + "_p";
                            this.m_pro.m_YX_P[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                        }
                    }
                    else if (xmlNode.Name == "YK")
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            string name = "yk" + j.ToString();
                            this.m_pro.m_YK[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                            name = "yk" + j.ToString() + "_p";
                            this.m_pro.m_YK_P[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                        }
                    }
                    else if (xmlNode.Name == "YC")
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            string name = "yc" + j.ToString();
                            this.m_pro.m_YC[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                            name = "yc" + j.ToString() + "bb";
                            this.m_pro.m_Rate[j] = (float)Convert.ToDouble(((XmlElement)xmlNode).GetAttribute(name));
                            //name = "yc" + j.ToString() + "_offset";
                            //this.m_pro.m_OffSet[j] = Convert.ToUInt16(((XmlElement)xmlNode).GetAttribute(name));
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (this.m_pro.m_YK[i] < this.m_pro.m_Min_YK)
                    {
                        this.m_pro.m_Min_YK = this.m_pro.m_YK[i];
                        this.m_pro.m_Min_YK_P = this.m_pro.m_YK_P[i];
                    }
                    else if (this.m_pro.m_YK[i] == this.m_pro.m_Min_YK && this.m_pro.m_YK_P[i] < this.m_pro.m_Min_YK_P)
                    {
                        this.m_pro.m_Min_YK_P = this.m_pro.m_YK_P[i];
                    }
                }
            }
        }
    }
}
