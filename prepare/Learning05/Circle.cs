using System.Drawing;

public class Circle : Shape {

    double _radius;

    public Circle(string color, double radius) : base(color) {

        _radius = radius;

        _name = "circle";
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}