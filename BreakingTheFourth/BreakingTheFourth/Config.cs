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

        //enums for different buttons -yes
        public enum Buttons
        {
            Restart,
            Start,
            Exit,
            Save,
            Load,
            Resume,
            Menu
        }
        //fields
        private Buttons button;
        private Rectangle startButton;
        private Rectangle restartButton;
        private Rectangle quitButton;
        private Rectangle saveButton;
        private Rectangle loadButton;
        private Rectangle resumeButton;
        private Rectangle menuButton;
        //restart button
        private Texture2D restartTexture;//normal texture
        private Texture2D restartOvrTexture;//texture for button when mouse is over the bounds
        //start button
        private Texture2D startTexture;
        private Texture2D startOvrTexture;
        //resume button
        private Texture2D resumeTexture;
        private Texture2D resumeOvrTexture;
        //exit / quit button
        private Texture2D exitTexture;
        private Texture2D exitOvrTexture;
        //save button
        private Texture2D saveTexture;
        private Texture2D saveOvrTexture;
        //load button
        private Texture2D loadTexture;
        private Texture2D loadOvrTexture;
        //menu button
        private Texture2D menuTexture;
        private Texture2D menuOvrTexture;
        //properties
        public Texture2D RestartTexture
        {
            get { return restartTexture; }
            set { restartTexture = value; }
        }
        public Texture2D RestartOvrTexture
        {
            get { return restartOvrTexture; }
            set { restartOvrTexture = value; }
        }
        public Texture2D StartTexture
        {
            get { return startTexture; }
            set { startTexture = value; }
        }
        public Texture2D StartOvrTexture
        {
            get { return startOvrTexture; }
            set { startOvrTexture = value; }
        }
        public Texture2D ResumeTexture
        {
            get { return resumeTexture; }
            set { resumeTexture = value; }
        }
        public Texture2D ResumeOvrTexture
        {
            get { return resumeOvrTexture; }
            set { resumeOvrTexture = value; }
        }
        public Texture2D ExitTexture
        {
            get { return exitTexture; }
            set { exitTexture = value; }
        }
        public Texture2D ExitOvrTexture
        {
            get { return exitOvrTexture; }
            set { exitOvrTexture = value; }
        }
        public Texture2D SaveTexture
        {
            get { return saveTexture; }
            set { saveTexture = value; }
        }
        public Texture2D SaveOvrTexture
        {
            get { return saveOvrTexture; }
            set { saveOvrTexture = value; }
        }
        public Texture2D LoadTexture
        {
            get { return loadTexture; }
            set { loadTexture = value; }
        }
        public Texture2D LoadOvrTexture
        {
            get { return loadOvrTexture; }
            set { loadOvrTexture = value; }
        }
        public Texture2D MenuTexture
        {
            get { return menuTexture; }
            set { menuTexture = value; }
        }
        public Texture2D MenuOvrTexture
        {
            get { return menuOvrTexture; }
            set { menuOvrTexture = value; }
        }
        //property for enum
        public Buttons Button
        {
            get { return button; }
            set { button = value; }
        }
        //make all the buttons separate methods???
        public void Restart(int x, int y)
        {
            restartButton = new Rectangle(x, y, 75, 50);
        }
        public void Start(int x, int y)
        {
            startButton = new Rectangle(x, y, 75, 50);
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
        public void Menu(int x, int y)
        {
            menuButton = new Rectangle(x, y, 75, 50);
        }
        public void Update(MouseState mouse, Game1 game, GameState preState, MouseState preMState)
        {
            if(game.PreGamestate != game.Gamestate)//clears buttons
            {
                startButton.X = 0;
                startButton.Y = 0;
                restartButton.X = 0;
                restartButton.Y = 0;
                quitButton.X = 0;
                quitButton.Y = 0;
                saveButton.X = 0;
                saveButton.Y = 0;
                loadButton.X = 0;
                loadButton.Y = 0;
                resumeButton.X = 0;
                resumeButton.Y = 0;
                menuButton.X = 0;
                menuButton.Y = 0;
            }
            if(game.Gamestate == GameState.Game || game.Gamestate == GameState.Controls)
            {
                return;
            }
            if (restartButton.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && 
                preMState.LeftButton == ButtonState.Released)
            {
                game.PreGamestate = game.Gamestate;
                game.Gamestate = GameState.Game;
                game.Restart();
            }
            //resume from pause menu
            if (resumeButton.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed &&
                preMState.LeftButton == ButtonState.Released)
            {
                game.PreGamestate = game.Gamestate;
                game.Gamestate = GameState.Game;
            }
            //quit button / exit button
            if (quitButton.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed &&
                preMState.LeftButton == ButtonState.Released)
            {
                game.Exit();
            }
            //exits to main menu
            if (menuButton.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed &&
                preMState.LeftButton == ButtonState.Released)
            {
                game.PreGamestate = game.Gamestate;
                game.Gamestate = GameState.Main;
            }
            //starts game
            if (startButton.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed &&
                preMState.LeftButton == ButtonState.Released)
            {
                game.LevelCounter = 1;
                game.PreGamestate = game.Gamestate;
                game.Gamestate = GameState.Game;
            }
            //need to put in the load and save here eventually
        }
        public void Draw(SpriteBatch spritebatch, MouseState mouse, Buttons button)
        {
            //switch statement that determines what to draw
            switch(button)
            {
                case Buttons.Exit:
                    {
                        if(quitButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(ExitOvrTexture, quitButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(ExitTexture, quitButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Load:
                    {
                        if (loadButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(LoadOvrTexture, loadButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(LoadTexture, loadButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Menu:
                    {
                        if (menuButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(MenuOvrTexture, menuButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(MenuTexture, menuButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Restart:
                    {
                        if (restartButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(RestartOvrTexture, restartButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(RestartTexture, restartButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Start:
                    {
                        if (startButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(StartOvrTexture, startButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(StartTexture, startButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Resume:
                    {
                        if (resumeButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(ResumeOvrTexture, resumeButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(ResumeTexture, resumeButton, Color.White);
                        }
                    }
                    break;
                case Buttons.Save:
                    {
                        if (saveButton.Contains(mouse.X, mouse.Y))
                        {
                            spritebatch.Draw(SaveOvrTexture, saveButton, Color.White);
                        }
                        else
                        {
                            spritebatch.Draw(SaveTexture, saveButton, Color.White);
                        }
                    }
                    break;
            }
        }
        //I'm not even 100% sure this class is necessary.
        //It could be used for menus but we could just do that with State Machines in the Game Class.
        //Maybe to just store the files for the GUI.
        //Again, the same thing with Death. We could just make that a state.
        //We'll just start by putting what we think should go here and if we find it unnecessary, we move it.
        //Shouldn't require a constructor
    }
}
