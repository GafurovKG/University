namespace M07_Dlegates
{
    internal class SortByMaxOfRow : ISortStrategy
    {
        public int[] SortByStratagy(int[,] unsortedmatrix)
        {
            var result = new List<int>();
            for (int i = 0; i < unsortedmatrix.GetLength(0); i++)
            {
                int rowMax = unsortedmatrix[i, 0];
                for (int j = 0; j < unsortedmatrix.GetLength(1); j++)
                {
                    rowMax = unsortedmatrix[i, j] > rowMax ? unsortedmatrix[i, j] : rowMax;
                }

                result.Add(rowMax);
            }

            return result.ToArray();
        }
    }
}