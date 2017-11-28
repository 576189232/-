using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class TvGunObject : DeviceObject
    {
        public TvGunObject(Point p)
        {
            this.init(p);
        }

        public TvGunObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.TV_CCTV_Gun;
            this.equid = (int)equtype + "0001";
            this.picName = "TV_CCTV_Gun.png";
            this.equName = "枪机";
        }
    }
}
