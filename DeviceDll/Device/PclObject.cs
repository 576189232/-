using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PclObject : DeviceObject
    {
        public PclObject(Point p)
        {
            this.init(p);
        }

        public PclObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_CL;
            this.equid = (int)equtype + "0001";
            this.picName = "P_CL.png";
            this.equName = "车行横通标志";
        }
    }
}
