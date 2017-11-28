using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class IObject : DeviceObject
    {
        public IObject(Point p)
        {
            this.init(p);
        }

        public IObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.I;
            this.equid = (int)equtype + "0001";
            this.picName = "I.png";
            this.equName = "凝冰喷洒";
        }
    }
}
