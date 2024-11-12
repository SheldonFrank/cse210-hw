using System.Drawing;

public class Rectangle : Shape {

    double _length;

    double _width;

    public Rectangle(string color, double length, double width) : base(color) {

        _length = length;

        _width = width;

        _name = "rectangle";

    }

    public override double GetArea()
    {
        return _length * _width;
    }
}