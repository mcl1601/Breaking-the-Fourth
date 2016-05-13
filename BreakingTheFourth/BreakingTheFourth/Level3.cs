using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    //Contribution comments
    //Kat Weis - background music and color, number of bullets
    class Level3
    {
        List<Terrain> pieces = new List<Terrain>();
        int playerY;
        private int numBullets;
        Song bgMusic;
        Color bgColor = Color.Yellow;
        //properties
        public Song BgMusic
        {
            get { return bgMusic; }
            set { bgMusic = value; }
        }
        public Color BgColor
        {
            get { return bgColor; }
        }
        public int PlayerY
        {
            get { return playerY; }
        }
        public int NumBullets
        {
            get { return numBullets; }
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
                    pieces.Add(new Terrain(0, 0, 25, 600, Color.White)); // left wall
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White)); //left floor
                    pieces.Add(new Terrain(130, 440, 20, 10, Color.White)); //thingy to stop you from walking right onto the spikes
                    pieces.Add(new DeathObject(150, 460, 300, 40, "none", Color.White));//left spikes
                    pieces.Add(new Terrain(170, 410, 50, 50, Color.White)); //first platform
                    pieces.Add(new Terrain(250, 370, 50, 50, Color.White)); //second platform
                    pieces.Add(new DeathObject(250, 340, 50, 30, "none", Color.White)); //second platform spikes
                    pieces.Add(new Terrain(360, 120, 50, 20, Color.White)); //third platform (top)
                    pieces.Add(new Terrain(360, 250, 50, 20, Color.White)); //third platform (bottom)
                    pieces.Add(new SpecialTerrain(460, 250, 10, 10, 160, 250, Movement.Vertical, Color.White)); //moving platform
                    pieces.Add(new Terrain(480, 0, 30, 180, Color.White)); //top wall obstacle
                    pieces.Add(new Terrain(480, 230, 30, 300, Color.White)); //bottom wall obstacle
                    pieces.Add(new Terrain(650, 180, 30, 110, Color.White)); //fourth platform (vertical)
                    pieces.Add(new Terrain(590, 260, 60, 30, Color.White)); //fourth platform (horizontal)
                    pieces.Add(new DeathObject(510, 460, 180, 40, "none", Color.White)); //right spikes
                    pieces.Add(new Terrain(690, 460, 200, 40, Color.White)); //right floor
                    playerY = 380;
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 350, Color.White));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new Terrain(130, 440, 20, 10, Color.White)); //thingy to stop you from walking right onto the spikes
                    pieces.Add(new SpecialTerrain(250, 75, 50, 50, 75, 470, Movement.Vertical, Color.White));//first moving platform
                    //first set of platforms with spikes
                    pieces.Add(new Terrain(350, 130, 40, 40, Color.White));
                    pieces.Add(new DeathObject(350, 100, 40, 30, "none", Color.White));
                    pieces.Add(new Terrain(350, 330, 40, 40, Color.White));
                    pieces.Add(new SpecialTerrain(450, 470, 50, 50, 75, 470, Movement.Vertical, Color.White));//second moving platform
                    pieces.Add(new DeathObject(350, 300, 40, 30, "none", Color.White));
                    //second set of platforms with spikes
                    pieces.Add(new Terrain(550, 130, 40, 40, Color.White));
                    pieces.Add(new DeathObject(550, 100, 40, 30, "none", Color.White));
                    pieces.Add(new Terrain(550, 330, 40, 40, Color.White));
                    pieces.Add(new SpecialTerrain(650, 75, 50, 50, 75, 470, Movement.Vertical, Color.White));//third moving platform
                    pieces.Add(new Terrain(750, 0, 50, 350, Color.White));//left wall
                    pieces.Add(new Terrain(750, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DeathObject(550, 300, 40, 30, "none", Color.White));
                    playerY = 370;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 350, Color.White));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new SpecialTerrain(150, 75, 600, 40, 50, 460, Movement.Vertical, Color.White));//moving platform
                    pieces.Add(new Terrain(250, 0, 30, 300, Color.White));//first obstacle (top)
                    pieces.Add(new Terrain(250, 375, 30, 200, Color.White));//first obstacle (bottom)
                    pieces.Add(new Terrain(350, 0, 30, 150, Color.White));//second obstacle (top)
                    pieces.Add(new Terrain(350, 225, 30, 500, Color.White));//second obstacle (bottom)
                    pieces.Add(new Terrain(450, 0, 30, 350, Color.White));//third obstacle (top)
                    pieces.Add(new Terrain(450, 425, 30, 100, Color.White));//third obstacle (bottom)
                    pieces.Add(new Terrain(550, 0, 30, 250, Color.White));//fourth obstacle (top)
                    pieces.Add(new Terrain(550, 325, 30, 200, Color.White));//fourth obstacle (bottom)
                    pieces.Add(new Terrain(650, 0, 30, 200, Color.White));//fifth obstacle (top)
                    pieces.Add(new Terrain(650, 275, 30, 300, Color.White));//fifth obstacle (bottom)
                    pieces.Add(new Terrain(750, 0, 50, 350, Color.White));//right wall
                    pieces.Add(new Terrain(750, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 350, Color.White));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new Terrain(0, 0, 200, 30, Color.White));//left ceiling
                    pieces.Add(new Terrain(150, 300, 50, 30, Color.White));//platform
                    pieces.Add(new SpecialTerrain(225, 25, 30, 200, 25, 250,Movement.Vertical, Color.White));//top left moving platform
                    pieces.Add(new SpecialTerrain(225, 275, 30, 200, 250, 475, Movement.Vertical, Color.White));//bottom left moving platform
                    pieces.Add(new SpecialTerrain(425, 25, 30, 200, 25, 250, Movement.Vertical, Color.White));//top left moving platform
                    pieces.Add(new SpecialTerrain(425, 275, 30, 200, 250, 475, Movement.Vertical, Color.White));//bottom left moving platform
                    pieces.Add(new SpecialTerrain(625, 25, 30, 200, 25, 250, Movement.Vertical, Color.White));//top left moving platform
                    pieces.Add(new SpecialTerrain(625, 275, 30, 200, 250, 475, Movement.Vertical, Color.White));//bottom left moving platform
                    //pieces.Add(new SpecialTerrain(300, 300, 30, 30, 600, 300, "horizontal"));
                    pieces.Add(new Terrain(750, 0, 50, 350, Color.White));//right wall
                    pieces.Add(new Terrain(710, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 450, 100, 40, Color.White));//left lower floor
                    pieces.Add(new Terrain(0, 0, 30, 200, Color.White));//left wall
                    pieces.Add(new Terrain(0, 0, 100, 30, Color.White));//left ceiling
                    pieces.Add(new Terrain(0, 170, 100, 30, Color.White));//left lower platform above floor
                    pieces.Add(new SpecialTerrain(300, 450, 50, 30, 400, 300, Movement.Horizontal, Color.White));//bottom sideways moving platform
                    pieces.Add(new SpecialTerrain(450, 300, 30, 50, 300, 400, Movement.Vertical, Color.White));//bottom vertical moving platform
                    pieces.Add(new Terrain(200, 170, 300, 30, Color.White));//platform covered in spikes
                    pieces.Add(new DeathObject(200, 140, 300, 30, "none", Color.White));//top spikes
                    pieces.Add(new DeathObject(200, 200, 300, 30, "down", Color.White));//bottom spikes
                    pieces.Add(new SpecialTerrain(300, 0, 20, 60, 0, 140, Movement.Vertical, Color.White));//top left moving platform
                    pieces.Add(new SpecialTerrain(400, 0, 20, 60, 0, 140, Movement.Vertical, Color.White));//top right moving platform
                    pieces.Add(new Terrain(500, 200, 40, 300, Color.White));//wall adjacent to spike platform
                    pieces.Add(new Terrain(540, 450, 300, 40, Color.White));//right floor
                    pieces.Add(new Terrain(750, 0, 50, 500, Color.White));//right wall
                    pieces.Add(new LevelGoal(650, 400, 50, 50)); //LOS GOALLLLLLOSSSSSSS
                    playerY = 370;
                    break;

            }
            return pieces;
        }

    }
}
