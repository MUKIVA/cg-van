using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    public class ViewPort
    {
        private int _left;
        private int _top;
        private int _width;
        private int _height;

        public ViewPort()
        { 
        }

        public ViewPort(int left, int top, int width, int height)
        {
            _left = left;
            _top = top;
            _width = width;
            _height = height;
        }

        public bool TestPoint(int x, int y)
        {
            return !(x < Left || x >= Right || y < Top || y >= Bottom);
        }

        public int Left => _left;
        public int Right => _left + _width;
        public int Top => _top;
        public int Bottom => _top + _height;
        public int Height => _height;
        public int Width => _width;
    }
}
