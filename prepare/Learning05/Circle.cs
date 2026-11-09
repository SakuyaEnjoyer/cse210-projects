using System;


public class Circle : Shape
{
    private double _radius;


    public Circle (double radius, string color) : base (color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        double rad = _radius * _radius;
        double area = Math.PI * rad;
        return area;
    }
}