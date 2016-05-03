using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace BreakingTheFourth
{
    class Level3
    {
        List<Terrain> pieces = new List<Terrain>();
        int playerY;
        Song bgMusic;
        //properties
        public Song BgMusic
        {
            get { return bgMusic; }
            set { bgMusic = value; }
        }
        public int PlayerY
        {
            get { return playerY; }
        }
        // Next Screen method
        public List<Terrain> NextScreen(int screen, Bullet bullet)
        {
            bullet.Bullets = 500;
            // switch to determine which screen to draw
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 25, 600)); // left wall
                    pieces.Add(new Terrain(0, 450, 150, 40)); //left floor
                    pieces.Add(new Terrain(130, 440, 20, 10)); //thingy to stop you from walking right onto the spikes
                    pieces.Add(new DeathObject(150, 460, 300, 40));//left spikes
                    pieces.Add(new Terrain(170, 410, 50, 50)); //first platform
                    pieces.Add(new Terrain(250, 370, 50, 50)); //second platform
                    pieces.Add(new DeathObject(250, 340, 50, 30)); //second platform spikes
                    pieces.Add(new Terrain(360, 120, 50, 20)); //third platform (top)
                    pieces.Add(new Terrain(360, 250, 50, 20)); //third platform (bottom)
                    pieces.Add(new SpecialTerrain(460, 250, 10, 10, 160, 250)); //moving platform
                    pieces.Add(new Terrain(480, 0, 30, 180)); //top wall obstacle
                    pieces.Add(new Terrain(480, 230, 30, 300)); //bottom wall obstacle
                    pieces.Add(new Terrain(650, 180, 30, 110)); //fourth platform (vertical)
                    pieces.Add(new Terrain(590, 260, 60, 30)); //fourth platform (horizontal)
                    pieces.Add(new DeathObject(510, 460, 180, 40)); //right spikes
                    pieces.Add(new Terrain(690, 460, 200, 40)); //right floor
                    playerY = 380;
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new pieces
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    break;


            }
            return pieces;
        }

    }
}
