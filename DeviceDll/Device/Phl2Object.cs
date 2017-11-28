using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class Phl2Object : DeviceObject
    {
        public Phl2Object(Point p)
        {
            this.init(p);
        }

        public Phl2Object()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_HL2;
            this.equid = (int)equtype + "0001";
            this.picName = "P_HL2.png";
            this.equName = "四显交通灯";
        }
    }
}
