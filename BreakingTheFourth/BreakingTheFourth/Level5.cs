using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace BreakingTheFourth
{
    class Level5
    {
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
                    pieces.Add(new Terrain(0, 450, 150, 40, Color.White));//left floor
                    pieces.Add(new DisappearingPlatforms(200, 450, 50, 50, Color.Red, DisappearingPlatforms.Disappear.Blinking));//first blinking platform
                    pieces.Add(new SpecialTerrain(300, 150, 50, 50, 150, 450, Movement.Vertical, Color.White));//first moving platform
                    pieces.Add(new Terrain(400, 0, 40, 100, Color.White));//first top wall
                    pieces.Add(new DisappearingPlatforms(400, 100, 20, 50, Color.White, DisappearingPlatforms.Disappear.Intangible));//intangible wall between first wall set
                    pieces.Add(new Terrain(400, 150, 40, 400, Color.White));
                    playerY = 370;
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
