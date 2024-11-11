using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> inventory = new Dictionary<string, int>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nМЕНЮ:");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Просмотреть все товары");
            Console.WriteLine("3. Удалить товар");
            Console.WriteLine("4. Найти товар");
            Console.WriteLine("5. Выйти");
            Console.Write("Введите номер действия: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ViewAllProducts();
                    break;
                case "3":
                    RemoveProduct();
                    break;
                case "4":
                    FindProduct();
                    break;
                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Введите название товара: ");
        string name = Console.ReadLine();

        Console.Write("Введите количество: ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            if (inventory.ContainsKey(name))
            {
                inventory[name] += quantity;
                Console.WriteLine($"Количество товара \"{name}\" обновлено. Теперь в наличии: {inventory[name]} шт.");
            }
            else
            {
                inventory[name] = quantity;
                Console.WriteLine($"Товар \"{name}\" добавлен с количеством: {quantity} шт.");
            }
        }
        else
        {
            Console.WriteLine("Некорректное количество. Попробуйте снова.");
        }
    }

    static void ViewAllProducts()
    {
        Console.WriteLine("\nСписок товаров на складе:");
        if (inventory.Count > 0)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("На складе нет товаров.");
        }
    }

    static void RemoveProduct()
    {
        Console.Write("Введите название товара для удаления: ");
        string name = Console.ReadLine();

        if (inventory.ContainsKey(name))
        {
            inventory.Remove(name);
            Console.WriteLine($"Товар \"{name}\" удален из списка.");
        }
        else
        {
            Console.WriteLine("Товар не найден.");
        }
    }

    static void FindProduct()
    {
        Console.Write("Введите название товара для поиска: ");
        string name = Console.ReadLine();

        if (inventory.TryGetValue(name, out int quantity))
        {
            Console.WriteLine($"Товар \"{name}\" в наличии: {quantity} шт.");
        }
        else
        {
            Console.WriteLine("Товар не найден.");
        }
    }
}
