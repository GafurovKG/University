using MyGenetics;

var NewStack = new StackCollection<int>();

NewStack.Enqueue(1);

NewStack.Enqueue(2);

NewStack.Enqueue(3);

NewStack.Enqueue(4);

Console.WriteLine("Все элементы в очереди");

foreach (var item in NewStack)
{
    Console.WriteLine(item);
}

Console.WriteLine("Удаляем последний");

NewStack.Dequeue();

foreach (var item in NewStack)
{
    Console.WriteLine(item);
}

Console.WriteLine("Удаляем последний");

NewStack.Dequeue();

foreach (var item in NewStack)
{
    Console.WriteLine(item);
}