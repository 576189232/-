using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class EptObject : DeviceObject
    {
        public EptObject(Point p)
        {
            this.init(p);
        }

        public EptObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.EP_T;
            this.equid = (int)equtype + "0001";
            this.picName = "EP_T.png";
            this.equName = "紧急电话";
        }
    }
}
