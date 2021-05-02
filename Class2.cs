using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 下落的小球
{
    class board
    {
        int Height = 10;
        int Length = 50;
        int Location;
        public int height { get { return Height; } }
        public int length 
        { 
            get { return Length; }
            set { Length = value; }
        }
        public int location
        {
            get { return Location; }
            set { Location = value; }
        }
    }
}
