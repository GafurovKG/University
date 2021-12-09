using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleHelper
{
    public class Rectangl
    {
        int a;
        int b;

        public Rectangl(int a, int b)
        {
            this.a = Math.Abs(a);
            this.b = Math.Abs(b);
        }
        public int perimetr()
        {
            return a*2+b*2;
        }
        public int square()
        {
            return a * b;
        }
    }
}
