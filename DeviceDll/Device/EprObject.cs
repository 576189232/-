using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class EprObject : DeviceObject
    {
        public EprObject(Point p)
        {
            this.init(p);
        }

        public EprObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.EP_R;
            this.equid = (int)equtype + "0001";
            this.picName = "EP_R.png";
            this.equName = "广播";
        }
    }
}
