using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    //Contribution comments
    //Kat Weis - background music and color, number of bullets
    class Level5
    {
        //Contribution Comments - 
        //Mike O'Donnell: Anything involving level generation
        List<Terrain> pieces = new List<Terrain>();
        private int numBullets;
        int playerY;
        Song bgMusic;
        Color bgColor = Color.Red;
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
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
                    bullet.Bullets = 1;
                    numBullets = 1;
                    pieces.Add(new Terrain(0, 0, 30, 500, Color.White));//left wall
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DeathObject(150, 460, 600, 30, "none", Color.White));//spikes
                    pieces.Add(new Terrain(150, 450, 600, 10, Color.Transparent));//invisible floor that is totally not a dick move
                    pieces.Add(new Terrain(710, 350, 150, 200, Color.White));//right floor
                    pieces.Add(new Terrain(710, 0, 150, 40, Color.Transparent));//invisible ceiling
                    playerY = 270;
                    break;
                case 2:
                    //Clear the list
                    pieces.Clear();
                    //add new terrain pieces
                    bullet.Bullets = 0;
                    numBullets = 0;
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    //all spikes, blinking platforms, and safe zones from left to right
                    pieces.Add(new DeathObject(155, 430, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(150, 420, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(200, 400, 40, 800, Color.White));
                    pieces.Add(new DeathObject(255, 380, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(250, 370, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(300, 350, 40, 800, Color.White));
                    pieces.Add(new DeathObject(355, 330, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(350, 320, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(400, 300, 40, 800, Color.White));
                    pieces.Add(new DeathObject(455, 280, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(450, 270, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(500, 250, 40, 800, Color.White));
                    pieces.Add(new DeathObject(555, 230, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(550, 220, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(600, 200, 40, 800, Color.White));
                    pieces.Add(new DeathObject(655, 180, 35, 775, "none", Color.White));
                    pieces.Add(new DisappearingPlatforms(650, 170, 40, 10, Color.Red, DisappearingPlatforms.Disappear.Blinking));
                    pieces.Add(new Terrain(700, 150, 100, 800, Color.White));
                    playerY = 80;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    //add new terrain pieces
                    bullet.Bullets = 1;
                    numBullets = 1;
                    pieces.Add(new Terrain(0, 450, 350, 40, Color.White));//left floor
                    pieces.Add(new DisappearingPlatforms(200, 0, 40, 500, Color.White, DisappearingPlatforms.Disappear.Intangible));//unsolid wall
                    pieces.Add(new DisappearingPlatforms(400, 450, 40, 40, Color.White, DisappearingPlatforms.Disappear.Invisible));//first invisible platform
                    pieces.Add(new DisappearingPlatforms(400, 250, 40, 40, Color.White, DisappearingPlatforms.Disappear.Intangible));//trick platform above that one
                    pieces.Add(new DisappearingPlatforms(600, 50, 50, 20, Color.Red, DisappearingPlatforms.Disappear.Blinking));//invisible vertically moving platform
                    pieces.Add(new DisappearingPlatforms(600, 250, 40, 40, Color.White, DisappearingPlatforms.Disappear.Invisible));//second invisible platform
                    pieces.Add(new DisappearingPlatforms(600, 450, 40, 40, Color.White, DisappearingPlatforms.Disappear.Intangible));//trick platform below that one
                    pieces.Add(new DisappearingPlatforms(650, 275, 75, 20, Color.White, DisappearingPlatforms.Disappear.Invisible));//invisible platform above the spikes
                    pieces.Add(new DeathObject(650, 300, 75, 200, "none", Color.White));//spikes
                    pieces.Add(new Terrain(750, 375, 100, 100, Color.White));//right floor
                    playerY = 295;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
                    bullet.Bullets = 3;
                    numBullets = 3;
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DisappearingPlatforms(200, 450, 50, 50, Color.Red, DisappearingPlatforms.Disappear.Blinking));//first blinking platform
                    pieces.Add(new SpecialTerrain(300, 150, 50, 50, 150, 450, Movement.Vertical, Color.White));//first moving platform
                    pieces.Add(new Terrain(400, 0, 40, 100, Color.White));//first top wall
                    pieces.Add(new DisappearingPlatforms(400, 100, 20, 50, Color.White, DisappearingPlatforms.Disappear.Intangible));//intangible wall between first wall set
                    pieces.Add(new Terrain(400, 150, 40, 400, Color.White));//first bottom wall
                    pieces.Add(new Terrain(430, 175, 70, 30, Color.White));//platform between first and second wall set
                    pieces.Add(new Terrain(500, 0, 40, 100, Color.White));//second top wall
                    pieces.Add(new DisappearingPlatforms(500, 100, 40, 50, Color.Red, DisappearingPlatforms.Disappear.Blinking));//blinking wall between second wall set
                    pieces.Add(new Terrain(500, 150, 40, 400, Color.White));//second bottom wall
                    pieces.Add(new DeathObject(535, 275, 65, 250,"none",Color.White));//spikes between second and third wall set
                    pieces.Add(new DisappearingPlatforms(530, 175, 50, 30, Color.White, DisappearingPlatforms.Disappear.Invisible));//platform between second and third wall set
                    pieces.Add(new Terrain(600, 0, 40, 100, Color.White));//third top wall
                    pieces.Add(new DisappearingPlatforms(600, 100, 40, 50, Color.Transparent, DisappearingPlatforms.Disappear.Blinking));//blinking wall between third wall set
                    pieces.Add(new Terrain(600, 150, 40, 400, Color.White));//third bottom wall
                    pieces.Add(new DisappearingPlatforms(700, 100, 50, 50, Color.White, DisappearingPlatforms.Disappear.Invisible));//invisible wall in front of intangible wall
                    pieces.Add(new DisappearingPlatforms(750, 0, 50, 800, Color.White, DisappearingPlatforms.Disappear.Intangible));//intangible wall at the end of the level
                    pieces.Add(new DisappearingPlatforms(650, 450, 100, 100, Color.White, DisappearingPlatforms.Disappear.Invisible));//invisible exit
                    playerY = 370;
                    break;
                case 5:
                    //clear the list
                    pieces.Clear();
                    //add new pieces
                    bullet.Bullets = 6;
                    numBullets = 6;
                    pieces.Add(new Terrain(0, 450, 200, 40, Color.White));//left floor
                    pieces.Add(new Terrain(0, 0, 100, 10, Color.White));//left ceiling
                    pieces.Add(new DisappearingPlatforms(0, 130, 100, 20, Color.Red, DisappearingPlatforms.Disappear.Blinking));//first blinking platform
                    pieces.Add(new Terrain(100, 0, 300, 50, Color.White));//ceiling indentation
                    pieces.Add(new Terrain(100, 100, 30, 400, Color.White));//first wall
                    pieces.Add(new Terrain(130, 100, 400, 10, Color.White));//floor that extends from wall
                    pieces.Add(new DisappearingPlatforms(100, 50, 30, 50, Color.Transparent, DisappearingPlatforms.Disappear.Blinking));//second blinking platform
                    pieces.Add(new Terrain(530, 30, 100, 170, Color.White));//wall after first tunnel
                    pieces.Add(new Terrain(530, 250, 100, 800, Color.White));//wall under that one
                    pieces.Add(new DisappearingPlatforms(600, 30, 30, 220,Color.White,DisappearingPlatforms.Disappear.Intangible));//Intangible platform in between those two walls
                    pieces.Add(new Terrain(750, 0, 50, 800, Color.White));//Right wall
                    pieces.Add(new DisappearingPlatforms(630, 280, 120, 20, Color.Red, DisappearingPlatforms.Disappear.Invisible));//blinking platform connecting right wall and other wall
                    pieces.Add(new Terrain(430, 100, 20, 230, Color.White));//thin wall
                    pieces.Add(new Terrain(470, 425, 60, 100, Color.White));//floor attached to wall
                    pieces.Add(new SpecialTerrain(350, 425, 20, 20, 450, 350, Movement.Horizontal, Color.White));//bottom right moving platform
                    pieces.Add(new SpecialTerrain(300, 450, 20, 20, 300, 200, Movement.Horizontal, Color.White));//bottom left moving platform
                    pieces.Add(new DisappearingPlatforms(200, 100, 30, 100, Color.White, DisappearingPlatforms.Disappear.Intangible));//intangible wall that platform moves under
                    pieces.Add(new Terrain(200, 200, 30, 130, Color.White));//wall that platform moves under
                    pieces.Add(new DisappearingPlatforms(130, 200, 70, 20, Color.Red, DisappearingPlatforms.Disappear.Blinking));//blinking platform next to intangible wall
                    pieces.Add(new DeathObject(400, 120, 30, 210, "left", Color.White));//spikes connected to thin wall
                    pieces.Add(new DeathObject(230, 300, 200, 30, "none", Color.White));//spike floor
                    pieces.Add(new DeathObject(230, 110, 200, 30, "down", Color.White));//spike ceiling
                    pieces.Add(new LevelGoal(325, 170, 50, 50));//CONGRATS KID YA BEAT BREAKING THE FOURTH
                    break;
            }
            return pieces;
        }
    }
}
