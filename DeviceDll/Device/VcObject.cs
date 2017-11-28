using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class VcObject : DeviceObject
    {
        public VcObject(Point p)
        {
            this.init(p);
        }

        public VcObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            equtype = MyObject.ObjectType.VC;
            equid = (int)equtype+"0001";
            picName = "VC_Normal.png";
            equName = "车检器";
        }
    }
}
