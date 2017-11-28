using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class Ptl5RightObject : DeviceObject
    {
        public Ptl5RightObject(Point p)
        {
            this.init(p);
        }

        public Ptl5RightObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TL5_Right;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TL_Right.png";
            this.equName = "P_TL5_Right";
        }
    }
}
