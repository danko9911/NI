using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NI_Fonakolos_játék.Model
{
    /// <summary>
    /// Model class for each tile on board.
    /// </summary>
    class BoardTile
    {
        public double pos_x { get; private set; }
        public double pos_y { get; private set; }
        public int field_owner { get; set; }
        //0=noOwner 1=white 2=black 3=whiteMust 4=blackMust

        public BoardTile( double pos_x, double pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            field_owner = 0;
        }

        public Point getPosition()
        {
            return new Point(pos_x, pos_y);
        } 
    }
}
