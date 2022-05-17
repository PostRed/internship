using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileWiThreads
{
    class TripletsFinder
    {
        // Абсолютный путь к файлу.
        string path;

        // Потокобезопасный словарь триплетов.
        ConcurrentDictionary<string, int> triplets = new ConcurrentDictionary<string, int>();

        // Количество потоков, которые будут обрабатывать файл.
        int countThreads;

        // Список строк.
        List<string> text = new List<string>();

        // Свойство для поля path.
        public string Path
        {
            get { return path; }
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException("Файл не существует!");
                }
                path = value;
            }
        }

        // Свойство для поля countThreads.
        public int CountThreads
        {
            get { return countThreads; }
            set { countThreads = value; }
        }


        /// <summary>
        /// Конструктор, связанный со свойствами.
        /// </summary>
        /// <param name="p"> Абсолютный путь к файлу. </param>
        /// <param name="count"> Количество потоков, которые будут обрабатывать файл. </param>
        public TripletsFinder(string p, int count)
        {
            Path = p;
            CountThreads = count;
        }

        /// <summary>
        /// Заполение словаря триплетами из списка строк.
        /// </summary>
        /// <param name="o"> список строк. </param>
        void GetTripletsFromList(object o)
        {
            var arr = (List<string>)o;
            foreach (string line in arr)
            {
                GetTripletFromLine(line);
            }
        }


        /// <summary>
        /// Заполнение словаря триплетами из данной строки.
        /// </summary>
        /// <param name="l"> Строка, из которой считываются триплеты. </param>
        void GetTripletFromLine(string line)
        {
            string triplet = "";
            char a, b, c;
            for (int i = 0; i < line.Length - 2; i++)
            {
                if (Char.IsLetter(line[i]) && Char.IsLetter(line[i + 1]) && Char.IsLetter(line[i + 2]))
                {
                    a = Char.ToLower(line[i]);
                    b = Char.ToLower(line[i + 1]);
                    c = Char.ToLower(line[i + 2]);
                    triplet += a;
                    triplet += b;
                    triplet += c;
                    if (triplets.ContainsKey(triplet))
                    {
                        triplets[triplet]++;
                    }
                    else
                    {
                        triplets[triplet] = 1;
                    }
                }
                triplet = "";
            }
        }


        /// <summary>
        /// Чтение файла.
        /// </summary>
        public void GetTriplets()
        {
            string line;
            try
            {
                using (var sr = new StreamReader(Path))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        text.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невозможно прочесть файл!");
                Console.ResetColor();
            }
            RunProcess();
        }


        /// <summary>
        /// Запуск потоков.
        /// </summary>
        public void RunProcess()
        {
            int countLines = text.Count / countThreads;
            int start = 0;
            Thread[] threads = new Thread[countThreads];
            for (int i = 0; i < countThreads; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(GetTripletsFromList));
                if (i == countThreads - 1)
                {
                    threads[i].Start(text.GetRange(start, text.Count - start));
                }
                else
                {
                    threads[i].Start(text.GetRange(start, countLines));
                }
                start += countLines;
            }
            for (int i = 0; i < countThreads; i++)
            {
                if (threads[i] != null)
                {
                    threads[i].Join();
                }
            }
        }


        /// <summary>
        /// переопределение вывода TripletsFinder.
        /// </summary>
        /// <returns> 10 самых встречающихся триплетов. </returns>
        public override string ToString()
        {
            string res = "";
            int numOfTop = 1;
            foreach (var pair in triplets.OrderBy(pair => -pair.Value))
            {
                if (numOfTop < 11)
                {
                    res += $"{numOfTop}:\t{pair.Key}\t{pair.Value}\n";
                    numOfTop++;
                }
                else
                {
                    break;
                }
            }
            return res;
        }
    }
}
