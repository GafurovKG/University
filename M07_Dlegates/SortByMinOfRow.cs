namespace M07_Dlegates
{
    internal class SortByMinOfRow : ISortStrategy
    {
        public int[] SortByStratagy(int[,] unsortedmatrix)
        {
            var result = new List<int>();
            for (int i = 0; i < unsortedmatrix.GetLength(0); i++)
            {
                int rowMin = unsortedmatrix[i, 0];
                for (int j = 0; j < unsortedmatrix.GetLength(1); j++)
                {
                    rowMin = unsortedmatrix[i, j] < rowMin ? unsortedmatrix[i, j] : rowMin;
                }

                result.Add(rowMin);
            }

            return result.ToArray();
        }
    }
}