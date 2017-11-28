using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PcoObject : DeviceObject
    {
        public PcoObject(Point p)
        {
            this.init(p);
        }

        public PcoObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_CO;
            this.equid = (int)equtype + "0001";
            this.picName = "CO.png";
            this.equName = "CO";
        }
    }
}
