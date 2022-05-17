using System;
using System.Diagnostics;

namespace FileWiThreads
{
    class Program
    {
        
        /// <summary>
        /// Сбор входных параметров.
        /// </summary>
        /// <returns> Абсолютный путь к файлу и число потоков, которые будут обрабатывать файл. </returns>
        static (string, int) Input()
        {
            Console.WriteLine("Введите абсолютный путь к файлу, в котором нужно вывести триплеты:");
            string path = Console.ReadLine();
            int num;
            do
            {
                Console.WriteLine("Введите число потоков, которые будут построчно обрабатывать файл (от 4 до 8)");
            } while (!int.TryParse(Console.ReadLine(), out num) || num < 4 || num > 8);
            return (path, num);
        }

        /// <summary>
        /// Создание элемента класса TripletsFinder.
        /// </summary>
        static void Start()
        {
            string path;
            int num;
            (path, num) = Input();
            try
            {
                var finder = new TripletsFinder(path, num); 
                finder.GetTriplets();
                Console.WriteLine(finder);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Запуск программы, Подчсет времени выполнения программы, реализация повтора решения.
        /// </summary>
        static void Main()
        {
            ConsoleKeyInfo keyToExit;
            do
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                Start();
                stopwatch.Stop();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Время работы программы: {stopwatch.ElapsedMilliseconds}ms.");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Для выхода из программы нажмите Escape.");
                Console.WriteLine("Для повтора работы программы нажмите Enter.");
                Console.WriteLine();
                keyToExit = Console.ReadKey();
                Console.Clear();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}
