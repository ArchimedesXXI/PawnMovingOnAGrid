using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public interface IPawn
    {
        IPosition Position { get; }
        Heading Heading { get; }

        void RotateRight();
        void RotateLeft();
        void MoveAhead();
    }
}
