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

        public void suggestedStep(int selectedID, Directions selectedDir)
        {

            
            int calcualtedID = -1;
            List<int> oppositeIDs = new List<int>();
            bool endOfTable = true;

            try
            {
               int player = tileList[selectedID].field_owner;

                while (endOfTable)
                {

                    if (tileList[selectedID + directionInT(selectedDir)].field_owner != player )
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
                            endOfTable = false;
                        }
                        else
                        {
                            selectedID += directionInT(selectedDir);
                            calcualtedID = selectedID;
                        }
                    }
                    if (tileList[selectedID + directionInT(selectedDir)].field_owner != 1 && tileList[selectedID + directionInT(selectedDir)].field_owner != 2)
                    {
                        endOfTable = false;
                        //TODO: A lépéskényszert itt kel kialakítani!
                        /*if (calcualtedID != -1 && player != tileList[selectedID].field_owner)
                        {
                            tileList[selectedID + directionInT(selectedDir)].field_owner = player % 2 + 3;
                        }*/
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
