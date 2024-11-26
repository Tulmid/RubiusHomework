using System;

public interface IPrintableShape
{
    void PrintType();
    void PrintSquare();
    void PrintPerimeter();
}

public abstract class Shape : IPrintableShape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();

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
    private double _radius;

    public double Radius
    {
        get { return _radius; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Radius must be greater than zero.");
            _radius = value;
        }
    }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be greater than zero.");
        _radius = radius;
    }

    public bool TrySetRadius(double radius)
    {
        if (radius > 0)
        {
            _radius = radius;
            return true;
        }
        return false;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public double Length
    {
        get { return _length; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Length must be greater than zero.");
            _length = value;
        }
    }

    public double Width
    {
        get { return _width; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Width must be greater than zero.");
            _width = value;
        }
    }

    public Rectangle(double length, double width)
    {
        if (length <= 0 || width <= 0)
            throw new ArgumentException("Length and width must be greater than zero.");
        _length = length;
        _width = width;
    }

    public bool TrySetLength(double length)
    {
        if (length > 0)
        {
            _length = length;
            return true;
        }
        return false;
    }

    public bool TrySetWidth(double width)
    {
        if (width > 0)
        {
            _width = width;
            return true;
        }
        return false;
    }

    public override double CalculateArea()
    {
        return _length * _width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (_length + _width);
    }
}

public class Triangle : Shape
{
    private double _sideA;
    private double _sideB;
    private double _sideC;

    public double SideA
    {
        get { return _sideA; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Side A must be greater than zero.");
            if (value >= _sideB + _sideC)
                throw new ArgumentException("Side A must be less than the sum of the other two sides.");
            _sideA = value;
        }
    }

    public double SideB
    {
        get { return _sideB; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Side B must be greater than zero.");
            if (value >= _sideA + _sideC)
                throw new ArgumentException("Side B must be less than the sum of the other two sides.");
            _sideB = value;
        }
    }

    public double SideC
    {
        get { return _sideC; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Side C must be greater than zero.");
            if (value >= _sideA + _sideB)
                throw new ArgumentException("Side C must be less than the sum of the other two sides.");
            _sideC = value;
        }
    }

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Sides must be greater than zero.");
        if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB)
            throw new ArgumentException("The sum of any two sides must be greater than the third side.");
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public bool TrySetSideA(double sideA)
    {
        if (sideA > 0 && sideA < _sideB + _sideC)
        {
            _sideA = sideA;
            return true;
        }
        return false;
    }

    public bool TrySetSideB(double sideB)
    {
        if (sideB > 0 && sideB < _sideA + _sideC)
        {
            _sideB = sideB;
            return true;
        }
        return false;
    }

    public bool TrySetSideC(double sideC)
    {
        if (sideC > 0 && sideC < _sideA + _sideB)
        {
            _sideC = sideC;
            return true;
        }
        return false;
    }

    public override double CalculateArea()
    {
        double semiPerimeter = CalculatePerimeter() / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

    public override double CalculatePerimeter()
    {
        return _sideA + _sideB + _sideC;
    }
}

public class Trapezoid : Shape
{
    private double _base1;
    private double _base2;
    private double _height;
    private double _side1;
    private double _side2;

    public double Base1
    {
        get { return _base1; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Base1 must be greater than zero.");
            _base1 = value;
        }
    }

    public double Base2
    {
        get { return _base2; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Base2 must be greater than zero.");
            _base2 = value;
        }
    }

    public double Height
    {
        get { return _height; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Height must be greater than zero.");
            _height = value;
        }
    }

    public double Side1
    {
        get { return _side1; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Side1 must be greater than zero.");
            _side1 = value;
        }
    }

    public double Side2
    {
        get { return _side2; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Side2 must be greater than zero.");
            _side2 = value;
        }
    }

    public Trapezoid(double base1, double base2, double height, double side1, double side2)
    {
        if (base1 <= 0 || base2 <= 0 || height <= 0 || side1 <= 0 || side2 <= 0)
            throw new ArgumentException("All dimensions must be greater than zero.");
        _base1 = base1;
        _base2 = base2;
        _height = height;
        _side1 = side1;
        _side2 = side2;
    }

    public bool TrySetBase1(double base1)
    {
        if (base1 > 0)
        {
            _base1 = base1;
            return true;
        }
        return false;
    }

    public bool TrySetBase2(double base2)
    {
        if (base2 > 0)
        {
            _base2 = base2;
            return true;
        }
        return false;
    }

    public bool TrySetHeight(double height)
    {
        if (height > 0)
        {
            _height = height;
            return true;
        }
        return false;
    }

    public bool TrySetSide1(double side1)
    {
        if (side1 > 0)
        {
            _side1 = side1;
            return true;
        }
        return false;
    }

    public bool TrySetSide2(double side2)
    {
        if (side2 > 0)
        {
            _side2 = side2;
            return true;
        }
        return false;
    }

    public override double CalculateArea()
    {
        return (_base1 + _base2) * _height / 2;
    }

    public override double CalculatePerimeter()
    {
        return _base1 + _base2 + _side1 + _side2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования с валидными значениями
        try
        {
            Circle circle = new Circle(5);
            circle.PrintType();
            circle.PrintSquare();
            circle.PrintPerimeter();
            Console.WriteLine();

            Rectangle rectangle = new Rectangle(4, 6);
            rectangle.PrintType();
            rectangle.PrintSquare();
            rectangle.PrintPerimeter();
            Console.WriteLine();

            Triangle triangle = new Triangle(3, 4, 5);
            triangle.PrintType();
            triangle.PrintSquare();
            triangle.PrintPerimeter();
            Console.WriteLine();

            Trapezoid trapezoid = new Trapezoid(6, 8, 5, 4, 4);
            trapezoid.PrintType();
            trapezoid.PrintSquare();
            trapezoid.PrintPerimeter();
            Console.WriteLine();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // Пример использования с методом TrySet
        Circle circle2 = new Circle(0); // Неверный радиус
        if (!circle2.TrySetRadius(-5))
        {
            Console.WriteLine("Invalid radius for circle2");
        }
        if (circle2.TrySetRadius(7))
        {
            Console.WriteLine("Radius successfully updated to 7");
        }
    }
}
