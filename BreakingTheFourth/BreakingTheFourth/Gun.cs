
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BreakingTheFourth
{
    //Mike O'Donnell - everything here
    class Gun
    {
        //properties for the texture and the rectangle
        private Texture2D gunImage;
        private Rectangle gunPosition;
        //property for rotation
        //Constructor to call
        public Gun(int x, int y, int width, int height)
        {
            gunPosition = new Rectangle(x, y, width, height);
        }
        //Field for image
        public Texture2D GunImage
        {
            get { return gunImage; }
            set { gunImage = value; }
        }
        //Field for position
        public Rectangle GunPosition
        {
            get { return gunPosition; }
        }
        //Field for rotation

        public int X
        {
            get { return gunPosition.X; }
            set { gunPosition.X = value; }
        }
        public int Y
        {
            get { return gunPosition.Y; }
            set { gunPosition.Y = value; }
        }
        //Draw method
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(gunImage, gunPosition, Color.White);
        }
    }
}
