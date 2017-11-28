using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class FsbObject : DeviceObject
    {
        public FsbObject(Point p)
        {
            this.init(p);
        }

        public FsbObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.F_SB;
            this.equid = (int)equtype + "0001";
            this.picName = "F_SB.png";
            this.equName = "火灾手报";
        }
    }
}
