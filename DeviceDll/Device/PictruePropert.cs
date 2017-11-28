using System.Drawing;

namespace DeviceDll.Device
{
    public struct Map
    {
        //public Image background;
        public string mapId;
        public string mapName;
        /// <summary>
        /// 1表示路段，0表示隧道
        /// </summary>
        public int IsRoad;
        public string mapAddress;
        public string bkfile;
        public Size size;
    }
}
