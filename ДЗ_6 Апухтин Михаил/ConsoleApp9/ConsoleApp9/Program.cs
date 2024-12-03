using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Класс для хранения записи
    class Record
    {
        public string Surname { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Record(string surname, DateTime registrationDate)
        {
            Surname = surname;
            RegistrationDate = registrationDate;
        }
    }

    static void Main()
    {
        List<Record> records = new List<Record>(); // Коллекция для хранения записей

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Показать все записи (отсортировано по дате)");
            Console.WriteLine("3. Получить записи по дате");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Добавление записи
                        AddRecord(records);
                        break;
                    case 2:
                        // Показать все записи, отсортированные по дате
                        ShowSortedRecords(records);
                        break;
                    case 3:
                        // Получить записи по дате
                        GetRecordsByDate(records);
                        break;
                    case 4:
                        // Выход из программы
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
            }
        }
    }

    static void AddRecord(List<Record> records)
    {
        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        Console.Write("Введите дату регистрации (гггг-мм-дд): ");
        DateTime registrationDate;
        while (!DateTime.TryParse(Console.ReadLine(), out registrationDate))
        {
            Console.Write("Неверный формат даты. Пожалуйста, введите дату в формате гггг-мм-дд: ");
        }

        // Добавляем запись в список
        records.Add(new Record(surname, registrationDate));
        Console.WriteLine("Запись успешно добавлена!");
    }

    static void ShowSortedRecords(List<Record> records)
    {
        var sortedRecords = records.OrderBy(r => r.RegistrationDate).ToList();

        if (sortedRecords.Count == 0)
        {
            Console.WriteLine("Нет записей для отображения.");
            return;
        }

        Console.WriteLine("Все записи (отсортированы по дате):");
        foreach (var record in sortedRecords)
        {
            Console.WriteLine($"{record.RegistrationDate:yyyy-MM-dd}: {record.Surname}");
        }
    }

    static void GetRecordsByDate(List<Record> records)
    {
        Console.Write("Введите дату для поиска записей (гггг-мм-дд): ");
        DateTime searchDate;
        while (!DateTime.TryParse(Console.ReadLine(), out searchDate))
        {
            Console.Write("Неверный формат даты. Пожалуйста, введите дату в формате гггг-мм-дд: ");
        }

        var recordsOnDate = records.Where(r => r.RegistrationDate.Date == searchDate.Date).ToList();

        if (recordsOnDate.Count == 0)
        {
            Console.WriteLine("Нет записей на эту дату.");
            return;
        }

        Console.WriteLine($"Записи на {searchDate:yyyy-MM-dd}:");
        foreach (var record in recordsOnDate)
        {
            Console.WriteLine($"{record.RegistrationDate:yyyy-MM-dd}: {record.Surname}");
        }
    }
}