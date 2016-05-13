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
        //Contributors:
        //Kat Weis - All the code in here
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
        private bool isTeleporting;
        private float rotation;
        //set bullets for each screen in the level classes
        private int bullets;
        // FileIO object
        FileIO movement = new FileIO(1);
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

        public bool IsTeleporting
        {
            get { return isTeleporting; }
            set { isTeleporting = value; }
        }


        //constructor
        public Bullet(int x, int y, int width, int height)
        {
            bState = BulletState.ready;
            position = new Rectangle(x, y, width, height);
            IsTeleporting = false;
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
            //assigns amount of movement to the y direction
            double movementY = (Math.Round(Math.Sin(rotation) * movement.BulletSpeed));//rotation determines where bullet goes
            //assigns amount of movement to the x direction
            double movementX = (Math.Round(Math.Cos(rotation) * movement.BulletSpeed));
            switch (bState)
            {
                case Bullet.BulletState.airborne:
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
                        if(terrain[i] is DisappearingPlatforms)
                        {
                            DisappearingPlatforms plat = (DisappearingPlatforms)terrain[i];
                            //makes sure you can't teleport to a platform that isn't supposed to be there
                            if ((plat.Type == DisappearingPlatforms.Disappear.Blinking && plat.Tint == Color.Transparent)
                                || plat.Type == DisappearingPlatforms.Disappear.Intangible)
                            {
                                continue;
                            }
                            if (plat.CollisionDetected(position) == true)
                            {
                                // teleporting
                                IsTeleporting = true;
                                bState = BulletState.ready;
                                //actual teleporting
                                player.X = position.X;
                                player.Y = position.Y - 40;
                                //stops no clip
                                player.OffsetTele(terrain, i, this);
                            }
                        }
                        
                        if (terrain[i].CollisionDetected(position) == true) //collision detection causes the bullet to disappear
                        {
                            // teleporting
                            IsTeleporting = true;
                            if(terrain[i] is DeathObject)
                            {
                                game.Death();
                                break;
                            }
                            if (terrain[i] is LevelGoal)
                            {
                                if (terrain[i].CollisionDetected(Position) == true) ////////////////////
                                {
                                    game.PreGamestate = game.Gamestate;
                                    game.Gamestate = GameState.LevelClear;
                                }
                            }
                            bState = BulletState.ready;
                            //actual teleporting
                            player.X = position.X;
                            player.Y = position.Y - 40;
                            //stops no clip
                            player.OffsetTele(terrain, i, this);
                        }
                        if(terrain[i].CollisionDetected(player.Position)==true)//not working
                        {
                            player.OffsetTele(terrain, i, this);
                        }
                    }//end of for loop
                    //handles if the bullet leaves the screen in x direction
                    if(position.X > GraphicsDevice.Viewport.Width || position.Right < GraphicsDevice.Viewport.X)
                    {
                        bState = BulletState.ready;
                    }
                    //handles if billet leaves screen in y direction
                    if(position.Y > GraphicsDevice.Viewport.Height || position.Y < GraphicsDevice.Viewport.Y)
                    {
                        bState = BulletState.ready;
                    }
                    //handles if player changes screen
                    if(player.X > GraphicsDevice.Viewport.Width || player.Position.Right < GraphicsDevice.Viewport.X)
                    {
                        bState = BulletState.ready;
                    }
                    break;
                case Bullet.BulletState.empty:
                    {
                        //allows firing after changing screens
                        if (player.X > GraphicsDevice.Viewport.Width || player.Position.Right < GraphicsDevice.Viewport.X)
                        {
                            bState = BulletState.ready;
                        }
                    }
                    break;
                case Bullet.BulletState.justFired:
                    {
                        //sets up bullet position to be right before gun
                        position.Y = gun.GunPosition.Top;//can't fix it with a simple hardcoded offset, due to rot
                        if(rotation > 0)
                        {
                            position.Y -= Math.Abs(Convert.ToInt32(movementY / movement.BulletSpeed * 28));
                        }
                        else
                        {
                            position.Y += Math.Abs(Convert.ToInt32(movementY / movement.BulletSpeed * 28));
                        }
                        //shift bulletstate
                        bState = BulletState.airborne;
                        //bool that says whether it is left or right
                        if (player.PState == Player.PlayerState.faceLeft || player.PState == Player.PlayerState.walkLeft)
                        {
                            facingLeft = true;
                            position.X = gun.GunPosition.Left;// -30;
                            //position.X = Convert.ToInt32(gun.Origin.X) - 95;
                            position.X -= Math.Abs(Convert.ToInt32(movementX / movement.BulletSpeed * 28));
                        }
                        else
                        {
                            facingLeft = false;
                            position.X = gun.GunPosition.Right;
                            position.X -= Math.Abs(Convert.ToInt32(movementY / movement.BulletSpeed * 28));
                        }
                    }
                    break;
                case Bullet.BulletState.ready: //fires bullet when clicking left mouse button
                    {
                        // reset teleporting bool
                        IsTeleporting = false;
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

        
    }
}
