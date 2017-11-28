using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PlObject : DeviceObject
    {
        public PlObject(Point p)
        {
            this.init(p);
        }

        public PlObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_L;
            this.equid = (int)equtype + "0001";
            this.picName = "P_L.png";
            this.equName = "基本照明";
        }
    }
}
