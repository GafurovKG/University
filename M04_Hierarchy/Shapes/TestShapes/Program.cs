using M04_Shapes;

Circle circle = new(10, 5, 7);

Console.WriteLine(circle.Perimetr());

Console.WriteLine(circle.Area());

Console.WriteLine(circle.Coordinate.X + " " + circle.Coordinate.Y);

Triangle triangle = new(7, 8, 9, 1, 0);

Console.WriteLine(triangle.Perimetr());

Console.WriteLine(triangle.Area());

Console.WriteLine(triangle.Coordinate.X + " " + triangle.Coordinate.Y);