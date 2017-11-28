using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PhlObject : DeviceObject
    {
        public PhlObject(Point p)
        {
            this.init(p);
        }

        public PhlObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_HL;
            this.equid = (int)equtype + "0001";
            this.picName = "P_HL.png";
            this.equName = "三显交通灯";
        }
    }
}
