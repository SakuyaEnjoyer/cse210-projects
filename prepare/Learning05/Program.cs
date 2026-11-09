using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Shape> shapes = new List<Shape>();

        Square square = new Square(5, "red");
        shapes.Add(square);

        Rectangle rectangle = new Rectangle(5, 10, "blue");
        shapes.Add(rectangle);

        Circle circle = new Circle(15, "yellow");
        shapes.Add(circle);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}