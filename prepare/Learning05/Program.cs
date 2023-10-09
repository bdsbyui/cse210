using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new()
        {
            new Square("red", 2),
            new Rectangle("yellow", 3, 4),
            new Circle("blue", 5)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine
                (
                    $"The {shape.GetColor()} {shape.GetType().Name.ToLower()} has an area of {shape.GetArea()} square units."
                );
        }
    }
}