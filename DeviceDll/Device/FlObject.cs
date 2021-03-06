﻿using System;
using System.Drawing;

namespace DeviceDll.Device
{
    public class FlObject : DeviceObject
    {
        public FlObject(Point p)
        {
            this.init(p);
        }

        public FlObject()
        {
            this.init(this.start);
        }

        public void init(Point p)
        {
            this.start = p;
            this.end = new Point(p.X + 30, p.Y + 30);
            this.equtype = MyObject.ObjectType.F_L;
            this.equid = (int)equtype + "0001";
            this.picName = "F_L.png";
            this.equName = "火灾光纤";
        }
    }
}
