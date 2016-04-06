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
        MouseState previousMState;
        List<Terrain> terrain;
        Level1 level1;
        int screenCounter;
        //fields for finite state machines
        private GameState gamestate;
        private GameState previousGamestate;
        //fields for font
        SpriteFont font;
        Vector2 fontPosition;
        //variable to track the mouse position
        Vector2 mousePosition;
        Rectangle mouse;
        Texture2D crosshare;
        //bullet fields
        Bullet bullet;
        float directionX;
        float directionY;

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
            //initialize font
            fontPosition = new Vector2(5, 5);
            //initialize bullet object
            bullet = new Bullet(player.X, player.Y, 20, 20);
            IsMouseVisible = true;
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
            //texture for mouse
            //crosshare = Content.Load<Texture2D>("crosshare.png");////////////////////////////////load in texture for mouse here
            //texture for bullet
            bullet.BulletTexture = Content.Load<Texture2D>("Bullet.png");
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
            previousMState = mouseState;
            mouseState = Mouse.GetState(Window);
            //Put the coordinates into the position variable then calculate the rotation (not yet sure if this equation will work)
            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            directionX = gun.GunPosition.X - mouseState.X;
            directionY = gun.GunPosition.Y - mouseState.Y;
            gun.Rotation = (float)Math.Atan2(directionY , directionX);
            switch (gamestate)
            {
                case GameState.Main:
                    {
                        if(kbState.IsKeyDown(Keys.Enter)==true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Game;
                        }
                        else if (kbState.IsKeyDown(Keys.Escape) && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            Exit();
                        }
                        else
                        {
                            previousGamestate = gamestate;
                        }
                    }
                    break;
                case GameState.Controls:
                    break;
                case GameState.Game:
                    {
                        if(previousGamestate == GameState.Main || previousGamestate == GameState.GameOver) //restarts level
                        {
                            screenCounter = 1;
                            terrain = level1.NextScreen(screenCounter);
                            for (int x = 0; x < terrain.Count; x++)
                            {
                                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
                            }
                            player.X = 50;
                            player.Y = 50;
                        }
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Paused;
                        }
                        // player falls to their death
                        else if (player.Y > GraphicsDevice.Viewport.Height)
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.GameOver;
                        }
                        else
                        {
                            previousGamestate = gamestate;
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
                        gun.Update(player);
                        //update the bullet
                        bullet.Update(terrain, gun, player, mouseState, previousMState, gun.Rotation, kbState);

                       
                    }
                    break;
                case GameState.Paused:
                    {
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Main;
                        }
                        else if (kbState.IsKeyDown(Keys.Enter) == true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Game;
                        }
                        else
                        {
                            previousGamestate = gamestate;
                        }
                    }
                    break;
                case GameState.GameOver:
                    {
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Main;
                        }
                        else if (kbState.IsKeyDown(Keys.Enter) == true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Game;
                        }
                        else
                        {
                            previousGamestate = gamestate;
                        }
                    }
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
            //draw mouse
            //spriteBatch.Draw(crosshare, mousePosition, Color.White); ///////////////////////////need texture
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
                        gun.Draw(spriteBatch, player, gun.Rotation, new Vector2(325, 325));
                        for (int x = 0; x < terrain.Count; x++)
                        {
                            terrain[x].Draw(spriteBatch);
                        }
                        //THIS SHOULD BE TRACKING THE MOUSE POSITION BUT IT ISN'T AND I HATE IT! For some reason the mouseState is never changing...
                        string mouse = ("Mouse X: " + mouseState.X + " Mouse Y: " + mouseState.Y);
                        spriteBatch.DrawString(font, mouse, fontPosition, Color.Red);
                        //draw bullet if it has been fired
                        if(bullet.BState == Bullet.BulletState.justFired || bullet.BState == Bullet.BulletState.airborne)
                        {
                            bullet.Draw(spriteBatch, player);
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
                    {
                        string death = "GAME OVER\n Press Esc to go to the main menu \n Press Enter to start over";
                        spriteBatch.DrawString(font, death, fontPosition, Color.Red);
                    }
                    break;
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
