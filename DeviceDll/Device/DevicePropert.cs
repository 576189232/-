using System.Collections.Generic;

namespace DeviceDll.Device
{
    public class DevicePropert
    {
        public string m_location;

        public ushort m_PLCStation;

        public string m_note;

        public string Vendor;

        public string RunMode;

        public ushort[] m_YX;

        public ushort[] m_YX_P;

        public ushort[] m_YK;

        public ushort[] m_YK_P;

        public ushort[] m_YC;

        public float[] m_Rate;

        //public ushort[] m_OffSet;

        public ushort m_Min_YK;

        public ushort m_Min_YK_P;

        public bool[] m_bYX;

        public ushort m_Postion;

        public DevicePropert()
        {
            this.m_YX = new ushort[]
            {
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535
            };
            this.m_YX_P = new ushort[]
            {
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255
            };
            this.m_YK = new ushort[]
            {
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535
            };
            this.m_YK_P = new ushort[]
            {
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255
            };
            this.m_YC = new ushort[]
            {
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535,
                65535
            };
            this.m_Rate = new float[]
            {
                1f,
                1f,
                1f,
                1f,
                1f,
                1f,
                1f,
                1f
            };
            //this.m_OffSet = new ushort[]
            //{
            //    65535,
            //    65535,
            //    65535,
            //    65535,
            //    65535,
            //    65535,
            //    65535,
            //    65535
            //};
            this.m_Min_YK = 65535;
            this.m_Min_YK_P = 255;
            bool[] bYX = new bool[8];
            this.m_bYX = bYX;
            this.m_Postion = 0;
        }
    }
}
