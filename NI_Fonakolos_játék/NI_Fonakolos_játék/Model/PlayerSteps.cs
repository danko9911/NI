using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
    class PlayerSteps
    {

        public List<BoardTile> tileList = new List<BoardTile>();

        

        public PlayerSteps(List<BoardTile> tileList)
        {
            this.tileList = tileList;
        }

        public void suggestedStep(int selectedID, Directions selectedDir, int player)
        {

            
            int calcualtedID = -1;
            List<int> oppositeIDs = new List<int>();
            bool endOfTable = true;

            try
            {
                //int player = tileList[selectedID].field_owner;

                oppositeIDs.Add(selectedID);

                while (endOfTable)
                {
                    if((selectedID+1)%8 == 0 && (selectedDir == Directions.DOWN || selectedDir == Directions.DOWNLEFT || selectedDir == Directions.DOWNRIGHT) ||
                       (selectedID) % 8 == 0 && (selectedDir == Directions.UP || selectedDir == Directions.UPLEFT || selectedDir == Directions.UPRIGHT) ||
                       (selectedID < 8) && (selectedDir == Directions.LEFT || selectedDir == Directions.UPLEFT || selectedDir == Directions.DOWNLEFT) ||
                       (selectedID > 55) && (selectedDir == Directions.RIGHT || selectedDir == Directions.DOWNRIGHT || selectedDir == Directions.UPRIGHT))
                    {
                        endOfTable = false;
                    }
                    

                    if (tileList[selectedID + directionInT(selectedDir)].field_owner == (player % 2) +1 )
                    {

                        selectedID += directionInT(selectedDir);
                        calcualtedID = selectedID;
                        oppositeIDs.Add(selectedID);

                    }

                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner == player)
                    {
                        if (calcualtedID != -1)
                        {
                            foreach (int tiles in oppositeIDs)
                            {
                                tileList[tiles].field_owner = player;


                            }
                            
                        }
                        endOfTable = false;
                    }
                    if (tileList[selectedID + directionInT(selectedDir)].field_owner != 1 && tileList[selectedID + directionInT(selectedDir)].field_owner != 2)
                    {
                        endOfTable = false;
                        //TODO: A lépéskényszert itt kell kialakítani!

                    }


                }
            }

            catch (ArgumentOutOfRangeException e)
            {
                //DoNothing
            }
        }

            public List<BoardTile> finalTiles()
        {

            return tileList;
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
