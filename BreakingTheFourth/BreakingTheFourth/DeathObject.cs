using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakingTheFourth
{
    //Contributors:
    //Mike O'Donnell - Everything here
    class DeathObject : Terrain
    {
        private Rectangle position;
        private Texture2D image;
        public DeathObject(int x, int y, int width, int height) : base(x,y,width,height)
        {
            position = new Rectangle(x, y, width, height);
        }
        public new Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }

    }
}
