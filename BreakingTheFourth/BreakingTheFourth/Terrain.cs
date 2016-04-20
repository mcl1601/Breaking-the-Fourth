using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BreakingTheFourth
{
    //Contributors:
    //Kat Weis - did collision detection and tweaked so special terrain could inherit
    //Mike O'Donnell - Created Rectangle and Texture and decided to put each block of Terrain in a list. And added beginning comments 
    //to outline.
    class Terrain
    {
        //Here's where we get to the meat of the collision detection
        //Are we gonna need Intersect methods for both the player and the ground? Seems redundant.
        //If we're gonna make the level move around the player, we'll need X and Y coordinates to move. How does that even work?
        //Do we make the ground a Rectangle? This will probably be the trickiest class.


        private Texture2D image;
        private Rectangle position;
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
            if(position.Intersects(entity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Update()
        {

        }
    }
}
