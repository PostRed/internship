using System;

namespace ActionsWithFigures
{
    abstract public class Figures
    {
        protected string type;

        // Метод, который должен быть реализован во всех наследниках
        abstract public double GetSquare();

        public override string ToString()
        {
            return $"Type: {type}; Square: {GetSquare()}; ";
        }

    }
}
