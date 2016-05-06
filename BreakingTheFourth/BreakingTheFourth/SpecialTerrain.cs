using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakingTheFourth
{
    //Contributors:
    //Mike O'Donnell - Helped plan on logic for getting the block to move up and down a constant distance. Also added the beginning comments for outlining
    //Kat Weis - did inheriting from terrain and adjustments to make that work
    //Matt Lienhard - worked on moving platforms mainly
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
        private bool movingLeft;
        private int maxY = -1;
        private int minY = -1;
        private int maxX = -1;
        private int minX = -1;
        FileIO movement = new FileIO();

        public SpecialTerrain(int x, int y, int width, int height, int max, int min, string axis) : base (x, y,width, height)
        {
            position = new Rectangle(x, y, width, height);
            if(axis == "horizontal")
            {
                movingLeft = true;
                maxX = max;
                minX = min;
            }
            else if (axis == "vertical")
            {
                movingUp = true;
                maxY = max;
                minY = min;
            }
        }

        // properties
        public int MaxY
        {
            get { return maxY; }
        }

        public int MinY
        {
            get { return minY; }
        }
        public int MaxX
        {
            get { return maxX; }
        }

        public int MinX
        {
            get { return minX; }
        }
        public bool MovingUp
        {
            get { return movingUp; }
        }

        // moving platforms
        public override void Update()
        {
            if (movingUp == true)
            {
                Y--;
                if(Y <= maxY)
                {
                    movingUp = false;
                }
            }
            else if(movingLeft == true)
            {
                X--;
                if (X <= minX)
                {
                    movingLeft = false;
                }
            }
            else if(maxX < 0 || minX < 0)
            {
                Y++;
                if(Y >= minY)
                {
                    movingUp = true;
                }
            }
            else
            {
                X++;
                if (X >= maxX)
                {
                    movingLeft = true;
                }
            }
            
        }
    }
}
