using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class TvBallObject : DeviceObject
    {
        public TvBallObject(Point p)
        {
            this.init(p);
        }

        public TvBallObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.TV_CCTV_Ball;
            this.equid = (int)equtype + "0001";
            this.picName = "TV_CCTV_Ball.png";
            this.equName = "球机";
        }
    }
}
