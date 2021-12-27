namespace M04_TheGame
{
    public class Player : Units, IMove
    {
        protected string PlayerName { get; init; }

        private int _score;

        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score += value;
                SearchTarget();
            }
        }

        public int Speed { get; set; } // Этот реализуемый член должен быть открытым! Почему???

        public int XCoordsOfTarget { get; set; }

        public int YCoordsOfTarget { get; set; }

        public Player(World currentWorld, string name) : base(currentWorld, name)
        {
            PlayerName = name;
            Score = 0;
            Speed = 3;
        }

        // Алгоритм автоматического передвижения игрока - идет к ближйшему бонусу, если упирается в границу или припятствие пробует другое направление
        public void DoStepToTarget()
        {
            Console.WriteLine("Двигаюсь к бонусу");
            if (XCoordinate - XCoordsOfTarget < YCoordinate - YCoordsOfTarget)
            {
                if (XCoordinate - XCoordsOfTarget < 0)
                {
                    // пробуем шаг вправо
                    if (MyWorld.CheckNewPosition(XCoordinate + 1, YCoordinate))
                    {
                        XCoordinate += 1;
                    }
                }
                else if (XCoordinate - XCoordsOfTarget < 0)
                {
                    // делаем шаг влево
                }
            }
            else
            {
                if (YCoordinate - YCoordsOfTarget < 0)
                {
                    // делаем шаг вниз
                }
                else if (XCoordinate - XCoordsOfTarget > 0)
                {
                    // делаем шаг вверх
                }
            }
        }

        // Ищем ближайший бонус. Метод используется в начале игры и после каждого бонуса.
        // Возможно, реализацию метода лучше перенести в World: Unit запрашивает у World подходящую цель
        public void SearchTarget()
        {
            int xdistant = MyWorld.Height;
            int ydistant = MyWorld.Width;

            // Если дистанция до item ближе чем до сравниваемой точки, то записываем в target координаты item. Через сумму квадратов катетов
            foreach (var item in MyWorld.WorldUnits)
            {
                if (item is Bonus && (Math.Pow(item.XCoordinate - this.XCoordinate, 2) + Math.Pow(item.YCoordinate - this.YCoordinate, 2)
                    < Math.Pow(xdistant - this.XCoordinate, 2) + Math.Pow(ydistant - this.YCoordinate, 2)))
                {
                    XCoordsOfTarget = item.XCoordinate;
                    YCoordsOfTarget = item.YCoordinate;
                }
            }
        }
    }
}