using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class CLObject : DeviceObject
    {
        public CLObject(Point p)
        {
            this.init(p);
        }

        public CLObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.CL;
            this.equid = (int)equtype + "0001";
            this.picName = "cl.png";
            this.equName = "立柱情报板";
        }
    }
}
