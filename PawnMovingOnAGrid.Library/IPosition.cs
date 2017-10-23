using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public interface IPosition
    {
        int X_coordinate { get; }
        int Y_coordinate { get; }

        void MoveDue(Heading heading, int steps);
    }
}
