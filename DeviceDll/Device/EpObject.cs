using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class EpObject : DeviceObject
    {
        public EpObject(Point p)
        {
            this.init(p);
        }

        public EpObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.EP;
            this.equid = (int)equtype + "0001";
            this.picName = "EP.png";
            this.equName = "紧急电话主机";
        }
    }
}
