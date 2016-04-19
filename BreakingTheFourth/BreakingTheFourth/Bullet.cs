using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakingTheFourth
{
    class Bullet
    {
        //Mike O'Donnell - Added these comments, no work on it so far though.
        public enum BulletState
        {
            justFired,
            empty,
            airborne,
            ready
        }
        //add fields
        private Texture2D bulletTexture;
        private BulletState bState;
        private Rectangle position;
        private bool facingLeft = false; //whether player is facing left or right
        private float rotation;
        //set bullets for each screen in the level classes
        private int bullets;
        // FileIO object
        FileIO movement = new FileIO();
        //properties

        public Texture2D BulletTexture
        {
            get { return bulletTexture; }
            set { bulletTexture = value; }
        }

        public BulletState BState
        {
            get { return bState; }
        }

        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool FacingLeft
        {
            get { return facingLeft; }
        }

        public int Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }


        //constructor
        public Bullet(int x, int y, int width, int height)
        {
            bState = BulletState.ready;
            position = new Rectangle(x, y, width, height);
        }

        public void Fire(float rot)
        {
            if(bullets == 0)
            {
                bState = BulletState.empty;
            }
            else
            {
                bState = BulletState.justFired;
                rotation = rot;
                bullets--;
            }
        }
        public void Update(List<Terrain> terrain, Gun gun, Player player, MouseState mouseState, MouseState previousMState, 
            float rot, KeyboardState kbState, GraphicsDevice GraphicsDevice, Game1 game)
        {
            switch (bState)
            {
                case Bullet.BulletState.airborne:
                    //assigns amount of movement to the y direction
                    double movementY = (Math.Round(Math.Sin(rotation) * movement.BulletSpeed));//rotation determines where bullet goes
                    //assigns amount of movement to the x direction                            //rotation is determined by gun
                    double movementX = (Math.Round(Math.Cos(rotation) * movement.BulletSpeed));//gun is broken w/ the states in right direction
                    if (facingLeft == true)
                    {
                        //position.X -= movement.BulletSpeed;
                        position.X -= Convert.ToInt32(movementX);
                        position.Y -= Convert.ToInt32(movementY);
                    }
                    else if (facingLeft == false)
                    {
                        movementX = -movementX; //shifts bullet direction to resemble where the player is facing
                        position.X += Convert.ToInt32(movementX);
                        position.Y -= Convert.ToInt32(movementY);
                    }
                    for (int i = 0; i < terrain.Count; i++)
                    {
                        if (terrain[i].CollisionDetected(position) == true) //collision detection causes the bullet to disappear
                        {
                            if(terrain[i] is DeathObject)
                            {
                                player.PlayerLives--;
                                player.X = 50;
                                player.Y = 370;
                                //game.PreGamestate = game.Gamestate;
                                //game.Gamestate = GameState.GameOver;
                            }
                            bState = BulletState.ready;
                            //actual teleporting
                            player.X = position.X;
                            player.Y = position.Y - 40;
                            //stops no clip
                            player.OffsetTele(terrain, i, this);
                        }
                    }//end of for loop
                    //handles if the bullet leaves the screen in x direction
                    if(position.X > GraphicsDevice.Viewport.Width || position.X < GraphicsDevice.Viewport.X)
                    {
                        bState = BulletState.ready;
                    }
                    //handles if billet leaves screen in y direction
                    if(position.Y > GraphicsDevice.Viewport.Height || position.Y < GraphicsDevice.Viewport.Y)
                    {
                        bState = BulletState.ready;
                    }
                    //handles if player changes screen
                    if(player.X > GraphicsDevice.Viewport.Width || player.X < GraphicsDevice.Viewport.X)
                    {
                        bState = BulletState.ready;
                    }
                    break;
                case Bullet.BulletState.empty:
                    {
                        //allows firing after changing screens
                        if (player.X > GraphicsDevice.Viewport.Width || player.X < GraphicsDevice.Viewport.X)
                        {
                            bState = BulletState.ready;
                        }
                    }
                    break;
                case Bullet.BulletState.justFired:
                    {
                        //sets up bullet position to be right before gun
                        position.Y = gun.GunPosition.Top -5;//can't fix it with a simple hardcoded offset, due to rot
                        //shift bulletstate
                        bState = BulletState.airborne;
                        //bool that says whether it is left or right
                        if (player.PState == Player.PlayerState.faceLeft || player.PState == Player.PlayerState.walkLeft)
                        {
                            facingLeft = true;
                            position.X = gun.GunPosition.Left;
                        }
                        else
                        {
                            facingLeft = false;
                            position.X = gun.GunPosition.Right;
                        }
                    }
                    break;
                case Bullet.BulletState.ready: //fires bullet when clicking left mouse button
                    {
                        if (mouseState.LeftButton == ButtonState.Pressed && previousMState.LeftButton == ButtonState.Released)
                        {
                            Fire(rot);
                        }
                    }
                    break;
            }//end of switch statement
        }//end of update method
        public void Draw(SpriteBatch spritebatch, Player player)
        {
            //spritebatch.Draw(bulletTexture, position, Color.White);
            if (facingLeft == false)
            {
                spritebatch.Draw(bulletTexture, position, null, Color.White, rotation, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }

            if (facingLeft == true)
            {
                spritebatch.Draw(bulletTexture, position, null, Color.White, rotation, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }//end of draw method

        //Here we have the bullet
        //We might wanna make this a vector2, and save it's current position as well as a few previous ones - needs to be rectangle
        //in order to do collision detection
        //Will need a method to check collision - in terrain class
        //Do we need a parameterized constructor for just a vector2? Probably.
        //Will need seperate values to not only calculate x and y position, but also speed - speed determined by tool
        //And of course the method for the actual teleporting, which we'll use the previous vector2's for
    }
}
