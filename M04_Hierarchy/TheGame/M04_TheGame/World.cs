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

        // внешний запос в World, свободна ли точка?
        public bool CheckNewPosition(int newX, int newY)
        {
            foreach (var item in WorldUnits)
            {
                // Если новая точка претядствие или за пределами мира - false
                if ((item is Obstacles && item.XCoordinate == newX && item.YCoordinate == newY) || newX > Width || newX <= 0 || newY > Height || newY <= 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}