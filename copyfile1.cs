using System;
using System.Diagnostics;
using System.IO;
//для измерения времени создаю объект класса Stopwatch. для него нужно импортировать
//пространство имен System.Diagnostics
//перед измерением времени создаю объект класса Stopwatch.Чтобы начать отсчет, вызываю метод Start(),
//а чтобы остановить Stop().
//чтобы сбросить таймер использую метод Reset().
class Program
{
    static void Main(string[] args)
    {
        string file1 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование1\копирование1.txt";
        string papka1 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование1.txt";
        string file2 = @"\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование2\копирование2.txt";
        string papka2 = @"C:\Users\alina\OneDrive\Рабочий стол\2 курс\системка\копирование2.txt";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        CopyFile(file1, papka1);
        stopwatch.Stop();
        Console.WriteLine($"время копирований file1 {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Reset();
        stopwatch.Start();
        CopyFile(file2, papka2);
        stopwatch.Stop();
        Console.WriteLine($"время копирования file2 {stopwatch.Elapsed.TotalMilliseconds}");
    }

    static void CopyFile(string papkapapki, string papkapapki2)
    {
        try
        {
            File.Copy(papkapapki, papkapapki2, true); // true для перезаписи
            Console.WriteLine($"файл {papkapapki} скопирован в {papkapapki2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибочка вышла {papkapapki2} {ex.Message}");
        }
    }
}
