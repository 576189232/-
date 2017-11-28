using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class EObject : DeviceObject
    {
        public EObject(Point p)
        {
            this.init(p);
        }

        public EObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.E;
            this.equid = (int)equtype + "0001";
            this.picName = "E.png";
            this.equName = "事件检测服务器";
        }
    }
}
