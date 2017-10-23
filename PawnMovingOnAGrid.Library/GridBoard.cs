using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class GridBoard
    {
        public GridBoard(int numOfSquares_X, int numOfSquares_Y)
        {
            this.numOfSquares_X = numOfSquares_X;
            this.numOfSquares_Y = numOfSquares_Y;
        }

        public int numOfSquares_X { get; private set; }
        public int numOfSquares_Y { get; private set; }

    }
}
