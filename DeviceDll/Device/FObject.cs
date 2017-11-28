using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class FObject : DeviceObject
    {
        public FObject(Point p)
        {
            this.init(p);
        }

        public FObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.F;
            this.equid = (int)equtype + "0001";
            this.picName = "F.png";
            this.equName = "火灾主机";
        }
    }
}
