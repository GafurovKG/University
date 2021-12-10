using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleHelper
{
    public class Rectangl
    {
        private readonly int a;
        private readonly int b;

        public Rectangl(int a, int b)
        {
            this.a = Math.Abs(a);
            this.b = Math.Abs(b);
        }
        public int Perimetr()
        {
            return a*2+b*2;
        }
        public int Square()
        {
            return a * b;
        }
    }
}
