using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Audit
{
    public class RectHelper
    {
        public const int _ALIGNCENTER = 0, _ALIGNLEFT = 1, _ALIGNRIGHT = 2, _ALIGNTOP = 4, _ALIGNBOTTOM = 8;
        public Point lefttop;
        public Size siz;
        public Rectangle GetRectByProp(double l, double t, double r, double b)
        {
            Rectangle rect = new Rectangle(lefttop, siz);
            return GetRectByProp(rect, l, t, r, b);            
        }
        public Rectangle GetRectByProp(Rectangle rect, double l, double t, double r, double b)
        {
            Rectangle _r= new Rectangle();
            _r.X = (int)(rect.X +  rect.Width * l);
            _r.Y = (int)(rect.Y + rect.Height * t);
            _r.Width = (int)(rect.Width * (r - l));
            _r.Height = (int)(rect.Height * (b - t));
            return _r;   
        }

        public Rectangle GetAlignRect(Rectangle whole, Size size, int align)
        {
            Rectangle r = new Rectangle();
            if ((align & _ALIGNLEFT) == (align & _ALIGNRIGHT))
            {
                r.X = whole.X + (whole.Width - size.Width) / 2;
            }
            else if ((align & _ALIGNLEFT) != 0)
            {
                r.X = whole.X;
            }
            else
            {
                r.X = whole.Right - size.Width;
            }

            if ((align & _ALIGNTOP) == (align & _ALIGNBOTTOM))
            {
                r.Y = whole.Y + (whole.Height - size.Height) / 2;
            }
            else if ((align & _ALIGNTOP)!=0)
            {
                r.Y = whole.Y;
            }
            else
            {
                r.Y = whole.Bottom - size.Height;
            }
            r.Size = size;
            return r;
        }
        public Rectangle GetCenterRect(Rectangle whole, Size size)
        {
            return GetAlignRect(whole, size, 0);
        }
    }
}
