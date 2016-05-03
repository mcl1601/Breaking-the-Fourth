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
                    pieces.Add(new Terrain(0, 0, 25, 350));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40));//left floor
                    pieces.Add(new Terrain(130, 440, 20, 10)); //thingy to stop you from walking right onto the spikes
                    pieces.Add(new SpecialTerrain(250, 470, 50, 50, 75, 470));//first moving platform
                    //first set of platforms with spikes
                    pieces.Add(new Terrain(350, 130, 40, 40));
                    pieces.Add(new DeathObject(350, 100, 40, 30));
                    pieces.Add(new Terrain(350, 330, 40, 40));
                    pieces.Add(new DeathObject(350, 300, 40, 30));
                    pieces.Add(new SpecialTerrain(450, 75, 50, 50, 75, 470));//second moving platform
                    //second set of platforms with spikes
                    pieces.Add(new Terrain(550, 130, 40, 40));
                    pieces.Add(new DeathObject(550, 100, 40, 30));
                    pieces.Add(new Terrain(550, 330, 40, 40));
                    pieces.Add(new DeathObject(550, 300, 40, 30));
                    pieces.Add(new SpecialTerrain(650, 470, 50, 50, 75, 470));//third moving platform
                    pieces.Add(new Terrain(750, 0, 50, 350));//left wall
                    pieces.Add(new Terrain(750, 450, 150, 40));//left floor
                    playerY = 370;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 350));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40));//left floor
                    pieces.Add(new SpecialTerrain(150, 460, 600, 40, 50, 460));//moving platform
                    pieces.Add(new Terrain(250, 0, 30, 300));//first obstacle (top)
                    pieces.Add(new Terrain(250, 375, 30, 200));//first obstacle (bottom)
                    pieces.Add(new Terrain(350, 0, 30, 150));//second obstacle (top)
                    pieces.Add(new Terrain(350, 225, 30, 500));//second obstacle (bottom)
                    pieces.Add(new Terrain(450, 0, 30, 350));//third obstacle (top)
                    pieces.Add(new Terrain(450, 425, 30, 100));//third obstacle (bottom)
                    pieces.Add(new Terrain(550, 0, 30, 250));//fourth obstacle (top)
                    pieces.Add(new Terrain(550, 325, 30, 200));//fourth obstacle (bottom)
                    pieces.Add(new Terrain(650, 0, 30, 200));//fifth obstacle (top)
                    pieces.Add(new Terrain(650, 275, 30, 300));//fifth obstacle (bottom)
                    pieces.Add(new Terrain(750, 0, 50, 350));//left wall
                    pieces.Add(new Terrain(750, 450, 150, 40));//left floor
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
