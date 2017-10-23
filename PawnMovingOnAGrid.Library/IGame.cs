using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public interface IGame
    {
        IPawn Pawn { get; }
        GridBoard Board { get; }

        bool IsPawnWithinBoard();

    }
}
