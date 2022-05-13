using System;
using Xunit;

namespace ActionsWithFigures.Tests
{
    public class Tests
    {
        [Fact]
        public void Test_Triangle_GetSquare1()
        {
            var tr = new Triangle(3, 4, 5);
            var ex = 6;
            Assert.Equal(tr.GetSquare(), ex);
        }

        [Fact]
        public void Test_Triangle_GetSquare2()
        {
            var tr = new Triangle(57, 34, 46);
            var ex = 781.98;
            Assert.Equal(Math.Round(tr.GetSquare(), 2), ex);
        }

        [Fact]
        public void Test_Circle_GetSquare()
        {
            var cir = new Circle(4);
            var ex = 50.265;
            Assert.Equal(Math.Round(cir.GetSquare(), 3), ex);
        }

        [Fact]
        public void Test_Triangle_IsRight1()
        {
            var tr = new Triangle(3, 4, 5);
            var ex = true;
            Assert.Equal(tr.IsRight(), ex);
        }
        [Fact]
        public void Test_Triangle_IsRight()
        {
            var tr = new Triangle(1, 1, 1);
            var ex = false;
            Assert.Equal(tr.IsRight(), ex);
        }
    }
}
