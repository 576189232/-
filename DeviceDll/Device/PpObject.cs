using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PpObject : DeviceObject
    {
        public PpObject(Point p)
        {
            this.init(p);
        }

        public PpObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_P;
            this.equid = (int)equtype + "0001";
            this.picName = "P_P.png";
            this.equName = "水泵";
        }
    }
}
