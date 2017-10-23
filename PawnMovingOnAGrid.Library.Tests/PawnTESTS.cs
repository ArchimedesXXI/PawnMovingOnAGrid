using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace PawnMovingOnAGrid.Library.Tests
{
    [TestFixture]
    class PawnTESTS
    {
        [TestCase(456, 17,  Heading.North,  Heading.East)]
        [TestCase(-8, -11,  Heading.East,   Heading.South)]
        [TestCase(4, 2,     Heading.South,  Heading.West)]
        [TestCase(9, -3,    Heading.West,   Heading.North)]
        public void RotateRight_PositiveOutcomeTESTS(int x, int y, Heading h0, Heading h1)
        {
            IPosition fakePosition = Mock.Of<IPosition>(f => f.X_coordinate == x && f.Y_coordinate == y);
            Pawn pawn = new Pawn(fakePosition, h0);
            pawn.RotateRight();
            Assert.AreEqual(h1, pawn.Heading);
        }

        [TestCase(456, 17,  Heading.North,  Heading.West)]
        [TestCase(4, 2,     Heading.South,  Heading.East)]
        [TestCase(-8, -11,  Heading.East,   Heading.North)]
        [TestCase(9, -3,    Heading.West,   Heading.South)]
        public void RotateLeft_PositiveOutcomeTESTS(int x, int y, Heading h0, Heading h1)
        {
            IPosition fakePosition = Mock.Of<IPosition>( f => f.X_coordinate == x && f.Y_coordinate == y);
            Pawn pawn = new Pawn(fakePosition, h0);
            pawn.RotateLeft();
            Assert.AreEqual(h1, pawn.Heading);
        }


        [Test]
        public void Pawn_ConstructorWith0Param_TEST()
        {
            Pawn pawn = new Pawn();
            Assert.AreEqual(0, pawn.Position.X_coordinate);
            Assert.AreEqual(0, pawn.Position.Y_coordinate);
            Assert.AreEqual(Heading.North, pawn.Heading);
        }

        [TestCase(-2313, 7123131,   Heading.South)]
        [TestCase(892313, -431,     Heading.East)]
        [TestCase(-322313, -1001,   Heading.North)]
        [TestCase(13, 1,            Heading.West)]
        public void Pawn_ConstructorWith2Param_TEST(int x, int y, Heading h)
        {
            IPosition fakePosition = Mock.Of<IPosition>( f => f.X_coordinate == x && f.Y_coordinate == y);

            Pawn pawn = new Pawn(fakePosition, h);

            Assert.AreEqual(x, pawn.Position.X_coordinate);
            Assert.AreEqual(y, pawn.Position.Y_coordinate);
            Assert.AreEqual(h, pawn.Heading);
        }



        /// <summary>
        /// Integration Test
        /// </summary>
        [TestCase(0, 0,     Heading.North,      0, 1)]
        [TestCase(0, 0,     Heading.East,       1, 0)]
        [TestCase(0, 0,     Heading.South,      0, -1)]
        [TestCase(0, 0,     Heading.West,       -1, 0)]
        [TestCase(456, 17,  Heading.North,      456, 18)]
        [TestCase(4, 2,     Heading.South,      4, 1)]
        [TestCase(-8, -11,  Heading.East,       -7, -11)]
        [TestCase(9, -3,    Heading.West,       8, -3)]
        public void MoveAhead_PositiveOutcomeTESTS(int x0, int y0, Heading h, int x1, int y1)
        {
            Position position = new Position(x0, y0);
            Pawn pawn = new Pawn(position, h);

            pawn.MoveAhead();

            Assert.AreEqual(x1, pawn.Position.X_coordinate);
            Assert.AreEqual(y1, pawn.Position.Y_coordinate);
        }


    }
}
