using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\gipta\source\repos\ConsoleApp8\voyna-i-mir.txt"; // Путь к скачанному файлу

        // Способ 1: Чтение всего файла
        string text = File.ReadAllText(filePath);
        string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Количество слов (чтение всего файла): {words.Length}");

        // Способ 2: Потоковая обработка файла
        int wordCount = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Разбиваем каждую строку на слова
                string[] lineWords = line.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                wordCount += lineWords.Length;
            }
        }

        Console.WriteLine($"Количество слов (потоковая обработка): {wordCount}");
    }
}