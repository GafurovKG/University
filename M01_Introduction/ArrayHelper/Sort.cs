namespace ArrayHelper
{
    public class Sort
    {
        public static void SortASC(int[] array, bool isASC)
        {
            int temp;
            var maxN = array.Length - 1;
            do
            {
                for (int n = 0; n < maxN; n++)
                {
                    if ((isASC && array[n] > array[n + 1]) || (!isASC && array[n] < array[n + 1]))
                    {
                        temp = array[n + 1];
                        array[n + 1] = array[n];
                        array[n] = temp;
                    }
                }

                maxN--;
            }
            while (maxN > 0);
        }
    }
}