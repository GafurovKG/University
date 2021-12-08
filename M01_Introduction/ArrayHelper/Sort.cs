using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayHelper
{
    public class Sort
    {
         public static void sortASC(int[] array)
        {
            Console.Write("\n\nДля сортировка по возрастанию введите 1, по убыванию - любой символ: ");
            bool isASC = Console.Read() == '1' ? true : false;

            int temp;
            int maxN = array.Length - 1;
            int count = 0;
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
                    count++;
                }
                maxN--;
            } while (maxN > 0);
            Console.WriteLine("Count:" + count);
        }
    }
}
