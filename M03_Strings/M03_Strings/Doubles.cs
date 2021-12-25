using System.Text;

namespace M03_Strings
{
    internal class Doubles
    {
        public static string DoIt(string str1, string str2)
        {
            var res = new StringBuilder();

            foreach (var item1 in str1)
            {
                res.Append(item1);
                if (item1 != ' ' && str2.IndexOf(item1) != -1)
                {
                    res.Append(item1);
                }
            }

            return res.ToString();
        }
    }
}