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

        public LevelGoal(int x, int y, int width, int height) : base(x,y,width,height, Color.White)
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
            Rotation += 0.05f;
        }
        public new void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle(X + 25, Y + 25, Width, Height), null, Color.White, rotation, new Vector2(100,100), SpriteEffects.None, 0);
        }
    }
}
