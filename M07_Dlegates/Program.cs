using M07_Delegates;

Console.WriteLine("Задача 1");

int[,] matrix =
{
            { 1, 2, 3, 4 },
            { -1, -2, -3, -4 },
            { 1, -2, 3, -4 },
            { -1, 2, 3, 4 },
            { 0, 1, -1, 0 }
};

Matrixprint(matrix);

matrix = matrix.SortMatrix(ChooseSortStrategy(), AscendingDirection());

Console.WriteLine();

Matrixprint(matrix);

// Lambda test
Console.WriteLine("\nLambda test: ((int[] rowA, int[] rowB) => rowA[3] > rowB[0])");

matrix = matrix.SortMatrix((int[] rowA, int[] rowB) => rowA[3] > rowB[0], AscendingDirection());

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

// Task2 CountDown
Console.WriteLine("Задача 2. События\nПодписки до первого события:");

var pub = new CountDown();

// Подписка до события в конструкторе...
var beforeEventSubInConstructor = new Subscriber1("beforeEventSubInConstructor", pub);

// через специальный метод в CountDown
var beforeEventSubInMethod = new Subscriber1("beforeEventSubInMethod");

pub.SubscribeOnMe(beforeEventSubInMethod.ActionOnAvent, "beforeEventSubInMethod");

// напрямую чере +=
var beforeEventSubDirectly = new Subscriber1("beforeEventSubDirectly");

Console.WriteLine("Сообщение из Маин: еще есть подписчик beforeEventSubDirectly, подписанный напрямую через +=");

pub.EventHappened += beforeEventSubDirectly.ActionOnAvent;

Thread.Sleep(1500);

pub.SomeFunc();

Console.WriteLine("\nОпоздавшие подписчики после первого события сразу получают сообщения о прошедших событиях:\n");

// Подписка после события
// в конструкторе...
var afterEvntsubInConstructor = new Subscriber1("afterEvntsubInConstructor", pub);

// через специальный метод в CountDown
var afterEvntsubInMethod = new Subscriber1("afterEvntsubInMethod");

pub.SubscribeOnMe(afterEvntsubInMethod.ActionOnAvent, "afterEvntsubInMethod");

Thread.Sleep(1500);

Console.WriteLine("Событие произошло второй раз...");

pub.SomeFunc();