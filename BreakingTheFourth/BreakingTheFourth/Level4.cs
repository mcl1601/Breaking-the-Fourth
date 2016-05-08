using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    class Level4
    {
        List<Terrain> pieces = new List<Terrain>();
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
                    pieces.Add(new Terrain(0, 0, 40, 500));//left wall
                    pieces.Add(new Terrain(0, 450, 300, 40));//left floor
                    pieces.Add(new Terrain(300, 200, 40, 300));//right wall connected to left floor
                    pieces.Add(new Terrain(200, 250, 100, 40));//right spiked floor
                    pieces.Add(new DeathObject(200, 230, 100, 20, "none"));//said spikes
                    pieces.Add(new Terrain(40, 250, 100, 40));//left spiked floor
                    pieces.Add(new DeathObject(40, 230, 100, 20,"none"));//said spikes
                    pieces.Add(new Terrain(0, 0, 300, 10));//left ceiling
                    pieces.Add(new SpecialTerrain(40, 130, 70, 30, 700, 40, Movement.Horizontal));//moving platform
                    pieces.Add(new Terrain(550, 0, 50, 250));//giant spiked wall of death in the middle, hard to miss
                    pieces.Add(new DeathObject(500, 0, 50, 250, "left"));//left facing spikes
                    pieces.Add(new DeathObject(600, 0, 50, 250, "right"));//right facing spikes
                    pieces.Add(new Terrain(530, 450, 100, 40));//platform under death wall of death
                    pieces.Add(new Terrain(710, 450, 150, 40));//right floor
                    playerY = 370;
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
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
