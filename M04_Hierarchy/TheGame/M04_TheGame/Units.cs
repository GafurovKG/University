namespace M04_TheGame
{
    public abstract class Units
    {
        public Point Coordinate { get; set; }

        public string Name { get; set; }

        // Добавляем Юнита, в свободную точку мира
        public Units(World givenWorld, string name)
        {
            Coordinate = givenWorld.GiveRandomPoint();
            Name = name;
            givenWorld.NewUnit(this);
        }
    }
}