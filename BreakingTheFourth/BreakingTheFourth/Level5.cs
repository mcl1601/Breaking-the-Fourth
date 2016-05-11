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
        // Next Screen method
        public List<Terrain> NextScreen(int screen, Bullet bullet)
        {
            bullet.Bullets = 500;
            switch (screen)
            {
                case 1:
                    // clear the list
                    pieces.Clear();
                    // add new terrain pieces
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
                    playerY = 370;
                    break;
                case 3:
                    // clear the list
                    pieces.Clear();
                    //add new terrain pieces
                    playerY = 370;
                    break;
                case 4:
                    // clear the list
                    pieces.Clear();
                    // add new pieces
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
