using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PjfObject : DeviceObject
    {
        public PjfObject(Point p)
        {
            this.init(p);
        }

        public PjfObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_JF;
            this.equid = (int)equtype + "0001";
            this.picName = "P_JF.png";
            this.equName = "射流风机";
        }
    }
}
