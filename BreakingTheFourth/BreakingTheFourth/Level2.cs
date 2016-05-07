using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    class Level2
    {
        //Contributors:
        //Kat Weis - Implemented the num of bullets
        //Mike O'Donnell - Designed and coded of the screens

        // list to hold the terrain pieces
        List<Terrain> pieces = new List<Terrain>();
        int playerY;
        Song bgMusic;
        Color bgColor = Color.Chartreuse;
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
        // Next Screen method
        public List<Terrain> NextScreen(int screen, Bullet bullet)
        {
            bullet.Bullets = 500;
            // switch to determine which screen to draw
            switch (screen)
            {//////////////////////////////////////////////////////////////////issue on level 2 screen 1 where if you walk into the left wall you lose a life
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 25, 600)); // left wall
                    pieces.Add(new Terrain(0, 450, 200, 40)); //left floor
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new SpecialTerrain(200, 470, 40, 40, 200, 490, "vertical")); //moving platform
                    pieces.Add(new Terrain(250, 210, 50, 400)); //upper left floor
                    pieces.Add(new Terrain(370, 0, 40, 300)); // first pillar
                    pieces.Add(new Terrain(300, 400, 100, 40)); //first platform
                    pieces.Add(new Terrain(500, 200, 40, 240)); //second pillar
                    pieces.Add(new Terrain(600, 350, 75, 40)); //second platform
                    pieces.Add(new Terrain(620, 0, 40, 200)); //third pillar
                    pieces.Add(new Terrain(725, 210, 100, 400));// upper right floor
                    playerY = 130;                    
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(60, 440, 15, 10)); //thingy to stop you from walking right off a cliff
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(150, 0, 40, 350)); //left center wall
                    pieces.Add(new Terrain(350, 175, 40, 400)); //right center wall
                    //platforms from bottom to top
                    pieces.Add(new Terrain(250, 450, 100, 20));
                    pieces.Add(new Terrain(190, 320, 50, 20));
                    pieces.Add(new Terrain(300, 250, 50, 20));
                    pieces.Add(new Terrain(190, 150, 50, 20));
                    pieces.Add(new SpecialTerrain(450, 125, 40, 40, 50, 250, "vertical"));//moving platform
                    pieces.Add(new Terrain(600, 250, 200, 300)); //right floor
                    pieces.Add(new DeathObject(600, 210, 50, 40, "none")); //spikes
                    playerY = 170;
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
                    pieces.Add(new DeathObject(400, 400, 350, 50, "none")); //spikes
                    playerY = 120;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new SpecialTerrain(200, 440, 60, 60, 200, 440, "vertical")); //moving platform
                    pieces.Add(new Terrain(275, 0, 40, 200)); //first obstacle (top)
                    pieces.Add(new Terrain(275, 260, 40, 60)); //first obstacle (middle)
                    pieces.Add(new Terrain(275, 380, 40, 100)); //first obstacle (bottom)
                    pieces.Add(new Terrain(470, 200, 20, 60)); //top floating platform (vertical)
                    pieces.Add(new Terrain(370, 260, 120, 20)); //top floating platform (horizontal)
                    pieces.Add(new Terrain(400, 320, 20, 60)); //bottom floating platform
                    pieces.Add(new Terrain(500, 0, 800, 40)); //ceiling
                    pieces.Add(new Terrain(500, 120, 40, 300)); // giant floating wall in the middle, ya can't miss it
                    pieces.Add(new Terrain(500, 450, 350, 40)); //right floor
                    pieces.Add(new Terrain(700, 200, 60, 30)); //top spike platform
                    pieces.Add(new Terrain(540, 250, 80, 30)); //bottom spike platform
                    pieces.Add(new Terrain(760, 0, 50, 230)); //right wall (top)
                    pieces.Add(new Terrain(760, 380, 50, 400)); //right wall (bottom)
                    pieces.Add(new Terrain(720, 380, 40, 20)); //bottom right wall cliff
                    pieces.Add(new DeathObject(700, 170, 60, 30, "none")); //top spikes
                    pieces.Add(new DeathObject(540, 220, 80, 30, "none")); //middle spikes
                    pieces.Add(new DeathObject(500, 420, 260, 30, "none")); //bottom spikes
                    playerY = 300;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 450, 225, 40)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 500)); // right wall
                    pieces.Add(new Terrain(225, 150, 50, 500)); //big wall
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new SpecialTerrain(325, 90, 20, 20, 40, 120, "vertical")); //tiny moving platform
                    pieces.Add(new SpecialTerrain(450, 90, 50, 50, 40, 90, "vertical")); //bigger moving platform
                    pieces.Add(new Terrain(400, 140, 500, 30)); //platform that connects to bigger moving platform
                    pieces.Add(new DeathObject(500, 110, 250, 30, "none")); //YOU SHALL NOT PASS
                    pieces.Add(new Terrain(500, 450, 275, 40)); //right floor
                    pieces.Add(new DeathObject(600, 420, 100, 30, "none")); //spikes on right floor
                    pieces.Add(new Terrain(400, 170, 40, 130)); //wall thing
                    pieces.Add(new LevelGoal(710, 360, 50, 50)); //GOOOOOOOAAAAAAAAALLLLLLLL
                    playerY = 370;
                    break;


            }
            return pieces;
        }
    }
}
