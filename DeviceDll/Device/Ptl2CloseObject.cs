using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class Ptl2CloseObject : DeviceObject
    {
        public Ptl2CloseObject(Point p)
        {
            this.init(p);
        }

        public Ptl2CloseObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TL2_Close;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TL2_Close.png";
            this.equName = "P_TL2_Close";
        }
    }
}
