using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PgjObject : DeviceObject
    {
        public PgjObject(Point p)
        {
            this.init(p);
        }

        public PgjObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_GJ;
            this.equid = (int)equtype + "0001";
            this.picName = "P_GJ.png";
            this.equName = "光强检测";
        }
    }
}
