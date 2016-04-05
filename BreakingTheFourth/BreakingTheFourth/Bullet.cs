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
        private bool facingLeft = false;
        private float rotation;
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

        //constructor
        public Bullet(int x, int y, int width, int height)
        {
            bState = BulletState.ready;
            position = new Rectangle(x, y, width, height);
        }

        public void Fire(float rot)
        {
            bState = BulletState.justFired;
            rotation = rot;
        }
        public void Update(List<Terrain> terrain, Gun gun, Player player, MouseState mouseState, MouseState previousMState, float rot)
        {
            switch (bState)
            {
                case Bullet.BulletState.airborne:
                    if (facingLeft == true)
                    {
                        position.X -= movement.BulletSpeed;
                    }
                    else if (facingLeft == false)
                    {
                        position.X += movement.BulletSpeed;
                    }
                    for (int i = 0; i < terrain.Count; i++)
                    {
                        if (terrain[i].CollisionDetected(position) == true) //collision detection causes the bullet to disappear
                        {
                            bState = BulletState.ready;
                        }
                    }//end of for loop
                    break;
                case Bullet.BulletState.empty:
                    break;
                case Bullet.BulletState.justFired:
                    {
                        //sets up bullet position to be right before gun
                        position.Y = gun.GunPosition.Top;
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
                spritebatch.Draw(bulletTexture, position, null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0);
            }

            if (facingLeft == true)
            {
                spritebatch.Draw(bulletTexture, position, null, Color.White, rotation, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }
        public void Velocity()
        {

        }
        //Here we have the bullet
        //We might wanna make this a vector2, and save it's current position as well as a few previous ones
        //Will need a method to check collision.
        //Do we need a parameterized constructor for just a vector2? Probably.
        //Will need seperate values to not only calculate x and y position, but also speed
        //And of course the method for the actual teleporting, which we'll use the previous vector2's for
    }
}
