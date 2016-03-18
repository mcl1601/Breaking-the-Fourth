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
        /*public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public Rectangle Position
        {
            get { return position; }
        }
        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public int Width { get { return position.Width; } }
        public int Height { get { return position.Height; } }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }
        //method for collision detection for player and bullet
        public bool CollisionDetected(Rectangle entity)
        {
            /*if (position.Intersects(entity) && movingUp == true)
            {
                entity.Y += 10;
                return true;
            }
            if (position.Intersects(entity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
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
