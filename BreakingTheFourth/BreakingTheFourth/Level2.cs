using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakingTheFourth
{
    class Level2
    {
        // list to hold the terrain pieces
        List<Terrain> pieces = new List<Terrain>();

        // Next Screen method
        public List<Terrain> NextScreen(int screen)
        {
            // switch to determine which screen to draw
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    break;

            }
            return pieces;
        }
    }
}
