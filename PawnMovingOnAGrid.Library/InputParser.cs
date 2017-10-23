using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class InputParser
    {
        /// <summary>
        /// Returns an array of ValidMoves, from the string input, according to the rule:
        /// 'M' -> moveAhead,  'L' -> rotateLeft,  'R' -> rotateRight.
        /// Any other char in the input string causes the function to throw an ArgumentException.
        /// </summary>
        public static ValidMove[] ParseMoves(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), $"Argument {nameof(input)} cannot be null!");

            int N = input.Length;
            ValidMove[] parsedMoves = new ValidMove[N];

            for(int i = 0; i < N; i++)
            {
                switch(input[i])
                {
                    case 'M':
                        parsedMoves[i] = ValidMove.moveAhead;
                        break;
                    case 'L':
                        parsedMoves[i] = ValidMove.rotateLeft;
                        break;
                    case 'R':
                        parsedMoves[i] = ValidMove.rotateRight;
                        break;
                    default:
                        throw new ArgumentException($"String argument {nameof(input)} should only consist of characters: 'M', 'L', 'R'. But the following character was encountered: '{input[i]}'.");
                }
            }

            return parsedMoves;
        }

    }
}
