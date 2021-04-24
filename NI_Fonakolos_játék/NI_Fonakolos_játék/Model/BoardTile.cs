using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NI_Fonakolos_játék.Model
{
    class BoardTile
    {
        int pos_x { get; set; }
        int pos_y { get; set; }
        public int field_owner { get; set; }
        //0=noOwner 1=white 2=black 3=whiteMust 4=blackMust

        public BoardTile( int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            field_owner = 0;
        }

        public BoardTile() { }

        public Point getPosition()
        {
            return new Point(pos_x, pos_y);
        } 
    }
}
