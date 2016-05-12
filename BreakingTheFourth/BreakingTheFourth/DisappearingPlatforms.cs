using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakingTheFourth
{
    class DisappearingPlatforms: SpecialTerrain
    {
        public enum Disappear
        {
            Visible,
            Invisible,
            Blinking,
            Intangible
        }
        //fields
        private Texture2D image;
        private Rectangle position;
        private bool movingUp = false;
        private bool movingLeft = false;
        //max and mins
        private int maxY = -1;
        private int minY = -1;
        private int maxX = -1;
        private int minX = -1;
        private Color tint;
        private Disappear type;
        private Movement direction;
        private int timer = 0;
        FileIO movement = new FileIO();
        //properties
        public Disappear Type
        {
            get { return type; }
        }
        public Color Tint
        {
            get { return tint; }
        }
        // Constructor
        public DisappearingPlatforms(int x, int y, int width, int height, int max, int min, Movement axis, Color color, Disappear version) 
            : base (x, y,width, height, max, min, axis, color)
        {
            direction = axis;
            tint = color;
            image = base.image;
            type = version;
            position = new Rectangle(x, y, width, height);
            //determines where to set max and min and where its moving
            if (axis == Movement.Horizontal)
            {
                movingLeft = true;
                maxX = max;
                minX = min;
            }
            else if (axis == Movement.Vertical)
            {
                movingUp = true;
                maxY = max;
                minY = min;
            }
        }
        public DisappearingPlatforms(int x, int y, int width, int height, Color color, Disappear version)
            : base(x, y, width, height, -1, -1, Movement.None, color)
        {
            direction = Movement.None;
            tint = color;
            image = base.image;
            type = version;
            position = new Rectangle(x, y, width, height);
        }

        // properties
        public new int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public new int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public new Texture2D Image
        {
            set { image = value; }
        }

        // moving platforms
        public override void Update()
        {
            //moving up
            if (movingUp == true)
            {
                Y--;
                if (Y <= maxY)
                {
                    movingUp = false;
                }
            }
            //moving left
            else if (movingLeft == true)
            {
                X--;
                if (X <= minX)
                {
                    movingLeft = false;
                }
            }
            //moving down
            else if (movingUp == false && direction == Movement.Vertical)
            {
                Y++;
                if (Y >= minY)
                {
                    movingUp = true;
                }
            }
            //moving right
            else if(movingLeft == false && direction == Movement.Horizontal)
            {
                X++;
                if (X >= maxX)
                {
                    movingLeft = true;
                }
            }
            //increase timer
            timer++;
            if(type == Disappear.Blinking)
            {
                if(tint == Color.Transparent && timer > 60)
                {
                    tint = Color.Red;
                    timer = 0;
                }
                if (tint == Color.Red && timer > 60)
                {
                    tint = Color.Transparent;
                    timer = 0;
                }
            }
            if(type == Disappear.Invisible)
            {
                tint = Color.Transparent;
            }
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }
        //had to use new collision detection since the terrain one wouldn't work for some reason //can't land on blinking platforms for some reason //bug//////////////////////
        public new bool CollisionDetected(Rectangle entity)
        {
            if (position.Intersects(entity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
