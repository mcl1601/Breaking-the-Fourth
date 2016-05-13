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
    //Kat Weis - did collision detection and tweaked so special terrain could inherit, tweaked so that terrain could be different colors,
    //and tweaked so that Disappearing platforms could inherit indirectly from it
    //Mike O'Donnell - Created Rectangle and Texture and decided to put each block of Terrain in a list. And added beginning comments 
    //to outline.
    class Terrain
    {
        //Here's where we get to the meat of the collision detection
        //Are we gonna need Intersect methods for both the player and the ground? Seems redundant.
        //If we're gonna make the level move around the player, we'll need X and Y coordinates to move. How does that even work?
        //Do we make the ground a Rectangle? This will probably be the trickiest class.

        protected Texture2D sideImage;
        private Texture2D image;
        private Rectangle position;
        private Color tint;
        public Terrain(int x, int y, int width, int height, Color color)
        {
            position = new Rectangle(x, y, width, height);
            tint = color;
        }
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public virtual Texture2D SideImage
        {
            get { return sideImage; }
            set { sideImage = value; }
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
            spriteBatch.Draw(image, position, tint);
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
