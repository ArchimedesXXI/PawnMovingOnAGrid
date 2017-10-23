using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PawnMovingOnAGrid.Library.Tests
{
    /// <summary>
    /// The class contains End-To-End (E2E) and some more Integration Tests.
    /// </summary>
    class E2E_Tests
    {

        [TestCaseSource(nameof(E2E_Tests_PositiveScenarios_DataGenerator))]
        public void E2E_Tests_PositiveScenarios(int gridSize_X, int gridSize_Y, int startPosition_x, int startPosition_y, Heading startHeading, 
            string movesAsString, int expectedEnd_x, int expectedEnd_y, int expectedEndHeading)
        {
            GridBoard board = new GridBoard(gridSize_X, gridSize_Y);
            Pawn pawn = new Pawn(new Position(startPosition_x, startPosition_y), startHeading);
            Game game = new Game(pawn, board);
            MovementExecutor executor = new MovementExecutor(game);
            ValidMove[] moves = InputParser.ParseMoves(movesAsString);

            executor.ExecuteMovements(moves);

            Assert.AreEqual(expectedEnd_x, pawn.Position.X_coordinate);
            Assert.AreEqual(expectedEnd_y, pawn.Position.Y_coordinate);
            Assert.AreEqual((Heading)expectedEndHeading, pawn.Heading);
        }

        [TestCaseSource(nameof(E2E_Tests_NegativeScenarios_DataGenerator))]
        public void E2E_Tests_NegativeScenarios(int gridSize_X, int gridSize_Y, int startPosition_x, int startPosition_y, Heading startHeading, string movesAsString)
        {
            GridBoard board = new GridBoard(gridSize_X, gridSize_Y);
            Pawn pawn = new Pawn(new Position(startPosition_x, startPosition_y), startHeading);
            Game game = new Game(pawn, board);
            MovementExecutor executor = new MovementExecutor(game);
            ValidMove[] moves = InputParser.ParseMoves(movesAsString);

            Assert.Throws(typeof(InvalidMoveException), () => executor.ExecuteMovements(moves));
        }



        #region Test Data generators
        public static IEnumerable<TestCaseData> E2E_Tests_PositiveScenarios_DataGenerator()
        {
            //
            // Obviously positive Test Cases:
            yield return new TestCaseData(5, 5, 1, 2, Heading.North, "", 1, 2, Heading.North);
            yield return new TestCaseData(5, 5, 3, 3, Heading.East, "", 3, 3, Heading.East);
            //
            // Positive Test Cases provided by specification:
            yield return new TestCaseData(5, 5, 1, 2, Heading.North, "LMLMLMLMM", 1, 3, Heading.North);
            yield return new TestCaseData(6, 6, 3, 3, Heading.East, "MMRMMRMRRM", 5, 1, Heading.East);
            //
            // Positive Test Cases based on a manually verified sequence of moves given below (with it intermediate positions given in parenthesis):
            // board: 7,10  start: 4,6,S  moves:  RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMM(0,0,S) RRLLRRRMMMMMM(6,0,E) LLRMMMMMMMMM(6,9,N) RRRRLMMMMMM(0,9,W) LLMMMRMMRRRRLLMLMMRRRMMMMLRRL(1,4,S) LMMMMMLMMRRRMMLLLR(4,6,E)
            //
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMM", 0, 0, Heading.South);
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMM", 6, 0, Heading.East);
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMM", 6, 9, Heading.North);
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMM", 0, 9, Heading.West);
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRL", 1, 4, Heading.South);
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRLLMMMMMLMMRRRMMLLLR", 4, 6, Heading.East);
            //
            // Same move sequence as above, but on a larger board: 
            yield return new TestCaseData(286, 710, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMM", 0, 0, Heading.South);
            yield return new TestCaseData(344, 12, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMM", 6, 0, Heading.East);
            yield return new TestCaseData(71, 105, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMM", 6, 9, Heading.North);
            yield return new TestCaseData(98, 45, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMM", 0, 9, Heading.West);
            yield return new TestCaseData(144, 155, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRL", 1, 4, Heading.South);
            yield return new TestCaseData(222, 333, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRLLMMMMMLMMRRRMMLLLR", 4, 6, Heading.East);
        }

        public static IEnumerable<TestCaseData> E2E_Tests_NegativeScenarios_DataGenerator()
        {
            // Obviously invalid sequence of moves:
            yield return new TestCaseData(0, 0, 1, 1, Heading.West, "L");
            yield return new TestCaseData(5, 5, 1, 2, Heading.North, "MMM");
            yield return new TestCaseData(158, 276, 0, 0, Heading.East, "RM");
            yield return new TestCaseData(158, 276, 0, 0, Heading.East, "LLM");
            yield return new TestCaseData(1, 1, 0, 0, Heading.West, "RM");
            yield return new TestCaseData(2, 2, 1, 1, Heading.East, "LLLMM");
            yield return new TestCaseData(2, 2, 1, 1, Heading.East, "LLLMRRRM");
            yield return new TestCaseData(2, 2, 1, 1, Heading.North, "LMLMLMLMM");
            yield return new TestCaseData(2, 2, 1, 1, Heading.North, "LMLMLMLMRM");
            // Manually verified invalid sequence of moves: 
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMM");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMM");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMM");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRM");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMM");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRLRMMMMMRR");
            yield return new TestCaseData(7, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMMRRRRLMMMMMMLLMMMRMMRRRRLLMLMMRRRMMMMLRRLLMMMMMLMMRRRMMLLLRMMMMMMMRRLLM");
            yield return new TestCaseData(6, 10, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMM");
            yield return new TestCaseData(7, 9, 4, 6, Heading.South, "RMMMRMLMLMMMMLMMMMMMRRMMMMMMLLLLLMMMRRLLRRRMMMMMMLLRMMMMMMMMM");
        }
        #endregion


    }
}
