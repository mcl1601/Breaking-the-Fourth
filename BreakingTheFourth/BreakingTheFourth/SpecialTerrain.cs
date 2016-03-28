using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakingTheFourth
{
    class SpecialTerrain : Terrain
    {
        //This class will inherit from Terrain
        //Since these will all likely be moving platforms, we will definitely need x and y coordinates and speed values for these
        //Again the same question with the Collision Detection. Do we need a method for all of them?
        //These will definitely require a parameterized constructor.
        //Separate method for spikes?

        // Constructor
        //private Texture2D image;
        private Rectangle position;
        private bool movingUp;

        public SpecialTerrain(int x, int y, int width, int height) : base (x, y,width, height)
        {
            position = new Rectangle(x, y, width, height);
            movingUp = true;
        }

        // moving platforms
        public override void Update()
        {
            if (movingUp == true)
            {
                Y--;
                if(Y == 300)
                {
                    movingUp = false;
                }
            }
            else
            {
                Y++;
                if(Y == 450)
                {
                    movingUp = true;
                }
            }
            
        }
    }
}
