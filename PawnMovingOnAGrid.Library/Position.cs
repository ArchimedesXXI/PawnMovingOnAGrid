using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMovingOnAGrid.Library
{
    public class Position : IPosition
    {
        #region Constructors
        public Position() : this(0, 0) { }

        public Position(int x, int y)
        {
            this.X_coordinate = x;
            this.Y_coordinate = y;
        }
        #endregion


        #region Fields & Properties
        public int X_coordinate { get; private set; }
        public int Y_coordinate { get; private set; }
        #endregion


        #region Methods
        public void MoveDue(Heading heading, int steps = 1)
        {
            switch (heading)
            {
                case Heading.North:
                    this.Y_coordinate = this.Y_coordinate + steps;
                    break;
                case Heading.South:
                    this.Y_coordinate = this.Y_coordinate - steps;
                    break;
                case Heading.East:
                    this.X_coordinate = this.X_coordinate + steps;
                    break;
                case Heading.West:
                    this.X_coordinate = this.X_coordinate - steps;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(heading));
            }
        }
        #endregion


    }
}
