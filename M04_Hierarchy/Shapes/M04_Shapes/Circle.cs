namespace M04_Shapes
{
    public class Circle : IShape
    {
        private double Radius { get; set; }

        public Point Coordinate { get; set; }

        public Circle(double radius, int xCentreCoordinate, int yCentreCoordinate) // можно ли сдалать конструктор кооринат в Shape?
        {
            Radius = Math.Abs(radius);
            Coordinate = new Point(xCentreCoordinate, yCentreCoordinate);
        }

        public double Area()
        {
            return Radius * Radius * Math.PI;
        }

        public double Perimetr()
        {
            return 2 * Radius * Math.PI;
        }
    }
}