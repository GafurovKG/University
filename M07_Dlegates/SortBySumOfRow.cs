namespace M07_Dlegates
{
    internal class SortBySumOfRow : ISortStrategy
    {
        public int[] SortByStratagy(int[,] unsortedmatrix)
        {
            var result = new List<int>();
            for (int i = 0; i < unsortedmatrix.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < unsortedmatrix.GetLength(1); j++)
                {
                    rowSum += unsortedmatrix[i, j];
                }

                result.Add(rowSum);
            }

            return result.ToArray();
        }
    }
}