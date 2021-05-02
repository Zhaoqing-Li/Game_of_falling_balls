using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 下落的小球
{
    class ball
    {
        int Radius = 10;
        int Speed = 10;   
        public int radius { get { return Radius; } }
        public int speed
        {
            get { return Speed; }
            set { speed = value; }
        }
    }
}
