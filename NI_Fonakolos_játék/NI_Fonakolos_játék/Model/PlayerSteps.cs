using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NI_Fonakolos_játék.Model
{
    class PlayerSteps
    {

        private List<BoardTile> tileList = new List<BoardTile>();

        

        public PlayerSteps(List<BoardTile> initTileList)
        {
            foreach(var tiles in initTileList)
            {
                BoardTile initTile = new BoardTile(tiles);
                tileList.Add(initTile);
            }
        }

        public void nextStep(int selectedID, Directions selectedDir)
        {

            
            int calcualtedID = -1;
            List<int> oppositeIDs = new List<int>();
            bool endOfTable = true;

            try
            {
               int player = tileList[selectedID].field_owner;

                while (endOfTable)
                {
                    if(((selectedID+1)%8 == 0 && (selectedDir == Directions.DOWN || selectedDir == Directions.DOWNLEFT || selectedDir == Directions.DOWNRIGHT)) ||
                       (selectedID % 8 == 0 && (selectedDir == Directions.UP || selectedDir == Directions.UPLEFT || selectedDir == Directions.UPRIGHT)) ||
                       (selectedID > 55 && (selectedDir == Directions.RIGHT || selectedDir == Directions.DOWNRIGHT || selectedDir == Directions.UPRIGHT)) ||
                           (selectedID < 8 && (selectedDir == Directions.LEFT || selectedDir == Directions.DOWNLEFT || selectedDir == Directions.UPLEFT)))
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
                            endOfTable = false;
                        }
                        else
                        {
                            selectedID += directionInT(selectedDir);
                            calcualtedID = selectedID;
                        }
                    }
                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner != 1 && tileList[selectedID + directionInT(selectedDir)].field_owner != 2)
                    {
                        endOfTable = false;
                        

                    }


                }
            }

            catch (ArgumentOutOfRangeException e)
            {

            }
        }

        public void suggestedStep(int selectedID, Directions selectedDir)
        {
            try {
                bool endOfTable = true;
                bool moved = false;
                int player = tileList[selectedID].field_owner;
                int opponent = (tileList[selectedID].field_owner %2) + 1; 

                while (endOfTable)
                {
                    if (((selectedID + 1) % 8 == 0 && (selectedDir == Directions.DOWN || selectedDir == Directions.DOWNLEFT || selectedDir == Directions.DOWNRIGHT)) ||
                           (selectedID % 8 == 0 && (selectedDir == Directions.UP || selectedDir == Directions.UPLEFT || selectedDir == Directions.UPRIGHT)) ||
                           (selectedID > 55 && (selectedDir == Directions.RIGHT || selectedDir == Directions.DOWNRIGHT || selectedDir == Directions.UPRIGHT)) ||
                           (selectedID < 8 && (selectedDir == Directions.LEFT || selectedDir == Directions.DOWNLEFT || selectedDir == Directions.UPLEFT)))
                    {
                        endOfTable = false;
                    }

                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner == 0)
                    {
                        if (moved)
                        {

                            tileList[selectedID + directionInT(selectedDir)].field_owner = player + 2;
                            //throw new Exception();
                        }

                        endOfTable = false;

                    }

                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner == opponent)
                    {

                        moved = true;
                        
                    }

                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner == player)
                    {
                        endOfTable = false;
                    }

                    else if (tileList[selectedID + directionInT(selectedDir)].field_owner == opponent + 2)
                    {
                        if (moved)
                        {
                            tileList[selectedID + directionInT(selectedDir)].field_owner = 5;
                            endOfTable = false;
                        }
                    }
                    else if(tileList[selectedID + directionInT(selectedDir)].field_owner > 2)
                    {
                        endOfTable = false;
                    }

                    selectedID += directionInT(selectedDir);

                }
            }

            catch (ArgumentOutOfRangeException e)
            {
            }
        }

        public List<BoardTile> getBoard()
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
