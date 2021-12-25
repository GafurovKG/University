using System.Collections.Generic;
using System.Text;

namespace M03_Strings
{
    internal class PhoneNumbers
    {
        public static List<string> DoIt(string str)
        {
            var PhoneNumbers = new List<string>();
            var PhoneNumberBuild = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) || str[i].Equals('(') || str[i].Equals(')') || str[i].Equals('-') || str[i].Equals('+') || str[i].Equals(' '))
                {
                    PhoneNumberBuild.Append(str[i]);
                }
                else
                {
                    if (PhoneNumberBuild.Length > 10)
                    {
                        PhoneNumbers.Add(PhoneNumberBuild.ToString().Trim());
                        PhoneNumberBuild.Clear();
                    }
                    else
                    {
                        PhoneNumberBuild.Clear();
                    }
                }
            }

            return PhoneNumbers;
        }
    }
}