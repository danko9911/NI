using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
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
    }
}
