using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PlyjObject : DeviceObject
    {
        public PlyjObject(Point p)
        {
            this.init(p);
        }

        public PlyjObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_LYJ;
            this.equid = (int)equtype + "0001";
            this.picName = "P_LYJ.png";
            this.equName = "应急照明";
        }
    }
}
