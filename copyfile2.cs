using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string file1 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование1\копирование1.txt"; 
        string papka2 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование2"; 
        string file2 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование2\копирование2.txt"; 
        string papka1 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование1"; 

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        Task a = CopyFileAsync(file1, papka2);
        Task b = CopyFileAsync(file2, papka1);

        await Task.WhenAll(a, b);

        stopwatch.Stop();

        Console.WriteLine($"время копирования {stopwatch.Elapsed.TotalMilliseconds}");
    }

    static async Task CopyFileAsync(string papkapapki1, string papkapapki2)
    {
        try
        {
            using (FileStream sourceStream = new FileStream(papkapapki1, FileMode.Open))
            using (FileStream destinationStream = new FileStream(papkapapki2, FileMode.Create))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
            Console.WriteLine($" файл копирован {papkapapki2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" ошибка {papkapapki1} {ex.Message}");
        }
    }
}