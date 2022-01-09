namespace M04_Shapes
{
    public class Triangle : IShape
    {
        private double SizeA { get; set; }

        private double SizeB { get; set; }

        private double SizeC { get; set; }

        public Point Coordinate { get; set; }

        public Triangle(double sizeA, double sizeB, double sizeC, int xCoordinate, int yCoordinate)
        {
            Coordinate = new Point(xCoordinate, yCoordinate);
            SizeA = Math.Abs(sizeA);
            SizeB = Math.Abs(sizeB);
            SizeC = Math.Abs(sizeC);
        }

        public double Area()
        {
            double halfPerimetr = Perimetr() / 2;
            return halfPerimetr * (halfPerimetr - SizeA) * (halfPerimetr - SizeB) * (halfPerimetr - SizeC);
        }

        public double Perimetr()
        {
            return SizeA + SizeB + SizeC;
        }
    }
}