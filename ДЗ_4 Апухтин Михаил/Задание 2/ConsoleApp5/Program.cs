using System;

class Program
{
    static void Main(string[] args)
    {
        // Список типов транспорта
        string[] transportTypes = { "Водный", "Воздушный", "Наземный" };

        // Подтипы для каждого типа транспорта
        string[,] subtypes =
        {
            { "Лодка", "Подводная лодка", "Корабль" }, // Водный транспорт
            { "Вертолет", "Самолет", "Дирижабль" }, // Воздушный транспорт
            { "Автомобиль", "Мотоцикл", "Танк" } // Наземный транспорт
        };

        // Выбор типа транспорта
        Console.WriteLine("Выберите тип транспорта:");
        for (int i = 0; i < transportTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {transportTypes[i]}");
        }

        Console.Write("Введите номер типа транспорта (1-3): ");
        int transportTypeChoice = int.Parse(Console.ReadLine()) - 1; // Выбор типа транспорта

        if (transportTypeChoice < 0 || transportTypeChoice >= transportTypes.Length)
        {
            Console.WriteLine("Некорректный выбор типа транспорта.");
            return;
        }

        Console.WriteLine($"\nВы выбрали: {transportTypes[transportTypeChoice]} транспорт.");

        // Выбор подтипа для выбранного типа транспорта
        Console.WriteLine("\nДоступные подтипы:");
        for (int i = 0; i < subtypes.GetLength(1); i++)
        {
            Console.WriteLine($"{i + 1}) {subtypes[transportTypeChoice, i]}");
        }

        Console.Write("Введите номер подтипа транспорта: ");
        int subtypeChoice = int.Parse(Console.ReadLine()) - 1; // Выбор подтипа транспорта

        if (subtypeChoice < 0 || subtypeChoice >= subtypes.GetLength(1))
        {
            Console.WriteLine("Некорректный выбор подтипа транспорта.");
            return;
        }

        // Вывод результата
        Console.WriteLine($"\nОтличный выбор! Вы передвигаетесь на: {subtypes[transportTypeChoice, subtypeChoice]}, тип транспорта: {transportTypes[transportTypeChoice]}.");
    }
}
