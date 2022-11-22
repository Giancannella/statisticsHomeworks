using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_polar_coord_
{
    class RealPoint
    {
        public double X;
        public double Y;

        public RealPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return X.ToString() + " - " + Y.ToString();
        }
    }
}
