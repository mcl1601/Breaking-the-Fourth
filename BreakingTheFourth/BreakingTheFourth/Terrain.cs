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
        public bool CollisionDetected(Rectangle entityPos)
        {
            if(position.Intersects(entityPos))
            {
                //OffsetPlayer(entityPos);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void OffsetPlayer(Rectangle entityPos)
        {
            if (entityPos.Bottom > position.Top)
            {
                entityPos.Offset(0, position.Top - entityPos.Bottom);
                entityPos.Y = Y + position.Top - entityPos.Bottom;
            }
            if (entityPos.Top < position.Bottom)
            {
                entityPos.Offset(0, position.Bottom - entityPos.Top);
                entityPos.Y = Y + position.Bottom - entityPos.Top;
            }
            if (entityPos.Right > position.Left)
            {
                entityPos.Offset(position.Left - entityPos.Right, 0);
                entityPos.X = X + position.Left - entityPos.Right;
            }
        }
    }
}
