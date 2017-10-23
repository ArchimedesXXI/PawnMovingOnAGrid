using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PawnMovingOnAGrid.Library.Tests
{

    class GameTESTS
    {
        [TestCase(1, 1, 0, 0)]
        [TestCase(1, 2, 0, 1)]
        [TestCase(5, 7, 4, 6)]
        [TestCase(154, 182, 130, 99)]
        [TestCase(3822, 4711, 3821, 4710)]
        [TestCase(3822, 4711, 3666, 4123)]

        public void IsPawnWithinBoard_PositiveOutcomeInNoMovementScenario_IntegrationTESTS(int X_size, int Y_size, int x, int y, [Values(Heading.North, Heading.East, Heading.South, Heading.West)] Heading h = Heading.North )
        {
            GridBoard board = new GridBoard(X_size, Y_size);
            Pawn pawn = new Pawn(new Position(x, y), h);
            Game game = new Game(pawn, board);

            Assert.IsTrue(game.IsPawnWithinBoard());
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 1, 0, 1)]
        [TestCase(5, 7, 5, 6)]
        [TestCase(1, 1, 0, -1)]
        [TestCase(1, 1, -1, 0)]
        [TestCase(154, 182, -17, -9)]
        [TestCase(3822, 4711, 3900, 4800)]
        public void IsPawnWithinBoard_NegativeOutcomeInNoMovementScenario_IntegrationTESTS(int X_size, int Y_size, int x, int y, [Values(Heading.North, Heading.East, Heading.South, Heading.West)] Heading h = Heading.North)
        {
            GridBoard board = new GridBoard(X_size, Y_size);
            Pawn pawn = new Pawn(new Position(x, y), h);
            Game game = new Game(pawn, board);
            
            Assert.IsFalse(game.IsPawnWithinBoard());
        }


    }
}
