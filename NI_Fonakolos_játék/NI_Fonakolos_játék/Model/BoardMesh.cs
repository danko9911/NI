using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace NI_Fonakolos_játék.Model
{
    /// <summary>
    /// Logical for BoardTile Class. Contains the list of tiles.
    /// </summary>
    class BoardMesh
    {
        public List<BoardTile> gameMesh = new List<BoardTile>();

        public List<BoardTile> LastState = new List<BoardTile>();
        public List<BoardTile> SecondLastState = new List<BoardTile>();


        public BoardMesh()
        {
            createTable();
        }

        public void createTable()
        {
            double x = -58;
            double y = -63;
            for(int i = 0; i<8; i++)
            {
                y = -63;
                x += 72.3;
                for(int j = 0; j<8; j++)
                {
                    y += 73.3;
                    gameMesh.Add(new BoardTile(x, y));
                }
            }

            startPhase();
            
        }

        public void startPhase()
        {
            gameMesh[27].field_owner = 1;
            gameMesh[36].field_owner = 1;
            gameMesh[35].field_owner = 2;
            gameMesh[28].field_owner = 2;
            calcualteNextStep();
        }

        public int calculateMousePosition(double x, double y)
        {
            //Callibrate position
            x -= 65;
            y -= 125;
            int id = 0;
            foreach (BoardTile tile in gameMesh)
            {

                if (tile.pos_x > x)
                {
                    for (int i = id; i < id + 8; i++)
                    {
                        if (gameMesh[i].pos_y > y)
                        {
                            return i;
                        }
                    }
                }

                id++;
            }
            return id;
        }
        public int aiStepInd()
        {
            List<int> possibleMoveIndexList = getPossibleMoves();
            int[] moveValueArray = new int[possibleMoveIndexList.Count];

            for (int i = 0; i < possibleMoveIndexList.Count; i++)
            {
                moveValueArray[i] = getMoveValue(possibleMoveIndexList[i]);
            }

            int maxValue = moveValueArray.Max();
            List<int> maxValueMoveList = new List<int>();

            for (int i = 0; i < possibleMoveIndexList.Count; i++)
            {
                if (moveValueArray[i] == maxValue)
                {
                    maxValueMoveList.Add(possibleMoveIndexList[i]);
                }
            }

            Random rndInd = new Random();
            return maxValueMoveList[rndInd.Next(0, maxValueMoveList.Count)];
        }

        public List<int> getPossibleMoves()
        {
            List<int> possibleMoveIndexList = new List<int>();

            for (int i = 0; i < 64; i++)
            {
                if (gameMesh[i].field_owner == 4 || gameMesh[i].field_owner == 5)
                {
                    possibleMoveIndexList.Add(i);
                }
            }

            return possibleMoveIndexList;
        }

        public int getMoveValue(int givenID)
        {
            PlayerSteps newStep = new PlayerSteps(gameMesh);
            int moveValue = 0;
            foreach (PlayerSteps.Directions selectedDir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
            {
                int selectedID = givenID;
                bool endOfTable = true;
                int counter = 0;
                while (endOfTable)
                {
                    if (((selectedID + 1) % 8 == 0 && (selectedDir == PlayerSteps.Directions.DOWN || selectedDir == PlayerSteps.Directions.DOWNLEFT || selectedDir == PlayerSteps.Directions.DOWNRIGHT)) ||
                        (selectedID % 8 == 0 && (selectedDir == PlayerSteps.Directions.UP || selectedDir == PlayerSteps.Directions.UPLEFT || selectedDir == PlayerSteps.Directions.UPRIGHT)) ||
                        (selectedID > 55 && (selectedDir == PlayerSteps.Directions.RIGHT || selectedDir == PlayerSteps.Directions.DOWNRIGHT || selectedDir == PlayerSteps.Directions.UPRIGHT)) ||
                        (selectedID < 8 && (selectedDir == PlayerSteps.Directions.LEFT || selectedDir == PlayerSteps.Directions.DOWNLEFT || selectedDir == PlayerSteps.Directions.UPLEFT)))
                    {
                        endOfTable = false;
                        counter = 0;
                    }
                    //enemy piece
                    else if (gameMesh[selectedID + newStep.directionInT(selectedDir)].field_owner == 1)
                    {
                        counter++;
                    }
                    //self piece
                    else if (gameMesh[selectedID + newStep.directionInT(selectedDir)].field_owner == 2)
                    {
                        endOfTable = false;
                    }
                    //no piece
                    else
                    {
                        endOfTable = false;
                        counter = 0;
                    }
                    selectedID += newStep.directionInT(selectedDir);
                }
                moveValue += counter;
            }
            return moveValue;
        }
        public void gameStep(int new_id, int player)
        {
            setLastState();

            gameMesh[new_id].field_owner = player;

            PlayerSteps newStep = new PlayerSteps(gameMesh);

            foreach (PlayerSteps.Directions dir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
            {

                newStep.nextStep(new_id, dir);

            }

            gameMesh.Clear();
            foreach(var tiles in newStep.getBoard())
            {
                BoardTile initTile = new BoardTile(tiles);
                gameMesh.Add(initTile);
            }
            
            calcualteNextStep();
        }

        public void calcualteNextStep()
        {
            int tileid = 0;

            foreach (BoardTile tiles in gameMesh)
            {
                if (tiles.field_owner == 3 || tiles.field_owner == 4 || tiles.field_owner == 5)
                {
                    tiles.field_owner = 0;
                }

                tileid++;
            }

            PlayerSteps newStep = new PlayerSteps(gameMesh);

            tileid = 0;

            foreach (BoardTile tiles in gameMesh)
            {
                if (tiles.field_owner == 1 || tiles.field_owner == 2)
                {
                    foreach (PlayerSteps.Directions dir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
                    {

                        newStep.suggestedStep(tileid, dir);

                    }
                }
                tileid++;
            }

            gameMesh.Clear();
            foreach (var tiles in newStep.getBoard())
            {
                BoardTile initTile = new BoardTile(tiles);
                gameMesh.Add(initTile);
            }
            

        }

        private void setLastState()
        {
            SecondLastState.Clear();
            if(LastState.Count != 0)
            {
                foreach(var tiles in LastState)
                {
                    BoardTile initTile = new BoardTile(tiles);
                    SecondLastState.Add(initTile);
                }
               
            }
            LastState.Clear();

            foreach (var tiles in gameMesh)
            {
                BoardTile initTile = new BoardTile(tiles);
                LastState.Add(initTile);
            }

        }

        public bool getLastState(bool isAI)
        {
            
            if (LastState.Count != 0)
            {

                gameMesh.Clear();
                if (isAI)
                {
                    LastState.Clear();
                    foreach (var tiles in SecondLastState)
                    {
                        BoardTile initTile = new BoardTile(tiles);
                        gameMesh.Add(initTile);
                    }
                    SecondLastState.Clear();
                }
                else
                {
                    foreach (var tiles in LastState)
                    {
                        BoardTile initTile = new BoardTile(tiles);
                        gameMesh.Add(initTile);
                    }

                    LastState.Clear();

                    if (SecondLastState.Count != 0)
                    {
                        foreach (var tiles in SecondLastState)
                        {
                            BoardTile initTile = new BoardTile(tiles);
                            LastState.Add(initTile);
                        }

                    }
                    SecondLastState.Clear();
                }
                return true;
            }

            return false;
        }
    }
}
