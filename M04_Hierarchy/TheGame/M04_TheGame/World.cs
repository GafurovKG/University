namespace M04_TheGame
{
    public class World
    {
        public int Height { get; init; }

        public int Width { get; init; }

        public World(int WeightArea, int HeightArea)
        {
            Height = HeightArea;
            Width = WeightArea;
            WorldUnits = new();
        }

        public List<Units> WorldUnits { get; set; }

        public void NewUnit(Units newUnit)
        {
            WorldUnits.Add(newUnit);
        }

        public void DelUnit(Units delUnit)
        {
            WorldUnits.Remove(delUnit);
        }

        // внешний запос в World, свободна ли точка?
        public bool CheckNewPosition(Point newPosition)
        {
            foreach (var item in WorldUnits)
            {
                // Если новая точка претятствие или за пределами мира - false
                if ((item is Obstacles && item.Coordinate.Equals(newPosition)) || newPosition.X > Width || newPosition.X <= 0 || newPosition.Y > Height || newPosition.Y <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        public Point GiveRandomPoint()
        {
            var rnd = new Random();
            Point isFreePiont;
            do
            {
                isFreePiont = new Point(rnd.Next(0, Height), rnd.Next(0, Width));
            }
            while (!CheckNewPosition(isFreePiont));
            return isFreePiont;
        }

        public void ShowInfo()
        {
            foreach (var item in WorldUnits)
            {
                if (item is Bonus)
                {
                    Console.WriteLine($"{item.Name} в точке {item.Coordinate.X},{item.Coordinate.Y}");
                }
            }

            Console.WriteLine();

            foreach (var item in WorldUnits)
            {
                if (item is IMove moveble)
                {
                    Console.WriteLine($"{item.Name} в точке {item.Coordinate.X},{item.Coordinate.Y}, цель в {moveble.Target.Coordinate.X},{moveble.Target.Coordinate.Y}");
                }
            }

            Console.WriteLine();
        }

        public void PrintWorld()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    foreach (var item in WorldUnits)
                    {
                        if (item.Coordinate.X == j && item.Coordinate.Y == i)
                        {
                            switch (item)
                            {
                                case Bonus:
                                    Console.Write("B");
                                    break;

                                case Monster:
                                    Console.Write("M");
                                    break;

                                case Player:
                                    Console.Write("P");
                                    break;

                                case Obstacles:
                                    Console.Write("O");
                                    break;

                                default:
                                    Console.Write("?");
                                    break;
                            }
                        }
                    }

                    Console.Write(" .");
                }

                Console.WriteLine();
            }
        }

        public bool DoStep()
        {
            foreach (var item in WorldUnits)
            {
                if (item is IMove movable)
                {
                    movable.DoStepToTarget(this);
                    foreach (var checkingUnit in WorldUnits)
                    {
                        if (item.Coordinate.Equals(checkingUnit.Coordinate))
                        {
                            switch (checkingUnit)
                            {
                                case Bonus bounty when item is Player player:
                                    player.Score += bounty.BonusWeight;
                                    Console.WriteLine($"Игрок {player.Name} слопал {bounty.Name} ({bounty.BonusWeight}). Итого {player.Score} очков");
                                    this.DelUnit(checkingUnit);
                                    return true;

                                case Player player when item is Monster monster:
                                    Console.WriteLine($"Монстр {monster.Name} слопал {player.Name}. GAME OVER");
                                    return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}