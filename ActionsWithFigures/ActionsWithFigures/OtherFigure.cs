using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithFigures
{
    public class OtherFigure : Figures
    {
        double square;
        public OtherFigure(string t, double s)
        {
            Square = s;
            type = t;
        }

        // Свойство для площади + проверка на корректность.
        public double Square
        {
            get
            {
                return square;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FiguresExeption("The square of a figure can not have a negative length");
                }
                square = value;
            }
        }

        public override double GetSquare()
        {
            return Square;
        }
    }
}
