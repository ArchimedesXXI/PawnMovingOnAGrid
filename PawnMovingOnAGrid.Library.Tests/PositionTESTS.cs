using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PawnMovingOnAGrid.Library.Tests
{
    [TestFixture]
    class PositionTESTS
    {
        [Test]
        public void Position_ConstructorWith0Param_TEST()
        {
            Position p = new Position();
            Assert.AreEqual(0, p.X_coordinate);
            Assert.AreEqual(0, p.Y_coordinate);
        }

        [TestCase(-2313, 7123131)]
        [TestCase(892313, -431)]
        [TestCase(-322313, -1001)]
        [TestCase(13, 1)]
        public void Position_ConstructorWith2Param_TEST(int x, int y)
        {
            Position p = new Position(x, y);
            Assert.AreEqual(x, p.X_coordinate);
            Assert.AreEqual(y, p.Y_coordinate);
        }

        [TestCase(-1)]
        [TestCase(-121414)]
        [TestCase(4)]
        [TestCase(456789)]
        public void MoveDue_When_GivenIncorrectHeading_Should_Throw(int a)
        {
            Position p = new Position();
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => p.MoveDue((Heading)a));
        }

        [TestCase(0, 0,     Heading.North, 1,       0, 1)]
        [TestCase(0, 0,     Heading.East, 2,        2, 0)]
        [TestCase(0, 0,     Heading.South, 3,      0, -3)]
        [TestCase(0, 0,     Heading.West, 1,       -1, 0)]
        [TestCase(0, 0,     Heading.North, 0,       0, 0)]
        [TestCase(456, 17,  Heading.West, 0,     456, 17)]
        [TestCase(4, 2,     Heading.South, 1,       4, 1)]
        [TestCase(3, 5,     Heading.East, 2,        5, 5)]
        [TestCase(-8, -11,  Heading.East, -2,   -10, -11)]
        [TestCase(9, -3,    Heading.South,-7,       9, 4)]
        public void MoveDue_When_GivenCorrectData_Should_ReturnCorrectResult(int x0, int y0, Heading h, int s, int x1, int y1)
        {
            Position p = new Position(x0, y0);
            p.MoveDue(h, s);
            Assert.AreEqual(x1, p.X_coordinate);
            Assert.AreEqual(y1, p.Y_coordinate);
        }



    }
}
