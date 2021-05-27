using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
    /// <summary>
    /// Logical for BoardTile Class. Contains the list of tiles.
    /// </summary>
    class BoardMesh
    {
        public List<BoardTile> gameMesh = new List<BoardTile>();

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

        public void calcualteNextStep(int id)
        {
            PlayerSteps newStep = new PlayerSteps(gameMesh);

            foreach (PlayerSteps.Directions dir in (PlayerSteps.Directions[])Enum.GetValues(typeof(PlayerSteps.Directions)))
            {

                newStep.suggestedStep(id , dir);

            }
            gameMesh = newStep.finalTiles();

            

        }


    }
}
