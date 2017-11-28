using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PafObject : DeviceObject
    {
        public PafObject(Point p)
        {
            this.init(p);
        }

        public PafObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_AF;
            this.equid = (int)equtype + "0001";
            this.picName = "P_AF.png";
            this.equName = "轴流风机";
        }
    }
}
