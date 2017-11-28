using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PObject : DeviceObject
    {
        public PObject(Point p)
        {
            this.init(p);
        }

        public PObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P;
            this.equid = (int)equtype + "0001";
            this.picName = "P.png";
            this.equName = "PLC主机";
        }
    }
}
