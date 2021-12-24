using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03_Strings
{
    internal class Doubles
    {
        public static string DoIt(string str1, string str2)
        {
            var res = new StringBuilder();
            
            foreach (var item1 in str1)
            {
                //Вариант 1
                res.Append(item1);
                if (item1 != ' ' && str2.IndexOf(item1) != -1)
                {
                    res.Append(item1);
                }


                // Вариант 2
                //if (item1 != ' ' &&  Array.Exists<char>(str2.ToCharArray(), item2 => item2 == item1))
                //{
                //    res.Append(item1);

                //}
                // Вариант 3

                //foreach (var item2 in str2)
                //{
                //if (item1 != ' '&& item1 == item2)
                //{
                //    res.Append(item1);
                //    break;
                //}
                //}
            }
            // Вариант 4
            //char[] chars = str1.ToCharArray();
            //int length = chars.Length * 2;
            //string result = string.Create(length, chars, (Span<char> strContent, char[] charArray) =>
            //{
            //    int i, j;
            //    for (i = 0, j = 0; i < charArray.Length; i++,j++)
            //    {
            //        strContent[j] = charArray[i];
            //        if (charArray[i] != ' ' && str2.IndexOf(charArray[i]) != -1)
            //        {
            //            j++;
            //            strContent[j] = charArray[i];
            //        }
            //    }
            //});

            return res.ToString(); //Для варианта 4 заменить на result
        }
    }
}
