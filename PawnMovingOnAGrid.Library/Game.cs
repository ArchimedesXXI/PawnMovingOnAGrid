using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class Game : IGame
    {
        public Game(IPawn pawn, GridBoard board)
        {
            this.Pawn = pawn ?? throw new ArgumentNullException(nameof(pawn));
            this.Board = board ?? throw new ArgumentNullException(nameof(board));

            //  TODO: Disambiguate specification to determine,  whether below behavior is expected: 
            //
            //if (!IsPawnWithinBoard())
            //    throw new InvalidMoveException("Pawn's starting position cannot be outside the bounds of the Board!");
        }

        public IPawn Pawn { get; private set; }
        public GridBoard Board { get; private set; }


        /// <summary>
        /// Returns true if Pawn's position is within Board, and false if Pawn's position is outside the Board (including when it is negative). 
        /// </summary>
        public bool IsPawnWithinBoard()
        {
            bool lowerBound = (this.Pawn.Position.X_coordinate >= 0)  &&  (this.Pawn.Position.Y_coordinate >= 0);
            bool upperBound = (this.Pawn.Position.X_coordinate <= this.Board.numOfSquares_X - 1)  &&  (this.Pawn.Position.Y_coordinate <= this.Board.numOfSquares_Y - 1);
            return lowerBound && upperBound;
        }

    }
}
