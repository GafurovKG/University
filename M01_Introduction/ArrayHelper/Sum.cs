namespace ArrayHelper
{
    public class Sum
    {
        public static int Summ(int[,] array)
        {
            var sum = 0;
            foreach (var item in array)
            {
                sum += item >= 0 ? item : 0;
            }

            return sum;
        }
    }
}