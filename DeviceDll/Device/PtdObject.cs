using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PtdObject : DeviceObject
    {
        public PtdObject(Point p)
        {
            this.init(p);
        }

        public PtdObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_TD;
            this.equid = (int)equtype + "0001";
            this.picName = "P_TD.png";
            this.equName = "横通门";
        }
    }
}
