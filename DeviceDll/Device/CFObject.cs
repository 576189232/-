using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class CFObject : DeviceObject
    {
        public CFObject(Point p)
        {
            this.init(p);
        }

        public CFObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.CF;
            this.equid = (int)MyObject.ObjectType.CF + "0001";
            this.picName = "cf.png";
            this.equName = "F型情报板";
        }
    }
}
