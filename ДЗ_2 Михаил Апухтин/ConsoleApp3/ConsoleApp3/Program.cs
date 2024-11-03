using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Запрашиваем у пользователя количество расходов
            Console.Write("Введите количество расходов: ");
            int numExpenses = int.Parse(Console.ReadLine());

            // Создаем список для хранения расходов
            List<decimal> expenses = new List<decimal>();

            // Запрашиваем у пользователя каждую статью расходов
            for (int i = 0; i < numExpenses; i++)
            {
                Console.Write($"Введите сумму расхода #{i + 1}: ");
                decimal expense = decimal.Parse(Console.ReadLine());
                expenses.Add(expense);
            }

            // Выводим все введенные расходы
            Console.WriteLine("\nВаши расходы:");
            for (int i = 0; i < expenses.Count; i++)
            {
                Console.WriteLine($"Расход #{i + 1}: {expenses[i]:F2}");
            }

            // Суммируем и выводим общую сумму расходов
            decimal totalExpense = 0;
            foreach (var expense in expenses)
            {
                totalExpense += expense;
            }
            Console.WriteLine($"\nОбщая сумма расходов: {totalExpense:F2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Пожалуйста, введите корректные числовые значения.");
        }
    }
}
