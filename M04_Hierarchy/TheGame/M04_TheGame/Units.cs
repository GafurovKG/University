namespace M04_TheGame
{
    public abstract class Units
    {
        public string Name { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        protected World MyWorld { get; set; }

        // Добавляем Юнита, в свободную точку мира
        public Units(World currentWorld, string name)
        {
            var rnd = new Random();
            do
            {
                XCoordinate = rnd.Next(0, currentWorld.Height);
                YCoordinate = rnd.Next(0, currentWorld.Width);
            }
            while (!currentWorld.CheckNewPosition(XCoordinate, YCoordinate));
            currentWorld.NewUnit(this);
            MyWorld = currentWorld;
            Name = name;
        }
    }
}