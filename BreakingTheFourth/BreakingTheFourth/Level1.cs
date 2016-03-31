
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
    class Level1
    {
        /*public List<Terrain> terrain = new List<Terrain>();
        Game1 game1 = new Game1();
        int counter = 0;
        public void ScreenOne()
        {
            terrain.Add(new Terrain(0, 700, 1000, 1000));
        }
        public void ScreenTwo()
        {
            terrain.Add(new Terrain(0, 700, 1000, 1000));
            terrain.Add(new Terrain(50, 50, 50, 50));
        }
        public void CreateLevelOne(int playerposX)
        {
            switch(counter)
            {
                case 0:
                    ScreenOne();
                    if(playerposX>1000)
                    {
                        counter = 1;
                    }
                    break;
                case 1:
                    playerposX = 0;
                    terrain.Clear();
                    ScreenTwo();
                    break;

            }
                
        }
        */

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
                    pieces.Add(new Terrain(0, 0, 800, 40));
                    pieces.Add(new Terrain(0, 450, 800, 40));
                    pieces.Add(new Terrain(0, 0, 25, 500));
                    pieces.Add(new Terrain(775, 0, 25, 300));
                    pieces.Add(new Terrain(150, 200, 70, 100));
                    pieces.Add(new Terrain(50, 150, 50, 50));
                    pieces.Add(new SpecialTerrain(400, 399, 75, 75));
                    break;
                case 2:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 800, 40)); 
                    pieces.Add(new Terrain(0, 450, 800, 40));
                    pieces.Add(new Terrain(0, 0, 25, 300));
                    pieces.Add(new Terrain(775, 0, 25, 500));
                    pieces.Add(new Terrain(500, 430, 100, 10));
                    break;
            }
            return pieces;
        }
    }
}
