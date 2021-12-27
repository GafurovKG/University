// See https://aka.ms/new-console-template for more information
using M04_TheGame;

var narnia = new World(100, 100);

// var apple = new Bonus(narnia, "Яюблоко", 100);

// var banana = new Bonus(narnia, "Банан", 130);

// var obstacles1 = new Obstacles(narnia, "Tree");

// var obstacles2 = new Obstacles(narnia, "Stone");
var wolf1 = new Wolf(narnia, "Снежок");

var wolf2 = new Wolf(narnia, "Ворчун");

var bear1 = new Bear(narnia, "Топтыга");

var player = new Player(narnia, "Капитан Америка");

player.SearchTarget();

wolf1.SearchTarget();

wolf2.SearchTarget();

bear1.SearchTarget();

foreach (var item in narnia.WorldUnits)
{
    if (item is IMove)
    {
        Console.WriteLine($"Я {item.GetType().Name} {item.Name}, нахожусь в точке {item.XCoordinate}, {item.YCoordinate}," +
            $" моя цель в точке {((IMove)item).XCoordsOfTarget}, {((IMove)item).YCoordsOfTarget}");
    }
    else if (item is Bonus || item is Obstacles)
    {
        Console.WriteLine($"Я {item.GetType().Name} {item.Name}, нахожусь в точке {item.XCoordinate}, {item.YCoordinate}");
    }
}

Console.WriteLine(player.Score);