using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03_Strings
{
    // Получился поцифровой калькулятор сложения.
    internal static class LongSum //нужно ли этот класс делать статическим?
    {
        public static string DoIt(string number1, string number2)
        {
            var StringBuilder = new StringBuilder();
            string revNumber1 = ReverseString(number1);
            string revNumber2 = ReverseString(number2);

            int sumDigitsPair;
            int overNine = 0;
            int maxlength = revNumber1.Length > revNumber2.Length ? revNumber1.Length : revNumber2.Length;
            int digit1, digit2;
            
            for (int i = 0; i < maxlength; i++)
            {
                digit1 = i < revNumber1.Length? Int32.Parse(revNumber1[i].ToString()):0;
                digit2 = i < revNumber2.Length? Int32.Parse(revNumber2[i].ToString()):0;
                sumDigitsPair = digit1 + digit2 + overNine;
                if (sumDigitsPair > 9)
                {
                    sumDigitsPair %= 10;
                    overNine = 1;
                }
                else overNine = 0;
                StringBuilder.Append(sumDigitsPair);
                
            }
            if (overNine != 0)
                StringBuilder.Append(overNine);
            return ReverseString(StringBuilder.ToString());
        }
        private static string ReverseString(string str) //переворачивает строку
        {
            var StringBuilder = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                StringBuilder.Append(str[i]);
            }
            string res = StringBuilder.ToString();
            return res;
        }
    }
}
