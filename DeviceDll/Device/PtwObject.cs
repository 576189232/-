using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PtwObject : DeviceObject
    {
        public PtwObject(Point p)
        {
            this.init(p);
        }

        public PtwObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TW;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TW.png";
            this.equName = "P_TW";
        }
    }
}
