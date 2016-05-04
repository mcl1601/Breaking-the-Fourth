
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace BreakingTheFourth
{
    //Contributors:
    //Mike O'Donnell - Worked on base code and logic for generating level, came up with the idea to divide levels into screens. Designed and coded all of the screens.
    //that change when player hits stage right.
    //Matt Lienhard - Came up with NextScreen structure, hard coded in values
    //Kat Weis - Implemented the num of bullets
    class Level1
    {

        // list to hold the terrain pieces
        List<Terrain> pieces = new List<Terrain>();
        //Field to hold the player's ending position
        int playerY;
        Song bgMusic;
        Color bgColor = Color.Aqua;
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
            bullet.Bullets = 500;//temp till we decide how many bullets are needed per puzzle
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
                    playerY = 370;
                    break;
                case 2:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    pieces.Add(new Terrain(0, 0, 800, 40)); //top
                    pieces.Add(new Terrain(0, 450, 150, 40)); // left floor
                    pieces.Add(new Terrain(60, 440, 15, 10)); //thingy to stop you from walking right off a cliff
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(775, 0, 25, 300)); // right wall
                    pieces.Add(new Terrain(550, 450, 400, 40)); // right floor
                    playerY = 370;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(0, 450, 800, 40)); //floor
                    pieces.Add(new DeathObject(350, 410, 100, 40)); //spikes
                    pieces.Add(new Terrain(350, 0, 100, 40)); //ceiling
                    pieces.Add(new Terrain(350, 225, 100, 40)); //platform
                    playerY = 370;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(0, 450, 800, 40)); //floor
                    pieces.Add(new Terrain(60, 440, 15, 10)); //thingy to stop you from walking right onto the spikes
                    pieces.Add(new DeathObject(140, 410, 570, 40)); //floor spikes
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new Terrain(100, 225, 75, 40)); //first platform
                    pieces.Add(new Terrain(225, 140, 75, 40)); // 1st top platform
                    pieces.Add(new DeathObject(225, 100, 75, 40)); //1st top platform spikes
                    pieces.Add(new Terrain(225, 325, 75, 40)); //1st bottom platform
                    pieces.Add(new Terrain(550, 140, 75, 40)); //2nd top platform
                    pieces.Add(new Terrain(550, 325, 75, 40)); //2nd bottom platform
                    pieces.Add(new DeathObject(550, 285, 75, 40)); //2nd bottom platform spikes 
                    pieces.Add(new Terrain(375, 0, 40, 195)); //divider
                    playerY = 370;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    pieces.Add(new Terrain(0, 0, 25, 300)); // left wall
                    pieces.Add(new Terrain(0, 450, 150, 40)); //left floor
                    pieces.Add(new Terrain(775, 0, 25, 500)); //right wall
                    pieces.Add(new Terrain(0, 0, 800, 40)); //ceiling
                    pieces.Add(new Terrain(150, 125, 40, 400)); // first wall
                    pieces.Add(new Terrain(400, 40, 250, 140)); //top obstacle
                    pieces.Add(new Terrain(400, 280, 400, 300)); //bottom obstacle
                    pieces.Add(new Terrain(700, 240, 100, 40)); //platform to shoot
                    pieces.Add(new LevelGoal(725, 110, 50, 50)); //GOOOOOAAAAAAALLLLLLLL
                    playerY = 370;
                    break;

            }
            return pieces;
        }
    }
}
