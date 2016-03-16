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
    class Player
    {
        //Here is the code for the player
        //Will need to store a texture and a rectangle
        private Texture2D playerTexture;
        private Rectangle position;
        //also needs field to detect falling
        private bool isFalling;
        private bool isJumping; //variable for determining if player jumped recently
        private int startingY; //variable for Y before jumping
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
        public void Update(KeyboardState kbState, KeyboardState previousKbState, List<Terrain> terrain, SpecialTerrain st)
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
            //collision detection
            for (int i = 0; i < terrain.Count; i++)
            {
                if (terrain[i].CollisionDetected(position) == true || st.CollisionDetected(position))
                {
                    //stops no clip issues
                    //Offset(terrain, kbState, i);
                    isFalling = false;
                    isJumping = false;
                    startingY = position.Y;
                }
                else if (IsJumping == false)
                {
                    isFalling = true;
                }

                if (isFalling == false)
                {
                    break;
                }
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

        public void Offset(List<Terrain> terrain, KeyboardState kbState, int count)
        {
            int i = 0;
            if (position.Bottom > terrain[i].Position.Top)
            {
                position.Offset(0, terrain[i].Position.Top - position.Bottom);
                position.Y = Y + terrain[i].Position.Top - position.Bottom;
            }
            if (position.Top < terrain[i].Position.Bottom)
            {
                position.Offset(0, terrain[i].Position.Bottom - position.Top);
                position.Y = Y + terrain[i].Position.Bottom - position.Top;
            }
            if (position.Right > terrain[i].Position.Left)
            {
                position.Offset(terrain[i].Position.Left - position.Right, 0);
                position.X = X + terrain[i].Position.Left - position.Right;
            }
            //set fields to simplify code
            /*int lyPlayer = Y + position.Height; //lower Y of player rect
            int fxPlayer = X + position.Width; //top left corner of player rect

            for (int i = 0; i < terrain.Count; i++)
            {
                int lyTerrain = terrain[i].Y + terrain[i].Height;//lower Y of terrain rect
                int fxTerrain = terrain[i].X + terrain[i].Width; //top left corner of terrain rect

                if ((Y < terrain[i].Y + terrain[i].Height || (Y + position.Height) < terrain[i].Y + terrain[i].Height) 
                    && (Y > terrain[i].Y || Y + position.Height > terrain[i].Y))
                    //checks if top of rect is inside terrain
                    {
                        if (isFalling == true && Y + movement.Gravity > terrain[i].Y)//if gravity will put player inside 
                        //terrain set em on top
                        {
                            if (X > terrain[i].X && X < fxTerrain)//only if player is over platform
                            {
                                Y = terrain[i].Y - position.Height;
                                break;
                            }

                        }
                        if (isJumping == true) //stops player from clipping through the bottom of terrain when jumping
                        {
                            Y = terrain[count].Y + terrain[count].Height;
                        }
                        if (kbState.IsKeyDown(Keys.A) )//&& (X - movement.PlayerSpeed) < (terrain[i].X + terrain[i].Width))
                        //if moving left and x will be between corners of terrain rectangles offset it
                        {
                            if ((X - movement.PlayerSpeed) < fxTerrain && X - movement.PlayerSpeed > terrain[i].X)
                            {
                                X = fxTerrain +1;
                            } 
                            if ((fxPlayer - movement.PlayerSpeed) < fxTerrain && fxPlayer - movement.PlayerSpeed > terrain[i].X)
                            {
                                X = terrain[i].X;
                            }
                        }
                        if (kbState.IsKeyDown(Keys.D) && (X + movement.PlayerSpeed) < terrain[i].X)
                        //if moving right and x will be between corners of terrain rectangles offset it
                        {
                            X = terrain[i].X;
                        }
                    }
                    
            }//end for loop that checks terrain
        }*/
        }//end of offset method
    }
}
