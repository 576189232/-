using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Xml;
using DeviceDll.Device;
using System.Linq;

namespace WindowMake
{
    public class DinoComparer : IComparer<MyObject>
    {
        public int Compare(MyObject x, MyObject y)
        {

            return x.equid.CompareTo(y.equid);
            //if (x.obj_id == y.obj_id)
            //    return 0;
            //else if (x.obj_id > y.obj_id)
            //    return 1;
            //else
            //    return -1;

        }
    }

    public class SelectEventArgs : EventArgs
    {
        private bool bMultiSelect;
        private bool bMultiCopy;

        public SelectEventArgs(bool select, bool copy)
        {
            bMultiSelect = select;
            bMultiCopy = copy;
        }
        public bool bSelect
        {
            get { return bMultiSelect; }
            set { bMultiSelect = value; }
        }
        public bool bCopy
        {
            get { return bMultiCopy; }
            set { bMultiCopy = value; }
        }
    }
    public class MyPanel : Panel
    {
        public List<MyObject> m_ObjectList = new List<MyObject>();
        public List<MyObject> m_tempList = new List<MyObject>();
        public MyObject[] m_SelectList = new MyObject[8];
        private int m_MoveUnit = 4;//方向键移动时的步长
        private enum DrawMode : int
        {
            Unkown = 0,//未知模式
            Drawing = 1,//作图中
            Select = 2,//已选择对象、但未操作
            Move = 3,//选择对象后，进行拖动操作
            Zoom = 4,//选择对象后，进行缩放操作
        }
        private bool m_bCtrlDown = false;
        private bool m_bAltDown = false;
        private Point m_StartPt, M_EndPt;//进行框选时的起始点
        private bool m_bMultiMove = false;//多对象移动
        private bool m_bCopy = false;//是否有对象可以复制
        private DrawMode m_DrawMode = DrawMode.Unkown;
        private Point m_oldMousePoint = new Point(0, 0);
        public Map mapPro;//画面背景属性 
        public MyObject m_pCurrentObject = null;
        private int m_ZoomType = 0;//拖动的方向

        public MyPanel()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;

            for (int i = 0; i < 8; i++)
                m_SelectList[i] = new MyObject();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            MyObject tempobj = null;
            if (m_pCurrentObject != null && m_pCurrentObject.obj_bSelect)
                MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
            if (e.Clicks==2)
            {
                tempobj = SeachObject(e.Location);
                if (tempobj != null)
                {
                    m_pCurrentObject = tempobj;
                    m_DrawMode = DrawMode.Select;
                    //SetObjectPro();
                }
            }
            if (e.Button == MouseButtons.Left)
            {//左键按下
                if (m_bAltDown)
                {
                    m_StartPt = e.Location;
                    M_EndPt = e.Location;
                    m_DrawMode = DrawMode.Move;
                }
                else if (gMain.drawType != MyObject.ObjectType.UnKnow)//画状态
                {
                    MyObject m_object = null;
                    CreateObject(gMain.drawType, ref m_object, e.Location);
                    if (m_object != null)
                    {
                        ChangeCurrentObject(m_object);
                        GenerateObjectID(m_object);
                        m_ObjectList.Add(m_pCurrentObject);
                    }
                    m_DrawMode = DrawMode.Drawing;
                }
                else if (m_DrawMode == DrawMode.Select)
                {//单击选择对象
                    if (m_bCtrlDown)
                    {
                        tempobj = null;
                        tempobj = SeachObject(e.Location);
                        if (tempobj != null)
                        {
                            tempobj.obj_bSelect = !tempobj.obj_bSelect;
                            m_pCurrentObject = tempobj;
                            m_DrawMode = DrawMode.Move;
                        }
                    }
                    else
                    {
                        m_ZoomType = TestZoom(e.Location);
                        if (m_ZoomType > 0)
                            m_DrawMode = DrawMode.Zoom;
                        else
                        {
                            tempobj = SeachObject(e.Location);
                            if (tempobj != null)
                            {
                                ChangeCurrentObject(tempobj);
                                m_DrawMode = DrawMode.Move;
                            }
                            else
                                m_DrawMode = DrawMode.Unkown;
                        }
                    }
                }
                else
                {//对象选择
                    if (m_bCtrlDown)
                    {
                        tempobj = null;
                        tempobj = SeachObject(e.Location);
                        if (tempobj != null)
                        {
                            tempobj.obj_bSelect = !tempobj.obj_bSelect;
                            m_pCurrentObject = tempobj;
                            m_DrawMode = DrawMode.Move;
                        }
                    }
                    else
                    {
                        tempobj = null;
                        if (m_pCurrentObject != null)
                            m_pCurrentObject.obj_bSelect = false;
                        tempobj = SeachObject(e.Location);
                        if (tempobj != null)
                        {
                            m_pCurrentObject = tempobj;
                            tempobj.obj_bSelect = true;
                            m_DrawMode = DrawMode.Move;
                        }
                        else
                            m_pCurrentObject = null;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                tempobj = SeachObject(e.Location);
                if (tempobj != null)
                {
                    m_pCurrentObject = tempobj;
                    m_DrawMode = DrawMode.Select;
                }
                else
                {
                    m_pCurrentObject = null;
                }
            }

            m_oldMousePoint = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                if (m_DrawMode == DrawMode.Drawing && m_pCurrentObject != null)
                {
                    MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
                    m_pCurrentObject.DrawOjbect(g);
                    m_DrawMode = DrawMode.Select;
                    gMain.drawType = MyObject.ObjectType.UnKnow;
                }
                else if (m_bAltDown && m_DrawMode == DrawMode.Move)
                {
                    m_pCurrentObject = TestObjectInRect(m_StartPt, M_EndPt);
                    PaintSelectObject();
                    Invalidate(new Rectangle(m_StartPt.X - 1, m_StartPt.Y - 1, M_EndPt.X + 2, M_EndPt.Y + 2));
                    m_DrawMode = DrawMode.Select;
                }
                else if ((m_DrawMode == DrawMode.Move || m_DrawMode == DrawMode.Zoom) && m_pCurrentObject != null)
                {
                    if (m_bCtrlDown)
                    {
                        PaintSelectObject();
                        m_DrawMode = DrawMode.Select;
                    }
                    else
                    {
                        m_pCurrentObject.DrawOjbect(g);
                        m_DrawMode = DrawMode.Select;
                    }
                }
                else
                {
                    m_DrawMode = DrawMode.Unkown;
                    ClearSelectObject();
                }
                //this.Invalidate();
            }
            if (m_pCurrentObject != null)
            {
                MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
                m_pCurrentObject.DrawOjbect(g);
            }
            if (SelectChanged != null)
                SelectChanged(this, new SelectEventArgs(m_bMultiMove, m_bCopy));
            base.OnMouseUp(e);
        }

