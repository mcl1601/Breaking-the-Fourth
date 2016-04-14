
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BreakingTheFourth
{
    //Mike O'Donnell - Worked on base code and logic for generating level, came up with the idea to divide levels into screens that change when player hits stage right.
    //Matt Lienhard - Came up with NextScreen structure, hard coded in values
    class Level1
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
                    pieces.Add(new Terrain(0, 0, 800, 40)); //top
                    pieces.Add(new Terrain(0, 450, 400, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 500)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 300)); // right wall
                    pieces.Add(new Terrain(475, 450, 400, 40)); // right floor
                    break;
                case 2:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 800, 40)); //top
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 300)); // right wall
                    pieces.Add(new Terrain(550, 450, 400, 40)); // right floor
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall 
                    pieces.Add(new Terrain(750, 0, 50, 110)); // right wall(upper)
                    pieces.Add(new Terrain(750, 200, 50, 250)); // right wall (lower)
                    pieces.Add(new Terrain(710, 200, 40, 50)); //right wall platform
                    pieces.Add(new Terrain(0, 450, 800, 40)); // floor
                    pieces.Add(new Terrain(125, 0, 20, 380)); // first obstacle (top)
                    pieces.Add(new Terrain(125, 425, 20, 25)); // first obstacle (bottom)
                    pieces.Add(new Terrain(350, 0, 50, 260)); // second obstacle (top)
                    pieces.Add(new Terrain(350, 350, 50, 100)); //second obstacle (bottom)
                    pieces.Add(new DeathObject(400, 400, 350, 50)); //spikes
                    break;
            }
            return pieces;
        }
    }
}
