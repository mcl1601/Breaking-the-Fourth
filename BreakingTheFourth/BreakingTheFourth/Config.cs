using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakingTheFourth
{
    class Config
    {
        //Mike O'Donnell - I added these comments, but I'm not even sure if we're gonna use this class. Can't hurt to keep it around.

        //enums for different buttons?
        //fields
        Rectangle restartButton;
        Rectangle quitButton;
        Rectangle saveButton;
        Rectangle loadButton;
        Rectangle resumeButton;
        Texture2D buttonTexture;//normal texture
        Texture2D ovrBTexture;//texture for button when mouse is over the bounds
        //properties
        public Texture2D ButtonTexture
        {
            get { return buttonTexture; }
            set { buttonTexture = value; }
        }
        public Texture2D OvrBTexture
        {
            get { return ovrBTexture; }
            set { ovrBTexture = value; }
        }
        //make all the buttons separate methods???
        public void Restart(int x, int y, MouseState mouseState)//need mouseState here or just when drawing?
        {
            restartButton = new Rectangle(x, y, 75, 50);
        }
        public void Quit(int x, int y)
        {
            quitButton = new Rectangle(x, y, 75, 50);
        }
        public void Resume(int x, int y)
        {
            resumeButton = new Rectangle(x, y, 75, 50);
        }
        public void Save(int x, int y)
        {
            saveButton = new Rectangle(x, y, 75, 50);
        }
        public void Load(int x, int y)
        {
            loadButton = new Rectangle(x, y, 75, 50);
        }
        public void Draw(SpriteBatch spritebatch, MouseState mouse)
        {

        }
        //I'm not even 100% sure this class is necessary.
        //It could be used for menus but we could just do that with State Machines in the Game Class.
        //Maybe to just store the files for the GUI.
        //Again, the same thing with Death. We could just make that a state.
        //We'll just start by putting what we think should go here and if we find it unnecessary, we move it.
        //Shouldn't require a constructor
    }
}
