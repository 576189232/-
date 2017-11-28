using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class Ptl5LeftObject : DeviceObject
    {
        public Ptl5LeftObject(Point p)
        {
            this.init(p);
        }

        public Ptl5LeftObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TL5_Left;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TL_Left.png";
            this.equName = "P_TL5_Left";
        }
    }
}
