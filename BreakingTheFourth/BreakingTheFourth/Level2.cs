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
        //Mike O'Donnell - Anything involving level generation
        //Kat Weis - Implemented the num of bullets, background color and music

        // list to hold the terrain pieces
        List<Terrain> pieces = new List<Terrain>();
        private int numBullets;
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
        public int NumBullets
        {
            get { return numBullets; }
        }
        // Next Screen method
        public List<Terrain> NextScreen(int screen, Bullet bullet)
        {
            // switch to determine which screen to draw
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    bullet.Bullets = 2;
                    numBullets = 2;
                    pieces.Add(new Terrain(0, 0, 25, 600, Color.White)); // left wall
                    pieces.Add(new Terrain(0, 450, 200, 40, Color.White)); //left floor
                    pieces.Add(new Terrain(0, 0, 800, 40, Color.White)); //ceiling
                    pieces.Add(new SpecialTerrain(200, 470, 40, 40, 200, 490, Movement.Vertical, Color.White)); //moving platform
                    pieces.Add(new Terrain(250, 210, 50, 400, Color.White)); //upper left floor
                    pieces.Add(new Terrain(370, 0, 40, 300, Color.White)); // first pillar
                    pieces.Add(new Terrain(300, 400, 100, 40, Color.White)); //first platform
                    pieces.Add(new Terrain(500, 200, 40, 240, Color.White)); //second pillar
                    pieces.Add(new Terrain(600, 350, 75, 40, Color.White)); //second platform
                    pieces.Add(new Terrain(620, 0, 40, 200, Color.White)); //third pillar
                    pieces.Add(new Terrain(725, 210, 100, 400, Color.White));// upper right floor
                    playerY = 130;                    
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new pieces
                    bullet.Bullets = 5;
                    numBullets = 5;
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White)); // left floor
                    pieces.Add(new Terrain(60, 440, 15, 10, Color.White)); //thingy to stop you from walking right off a cliff
                    pieces.Add(new Terrain(0, 0, 25, 300, Color.White)); // left wall
                    pieces.Add(new Terrain(150, 0, 40, 350, Color.White)); //left center wall
                    pieces.Add(new Terrain(350, 175, 40, 400, Color.White)); //right center wall
                    //platforms from bottom to top
                    pieces.Add(new Terrain(250, 450, 100, 20, Color.White));
                    pieces.Add(new Terrain(190, 320, 50, 20, Color.White));
                    pieces.Add(new Terrain(300, 250, 50, 20, Color.White));
                    pieces.Add(new Terrain(190, 150, 50, 20, Color.White));
                    pieces.Add(new SpecialTerrain(450, 125, 40, 40, 50, 250, Movement.Vertical, Color.White));//moving platform
                    pieces.Add(new Terrain(600, 250, 200, 300, Color.White)); //right floor
                    pieces.Add(new DeathObject(600, 210, 50, 40, "none", Color.White)); //spikes
                    playerY = 170;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    bullet.Bullets = 2;
                    numBullets = 2;
                    pieces.Add(new Terrain(0, 0, 25, 300, Color.White)); // left wall 
                    pieces.Add(new Terrain(750, 0, 50, 110, Color.White)); // right wall(upper)
                    pieces.Add(new Terrain(750, 200, 50, 250, Color.White)); // right wall (lower)
                    pieces.Add(new Terrain(710, 200, 40, 50, Color.White)); //right wall platform
                    pieces.Add(new Terrain(0, 450, 800, 40, Color.White)); // floor
                    pieces.Add(new Terrain(125, 0, 20, 380, Color.White)); // first obstacle (top)
                    pieces.Add(new Terrain(125, 425, 20, 25, Color.White)); // first obstacle (bottom)
                    pieces.Add(new Terrain(350, 0, 50, 260, Color.White)); // second obstacle (top)
                    pieces.Add(new Terrain(350, 350, 50, 100, Color.White)); //second obstacle (bottom)
                    pieces.Add(new DeathObject(400, 400, 350, 50, "none", Color.White)); //spikes
                    playerY = 120;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    bullet.Bullets = 3;
                    numBullets = 3;
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300, Color.White)); // left wall
                    pieces.Add(new SpecialTerrain(200, 440, 60, 60, 200, 440, Movement.Vertical, Color.White)); //moving platform
                    pieces.Add(new Terrain(275, 0, 40, 200, Color.White)); //first obstacle (top)
                    pieces.Add(new Terrain(275, 260, 40, 60, Color.White)); //first obstacle (middle)
                    pieces.Add(new Terrain(275, 380, 40, 100, Color.White)); //first obstacle (bottom)
                    pieces.Add(new Terrain(470, 200, 20, 60, Color.White)); //top floating platform (vertical)
                    pieces.Add(new Terrain(370, 260, 120, 20, Color.White)); //top floating platform (horizontal)
                    pieces.Add(new Terrain(400, 320, 20, 60, Color.White)); //bottom floating platform
                    pieces.Add(new Terrain(500, 0, 800, 40, Color.White)); //ceiling
                    pieces.Add(new Terrain(500, 120, 40, 300, Color.White)); // giant floating wall in the middle, ya can't miss it
                    pieces.Add(new Terrain(500, 450, 350, 40, Color.White)); //right floor
                    pieces.Add(new Terrain(700, 200, 60, 30, Color.White)); //top spike platform
                    pieces.Add(new Terrain(540, 250, 80, 30, Color.White)); //bottom spike platform
                    pieces.Add(new Terrain(760, 0, 50, 230, Color.White)); //right wall (top)
                    pieces.Add(new Terrain(760, 380, 50, 400, Color.White)); //right wall (bottom)
                    pieces.Add(new Terrain(720, 380, 40, 20, Color.White)); //bottom right wall cliff
                    pieces.Add(new DeathObject(700, 170, 60, 30, "none", Color.White)); //top spikes
                    pieces.Add(new DeathObject(540, 220, 80, 30, "none", Color.White)); //middle spikes
                    pieces.Add(new DeathObject(500, 420, 260, 30, "none", Color.White)); //bottom spikes
                    playerY = 300;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    bullet.Bullets = 2;
                    numBullets = 2;
                    pieces.Add(new Terrain(0, 450, 225, 40, Color.White)); // left floor
                    pieces.Add(new Terrain(0, 0, 25, 300, Color.White)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 500, Color.White)); // right wall
                    pieces.Add(new Terrain(225, 150, 50, 500, Color.White)); //big wall
                    pieces.Add(new Terrain(0, 0, 800, 40, Color.White)); //ceiling
                    pieces.Add(new SpecialTerrain(325, 90, 20, 20, 40, 120, Movement.Vertical, Color.White)); //tiny moving platform
                    pieces.Add(new SpecialTerrain(450, 90, 50, 50, 40, 90, Movement.Vertical, Color.White)); //bigger moving platform
                    pieces.Add(new Terrain(400, 140, 500, 30, Color.White)); //platform that connects to bigger moving platform
                    pieces.Add(new DeathObject(500, 110, 250, 30, "none", Color.White)); //YOU SHALL NOT PASS
                    pieces.Add(new Terrain(500, 450, 275, 40, Color.White)); //right floor
                    pieces.Add(new DeathObject(600, 420, 100, 30, "none", Color.White)); //spikes on right floor
                    pieces.Add(new Terrain(400, 170, 40, 130, Color.White)); //wall thing
                    pieces.Add(new LevelGoal(710, 360, 50, 50)); //GOOOOOOOAAAAAAAAALLLLLLLL
                    playerY = 370;
                    break;


            }
            return pieces;
        }
    }
}
