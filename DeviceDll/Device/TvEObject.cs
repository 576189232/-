using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class TvEObject : DeviceObject
    {
        public TvEObject(Point p)
        {
            this.init(p);
        }

        public TvEObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.TV_CCTV_E;
            this.equid = (int)equtype + "0001";
            this.picName = "TV_CCTV_E.png";
            this.equName = "事件检测摄像机";
        }
    }
}
