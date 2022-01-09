namespace M04_TheGame
{
    public class Player : Units, IMove
    {
        protected string PlayerName { get; init; }

        public int Score { get; set; }

        public int Speed { get; set; } // Этот реализуемый член должен быть открытым! Почему???

        public Units Target { get; set; }

        // private Point Threat { get; set; }
        public Player(World currentWorld, string name) : base(currentWorld, name)
        {
            PlayerName = name;
            Score = 0;
            Speed = 1;
            Target = this;
        }

        // Алгоритм автоматического передвижения игрока - идет к ближйшему бонусу, если упирается в границу или припятствие пробует другое направление
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
                    newPosition = new Point(this.Coordinate.X + Speed, this.Coordinate.Y);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then second way is Down, else Up
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y + Speed) : new Point(this.Coordinate.X, this.Coordinate.Y - Speed);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then third way is Up, else Doun
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y - Speed) : new Point(this.Coordinate.X, this.Coordinate.Y + Speed);
                    }
                }
                else
                {
                    // try best way - moving left
                    newPosition = new Point(this.Coordinate.X - Speed, this.Coordinate.Y);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then second way is Down, else Up
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y + Speed) : new Point(this.Coordinate.X, this.Coordinate.Y - Speed);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target lower us then third way is Up, else Doun
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X, this.Coordinate.Y - Speed) : new Point(this.Coordinate.X, this.Coordinate.Y + Speed);
                    }
                }
            }

            // vertical movement:
            else if (Math.Abs(xDirection) <= Math.Abs(yDirection))
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
                    newPosition = new Point(this.Coordinate.X, this.Coordinate.Y - Speed);

                    // if the best way is incorrect, choose second way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Right, else Left
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X + Speed, this.Coordinate.Y) : new Point(this.Coordinate.X - Speed, this.Coordinate.Y);
                    }

                    // if the second way is incorrect, choose third way
                    if (!currentWorld.CheckNewPosition(newPosition))
                    {
                        // if target is to the right of us us then second way is Left, else Rigth
                        newPosition = yDirection > 0 ? new Point(this.Coordinate.X - Speed, this.Coordinate.Y) : new Point(this.Coordinate.X + Speed, this.Coordinate.Y);
                    }
                }
            }

            if (currentWorld.CheckNewPosition(newPosition))
            {
                this.Coordinate = newPosition;
            }
        }

        // Ищем ближайший бонус. Метод используется в начале игры и после каждого бонуса.
        public void ScanWorld(World currentWorld)
        {
            int xdistant = currentWorld.Height;
            int ydistant = currentWorld.Width;

            // Если дистанция до item ближе чем до сравниваемой точки, то записываем в target координаты item. Дистанция (биссектриса) рассчитыается через сумму квадратов катетов
            foreach (var item in currentWorld.WorldUnits)
            {
                if (item is Bonus && (Math.Pow(item.Coordinate.X - this.Coordinate.X, 2) + Math.Pow(item.Coordinate.Y - this.Coordinate.Y, 2)
                    < Math.Pow(xdistant - this.Coordinate.X, 2) + Math.Pow(ydistant - this.Coordinate.Y, 2)))
                {
                    Target = item;
                }

                // else if (item is Monster && (Math.Pow(item.Coordinate.Y - this.Coordinate.Y, 2) + Math.Pow(item.Coordinate.Y - this.Coordinate.Y, 2)
                // < Math.Pow(xdistant - this.Coordinate.X, 2) + Math.Pow(ydistant - this.Coordinate.Y, 2)))
                // {
                // Threat = item.Coordinate;
                // }
            }
        }
    }
}