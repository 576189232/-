using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PviObject : DeviceObject
    {
        public PviObject(Point p)
        {
            this.init(p);
        }

        public PviObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_VI;
            this.equid = (int)equtype + "0001";
            this.picName = "P_VI.png";
            this.equName = "VI";
        }
    }
}
