using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class Ptl2UpObject : DeviceObject
    {
        public Ptl2UpObject(Point p)
        {
            this.init(p);
        }

        public Ptl2UpObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TL2_UP;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TL_UP.png";
            this.equName = "P_TL2_UP";
        }
    }
}
