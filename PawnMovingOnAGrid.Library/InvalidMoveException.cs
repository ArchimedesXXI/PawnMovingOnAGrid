using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class InvalidMoveException : InvalidOperationException
    {
        internal InvalidMoveException() : base() { }

        internal InvalidMoveException(string message) : base(message) { }

    }
}
