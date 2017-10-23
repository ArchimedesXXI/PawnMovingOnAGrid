using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PawnMovingOnAGrid.Library.Tests
{
    class InputParserTESTS
    {
        [Test]
        public void ParseMoves_When_GivenNull_Should_Throw()
        {
            Assert.Throws(typeof(ArgumentNullException), () => InputParser.ParseMoves(null) );
        }

        [Test]
        public void ParseMoves_When_GivenEmptyString_Should_ReturnEmptyArray()
        {
            ValidMove[] actual = InputParser.ParseMoves(String.Empty);
            Assert.IsEmpty(actual);
        }

        [TestCase(" ")]
        [TestCase(".")]
        [TestCase("m")]
        [TestCase("r")]
        [TestCase("l")]
        [TestCase("MMMRRRLLLLRRRLLMMMMMaMMMRRRLLL")]
        [TestCase("MMMRRRLLLLRRRLLMMMMMMMMRR RLLL")]
        [TestCase("MMMRRRLLLLRRRLLMMMMMMMMRRRLLL;")]
        [TestCase("1MMMRRRLLLLRRRLLMMMMMMMMRRRLLL")]
        [TestCase("MMMRRRLLLLRRRLLMMMMMMMMRRrRLLL")]
        public void ParseMoves_When_GivenIncorrectInput_Should_Throw(string input)
        {
            Assert.Throws(typeof(ArgumentException), () => InputParser.ParseMoves(input));
        }

        [TestCase("", new ValidMove[] { })]
        [TestCase("M", new ValidMove[] { ValidMove.moveAhead })]
        [TestCase("R", new ValidMove[] { ValidMove.rotateRight })]
        [TestCase("L", new ValidMove[] { ValidMove.rotateLeft })]
        [TestCase("LLMLRRM", 
            new ValidMove[] { ValidMove.rotateLeft, ValidMove.rotateLeft, ValidMove.moveAhead, ValidMove.rotateLeft,
            ValidMove.rotateRight, ValidMove.rotateRight, ValidMove.moveAhead })]
        public void ParseMoves_When_GivenCorrectInput_Should_ReturnCorrectResult(string input, ValidMove[] expected)
        {
            ValidMove[] actual = InputParser.ParseMoves(input);
            Assert.AreEqual(expected, actual);
        }


    }
}
