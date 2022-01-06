namespace M04_TheGame
{
    public abstract class Monster : Units, IMove
    {
        public int Speed { get; set; }

        private readonly int attaсkRange;

        public Units Target { get; set; }

        public Monster(World crrentWorld, string name, int typeOfMonsterSpeed, int typeOfMonsterAtackRAnge) : base(crrentWorld, name)
        {
            Speed = typeOfMonsterSpeed;
            attaсkRange = typeOfMonsterAtackRAnge;
            Target = this;

            // заглушка для attaсkRange
            Console.WriteLine($"Создан монстр {name} c дальностью атаки {attaсkRange}");
        }

        // the DoStepToTarget implementations of monsters are copied from the player, although they should differ
        public void DoStepToTarget(World currentWorld)
        {
            ScanWorld(currentWorld);
            Point newPosition = new(this.Coordinate.X, this.Coordinate.Y);

            // сhoose a direction
            int xDirection = Target.Coordinate.X - this.Coordinate.X;
            int yDirection = Target.Coordinate.Y - this.Coordinate.Y;

            // check gorizontal movement:
            if (Math.Abs(xDirection) > Math.Abs(yDirection))
            {
                if (xDirection > 0)
                {
                    // try best way - moving rigth
                    newPosition = new Point(this.Coordinate.X + 1, this.Coordinate.Y);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then second way is Down, else Up
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y + 1) : new Point(this.Coordinate.X, this.Coordinate.Y - 1);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then third way is Up, else Doun
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y - 1) : new Point(this.Coordinate.X, this.Coordinate.Y + 1);
                    }
                }
                else
                {
                    // try best way - moving left
                    newPosition = new Point(this.Coordinate.X - 1, this.Coordinate.Y);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then second way is Down, else Up
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y + 1) : new Point(this.Coordinate.X, this.Coordinate.Y - 1);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then third way is Up, else Doun
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y - 1) : new Point(this.Coordinate.X, this.Coordinate.Y + 1);
                    }
                }
            }

            // vertical movement:
            else if (Math.Abs(xDirection) < Math.Abs(yDirection))
            {
                if (yDirection > 0)
                {
                    // try best way - moving doun
                    newPosition = new Point(this.Coordinate.X, this.Coordinate.Y + 1);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Right, else Left
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X + 1, this.Coordinate.Y) : new Point(this.Coordinate.X - 1, this.Coordinate.Y);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Left, else Rigth
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X - 1, this.Coordinate.Y) : new Point(this.Coordinate.X + 1, this.Coordinate.Y);
                    }
                }
                else
                {
                    // try best way - moving up
                    newPosition = new Point(this.Coordinate.X, this.Coordinate.Y - 1);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Right, else Left
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X + 1, this.Coordinate.Y) : new Point(this.Coordinate.X - 1, this.Coordinate.Y);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Left, else Rigth
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X - 1, this.Coordinate.Y) : new Point(this.Coordinate.X + 1, this.Coordinate.Y);
                    }
                }
            }

            if (currentWorld.CheckNewPosition(newPosition))
            {
                this.Coordinate = newPosition;
            }
        }

        public void ScanWorld(World currentWorld)
        {
            int xdistant = currentWorld.Height;
            int ydistant = currentWorld.Width;

            // Если дистанция до item ближе чем до сравниваемой точки, то записываем в target координаты item. Дистанция (биссектриса) рассчитыается через сумму квадратов катетов
            foreach (var item in currentWorld.WorldUnits)
            {
                if (item is Player && (Math.Pow(item.Coordinate.X - this.Coordinate.Y, 2) + Math.Pow(item.Coordinate.Y - this.Coordinate.Y, 2)
                    < Math.Pow(xdistant - this.Coordinate.X, 2) + Math.Pow(ydistant - this.Coordinate.Y, 2)))
                {
                    Target = item;
                }
            }
        }
    }
}