using System;

namespace M03_Strings
{
    internal class WordsAverageLength
    {
        public static double DoIt(string str)
        {
            int letters = 0;

            var words = str.Split(new char[] { ' ', ',', '.', '!', '-', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in words)
            {
                letters += item.Length;
            }

            return letters / words.Length;
        }
    }
}