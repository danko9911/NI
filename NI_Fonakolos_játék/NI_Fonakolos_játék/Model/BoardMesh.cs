using System;
using System.Collections.Generic;
using System.Text;

namespace NI_Fonakolos_játék.Model
{
    class BoardMesh
    {
        List<BoardTile> gameMesh = new List<BoardTile>();

        public BoardMesh()
        {

        }

        public void createTable()
        {
            int x = 0;
            int y = 0;
            for(int i = 0; i<8; i++)
            {
                y = 0;
                x += 50;
                for(int j = 0; j<8; j++)
                {
                    y += 50;
                    gameMesh.Add(new BoardTile(x, y));
                }
            }
            
        }
    }
}
