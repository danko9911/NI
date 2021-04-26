using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
    class PlayerSteps
    {

        public List<BoardTile> tileList = new List<BoardTile>();
        int calcualtedID = -1;

        public PlayerSteps(List<BoardTile> tileList)
        {
            this.tileList = tileList;
        }

        public int suggestedStep(int selectedID, Directions selectedDir)
        {
            int tileOwner = tileList[selectedID + directionInT(selectedDir)].field_owner;

            if (tileOwner == tileList[selectedID].field_owner%2 + 1)
            {

                
            }
            else if (tileOwner == tileList[selectedID].field_owner)
            {

            }

            return calcualtedID;

        }



        public int directionInT(Directions dir)
        {
            switch (dir)
            {
                case Directions.UP: return -1;
                case Directions.DOWN: return 1;
                case Directions.LEFT: return -8;
                case Directions.RIGHT: return 8;
                case Directions.UPLEFT: return -9;
                case Directions.UPRIGHT: return 7;
                case Directions.DOWNLEFT: return -7;
                case Directions.DOWNRIGHT: return 9;
                    
            }

            return 0;


        }
        public enum Directions
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            UPLEFT,
            UPRIGHT,
            DOWNLEFT,
            DOWNRIGHT
        }

    }
}
