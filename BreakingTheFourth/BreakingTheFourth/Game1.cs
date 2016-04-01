using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace BreakingTheFourth
{
    //Contributors:
    //Kat Weis - enums for gamestates, player related stuff, keyboard states, placeholder font, case statements, 
    //moving back to previous screen of level, updates and draws for player and menus
    //Mike O'Donnell - implemented terrain list, screen list and gun. And added beginning comments for outline. 
    //Matt Lienhard - NextScreen and terrain loading

    /// <summary>
    /// This is the main type for your game.
    /// //This is the main game class, will be used to call methods and of course run the game. 
    /// //I assumed most of our methods will be in other classes, but the most recent homework may have proved otherwise
    /// //Will need space for loading content, initialization, etc.
    /// </summary>
    
    enum GameState
    {
        Main,
        Controls,
        Game,
        Paused,
        GameOver
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //add in player object and fields but don't intialize
        Player player;
        Texture2D stickFigure;
        Gun gun;
        Texture2D telegun;
        //fields for getting keyboard states
        KeyboardState kbState;
        KeyboardState previousKbState;
        //Field for getting mouse state 
        MouseState mouseState;
        List<Terrain> terrain;
        Level1 level1;
        int screenCounter;
        //fields for finite state machines
        private GameState gamestate;
        //fields for font
        SpriteFont font;
        Vector2 fontPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //initialize player object
            player = new Player(50, 50, 50, 80);
            //initialize gun object
            gun = new Gun(player.X + 40, player.Y + 40, 30, 30);
            //initialize terrain and levels
            terrain = new List<Terrain>();
            level1 =  new Level1();
            screenCounter = 1;
            //initialize game state
            gamestate = GameState.Main;
            fontPosition = new Vector2(5, 5);
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load in player texture
            stickFigure = Content.Load<Texture2D>("Stickman_Handgun.png");
            player.PlayerTexture = stickFigure;
            //load in gun texture
            telegun = Content.Load<Texture2D>("TeleGun_Handgun.png");
            gun.GunImage = telegun;
            // make textures for the level1
            terrain = level1.NextScreen(1);
            for (int x = 0; x < terrain.Count; x++)
            {
                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
            }
            //load in font
            font = Content.Load<SpriteFont>("Ebrima_14");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        //Rotation stuffs

        protected override void Update(GameTime gameTime)
        {
            
            previousKbState = kbState;
            //get keyboard and mouse states
            kbState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            switch(gamestate)
            {
                case GameState.Main:
                    {
                        if(kbState.IsKeyDown(Keys.Enter)==true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            gamestate = GameState.Game;
                        }
                        if (kbState.IsKeyDown(Keys.Escape) && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            Exit();
                        }
                    }
                    break;
                case GameState.Controls:
                    break;
                case GameState.Game:
                    {
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            gamestate = GameState.Paused;
                        }
                        //add player update for movement
                        player.Update(kbState, previousKbState, terrain);
                        //update for moving terrain
                        foreach (Terrain t in terrain)
                        {
                            if (t is SpecialTerrain)
                            {
                                t.Update();
                            }
                        }
                        //changes screen when player passes far right of viewport
                        if (player.X > GraphicsDevice.Viewport.Width)
                        {
                            screenCounter++;
                            terrain.Clear();
                            terrain = level1.NextScreen(screenCounter);
                            for (int x = 0; x < terrain.Count; x++)
                            {
                                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
                            }
                            player.X = 50;
                            player.Y = 370;
                        }
                        //allows player to return to previous screen if exits viewport to left
                        if (player.X < GraphicsDevice.Viewport.X)
                        {
                            screenCounter--;
                            terrain.Clear();
                            terrain = level1.NextScreen(screenCounter);
                            for (int x = 0; x < terrain.Count; x++)
                            {
                                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
                            }
                            player.X = GraphicsDevice.Viewport.Width - 50;
                            player.Y = 370;
                        }
                        //Keep the gun at the same position relative to the player
                        gun.X = player.X + 30;
                        gun.Y = player.Y + 20;

                        //level1.CreateLevelOne(player.Position.X);
                    }
                    break;
                case GameState.Paused:
                    {
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            gamestate = GameState.Main;
                        }
                        if (kbState.IsKeyDown(Keys.Enter) == true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            gamestate = GameState.Game;
                        }
                    }
                    break;
                case GameState.GameOver:
                    break;
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //case statement for gamestates in draw
            switch (gamestate)
            {
                case GameState.Main:
                    {
                        string welcome = "Welcome to Breaking the Fourth \n Press Enter to Begin";
                        spriteBatch.DrawString(font, welcome, fontPosition, Color.Black);
                    }
                    break;
                case GameState.Controls:
                    break;
                case GameState.Game:
                    {
                        //drawing methods in here
                        player.Draw(spriteBatch);
                        gun.Draw(spriteBatch);
                        for (int x = 0; x < terrain.Count; x++)
                        {
                            terrain[x].Draw(spriteBatch);
                        }
                    }
                    break;
                case GameState.Paused:
                    {
                        string paused = "PAUSED \n Press Esc to got to the main menu \n Press Enter to return to the game";
                        spriteBatch.DrawString(font, paused, fontPosition, Color.Black);
                    }
                    break;
                case GameState.GameOver:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
