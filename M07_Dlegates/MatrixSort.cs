namespace M07_Delegates
{
    using System;

    internal static class MatrixSort
    {
        internal static int[,] SortMatrix(this int[,] inputMatrix, Func<int[], int[], bool> sortStrategy, bool ascendingDirection)
        {
            var maxN = inputMatrix.GetLength(0) - 1;
            do
            {
                for (int i = 0; i < maxN; i++)
                {
                    var rowA = new List<int>();
                    var rowB = new List<int>();
                    for (int j = 0; j < inputMatrix.GetLength(1); j++)
                    {
                        rowA.Add(inputMatrix[i, j]);
                        rowB.Add(inputMatrix[i + 1, j]);
                    }

                    bool rowABiggerRowB = sortStrategy(rowA.ToArray(), rowB.ToArray());
                    for (int n = 0; n < rowA.Count; n++)
                    {
                        if (rowABiggerRowB & !ascendingDirection || !rowABiggerRowB & ascendingDirection)
                        {
                            inputMatrix[i, n] = rowA[n];
                            inputMatrix[i + 1, n] = rowB[n];
                        }
                        else
                        {
                            inputMatrix[i, n] = rowB[n];
                            inputMatrix[i + 1, n] = rowA[n];
                        }
                    }
                }

                maxN--;
            }
            while (maxN > 0);

            return inputMatrix;
        }

        public static bool SortBySumStratagy(int[] rowA, int[] rowB)
        {
            int rowASum = 0;
            int rowBSum = 0;
            for (int i = 0; i < rowA.Length; i++)
            {
                rowASum += rowA[i];
                rowBSum += rowB[i];
            }

            return rowASum > rowBSum;
        }

        public static bool SortByMaxStratagy(int[] rowA, int[] rowB)
        {
            int rowAMax = rowA[0];
            int rowBMax = rowB[0];
            for (int i = 1; i < rowA.Length; i++)
            {
                rowAMax = rowA[i] > rowAMax ? rowA[i] : rowAMax;
                rowBMax = rowB[i] > rowBMax ? rowB[i] : rowBMax;
            }

            return rowAMax > rowBMax;
        }

        public static bool SortByMinStratagy(int[] rowA, int[] rowB)
        {
            int rowAMax = rowA[0];
            int rowBMax = rowB[0];
            for (int i = 1; i < rowA.Length; i++)
            {
                rowAMax = rowA[i] < rowAMax ? rowA[i] : rowAMax;
                rowBMax = rowB[i] < rowBMax ? rowB[i] : rowBMax;
            }

            return rowAMax > rowBMax;
        }
    }
}