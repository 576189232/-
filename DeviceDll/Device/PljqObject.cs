using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class PljqObject : DeviceObject
    {
        public PljqObject(Point p)
        {
            this.init(p);
        }

        public PljqObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.P_LJQ;
            this.equid = (int)equtype + "0001";
            this.picName = "P_LJQ.png";
            this.equName = "加强照明";
        }
    }
}
