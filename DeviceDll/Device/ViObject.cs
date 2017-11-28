using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class ViObject : DeviceObject
    {
        public ViObject(Point p)
        {
            this.init(p);
        }

        public ViObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.VI;
            this.equid = (int)equtype + "0001";
            this.picName = "VI.png";
            this.equName = "气象仪";
        }
    }
}
