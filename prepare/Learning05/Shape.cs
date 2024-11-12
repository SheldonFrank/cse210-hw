using System.Drawing;

public abstract class Shape {
    protected string _color;
    protected string _name;

    public string GetColor(){

        return _color;
    }

    public void SetColor(string color){

        _color = color;
    }

    public abstract double GetArea();


    public Shape(string color) {

        _color = color;
    }

    public string GetName(){

        return _name;
    }


}