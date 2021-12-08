using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayHelper
{
    public class Sum
    {
        public static int sum(int[,] array)
        {
            int sum = 0;
            foreach (int item in array)
            {
                sum += item >= 0 ? item : 0;
            }
            return sum;
        }
    }
}
