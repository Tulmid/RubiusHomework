using System;

public interface IPrintableShape
{
    void PrintType();
    void PrintSquare();
    void PrintPerimeter();
}

public abstract class Shape : IPrintableShape
{
    // Абстрактные методы для расчёта площади и периметра
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();

    // Реализация методов интерфейса IPrintableShape
    public void PrintType()
    {
        Console.WriteLine("This is a " + this.GetType().Name);
    }

    public void PrintSquare()
    {
        Console.WriteLine("Area: " + CalculateArea());
    }

    public void PrintPerimeter()
    {
        Console.WriteLine("Perimeter: " + CalculatePerimeter());
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Length + Width);
    }
}

public class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double CalculateArea()
    {
        // Используем формулу Герона для площади треугольника
        double semiPerimeter = CalculatePerimeter() / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }
}

public class Trapezoid : Shape
{
    public double Base1 { get; set; }
    public double Base2 { get; set; }
    public double Height { get; set; }
    public double Side1 { get; set; }
    public double Side2 { get; set; }

    public Trapezoid(double base1, double base2, double height, double side1, double side2)
    {
        Base1 = base1;
        Base2 = base2;
        Height = height;
        Side1 = side1;
        Side2 = side2;
    }

    public override double CalculateArea()
    {
        return (Base1 + Base2) * Height / 2;
    }

    public override double CalculatePerimeter()
    {
        return Base1 + Base2 + Side1 + Side2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape circle = new Circle(5);
        circle.PrintType();
        circle.PrintSquare();
        circle.PrintPerimeter();

        Console.WriteLine();

        Shape rectangle = new Rectangle(4, 6);
        rectangle.PrintType();
        rectangle.PrintSquare();
        rectangle.PrintPerimeter();

        Console.WriteLine();

        Shape triangle = new Triangle(3, 4, 5);
        triangle.PrintType();
        triangle.PrintSquare();
        triangle.PrintPerimeter();

        Console.WriteLine();

        Shape trapezoid = new Trapezoid(6, 8, 5, 4, 4);
        trapezoid.PrintType();
        trapezoid.PrintSquare();
        trapezoid.PrintPerimeter();
    }
}
