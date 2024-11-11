using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите сумму дохода: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal income))
        {
            decimal tax = CalculateTax(income);
            Console.WriteLine($"Сумма налогов к уплате: {tax} рублей.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод дохода.");
        }
    }

    static decimal CalculateTax(decimal income)
    {
        decimal taxRate = 0.13m; // 13% ставка налога
        decimal taxAmount = income * taxRate;
        return Math.Round(taxAmount, 2);
    }
}