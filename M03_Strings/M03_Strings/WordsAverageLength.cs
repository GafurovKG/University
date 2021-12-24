using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03_Strings
{
    internal class WordsAverageLength
    {
        static public double DoIt(string str)
        {
            int letters = 0;

            var words = str.Split(new char[] { ' ', ',', '.', '!', '-', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var item in words)
            {
                letters += item.Length;
            }
            return ((double)letters / (double)words.Length);
        }
    }
}
