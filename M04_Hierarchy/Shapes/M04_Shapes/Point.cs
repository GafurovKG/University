namespace M04_Shapes
{
    public class Point
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        internal Point(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }
    }
}