using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace PawnMovingOnAGrid.Library.Tests
{
    class MovementExecutorTESTS
    {
        [Test]
        public void MovementExecutorConstructor_When_GivenNull_Should_Throw()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new MovementExecutor(null));
        }


        [TestCase(new ValidMove[] { (ValidMove)(-1) })]
        [TestCase(new ValidMove[] { (ValidMove)(3) })] 
        [TestCase(new ValidMove[] { (ValidMove)(528), ValidMove.rotateRight })] 
        [TestCase(new ValidMove[] { (ValidMove)(-74), ValidMove.moveAhead, ValidMove.rotateLeft })] 
        public void ExecuteMovements_When_NotGivenValidMove_should_Throw(ValidMove[] moves)
        {
            var fakeGame = new Mock<IGame>();
            MovementExecutor executor = new MovementExecutor(fakeGame.Object);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => executor.ExecuteMovements(moves));
        }

        [TestCase(new ValidMove[] { }, 0, 0, 0)]
        [TestCase(new ValidMove[] { ValidMove.moveAhead }, 1, 0, 0)]
        [TestCase(new ValidMove[] { ValidMove.rotateLeft }, 0, 1, 0)]
        [TestCase(new ValidMove[] { ValidMove.rotateRight }, 0, 0, 1)]
        [TestCase(new ValidMove[] { ValidMove.moveAhead, ValidMove.rotateLeft, ValidMove.rotateRight }, 1, 1, 1)]
        [TestCase(new ValidMove[] { ValidMove.moveAhead, ValidMove.rotateLeft, ValidMove.rotateRight }, 1, 1, 1)]
        [TestCase(new ValidMove[] { ValidMove.rotateRight, ValidMove.rotateRight, ValidMove.moveAhead, ValidMove.rotateLeft, ValidMove.rotateRight, ValidMove.rotateLeft }, 1, 2, 3)]

        public void ExecuteMovements_When_GivenCorrectInput_Should_CallAppropriateMethods(ValidMove[] moves, int m_count, int l_count, int r_count)
        {
            var mockPawn = new Mock<IPawn>();
            var mockGame = new Mock<IGame>();

            mockGame.Setup(m => m.Pawn).Returns(mockPawn.Object);
            mockGame.Setup(m => m.IsPawnWithinBoard()).Returns(true);

            MovementExecutor executor = new MovementExecutor(mockGame.Object);
            executor.ExecuteMovements(moves);

            mockPawn.Verify(f => f.MoveAhead(), Times.Exactly(m_count));
            mockPawn.Verify(f => f.RotateLeft(), Times.Exactly(l_count));
            mockPawn.Verify(f => f.RotateRight(), Times.Exactly(r_count));
        }


    }
}
