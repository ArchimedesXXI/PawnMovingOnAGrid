using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class MovementExecutor
    {
        public MovementExecutor(IGame game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game), "Game instance cannot be null!");

            this.Game = game;
        }

        public IGame Game { get; }


        public void ExecuteMovements(ValidMove[] moves)
        {
            foreach (ValidMove move in moves)
            {
                switch(move)
                {
                    case ValidMove.moveAhead:
                        this.Game.Pawn.MoveAhead();
                        break;
                    case ValidMove.rotateLeft:
                        this.Game.Pawn.RotateLeft();
                        break;
                    case ValidMove.rotateRight:
                        this.Game.Pawn.RotateRight();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(move));
                }

                bool validMove = this.Game.IsPawnWithinBoard();

                if (!validMove)
                    throw new InvalidMoveException("The Pawn has left the Board, which is considered an invalid move!");
            }
        }

    }
}
