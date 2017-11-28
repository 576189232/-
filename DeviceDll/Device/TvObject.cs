using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class TvObject : DeviceObject
    {
        public TvObject(Point p)
        {
            this.init(p);
        }

        public TvObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.TV;
            this.equid = (int)equtype + "0001";
            this.picName = "TV.png";
            this.equName = "流媒体服务器";
        }
    }
}
