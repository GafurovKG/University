namespace M07_Dlegates
{
    using System;

    internal static class MatrixSort
    {
        private static ISortStrategy sortStrategy;

        private delegate int[] SortStrategyDelegate(int[,] unsortedMatrix);

        internal static int[,] SortMatrix(this int[,] inputMatrix, ISortStrategy _sortStrategy, bool chooseSortDirection)
        {
            sortStrategy = _sortStrategy ?? throw new ArgumentNullException(nameof(sortStrategy));
            int[] arrayOfRowsKey = sortStrategy.SortByStratagy(inputMatrix);
            int key = arrayOfRowsKey[0];
            int index = 0;
            
            return inputMatrix;
        }

        //private static int[] SotrMatrixByStratagy(int[,] inputMatrix)
        //{
        //    int[,] arrayOfRowsKey = inputMatrix.ISortStrategy.SortByStratagy(); //ЗДЕСЬ ПРОБЛЕМА
        //}

        internal static ISortStrategy ChooseSortStrategy()
        {
            do
            {
                Console.WriteLine("Сhoose the sorting method :\n- by the sum (1)\n- by the max element (2)\n- by the min element (3):");
                ConsoleKeyInfo selectedKey = Console.ReadKey();
                switch (selectedKey.KeyChar)
                {
                    case '1':
                        return new SortBySumOfRow();
                    case '2':
                        return new SortByMaxOfRow();
                    case '3':
                        return new SortByMinOfRow();
                    default:
                        Console.WriteLine(" - incorrect choise\n");
                        break;
                }
            } while (true);
        }

        internal static bool ChooseSortDirection()
        {
            do
            {
                Console.WriteLine("\n\nСhoose the sorting direction :\n- ascending (+)\n- descending (-):");
                ConsoleKeyInfo selectedKey = Console.ReadKey();
                switch (selectedKey.KeyChar)
                {
                    case '+':
                        return true;
                    case '-':
                        return false;
                    default:
                        Console.WriteLine(" - incorrect choise\n");
                        break;
                }
            } while (true);
        }
    }
}