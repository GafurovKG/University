using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayHelper
{
    public class Sort
    {
         public static void sortASC(int[] array, bool isASC)
        {
            int temp;
            int maxN = array.Length - 1;
            do
            {
                for (int n = 0; n < maxN; n++)
                {
                    if ((isASC && array[n] > array[n + 1]) || (!isASC && array[n] < array[n + 1])) //направление сортировки зависит от isASC
                    {
                        temp = array[n + 1];
                        array[n + 1] = array[n];
                        array[n] = temp;
                    }
                }
                maxN--;
            } while (maxN > 0);
        }
    }
}
