using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithFigures
{

    [Serializable]
    public class FiguresExeption: Exception
    {
        public FiguresExeption() { }
        public FiguresExeption(string message) : base(message) { }
        public FiguresExeption(string message, Exception inner) : base(message, inner) { }
        protected FiguresExeption(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
