using System;

public class Fraction
{
    // Свойства для числителя и знаменателя
    public int Numerator { get; set; } // Числитель
    public int Denominator { get; set; } // Знаменатель

    // Конструктор
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть нулем.");
        }
        if (numerator <= 0 || denominator <= 0)
        {
            throw new ArgumentException("Числитель и знаменатель должны быть натуральными числами.");
        }

        Numerator = numerator;
        Denominator = denominator;
    }

    // Метод для вывода дроби на экран
    public void Print()
    {
        Console.WriteLine($"{Numerator}/{Denominator}");
    }

    // Сложение дробей
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
        int denominator = f1.Denominator * f2.Denominator;
        return new Fraction(numerator, denominator);
    }

    // Вычитание дробей
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
        int denominator = f1.Denominator * f2.Denominator;
        return new Fraction(numerator, denominator);
    }

    // Умножение дробей
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int numerator = f1.Numerator * f2.Numerator;
        int denominator = f1.Denominator * f2.Denominator;
        return new Fraction(numerator, denominator);
    }

    // Деление дробей
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.Numerator == 0)
        {
            throw new DivideByZeroException("Нельзя делить на дробь с числителем 0.");
        }
        int numerator = f1.Numerator * f2.Denominator;
        int denominator = f1.Denominator * f2.Numerator;
        return new Fraction(numerator, denominator);
    }

    // Преобразование в тип float
    public static explicit operator float(Fraction f)
    {
        return (float)f.Numerator / f.Denominator;
    }

    // Преобразование в тип double
    public static explicit operator double(Fraction f)
    {
        return (double)f.Numerator / f.Denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем две дроби
        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(1, 4);

        // Пример операций
        Fraction sum = f1 + f2;
        Fraction difference = f1 - f2;
        Fraction product = f1 * f2;
        Fraction quotient = f1 / f2;

        // Вывод результатов
        Console.WriteLine($"Сумма: {f1.Numerator}/{f1.Denominator} + {f2.Numerator}/{f2.Denominator} = {sum.Numerator}/{sum.Denominator}");
        Console.WriteLine($"Разность: {f1.Numerator}/{f1.Denominator} - {f2.Numerator}/{f2.Denominator} = {difference.Numerator}/{difference.Denominator}");
        Console.WriteLine($"Умножение: {f1.Numerator}/{f1.Denominator} * {f2.Numerator}/{f2.Denominator} = {product.Numerator}/{product.Denominator}");
        Console.WriteLine($"Деление: {f1.Numerator}/{f1.Denominator} / {f2.Numerator}/{f2.Denominator} = {quotient.Numerator}/{quotient.Denominator}");

        // Преобразование в float и double
        Console.WriteLine($"Дробь {f1.Numerator}/{f1.Denominator} в формате float: {(float)f1}");
        Console.WriteLine($"Дробь {f1.Numerator}/{f1.Denominator} в формате double: {(double)f1}");
    }
}
