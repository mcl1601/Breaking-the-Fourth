using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakingTheFourth
{
    //Contributors:
    //Mike O'Donnell - Everything here
    class LevelGoal : Terrain
    {
        private Rectangle position;
        private Texture2D image;
        private float rotation;

        public LevelGoal(int x, int y, int width, int height) : base(x,y,width,height)
        {
            position = new Rectangle(x, y, width, height);
            rotation = 0;
        }
        public new Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public override void Update()
        {
            Rotation += 0.25f;
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
