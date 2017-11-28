using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class CMObject : DeviceObject
    {
        public CMObject(Point p)
        {
            this.init(p);
        }

        public CMObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.CM;
            this.equid = (int)equtype + "0001";
            this.picName = "cm.png";
            this.equName = "门架情报板";
        }
    }
}
