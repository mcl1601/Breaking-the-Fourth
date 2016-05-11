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
        private Texture2D sideImage;
        private String direction;
        private Color tint;
        public DeathObject(int x, int y, int width, int height, string direction, Color color) : base(x,y,width,height, color)
        {
            position = new Rectangle(x, y, width, height);
            this.direction = direction;
            tint = color;
        }
        public new Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public override Texture2D SideImage
        {
            get { return sideImage; }
            set { sideImage = value; }
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            switch(direction)
            {
                case "none":
                    spriteBatch.Draw(image, position, tint);
                    break;
                case "down":
                    spriteBatch.Draw(image, position, null, tint, 0f, new Vector2(0,0), SpriteEffects.FlipVertically, 0);
                    break;
                case "left":
                    spriteBatch.Draw(sideImage, position, null, tint, 0f, new Vector2(0, 0), SpriteEffects.None, 0);
                    break;
                case "right":
                    spriteBatch.Draw(sideImage, position, null, tint, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                    break;
            }
            
        }

    }
}
