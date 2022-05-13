using System;
using System.Collections.Generic;
using ActionsWithFigures;

namespace FiguresMain
{
    class Program
    {
        // список фигур
        public List<Figures> array = new List<Figures>();

        /// <summary>
        /// Основные правила
        /// </summary>
        void Hello()
        {
            Console.WriteLine(@"Hello! You are using a library for working with geometric shapes.
The following functions will be available to you: 
help - show this message again.
add tr <side1> <side2> <side3> - add a triangle with given sides.
add cir <radius> - add a circle with given radius.
add other <type> <square> - add an other figure, you need specify a type and square of it.
show - display all added figures.
stop - stop this program. ");
        }

        /// <summary>
        /// Работа с командами
        /// </summary>
        void Process()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "stop")
            {
                if (input[0] == "add")
                {
                    int oldCount = array.Count;
                    if (input[1] == "tr")
                    {
                        AddTriangle(input);
                    }
                    else if (input[1] == "cir")
                    {
                        AddCircle(input);
                    }
                    else if (input[1] == "other")
                    {
                        AddOther(input);
                    }
                    if (array.Count == oldCount + 1)
                    {
                        Console.WriteLine("Figure added successfully");
                    }
                }
                else if (input[0] == "help") Hello();
                else if (input[0] == "show") Show();
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

        }

        /// <summary>
        /// Добавление треугольника в список фигур
        /// </summary>
        /// <param name="input"> входные параметры </param>
        void AddTriangle(string[] input)
        {
            if (input.Length != 5)
            {
                Console.WriteLine("Incorrect input!");
            }
            else
            {
                double a, b, c;
                if (!double.TryParse(input[2], out a) || !double.TryParse(input[3], out b) || !double.TryParse(input[4], out c))
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                {
                    try
                    {
                        Triangle tr = new Triangle(a, b, c);
                        array.Add(tr);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Добавление круга в список фигур
        /// </summary>
        /// <param name="input"> входные параметры </param>
        void AddCircle(string[] input)
        {
            if (input.Length != 3)
            {
                Console.WriteLine("Incorrect input!");
            }
            else
            {
                double r;
                if (!double.TryParse(input[2], out r))
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                {
                    try
                    {
                        Circle cir = new Circle(r);
                        array.Add(cir);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Добавление другой фигуры в список фигур
        /// </summary>
        /// <param name="input"> входные параметры </param>
        void AddOther(string[] input)
        {

            if (input.Length != 4)
            {
                Console.WriteLine("Incorrect input!");
            }
            else
            {
                double sq;
                if (!double.TryParse(input[3], out sq))
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                {
                    try
                    {
                        OtherFigure other = new OtherFigure(input[2], sq);
                        array.Add(other);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Вывод всех фигур
        /// </summary>
        void Show()
        {
            if (array.Count == 0)
            {
                Console.WriteLine("There are no figures in the vault yet");
            }
            else
            {
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                program.Hello();
                program.Process();
            }
            catch (Exception)
            {
                Console.WriteLine("Something was wrong, please try again");
            }
        }
    }
}
