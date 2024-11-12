using System;

class Program
{
    static void Main(string[] args)
    {
        Shape square = new Square("Blue", 2);

        Shape rectangle = new Rectangle("Red", 2, 4);

        Shape circle = new Circle("Purple", 1);

        List<Shape> shapes = [square, rectangle, circle];

        foreach (Shape shape in shapes) {

            Console.WriteLine($"Area of {shape.GetName()}: {shape.GetArea()}");
            Console.WriteLine($"Color of {shape.GetName()}: {shape.GetColor()}");
        }

    }
}