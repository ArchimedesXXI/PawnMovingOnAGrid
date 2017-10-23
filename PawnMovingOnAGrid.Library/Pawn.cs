using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PawnMovingOnAGrid.Library
{
    public class Pawn : IPawn
    {
        #region Constructors
        public Pawn() : this(new Position(0, 0), Heading.North) { }

        public Pawn(IPosition position, Heading heading)
        {
            this.Position = position;
            this.Heading = heading;
        }
        #endregion


        #region Fields & Properties
        public IPosition Position { get; private set; }
        public Heading Heading { get; private set; }
        #endregion


        #region Methods
        public void RotateRight()
        {
            this.Heading = (Heading)(((int)this.Heading + 1) % 4);
            Debug.Assert(Enum.IsDefined(typeof(Heading), this.Heading));
        }

        public void RotateLeft()
        {
            this.Heading = (Heading)(((int)this.Heading + 4 - 1) % 4);
            Debug.Assert(Enum.IsDefined(typeof(Heading), this.Heading));
        }

        public void MoveAhead()
        {
            this.Position.MoveDue(this.Heading, 1);
        }
        #endregion

    }
}