        public event EventHandler<SelectEventArgs> SelectChanged;
        /// <summary>
        /// 清除选中对象
        /// </summary>
        private void ClearSelectObject()
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    m_ObjectList[i].obj_bSelect = false;
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
            m_bMultiMove = false;
        }
        /// <summary>
        /// 绘制选中对象
        /// </summary>
        private void PaintSelectObject()
        {
            Graphics g = CreateGraphics();
            int n = 0;
            m_bCopy = false;
            int index = 9999999;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    n++;
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    m_ObjectList[i].DrawOjbect(g);
                    index = i;
                }
                if (m_ObjectList[i].obj_bCopy)
                    m_bCopy = true;
            }
            if (n > 1)
                m_bMultiMove = true;
            else
                m_bMultiMove = false;
            if (m_pCurrentObject == null && index < m_ObjectList.Count && index >= 0)
                m_pCurrentObject = m_ObjectList[index];
        }
        /// <summary>
        /// 移动对象
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (m_DrawMode == DrawMode.Drawing)//画状态
            {
            }
            else if (m_DrawMode == DrawMode.Move)
            {
                if (m_bAltDown)
                {
                    this.Invalidate(new Rectangle(m_StartPt.X, m_StartPt.Y, M_EndPt.X + 1, M_EndPt.Y + 1));
                    M_EndPt = e.Location;
                    Pen myPen = new Pen(Color.Black, 0.1F);
                    myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawRectangle(myPen, new Rectangle(m_StartPt.X, m_StartPt.Y, M_EndPt.X, M_EndPt.Y));
                }
                else
                {
                    if (m_pCurrentObject != null)
                    {
                        MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
                        int x = e.Location.X - m_oldMousePoint.X;
                        int y = e.Location.Y - m_oldMousePoint.Y;
                        m_pCurrentObject.start.X += x;
                        m_pCurrentObject.start.Y += y;
                        m_pCurrentObject.end.X += x;
                        m_pCurrentObject.end.Y += y;
                        m_oldMousePoint = e.Location;
                    }
                    m_pCurrentObject.DrawOjbect(g);
                }
            }
            else if (m_DrawMode == DrawMode.Zoom && m_pCurrentObject != null)
            {
                MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
                switch (m_ZoomType)
                {
                    case 1:
                        m_pCurrentObject.start.Y = e.Location.Y;
                        break;
                    case 2:
                        m_pCurrentObject.end.Y = e.Location.Y;
                        break;
                    case 3:
                        m_pCurrentObject.start.X = e.Location.X;
                        break;
                    case 4:
                        m_pCurrentObject.end.X = e.Location.X;
                        break;
                    case 5:
                        m_pCurrentObject.start = e.Location;
                        break;
                    case 6:
                        m_pCurrentObject.start.Y = e.Location.Y;
                        m_pCurrentObject.end.X = e.Location.X;
                        break;
                    case 7:
                        m_pCurrentObject.end = e.Location;
                        break;
                    case 8:
                        m_pCurrentObject.start.X = e.Location.X;
                        m_pCurrentObject.end.Y = e.Location.Y;
                        break;
                }
                m_pCurrentObject.DrawOjbect(g);
            }
            else
            {
                MyObject tempobject = null;
                tempobject = SeachObject(e.Location);
                if (tempobject == null)
                    this.Cursor = Cursors.Default;
                else
                    this.Cursor = Cursors.SizeAll;
                if (m_DrawMode == DrawMode.Select)
                    TestZoom(e.Location);

            }
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                m_ObjectList[i].DrawOjbect(e.Graphics);
                if (m_ObjectList[i].obj_bSelect)
                    DrawSelectRect(e.Graphics, m_ObjectList[i]);
            }
            if (m_DrawMode == DrawMode.Select && m_pCurrentObject != null)
            {
                //画矩形框以及4个小矩形
                DrawSelectRect2(e.Graphics, m_pCurrentObject);
            }
            if (m_bAltDown && m_DrawMode == DrawMode.Move)
            {
                Pen myPen = new Pen(Color.Black, 0.1F);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawRectangle(myPen, new Rectangle(m_StartPt.X, m_StartPt.Y, M_EndPt.X - m_StartPt.X, M_EndPt.Y - m_StartPt.Y));
            }
            base.OnPaint(e);
        }
        private void DrawSelectRect(Graphics g, MyObject obj)
        {
            //上边线
            int t = (obj.end.X + obj.start.X) / 2 - 2;
            m_SelectList[0].start = new Point(t, obj.start.Y - 2);
            m_SelectList[0].end = new Point(t + 4, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), t, obj.start.Y - 2, 4, 4);
            //下边线
            m_SelectList[1].start = new Point(t, obj.end.Y - 2);
            m_SelectList[1].end = new Point(t + 4, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), t, obj.end.Y - 2, 4, 4);
            //左边线
            t = (obj.end.Y + obj.start.Y) / 2 - 2;
            m_SelectList[2].start = new Point(obj.start.X - 2, t);
            m_SelectList[2].end = new Point(obj.start.X + 2, t + 4);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, t, 4, 4);
            //右边线
            m_SelectList[3].start = new Point(obj.end.X - 2, t);
            m_SelectList[3].end = new Point(obj.end.X + 2, t + 4);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, t, 4, 4);
            //左上角
            m_SelectList[4].start = new Point(obj.start.X - 2, obj.start.Y - 2);
            m_SelectList[4].end = new Point(obj.start.X + 2, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, obj.start.Y - 2, 4, 4);
            //右上角
            m_SelectList[5].start = new Point(obj.end.X - 2, obj.start.Y - 2);
            m_SelectList[5].end = new Point(obj.end.X + 2, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, obj.start.Y - 2, 4, 4);
            //右下角
            m_SelectList[6].start = new Point(obj.end.X - 2, obj.end.Y - 2);
            m_SelectList[6].end = new Point(obj.end.X + 2, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, obj.end.Y - 2, 4, 4);
            //左下角
            m_SelectList[7].start = new Point(obj.start.X - 2, obj.end.Y - 2);
            m_SelectList[7].end = new Point(obj.start.X + 2, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, obj.end.Y - 2, 4, 4);
        }
        private void DrawSelectRect2(Graphics g, MyObject obj)
        {
            //上边线
            int t = (obj.end.X + obj.start.X) / 2 - 2;
            m_SelectList[0].start = new Point(t, obj.start.Y - 2);
            m_SelectList[0].end = new Point(t + 4, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), t, obj.start.Y - 2, 4, 4);
            //下边线
            m_SelectList[1].start = new Point(t, obj.end.Y - 2);
            m_SelectList[1].end = new Point(t + 4, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), t, obj.end.Y - 2, 4, 4);
            //左边线
            t = (obj.end.Y + obj.start.Y) / 2 - 2;
            m_SelectList[2].start = new Point(obj.start.X - 2, t);
            m_SelectList[2].end = new Point(obj.start.X + 2, t + 4);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, t, 4, 4);
            //右边线
            m_SelectList[3].start = new Point(obj.end.X - 2, t);
            m_SelectList[3].end = new Point(obj.end.X + 2, t + 4);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, t, 4, 4);
            //左上角
            m_SelectList[4].start = new Point(obj.start.X - 2, obj.start.Y - 2);
            m_SelectList[4].end = new Point(obj.start.X + 2, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, obj.start.Y - 2, 4, 4);
            g.FillRectangle(Brushes.Black, obj.start.X - 2, obj.start.Y - 2, 4, 4);
            //右上角
            m_SelectList[5].start = new Point(obj.end.X - 2, obj.start.Y - 2);
            m_SelectList[5].end = new Point(obj.end.X + 2, obj.start.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, obj.start.Y - 2, 4, 4);
            g.FillRectangle(Brushes.Black, obj.end.X - 2, obj.start.Y - 2, 4, 4);
            //右下角
            m_SelectList[6].start = new Point(obj.end.X - 2, obj.end.Y - 2);
            m_SelectList[6].end = new Point(obj.end.X + 2, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.end.X - 2, obj.end.Y - 2, 4, 4);
            g.FillRectangle(Brushes.Black, obj.end.X - 2, obj.end.Y - 2, 4, 4);
            //左下角
            m_SelectList[7].start = new Point(obj.start.X - 2, obj.end.Y - 2);
            m_SelectList[7].end = new Point(obj.start.X + 2, obj.end.Y + 2);
            g.DrawRectangle(new Pen(Color.Black), obj.start.X - 2, obj.end.Y - 2, 4, 4);
            g.FillRectangle(Brushes.Black, obj.start.X - 2, obj.end.Y - 2, 4, 4);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyPanel
            // 
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 根据坐标查找选中对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private MyObject SeachObject(Point p)
        {
            for (int i = m_ObjectList.Count - 1; i >= 0; i--)
            {
                if (((p.X > m_ObjectList[i].start.X && p.X < m_ObjectList[i].end.X) || (p.X < m_ObjectList[i].start.X && p.X > m_ObjectList[i].end.X))
                    && ((p.Y > m_ObjectList[i].start.Y && p.Y < m_ObjectList[i].end.Y) || (p.Y < m_ObjectList[i].start.Y && p.Y > m_ObjectList[i].end.Y)))
                {
                    return m_ObjectList[i];
                }
            }
            return null;
        }
        private MyObject TestObjectInRect(Point s, Point e)
        {
            MyObject obj = null;
            for (int i = m_ObjectList.Count - 1; i >= 0; i--)
            {
                if (((m_ObjectList[i].start.X > s.X && m_ObjectList[i].start.Y > s.Y) && (m_ObjectList[i].end.X < e.X && m_ObjectList[i].start.Y < e.Y))
                    || ((m_ObjectList[i].start.X > e.X && m_ObjectList[i].start.Y > e.Y) && (m_ObjectList[i].end.X < s.X && m_ObjectList[i].start.Y < s.Y)))
                {
                    m_ObjectList[i].obj_bSelect = true;
                    obj = m_ObjectList[i];
                }
            }
            return obj;
        }
        private int TestZoom(Point p)
        {
            for (int i = 0; i < 8; i++)
            {
                if (((p.X > m_SelectList[i].start.X && p.X < m_SelectList[i].end.X) || (p.X < m_SelectList[i].start.X && p.X > m_SelectList[i].end.X))
                    && ((p.Y > m_SelectList[i].start.Y && p.Y < m_SelectList[i].end.Y) || (p.Y > m_SelectList[i].start.Y && p.Y < m_SelectList[i].end.Y)))
                {
                    switch (i)
                    {
                        case 0:
                        case 1:
                            this.Cursor = Cursors.SizeNS;
                            break;
                        case 2:
                        case 3:
                            this.Cursor = Cursors.SizeWE;
                            break;
                        case 4:
                        case 6:
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        case 5:
                        case 7:
                            this.Cursor = Cursors.SizeNESW;
                            break;
                    }
                    return i + 1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 刷新制定矩形区域的画面
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void MyObjectInvalidate(Point s, Point e)
        {
            Rectangle r = new Rectangle(s.X - 3, s.Y - 3, e.X - s.X + 6, e.Y - s.Y + 6);
            this.Invalidate(r, false);
        }
        public void InvalidateCurrentObject()
        {
            if (m_pCurrentObject != null)
            {
                //MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
            }
        }
        /// <summary>
        /// 重画当前对象
        /// </summary>
        public void DrawCurrentObject()
        {
            if (m_pCurrentObject != null)
            {
                Graphics g = this.CreateGraphics();
                m_pCurrentObject.DrawOjbect(g);
            }
        }

        /// <summary>
        /// 设备ID生成
        /// </summary>
        /// <param name="tempobj"></param>
        /// <returns></returns>
        private string GenerateObjectID(MyObject tempobj)
        {
            var equ = (from a in m_tempList where a.equtype == tempobj.equtype orderby a.equid descending select a).FirstOrDefault();
            int r = 0;
            if (equ != null)
            {
                int.TryParse(equ.equid, out r);
                tempobj.equid = (++r).ToString();
            }
            m_tempList.Add(tempobj);
            return tempobj.equid;
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right)
                return true;
            if (keyData == Keys.Alt || keyData == Keys.Control)
                return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Graphics g = CreateGraphics();
            int i = 0;
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        if (m_pCurrentObject != null)
                        {
                            m_ObjectList.Remove(m_pCurrentObject);
                            m_tempList.Remove(m_pCurrentObject);
                            MyObjectInvalidate(m_pCurrentObject.start, m_pCurrentObject.end);
                            m_pCurrentObject = null;
                        }
                    }
                    break;
                case Keys.Menu:
                    m_bAltDown = true; //框选状态
                    break;
                case Keys.ControlKey:
                    m_bCtrlDown = true;
                    break;
                case Keys.Up:
                    {
                        for (i = 0; i < m_ObjectList.Count; i++)
                        {
                            if (m_ObjectList[i].obj_bSelect)
                            {
                                MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                                m_ObjectList[i].start.Y -= m_MoveUnit;
                                m_ObjectList[i].end.Y -= m_MoveUnit;
                                m_ObjectList[i].DrawOjbect(g);
                            }
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        for (i = 0; i < m_ObjectList.Count; i++)
                        {
                            if (m_ObjectList[i].obj_bSelect)
                            {
                                MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                                m_ObjectList[i].start.Y += m_MoveUnit;
                                m_ObjectList[i].end.Y += m_MoveUnit;
                                m_ObjectList[i].DrawOjbect(g);
                            }
                        }
                    }
                    break;
                case Keys.Left:
                    {
                        for (i = 0; i < m_ObjectList.Count; i++)
                        {
                            if (m_ObjectList[i].obj_bSelect)
                            {
                                MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                                m_ObjectList[i].start.X -= m_MoveUnit;
                                m_ObjectList[i].end.X -= m_MoveUnit;
                                m_ObjectList[i].DrawOjbect(g);
                            }
                        }
                    }
                    break;
                case Keys.Right:
                    {
                        for (i = 0; i < m_ObjectList.Count; i++)
                        {
                            if (m_ObjectList[i].obj_bSelect)
                            {
                                MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                                m_ObjectList[i].start.X += m_MoveUnit;
                                m_ObjectList[i].end.X += m_MoveUnit;
                                m_ObjectList[i].DrawOjbect(g);
                            }
                        }
                    }
                    break;
            }
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    m_bCtrlDown = false;
                    break;
                case Keys.Menu:
                    m_bAltDown = false;
                    break;
            }
            base.OnKeyUp(e);
        }
        public void objectTop()
        {
            if (m_pCurrentObject != null)
            {
                m_ObjectList.Remove(m_pCurrentObject);
                m_ObjectList.Add(m_pCurrentObject);
            }
        }
        public void objectBottom()
        {
            if (m_pCurrentObject != null)
            {
                m_ObjectList.Remove(m_pCurrentObject);
                m_ObjectList.Insert(0, m_pCurrentObject);
            }
        }
        public void objectOn()
        {
            if (m_pCurrentObject != null)
            {
                int index = m_ObjectList.IndexOf(m_pCurrentObject, 0);
                m_ObjectList.Remove(m_pCurrentObject);
                index++;
                if (index > m_ObjectList.Count)
                    index = m_ObjectList.Count;
                m_ObjectList.Insert(index, m_pCurrentObject);
            }
        }
        public void objectUnder()
        {
            if (m_pCurrentObject != null)
            {
                int index = m_ObjectList.IndexOf(m_pCurrentObject, 0);
                m_ObjectList.Remove(m_pCurrentObject);
                index--;
                if (index < 0)
                    index = 0;
                m_ObjectList.Insert(index, m_pCurrentObject);
            }
        }
        public void SaveDocument(string fname)
        {
            XmlDocument doc = new XmlDocument(); // 创建dom对象

            XmlElement root = doc.CreateElement("root"); // 创建根节点album
            root.SetAttribute("version", gMain.g_version); // 设置属性
            doc.AppendChild(root);    //  加入到xml document
            XmlElement bk = doc.CreateElement("BK"); // 背景颜色
            bk.SetAttribute("mapId", mapPro.mapId);
            bk.SetAttribute("mapName", mapPro.mapName);
            bk.SetAttribute("IsRoad", mapPro.IsRoad.ToString());
            bk.SetAttribute("mapAddress", mapPro.mapAddress);
            bk.SetAttribute("bkfile", mapPro.bkfile);
            root.AppendChild(bk);
            XmlElement obj = doc.CreateElement("objList"); // 创建根节点album
            obj.SetAttribute("objNum", m_ObjectList.Count.ToString());
            root.AppendChild(obj);//对象节点
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                XmlElement preview = m_ObjectList[i].SaveObject(doc);
                obj.AppendChild(preview);   // 添加到xml document
            }
            doc.Save(fname);   // 保存文件

        }
        public void OpenDocument(string fname)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fname);
            XmlElement root = doc.DocumentElement;
            if (root != null)
            {
                string version = root.GetAttribute("version");
                if (version != gMain.g_version)
                    if (MessageBox.Show("文件版本不正确，是否要打开?", "版本错误", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                XmlNode temp;
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    temp = root.ChildNodes[i];
                    if (temp != null && temp.Name == "BK")
                    {
                        mapPro.mapId = ((XmlElement)temp).GetAttribute("mapId");
                        mapPro.mapName = ((XmlElement)temp).GetAttribute("mapName");
                        mapPro.IsRoad = Convert.ToInt32(((XmlElement)temp).GetAttribute("IsRoad"));
                        mapPro.mapAddress = ((XmlElement)temp).GetAttribute("mapAddress");
                        mapPro.bkfile = ((XmlElement)temp).GetAttribute("bkfile");

                        //this.Size = this.mapPro.size;
                        //this.BackColor = this.mapPro.bkcolor;
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                        if (!string.IsNullOrEmpty(this.mapPro.bkfile))
                        {
                            this.BackgroundImage = Image.FromFile(this.mapPro.bkfile);
                            this.Size = BackgroundImage.Size;
                        }
                        //this.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\BK\\" + this.mapPro.bkfile);
                        else
                            this.BackgroundImage = null;
                    }
                    else if (temp != null && temp.Name == "objList")
                    {
                        XmlNodeList objNodes = ((XmlElement)temp).GetElementsByTagName("obj");
                        MyObject m_object = null;
                        foreach (XmlNode node in objNodes)
                        {
                            int type = Convert.ToInt32(((XmlElement)node).GetAttribute("equtype"));   //获取name属性值
                            MyObject.ObjectType obj_type = (MyObject.ObjectType)type;
                            switch (obj_type)
                            {
                                case MyObject.ObjectType.CF:
                                    m_object = new CFObject();
                                    break;
                                case MyObject.ObjectType.CL:
                                    m_object = new CLObject();
                                    break;
                                case MyObject.ObjectType.CM:
                                    m_object = new CMObject();
                                    break;
                                case MyObject.ObjectType.E:
                                    m_object = new EObject();
                                    break;
                                case MyObject.ObjectType.EP:
                                    m_object = new EpObject();
                                    break;
                                case MyObject.ObjectType.EP_R:
                                    m_object = new EprObject();
                                    break;
                                case MyObject.ObjectType.EP_T:
                                    m_object = new EptObject();
                                    break;
                                case MyObject.ObjectType.F_L:
                                    m_object = new FlObject();
                                    break;
                                case MyObject.ObjectType.F_SB:
                                    m_object = new FsbObject();
                                    break;
                                case MyObject.ObjectType.F_YG:
                                    m_object = new FygObject();
                                    break;
                                case MyObject.ObjectType.I:
                                    m_object = new IObject();
                                    break;
                                case MyObject.ObjectType.P_AF:
                                    m_object = new PafObject();
                                    break;
                                case MyObject.ObjectType.P_CL:
                                    m_object = new PclObject();
                                    break;
                                case MyObject.ObjectType.P_CO:
                                    m_object = new PcoObject();
                                    break;
                                case MyObject.ObjectType.P_GJ:
                                    m_object = new PgjObject();
                                    break;
                                case MyObject.ObjectType.P_HL2:
                                    m_object = new Phl2Object();
                                    break;
                                case MyObject.ObjectType.P_HL:
                                    m_object = new PhlObject();
                                    break;
                                case MyObject.ObjectType.P_JF:
                                    m_object = new PjfObject();
                                    break;
                                case MyObject.ObjectType.P_LJQ:
                                    m_object = new PljqObject();
                                    break;
                                case MyObject.ObjectType.P_LLDI:
                                    m_object = new PlldiObject();
                                    break;
                                case MyObject.ObjectType.P_L:
                                    m_object = new PlObject();
                                    break;
                                case MyObject.ObjectType.P_LYJ:
                                    m_object = new PlyjObject();
                                    break;
                                case MyObject.ObjectType.P:
                                    m_object = new PObject();
                                    break;
                                case MyObject.ObjectType.P_P:
                                    m_object = new PpObject();
                                    break;
                                case MyObject.ObjectType.P_TD:
                                    m_object = new PtdObject();
                                    break;
                                case MyObject.ObjectType.P_TL2_Close:
                                    m_object = new Ptl2CloseObject();
                                    break;
                                case MyObject.ObjectType.P_TL2_Down:
                                    m_object = new Ptl2DownObject();
                                    break;
                                case MyObject.ObjectType.P_TL2_UP:
                                    m_object = new Ptl2UpObject();
                                    break;
                                case MyObject.ObjectType.P_TL5_Left:
                                    m_object = new Ptl5LeftObject();
                                    break;
                                case MyObject.ObjectType.P_TL5_Right:
                                    m_object = new Ptl5RightObject();
                                    break;
                                case MyObject.ObjectType.P_TW:
                                    m_object = new PtwObject();
                                    break;
                                case MyObject.ObjectType.P_VI:
                                    m_object = new PviObject();
                                    break;
                                case MyObject.ObjectType.S:
                                    m_object = new SObject();
                                    break;
                                case MyObject.ObjectType.TV_CCTV_Ball:
                                    m_object = new TvBallObject();
                                    break;
                                case MyObject.ObjectType.TV_CCTV_E:
                                    m_object = new TvEObject();
                                    break;
                                case MyObject.ObjectType.TV_CCTV_Gun:
                                    m_object = new TvGunObject();
                                    break;
                                case MyObject.ObjectType.TV:
                                    m_object = new TvObject();
                                    break;
                                case MyObject.ObjectType.VC:
                                    m_object = new VcObject();
                                    break;
                                case MyObject.ObjectType.VI:
                                    m_object = new ViObject();
                                    break;
                                default:
                                    break;
                            }
                            if (m_object != null)
                            {
                                m_object.OpenObject(node);
                                m_ObjectList.Add(m_object);
                                m_tempList.Add(m_object);
                            }
                        }
                    }
                }
            }
            DinoComparer dc = new DinoComparer();
            m_tempList.Sort(dc);
        }
        public void toolStripButton4_Click()
        {//左对齐
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int w = 0;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    w = m_ObjectList[i].end.X - m_ObjectList[i].start.X;
                    m_ObjectList[i].start.X = m_pCurrentObject.start.X;
                    m_ObjectList[i].end.X = m_ObjectList[i].start.X + w;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton5_Click()
        {//水平居中
        }

        public void toolStripButton6_Click()
        {//右对齐
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int w = 0;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    w = m_ObjectList[i].end.X - m_ObjectList[i].start.X;
                    m_ObjectList[i].end.X = m_pCurrentObject.end.X;
                    m_ObjectList[i].start.X = m_ObjectList[i].end.X - w;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton7_Click()
        {//顶对齐
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int h = 0;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    h = m_ObjectList[i].end.Y - m_ObjectList[i].start.Y;
                    m_ObjectList[i].start.Y = m_pCurrentObject.start.Y;
                    m_ObjectList[i].end.Y = m_ObjectList[i].start.Y + h;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton8_Click()
        {//垂直居中

        }

        public void toolStripButton9_Click()
        {//底对齐
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int h = 0;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    h = m_ObjectList[i].end.Y - m_ObjectList[i].start.Y;
                    m_ObjectList[i].end.Y = m_pCurrentObject.end.Y;
                    m_ObjectList[i].start.Y = m_ObjectList[i].end.Y - h;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton10_Click()
        {//宽度相等
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int len = m_pCurrentObject.end.X - m_pCurrentObject.start.X;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    m_ObjectList[i].end.X = m_ObjectList[i].start.X + len;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton11_Click()
        {//高度相等
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int len = m_pCurrentObject.end.Y - m_pCurrentObject.start.Y;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    m_ObjectList[i].end.Y = m_ObjectList[i].start.Y + len;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }

        public void toolStripButton12_Click()
        {//大小相等
            if (m_pCurrentObject == null)
                return;
            Graphics g = CreateGraphics();
            int lenX = m_pCurrentObject.end.X - m_pCurrentObject.start.X;
            int lenY = m_pCurrentObject.end.Y - m_pCurrentObject.start.Y;
            for (int i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    m_ObjectList[i].end.X = m_ObjectList[i].start.X + lenX;
                    m_ObjectList[i].end.Y = m_ObjectList[i].start.Y + lenY;
                    m_ObjectList[i].DrawOjbect(g);
                }
            }
        }
        private static int CompareObjectByPostionX(MyObject x, MyObject y)
        {
            return x.start.X.CompareTo(y.start.X);
        }

        public void toolStripButton13_Click()
        {//水平间距相等
            Graphics g = CreateGraphics();
            int start_x = 999999;
            int end_x = 0;
            int num = 0;
            List<MyObject> temp_array = new List<MyObject>();
            int i = 0;
            for (i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    num++;
                    temp_array.Add(m_ObjectList[i]);
                    if (m_ObjectList[i].start.X > end_x)
                        end_x = m_ObjectList[i].start.X;
                    if (m_ObjectList[i].start.X < start_x)
                        start_x = m_ObjectList[i].start.X;
                }
            }
            temp_array.Sort(CompareObjectByPostionX);
            int nlen = (end_x - start_x) / (num - 1);
            int width;
            for (i = 0; i < temp_array.Count; i++)
            {
                MyObjectInvalidate(temp_array[i].start, temp_array[i].end);
                width = temp_array[i].end.X - temp_array[i].start.X;
                temp_array[i].start.X = start_x + i * nlen;
                temp_array[i].end.X = temp_array[i].start.X + width;
                temp_array[i].DrawOjbect(g);
            }
        }

        public void toolStripButton14_Click()
        {//增加水平间距

        }

        public void toolStripButton15_Click()
        {//减少水平间距

        }
        private static int CompareObjectByPostionY(MyObject x, MyObject y)
        {
            return x.start.Y.CompareTo(y.start.Y);
        }
        public void toolStripButton16_Click()
        {//垂直间距相等
            Graphics g = CreateGraphics();
            int start_y = 999999;
            int end_y = 0;
            int num = 0;
            List<MyObject> temp_array = new List<MyObject>();
            int i = 0;
            for (i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    num++;
                    temp_array.Add(m_ObjectList[i]);
                    if (m_ObjectList[i].start.Y > end_y)
                        end_y = m_ObjectList[i].start.Y;
                    if (m_ObjectList[i].start.Y < start_y)
                        start_y = m_ObjectList[i].start.Y;
                }
            }
            temp_array.Sort(CompareObjectByPostionY);
            int nlen = (end_y - start_y) / (num - 1);
            int height;
            for (i = 0; i < temp_array.Count; i++)
            {
                MyObjectInvalidate(temp_array[i].start, temp_array[i].end);
                height = temp_array[i].end.Y - temp_array[i].start.Y;
                temp_array[i].start.Y = start_y + i * nlen;
                temp_array[i].end.Y = temp_array[i].start.Y + height;
                temp_array[i].DrawOjbect(g);
            }
        }

        public void toolStripButton17_Click()
        {//增加垂直间距

        }

        public void toolStripButton18_Click()
        {//减少垂直间距

        }
        public void toolCopyObject()
        {//复制 
            int i = 0;
            m_bCopy = false;
            for (i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bSelect)
                {
                    m_ObjectList[i].obj_bCopy = true;
                    m_bCopy = true;
                }
            }
            if (SelectChanged != null)
                SelectChanged(this, new SelectEventArgs(m_bMultiMove, m_bCopy));
        }

        public void toolPasteObject()
        {//粘贴
            int i = 0;
            MyObject m_object = null;
            Point start, end;
            int iMovePix = 50;
            for (i = 0; i < m_ObjectList.Count; i++)
            {
                if (m_ObjectList[i].obj_bCopy)
                {
                    m_ObjectList[i].obj_bSelect = false;
                    m_ObjectList[i].obj_bCopy = false;
                    MyObjectInvalidate(m_ObjectList[i].start, m_ObjectList[i].end);
                    start = new Point(m_ObjectList[i].start.X + iMovePix, m_ObjectList[i].start.Y + iMovePix);
                    end = new Point(m_ObjectList[i].end.X + iMovePix, m_ObjectList[i].end.Y + iMovePix);
                    CreateObject(m_ObjectList[i].equtype, ref m_object, start);
                    if (m_object != null)
                    {
                        m_object.end = end;
                        m_object.picName = m_ObjectList[i].picName;
                        m_object.obj_bSelect = true;
                        m_pCurrentObject = m_object;
                        GenerateObjectID(m_object);
                        m_ObjectList.Add(m_pCurrentObject);
                    }
                }
            }
            this.Invalidate(new Rectangle(m_StartPt.X + iMovePix, m_StartPt.Y + iMovePix, M_EndPt.X + iMovePix, M_EndPt.Y + iMovePix));
            PaintSelectObject();
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="equtype">对象类型</param>
        /// <param name="m_object">对象实体</param>
        /// <param name="start">坐标</param>
        /// <returns></returns>
        private void CreateObject(MyObject.ObjectType equtype, ref MyObject m_object, Point start)
        {
            switch (equtype)
            {
                case MyObject.ObjectType.CF:
                    m_object = new CFObject(start);
                    break;
                case MyObject.ObjectType.CL:
                    m_object = new CLObject(start);
                    break;
                case MyObject.ObjectType.CM:
                    m_object = new CMObject(start);
                    break;
                case MyObject.ObjectType.E:
                    m_object = new EObject(start);
                    break;
                case MyObject.ObjectType.EP:
                    m_object = new EpObject(start);
                    break;
                case MyObject.ObjectType.EP_R:
                    m_object = new EprObject(start);
                    break;
                case MyObject.ObjectType.EP_T:
                    m_object = new EptObject(start);
                    break;
                case MyObject.ObjectType.F_L:
                    m_object = new FlObject(start);
                    break;
                case MyObject.ObjectType.F_SB:
                    m_object = new FsbObject(start);
                    break;
                case MyObject.ObjectType.F_YG:
                    m_object = new FygObject(start);
                    break;
                case MyObject.ObjectType.I:
                    m_object = new IObject(start);
                    break;
                case MyObject.ObjectType.P_AF:
                    m_object = new PafObject(start);
                    break;
                case MyObject.ObjectType.P_CL:
                    m_object = new PclObject(start);
                    break;
                case MyObject.ObjectType.P_CO:
                    m_object = new PcoObject(start);
                    break;
                case MyObject.ObjectType.P_GJ:
                    m_object = new PgjObject(start);
                    break;
                case MyObject.ObjectType.P_HL2:
                    m_object = new Phl2Object(start);
                    break;
                case MyObject.ObjectType.P_HL:
                    m_object = new PhlObject(start);
                    break;
                case MyObject.ObjectType.P_JF:
                    m_object = new PjfObject(start);
                    break;
                case MyObject.ObjectType.P_LJQ:
                    m_object = new PljqObject(start);
                    break;
                case MyObject.ObjectType.P_LLDI:
                    m_object = new PlldiObject(start);
                    break;
                case MyObject.ObjectType.P_L:
                    m_object = new PlObject(start);
                    break;
                case MyObject.ObjectType.P_LYJ:
                    m_object = new PlyjObject(start);
                    break;
                case MyObject.ObjectType.P:
                    m_object = new PObject(start);
                    break;
                case MyObject.ObjectType.P_P:
                    m_object = new PpObject(start);
                    break;
                case MyObject.ObjectType.P_TD:
                    m_object = new PtdObject(start);
                    break;
                case MyObject.ObjectType.P_TL2_Close:
                    m_object = new Ptl2CloseObject(start);
                    break;
                case MyObject.ObjectType.P_TL2_Down:
                    m_object = new Ptl2DownObject(start);
                    break;
                case MyObject.ObjectType.P_TL2_UP:
                    m_object = new Ptl2UpObject(start);
                    break;
                case MyObject.ObjectType.P_TL5_Left:
                    m_object = new Ptl5LeftObject(start);
                    break;
                case MyObject.ObjectType.P_TL5_Right:
                    m_object = new Ptl5RightObject(start);
                    break;
                case MyObject.ObjectType.P_TW:
                    m_object = new PtwObject(start);
                    break;
                case MyObject.ObjectType.P_VI:
                    m_object = new PviObject(start);
                    break;
                case MyObject.ObjectType.S:
                    m_object = new SObject(start);
                    break;
                case MyObject.ObjectType.TV_CCTV_Ball:
                    m_object = new TvBallObject(start);
                    break;
                case MyObject.ObjectType.TV_CCTV_E:
                    m_object = new TvEObject(start);
                    break;
                case MyObject.ObjectType.TV_CCTV_Gun:
                    m_object = new TvGunObject(start);
                    break;
                case MyObject.ObjectType.TV:
                    m_object = new TvObject(start);
                    break;
                case MyObject.ObjectType.VC:
                    m_object = new VcObject(start);
                    break;
                case MyObject.ObjectType.VI:
                    m_object = new ViObject(start);
                    break;
                default:
                    break;
            }
        }

        private void ChangeCurrentObject(MyObject obj)
        {
            if (null != m_pCurrentObject)
            {
                m_pCurrentObject.obj_bSelect = false;
                InvalidateCurrentObject();
            }
            m_pCurrentObject = obj;
            m_pCurrentObject.obj_bSelect = true;
        }
    }
}
