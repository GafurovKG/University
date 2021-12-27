namespace M04_TheGame
{
    public abstract class Monster : Units, IMove
    {
        public int Speed { get; set; }

        private readonly int attaсkRange;

        public Monster(World crrentWorld, string name, int typeOfMonsterSpeed, int typeOfMonsterAtackRAnge) : base(crrentWorld, name)
        {
            Speed = typeOfMonsterSpeed;
            attaсkRange = typeOfMonsterAtackRAnge;
        }

        public int XCoordsOfTarget { get; set; }

        public int YCoordsOfTarget { get; set; }

        public void SearchTarget()
        {
            int xdistant = MyWorld.Height;
            int ydistant = MyWorld.Width;

            // Если дистанция до item ближе чем до сравниваемой точки, то записываем в target координаты item. Через сумму квадратов катетов
            foreach (var item in MyWorld.WorldUnits)
            {
                if (item is Player && (Math.Pow(item.XCoordinate - this.XCoordinate, 2) + Math.Pow(item.YCoordinate - this.YCoordinate, 2)
                    < Math.Pow(xdistant - this.XCoordinate, 2) + Math.Pow(ydistant - this.YCoordinate, 2)))
                {
                    XCoordsOfTarget = item.XCoordinate;
                    YCoordsOfTarget = item.YCoordinate;
                    xdistant = Math.Abs(item.XCoordinate - this.XCoordinate);
                    ydistant = Math.Abs(item.YCoordinate - this.YCoordinate);
                }
            }
        }

        void IMove.DoStepToTarget()
        {
            // алгоритм движения к цели, запрашивая у World, можно ли переместиться в эту точку
            Console.WriteLine("Двигаюсь к игроку, могу укусить игрока на расстоянии" + attaсkRange);
        }
    }
}