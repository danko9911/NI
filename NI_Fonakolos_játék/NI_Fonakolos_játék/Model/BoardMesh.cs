﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NI_Fonakolos_játék.Model
{
    /// <summary>
    /// Logical for BoardTile Class. Contains the list of tiles.
    /// </summary>
    class BoardMesh
    {
        public List<BoardTile> gameMesh = new List<BoardTile>();

        public Dictionary<int, List<BoardTile>> storedState = new Dictionary<int, List<BoardTile>>();

        public int rounds;

        public BoardMesh()
        {
            createTable();
            this.rounds = 0;
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
            foreach (Model.BoardTile tile in gameMesh)
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

        public void gameStep(int new_id)
        {
            setStoredState();
            
            PlayerSteps newStep = new PlayerSteps(gameMesh);

            foreach (PlayerSteps.Directions dir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
            {

                newStep.nextStep(new_id, dir);

            }

            gameMesh = newStep.finalTiles();

            calcualteNextStep();
            rounds++;
        }

        public void calcualteNextStep()
        {
            PlayerSteps newStep = new PlayerSteps(gameMesh);
            int testid = 0;

            foreach (BoardTile tiles in gameMesh)
            {
                if(tiles.field_owner == 3 || tiles.field_owner == 4)
                {
                    tiles.field_owner = 0;
                }

                testid++;
            }

            testid = 0;

            foreach (BoardTile tiles in gameMesh)
            {
                if (tiles.field_owner == 1 || tiles.field_owner == 2)
                {
                    foreach (PlayerSteps.Directions dir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
                    {

                        newStep.suggestedStep(testid, dir);

                    }
                }
                testid++;
            }
            gameMesh = newStep.finalTiles();
        }

        private void setStoredState()
        {
            if(storedState.Count > 5)
            {
                storedState.Remove(storedState.Keys.Min());
            }
            storedState.Add(rounds, gameMesh);
        }


    }
}
