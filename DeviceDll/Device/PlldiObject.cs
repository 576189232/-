using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PlldiObject : DeviceObject
    {
        public PlldiObject(Point p)
        {
            this.init(p);
        }

        public PlldiObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_LLDI;
            this.equid = (int)equtype + "0001";
            this.picName = "P_LLDI.png";
            this.equName = "液位检测仪";
        }
    }
}
