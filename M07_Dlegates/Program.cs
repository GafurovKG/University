using M07_Dlegates;

int[,] matrix =
{
            { 1, 2, 3, 4 },
            { -1, -2, -3, -4 },
            { 1, -2, 3, -4 },
            { -1, 2, 3, 4 },
            { 0, 1, -1, 0 }
};

Matrixprint(matrix);

matrix = MatrixSort.SortMatrix(matrix, ChooseSortStrategy(), AscendingDirection());

Console.WriteLine();

Matrixprint(matrix);

// Lambda test
matrix = MatrixSort.SortMatrix(matrix, (int[] rowA, int[] rowB) => rowA[3] > rowB[0], AscendingDirection());

Console.WriteLine("\nLambda test");

Matrixprint(matrix);

Console.WriteLine();

static Func<int[], int[], bool> ChooseSortStrategy()
{
    do
    {
        Console.WriteLine("Сhoose the sorting method :\n- by the sum (1)\n- by the max element (2)\n- by the min element (3):");
        ConsoleKeyInfo selectedKey = Console.ReadKey();
        switch (selectedKey.KeyChar)
        {
            case '1':
                return MatrixSort.SortBySumStratagy;
            case '2':
                return MatrixSort.SortByMaxStratagy;
            case '3':
                return MatrixSort.SortByMinStratagy;
            default:
                Console.WriteLine(" - incorrect choise\n");
                break;
        }
    }
    while (true);
}

static bool AscendingDirection()
{
    do
    {
        Console.WriteLine("\nСhoose the sorting direction :\n- ascending (+)\n- descending (-):");
        ConsoleKeyInfo selectedKey = Console.ReadKey();
        switch (selectedKey.KeyChar)
        {
            case '+':
                Console.WriteLine();
                return true;
            case '-':
                Console.WriteLine();
                return false;
            default:
                Console.WriteLine(" - incorrect choise\n");
                break;
        }
    }
    while (true);
}

static void Matrixprint(int[,] matrix)
{
    Console.WriteLine("Now matrix is:");
    int rowlength = matrix.GetLength(1);
    int index = 0;
    foreach (var item in matrix)
    {
        if (index != 0 && index % rowlength == 0)
        {
            Console.WriteLine();
        }

        Console.Write(item + ", ");
        index++;
    }

    Console.WriteLine("\n");
}