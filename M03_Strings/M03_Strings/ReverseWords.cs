using System.Text;

namespace M03_Strings
{
    internal static class ReverseWords
    {
        public static string DoIt(string str)
        {
            var words = str.Split(' ');
            var StrBuilder = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                StrBuilder.Append(words[i]);
                StrBuilder.Append(' ');
            }

            return StrBuilder.ToString().TrimEnd();
        }
    }
}