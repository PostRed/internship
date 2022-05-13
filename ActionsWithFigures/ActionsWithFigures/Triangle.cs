using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithFigures
{
    public class Triangle : Figures
    {
        private double side1;
        private double side2;
        private double side3;
        public Triangle(double a, double b, double c)
        {
            CheckSides(a, b, c);
        }

        // Проверка на корректность сторон треугольника
        void CheckSides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new FiguresExeption("The side of a triangle can not have a negative length");
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new FiguresExeption("There is no triangle with such sides");
            }
            side1 = a;
            side2 = b;
            side3 = c;
            type = "Triangle";
        }
        
       // Проверка на прямоугольный треугольник.
       public bool IsRight()
        {
            return side1 * side1 + side2 * side2 == side3 * side3 ||
                side3 * side3 + side2 * side2 == side1 * side1 ||
                side1 * side1 + side3 * side3 == side2 * side2;
        }

        public override double GetSquare()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        // К выводу добавляется сообщение о том, является ли треугольник прямоугольным.
        public override string ToString()
        {
            string res;
            if (IsRight())
            {
                res = "Is right angled";
            } 
            else
            {
                res = "Is not right angled";
            }
            return base.ToString() + res;
        }

    }
}
