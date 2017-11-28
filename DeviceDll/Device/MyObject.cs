using System;
using System.Drawing;
using System.Xml;

namespace DeviceDll.Device
{
    public class MyObject
    {
        public enum ObjectType
        {
            UnKnow,
            A,
            CF=21,
            CL,
            CM,
            E,
            EP,
            EP_R,
            EP_T,
            F,
            F_L,
            F_SB,
            F_YG,
            I,
            P,
            P_AF,
            P_CL,
            P_CO,
            P_GJ,
            P_HL,
            P_HL2,
            P_JF,
            P_L,
            P_LJQ,
            P_LLDI,
            P_LYJ,
            P_P,
            P_TD,
            P_TL2_Close,
            P_TL2_Down,
            P_TL2_Left,
            P_TL2_Right,
            P_TL2_UP,
            P_TL3_Down,
            P_TL3_Left,
            P_TL3_Right,
            P_TL3_UP,
            P_TL4_Down,
            P_TL4_Left,
            P_TL4_Right,
            P_TL4_UP,
            P_TL5_Down,
            P_TL5_Left,
            P_TL5_Right,
            P_TL5_UP,
            P_TL_Down,
            P_TL_Left,
            P_TL_Right,
            P_TL_UP,
            P_TW,
            P_VI,
            S,
            TV,
            TV_CCTV_Ball,
            TV_CCTV_E,
            TV_CCTV_Gun,
            VC,
            VI
        }

        public string equid;
        public ObjectType equtype;
        public Point start;
        public Point end;
        public string picName;
        public string equName;
        public bool obj_bSelect;
        public bool obj_bCopy;
        public MyObject()
        {
            equid = "";
            start = new Point(0, 0);
            picName = "";
            equName = "";
        }
        public virtual void DrawOjbect(Graphics g)
        {
        }
        public virtual XmlElement SaveObject(XmlDocument doc)
        {
            XmlElement xmlElement = doc.CreateElement("obj");
            xmlElement.SetAttribute("equid", equid);
            xmlElement.SetAttribute("equtype", Convert.ToInt32(equtype).ToString());
            xmlElement.SetAttribute("pic", picName);
            xmlElement.SetAttribute("equName", equName);
            xmlElement.SetAttribute("pointX", start.X.ToString());
            xmlElement.SetAttribute("pointY", start.Y.ToString());
            return xmlElement;
        }

        public virtual void OpenObject(XmlNode node)
        {
            equid = ((XmlElement)node).GetAttribute("equid");
            equtype = (MyObject.ObjectType)Convert.ToInt32(((XmlElement)node).GetAttribute("equtype"));
            picName = ((XmlElement)node).GetAttribute("pic");
            equName = ((XmlElement)node).GetAttribute("equName");
            start.X = Convert.ToInt32(((XmlElement)node).GetAttribute("pointX"));
            start.Y = Convert.ToInt32(((XmlElement)node).GetAttribute("pointY"));
            end.X = start.X + 30;
            end.Y = start.Y + 30;
        }
    }
}
