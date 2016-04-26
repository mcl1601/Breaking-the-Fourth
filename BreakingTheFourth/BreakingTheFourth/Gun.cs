
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BreakingTheFourth
{
    //Contributors:
    //Mike O'Donnell - Helped plan out gun rotation, worked on logic for following mouse cursor
    //Kat Weis - Resticted rotation of the gun
    //Matt Lienhard - handled the logic for how/where to draw the gun depending on the player state, implemented Draw
    class Gun
    {
        
        //properties for the texture and the rectangle
        private Texture2D gunImage;
        private Rectangle gunPosition;
        private float rotation;
        

        //property for rotation
        //Constructor to call
        public Gun(int x, int y, int width, int height)
        {
            gunPosition = new Rectangle(x, y, width, height);
            rotation = 0;
        }
        //Field for image
        public Texture2D GunImage
        {
            get { return gunImage; }
            set { gunImage = value; }
        }
        //Field for position
        public Rectangle GunPosition
        {
            get { return gunPosition; }
        }
       
        //Field for rotation

        public int X
        {
            get { return gunPosition.X; }
            set { gunPosition.X = value; }
        }
        public int Y
        {
            get { return gunPosition.Y; }
            set { gunPosition.Y = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set {rotation = value;}//maybe set limits on rotation?
        }

        public void DrawGun(SpriteEffects effect, SpriteBatch sb, float rotation, Vector2 origin)
        {
            sb.Draw(gunImage, gunPosition, null, Color.White, rotation, origin, effect, 0);
        }
        //Draw method
        public void Draw(SpriteBatch spritebatch, Player player, float rotation, Vector2 origin)
        {
            
            //spritebatch.Draw(gunImage, gunPosition, Color.White);
            if(player.PState == Player.PlayerState.faceRight || player.PState == Player.PlayerState.walkRight || player.PState == Player.PlayerState.faceRightWalkLeft)
            {
                DrawGun(SpriteEffects.FlipVertically|SpriteEffects.FlipHorizontally, spritebatch, rotation, origin); //needs to flip both horizontally and vertically
            }

            if(player.PState == Player.PlayerState.faceLeft || player.PState == Player.PlayerState.walkLeft || player.PState == Player.PlayerState.faceLeftWalkRight)
            {
                DrawGun(SpriteEffects.FlipHorizontally, spritebatch, rotation, origin);
            }
        }
        //Update method
        public void Update(Player player)
        {
            //Keep the gun at the same position relative to the player
            if (player.PState == Player.PlayerState.walkLeft)
            {
                X = player.X;
                Y = player.Y + 38;
                if(rotation > 1.6f)
                {
                    rotation = 1.6f;
                }
            }

            if (player.PState == Player.PlayerState.walkRight)
            {
                X = player.X + 50;
                Y = player.Y + 30;
                if(rotation < 1.4f)
                {
                    rotation = 1.4f;
                }
            }

            if (player.PState == Player.PlayerState.faceLeft || player.PState == Player.PlayerState.faceLeftWalkRight)
            {
                X = player.X;
                Y = player.Y + 38;
                if (rotation > 1.6f)
                {
                    rotation = 1.6f;
                }
                if (rotation < -1.6f)
                {
                    rotation = -1.6f;
                }
            }

            if (player.PState == Player.PlayerState.faceRight || player.PState == Player.PlayerState.faceRightWalkLeft)
            {
                X = player.X + 50;
                Y = player.Y + 30;
                if (rotation < 1.4f && rotation > -1.4f)
                {
                    rotation = 1.4f;
                }
            }
        }
    }
}
