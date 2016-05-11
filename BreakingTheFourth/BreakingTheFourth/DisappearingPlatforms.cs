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
        //private Texture2D image;
        private Rectangle position;
        private bool movingUp;
        private bool movingLeft;
        //max and mins
        private int maxY = -1;
        private int minY = -1;
        private int maxX = -1;
        private int minX = -1;
        private Color tint;
        private Disappear type;
        private int timer =0;
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
            type = version;
            position = new Rectangle(x, y, width, height);
            //determines where to set max and min and where its moving
            if (axis == Movement.Horizontal)
            {
                movingLeft = true;
                maxX = max;
                minX = min;
                tint = color;
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
            type = version;
            position = new Rectangle(x, y, width, height);
        }

        // properties
        public int MaxY
        {
            get { return maxY; }
        }

        public int MinY
        {
            get { return minY; }
        }
        public int MaxX
        {
            get { return maxX; }
        }

        public int MinX
        {
            get { return minX; }
        }
        public bool MovingUp
        {
            get { return movingUp; }
        }
        public bool MovingLeft
        {
            get { return movingLeft; }
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
            else if (maxX < 0 || minX < 0)
            {
                Y++;
                if (Y >= minY)
                {
                    movingUp = true;
                }
            }
            //moving right
            else if(maxY ==-1 || minY == -1)
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
                if(tint == Color.Transparent && timer > 30)
                {
                    tint = Color.Red;
                    timer = 0;
                }
                if (tint == Color.Red && timer > 30)
                {
                    tint = Color.Transparent;
                    timer = 0;
                }
            }
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }
    }
}
