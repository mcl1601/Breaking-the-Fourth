using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BreakingTheFourth
{
    class Terrain
    {
        //Here's where we get to the meat of the collision detection
        //Are we gonna need Intersect methods for both the player and the ground? Seems redundant.
        //If we're gonna make the level move around the player, we'll need X and Y coordinates to move. How does that even work?
        //Do we make the ground a Rectangle? This will probably be the trickiest class.


        Texture2D image;
        Rectangle position;
        public Terrain(int x, int y, int width, int height)
        {
            position = new Rectangle(x, y, width, height);
        }
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public Rectangle Position
        {
            get { return position; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }
                //method for collision detection for player and bullet
        /*public bool CollisionDetected(Rectangle entity)
        {
            if()
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
