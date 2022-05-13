using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithFigures
{
    public class Circle : Figures
    {
        double radius;
        public Circle(double r)
        {
            Radius = r;
            type = "Circle";
        }

        // публичное свойство для радиуса + проверка на корректность
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FiguresExeption("The radius of a circle can not have a negative length");
                }
                radius = value;
            }
        }
        public override double GetSquare()
        {
            return Math.PI * radius * radius;
        }
    }
}
