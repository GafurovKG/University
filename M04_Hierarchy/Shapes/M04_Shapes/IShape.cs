namespace M04_Shapes
{
    internal interface IShape
    {
        internal Point Coordinate { get; set; }

        internal double Perimetr();

        internal double Area();
    }
}