using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//updated namespaces
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakingTheFourth
{
    //Contributors:
    //Kat Weis - basically everything so far
    // Matt Lienhard - helped with Offset method
    class Player
    {
        //Here is the code for the player
        //Will need to store a texture and a rectangle
        private Texture2D playerTexture;
        private Rectangle position;
        //also needs field to detect falling
        private bool isFalling;
        private bool isJumping; //variable for determining if player jumped recently
        private int startingY; //variable for Y before jumpingd
        int screenCounter = 1;
        Level1 level1 = new Level1();

        // FileIO object
        FileIO movement = new FileIO();
        //Since we don't have collectibles, we probably won't need a GameObject class
        //Make a constructor that takes 4 parameters, the x, the y, the width and the height.
        public Player(int x, int y, int width, int height)
        {
            position = new Rectangle(x, y, width, height);
            startingY = y;
            isJumping = false;
            isFalling = false;
        }
        //make properties for the texture and the position & X , Y coords
        public Texture2D PlayerTexture
        {
            get { return playerTexture; }
            set { playerTexture = value; }
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
        //properties for isFalling
        public bool IsFalling
        {
            get { return isFalling; }
            set { isFalling = value; }
        }
        //property for isJumping
        public bool IsJumping
        {
            get { return isJumping; }
            set { isJumping = value; }
        }
        //property for startingY
        public int StartingY
        {
            get { return startingY; }
            set { startingY = value; }
        }
        public void Update(KeyboardState kbState, KeyboardState previousKbState, List<Terrain> terrain)
        {
            //x-axis movement determined by keyboard input
            if (kbState.IsKeyDown(Keys.A))
            {
                X -= movement.PlayerSpeed;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                X += movement.PlayerSpeed;
            }
            bool collided = false;
            //collision detection
            for (int i = 0; i < terrain.Count; i++)
            {
                if (terrain[i].CollisionDetected(position) == true )/////special terrain is causing issue still when going down
                {
                    //stops no clip issues
                    Offset(terrain, kbState, i);
                    //halts jumping after colliding
                    isJumping = false;
                    collided = true;
                }
                //checks if player is standing on terrain & counts that as colliding
                if(!(position.Left > terrain[i].Position.Right) && !(position.Right < terrain[i].Position.Left))
                {
                    if (position.Bottom == terrain[i].Position.Top)
                    {
                        collided = true;
                    }
                }
                
            }
            if(isJumping ==false && collided ==false)
            {
                isFalling = true;
            }
            if (isFalling == true)
            {
                //go down-gravity
                Gravity();
                isJumping = false; //stops player from jumping while falling to slow descend
            }
            if (isJumping == true)
            {
                position.Y -= 4;
                if (position.Y <= (startingY - (.5 * position.Height)))
                {
                    isFalling = true;
                }
            }
            //jump start
            if (kbState.IsKeyDown(Keys.Space) && previousKbState.IsKeyUp(Keys.Space))
            {
                //jump logic
                //go up
                position.Y -= 4;
                isJumping = true;
            }

            
        }
        public void Gravity()
        {
            position.Y += movement.Gravity;
        }
        /// <summary>
        /// draws the player to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, position, Color.White);
        }
        //We'll probably need math calculations for velocity and stuff
        //Need method for checking collisions with walls and other objects - in terrain
        //Need to decide whether to make player move around level or level move around player

        public void Offset(List<Terrain> terrain, KeyboardState kbState, int i)
        {
            if (position.Bottom > terrain[i].Position.Top + movement.Gravity)
            {
                if (position.Right > terrain[i].Position.Left && kbState.IsKeyDown(Keys.D))
                {
                    position.X = terrain[i].Position.Left - position.Width;
                    //position.X -= movement.PlayerSpeed;
                }
                if (position.Left < terrain[i].Position.Right && kbState.IsKeyDown(Keys.A))
                {
                    position.X = terrain[i].Position.Right;
                    //position.X += movement.PlayerSpeed;
                }
            }
            if(position.Bottom <= terrain[i].Position.Top + movement.Gravity && position.Bottom > terrain[i].Position.Top)//sets player on top of terrain if fell
            {
                position.Y -= position.Bottom - terrain[i].Position.Top;
                isFalling = false;
                startingY = position.Y;
            }
            
            if(startingY > terrain[i].Position.Bottom && IsJumping == true) // starts below the object & jumps
            {
                if (position.Top < terrain[i].Position.Bottom && IsJumping == true && position.Top > terrain[i].Position.Top)
                {
                    position.Y += terrain[i].Position.Bottom - position.Top;
                }
            }
            else if(startingY - position.Height < terrain[i].Position.Bottom && IsJumping == true) // jumps and hits an object from the side
            {
                if (position.Right > terrain[i].Position.Left && kbState.IsKeyDown(Keys.D))
                {
                    position.X = terrain[i].Position.Left - position.Width;
                    //position.X -= movement.PlayerSpeed;
                }
                if (position.Left < terrain[i].Position.Right && kbState.IsKeyDown(Keys.A))
                {
                    position.X = terrain[i].Position.Right;
                    //position.X += movement.PlayerSpeed;
                }
            }


            
        }//end of offset method
    }
}
