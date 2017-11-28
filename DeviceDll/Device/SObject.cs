using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class SObject : DeviceObject
    {
        public SObject(Point p)
        {
            this.init(p);
        }

        public SObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.S;
            this.equid = (int)equtype + "0001";
            this.picName = "S.png";
            this.equName = "限速标志";
        }
    }
}
