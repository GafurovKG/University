using M04_TheGame;

var narnia = new World(20, 20);

var apple = new Bonus(narnia, "Яюблоко", 100);

var banana = new Bonus(narnia, "Банан", 130);

var obstacles1 = new Obstacles(narnia, "Tree");

var obstacles2 = new Obstacles(narnia, "Stone");

var wolf1 = new Wolf(narnia, "Снежок");

var bear1 = new Bear(narnia, "Топтыга");

var player = new Player(narnia, "Капитан Америка");

// вывод имен чтобы компилятор не ругался на бесполезную инициализации Юниов
Console.WriteLine(apple.Name);

Console.WriteLine(banana.Name);

Console.WriteLine(bear1.Name);

Console.WriteLine(wolf1.Name);

Console.WriteLine(obstacles1.Name);

Console.WriteLine(obstacles2.Name);

Console.WriteLine(player.Name);

Console.WriteLine("\n\n Начало игры. Чтобы сделать ход нажжмите Enter\n");

while (narnia.DoStep())
{
    narnia.ShowInfo();
    narnia.PrintWorld();
    Console.ReadLine();
}