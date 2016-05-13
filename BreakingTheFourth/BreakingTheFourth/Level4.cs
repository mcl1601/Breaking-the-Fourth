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
    class Level4
    {
        List<Terrain> pieces = new List<Terrain>();
        private int numBullets;
        int playerY;
        Song bgMusic;
        Color bgColor = Color.Orange;
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
            switch(screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 30, 500, Color.White));//left wall
                    pieces.Add(new Terrain(0, 450, 300, 40, Color.White));//left floor
                    pieces.Add(new Terrain(300, 200, 40, 300, Color.White));//right wall connected to left floor
                    pieces.Add(new Terrain(200, 250, 100, 40, Color.White));//right spiked floor
                    pieces.Add(new DeathObject(200, 230, 100, 20, "none", Color.White));//said spikes
                    pieces.Add(new Terrain(30, 250, 100, 40, Color.White));//left spiked floor
                    pieces.Add(new DeathObject(30, 230, 100, 20,"none", Color.White));//said spikes
                    pieces.Add(new Terrain(0, 0, 300, 10, Color.White));//left ceiling
                    pieces.Add(new SpecialTerrain(40, 130, 70, 30, 700, 40, Movement.Horizontal, Color.White));//moving platform
                    pieces.Add(new Terrain(550, 0, 50, 250, Color.White));//giant spiked wall of death in the middle, hard to miss
                    pieces.Add(new DeathObject(500, 0, 50, 250, "left", Color.White));//left facing spikes
                    pieces.Add(new DeathObject(600, 0, 50, 250, "right", Color.White));//right facing spikes
                    pieces.Add(new Terrain(530, 450, 100, 40, Color.White));//platform under death wall of death
                    pieces.Add(new Terrain(710, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new terrain pieces
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new SpecialTerrain(700, 450, 100, 30, 700, 200,Movement.Horizontal, Color.White));//Bottom moving platform
                    pieces.Add(new SpecialTerrain(700, 200, 50, 30, 700, 200, Movement.Horizontal, Color.White));//Bottom moving platform of top pair
                    pieces.Add(new SpecialTerrain(700, 50, 100, 30, 700, 200, Movement.Horizontal, Color.White));//top moving platform of top pair
                    pieces.Add(new Terrain(250, 250, 30, 250, Color.White));//first death wall
                    pieces.Add(new DeathObject(220, 250, 30, 250, "left", Color.White));//left facing spikes
                    pieces.Add(new DeathObject(280, 250, 30, 250, "right", Color.White));//right facing spikes
                    pieces.Add(new Terrain(425, 0, 30, 250, Color.White));//second death wall
                    pieces.Add(new DeathObject(395, 0, 30, 250, "left", Color.White));//left facing spikes
                    pieces.Add(new DeathObject(455, 0, 30, 250, "right", Color.White));//right facing spikes
                    pieces.Add(new Terrain(600, 250, 30, 250, Color.White));//third death wall
                    pieces.Add(new DeathObject(570, 250, 30, 250, "left", Color.White));//left facing spikes
                    pieces.Add(new DeathObject(630, 250, 30, 250, "right", Color.White));//right facing spikes
                    pieces.Add(new Terrain(710, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    //add new terrain pieces
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new SpecialTerrain(160, 350, 40, 40, 100, 450, Movement.Vertical, Color.White));//lift next to start
                    pieces.Add(new Terrain(220, 100, 300, 40, Color.White));//spiked platform at the top
                    pieces.Add(new DeathObject(220, 70, 250, 30, "none", Color.White));//said spikes
                    pieces.Add(new Terrain(480, 0, 200, 20, Color.White));//ceiling after spikes
                    pieces.Add(new Terrain(550, 100, 30, 300, Color.White));//left spiked wall
                    pieces.Add(new DeathObject(580, 120, 20, 280, "right", Color.White));//spikes on left wall
                    pieces.Add(new Terrain(730, 100, 30, 250, Color.White));//right spiked wall
                    pieces.Add(new DeathObject(710, 120, 20, 230, "left", Color.White));//spikes on right wall
                    pieces.Add(new SpecialTerrain(550, 180, 30, 30, 730, 550, Movement.Horizontal, Color.White));//first moving platform
                    pieces.Add(new SpecialTerrain(730, 240, 30, 30, 730, 550, Movement.Horizontal, Color.White));//second moving platform
                    pieces.Add(new SpecialTerrain(550, 300, 30, 30, 730, 550, Movement.Horizontal, Color.White));//third moving platform
                    pieces.Add(new SpecialTerrain(730, 360, 30, 30, 730, 550, Movement.Horizontal, Color.White));//fourth moving platform
                    pieces.Add(new SpecialTerrain(550, 450, 30, 30, 730, 550, Movement.Horizontal, Color.White));//fifth moving platform
                    pieces.Add(new Terrain(710, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DeathObject(0, 0, 800, 50, "down", Color.White));//ceiling spikes of imminent demise
                    //Moving blocks from left to right
                    pieces.Add(new SpecialTerrain(150, 250, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new SpecialTerrain(250, 170, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new SpecialTerrain(350, 290, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new SpecialTerrain(450, 50, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new SpecialTerrain(550, 350, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new SpecialTerrain(650, 90, 50, 50, 50, 450, Movement.Vertical, Color.White));
                    pieces.Add(new DeathObject(700, 420, 10, 100,"none", Color.White));//spikes to stop dirty speedrunners
                    pieces.Add(new Terrain(710, 450, 150, 40, Color.White));//right floor
                    playerY = 370;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DeathObject(200, 200, 100, 30, "down", Color.White));//first top spikes
                    pieces.Add(new SpecialTerrain(225, 230, 50, 50, 230, 450, Movement.Vertical, Color.White));//first platform moving up and down
                    pieces.Add(new DeathObject(450, 200, 100, 30, "down", Color.White));//second top spikes
                    pieces.Add(new SpecialTerrain(475, 450, 50, 50, 230, 450, Movement.Vertical, Color.White));//second platform moving up and down
                    pieces.Add(new Terrain(600, 300, 250, 200, Color.White));//right floor
                    pieces.Add(new DeathObject(780, 0, 40, 300, "left", Color.White));//spikes to stop from leaving the right side of the screen. 
                    pieces.Add(new SpecialTerrain(790, 120, 30, 30, 750, 700, Movement.Horizontal, Color.White));//moving platform near end spikes
                    pieces.Add(new Terrain(670, 0, 200, 40, Color.White));//right ceiling
                    pieces.Add(new Terrain(200, 0, 470, 30, Color.White));//upper spiked ceiling
                    pieces.Add(new DeathObject(200, 30, 470, 20, "down", Color.White));//said spikes
                    pieces.Add(new Terrain(200, 170, 470, 30, Color.White));//upper spiked floor
                    pieces.Add(new DeathObject(200, 150, 470, 20, "none", Color.White));//said spikes
                    pieces.Add(new SpecialTerrain(300, 0, 40, 40, 0, 170, Movement.Vertical, Color.White));//left moving platform between them
                    pieces.Add(new SpecialTerrain(500, 170, 40, 40, 0, 170, Movement.Vertical, Color.White));//right moving platform between them
                    pieces.Add(new Terrain(0, 0, 40, 150, Color.White));//upper left wall
                    pieces.Add(new Terrain(0, 150, 150, 40, Color.White));//upper left floor
                    pieces.Add(new LevelGoal(50, 75, 50, 50));//Sorry Mario, our princess is in another mysterious multi-dimensional portal of questionable origin
                    break;
            }
            return pieces;
        }
    }
}
