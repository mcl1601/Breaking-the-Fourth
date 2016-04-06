
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BreakingTheFourth
{
    //Mike O'Donnell - everything here
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
            set { rotation = value; }
        }

        public void DrawGun(SpriteEffects effect, SpriteBatch sb, float rotation, Vector2 origin)
        {
            sb.Draw(gunImage, gunPosition, null, Color.White, rotation, origin, effect, 0);
        }
        //Draw method
        public void Draw(SpriteBatch spritebatch, Player player, float rotation, Vector2 origin)
        {
            
            //spritebatch.Draw(gunImage, gunPosition, Color.White);
            if(player.PState == Player.PlayerState.faceRight || player.PState == Player.PlayerState.walkRight)
            {
                DrawGun(SpriteEffects.FlipHorizontally, spritebatch, rotation, origin);
            }

            if(player.PState == Player.PlayerState.faceLeft || player.PState == Player.PlayerState.walkLeft)
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
            }

            if (player.PState == Player.PlayerState.walkRight)
            {
                X = player.X + 50;
                Y = player.Y + 38;
            }

            if (player.PState == Player.PlayerState.faceLeft)
            {
                X = player.X;
                Y = player.Y + 38;
            }

            if (player.PState == Player.PlayerState.faceRight)
            {
                X = player.X + 50;
                Y = player.Y + 38;
            }
        }
    }
}
