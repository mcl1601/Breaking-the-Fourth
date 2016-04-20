using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace BreakingTheFourth
{
    //Contributors:
    //Kat Weis - enums for gamestates, player related stuff, keyboard states, placeholder font, case statements, 
    //moving back to previous screen of level, updates and draws for player and menus, updates and draws for bullet, UI, got mouse state
    //to update, all the menu stuff (drawing, loading, updating), made mouse crosshair texture, restart method, death and player lives
    //Mike O'Donnell - implemented terrain list, screen list and gun. And added beginning comments for outline. 
    //Matt Lienhard - NextScreen and terrain loading

    /// <summary>
    /// This is the main type for your game.
    /// //This is the main game class, will be used to call methods and of course run the game. 
    /// //I assumed most of our methods will be in other classes, but the most recent homework may have proved otherwise
    /// //Will need space for loading content, initialization, etc.
    /// </summary>
    
    public enum GameState
    {
        Main,
        Controls,
        Game,
        Paused,
        LevelClear,
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
        Level2 level2;
        int screenCounter;
        int levelCounter;
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
        //fields for menu
        Config menus;
        //fields for terrain textures
        Texture2D spikes;
        Texture2D terrainBlock;
        Color color;
        Texture2D walking;
        //property for gamestate
        public GameState Gamestate
        {
            get { return gamestate;}
            set { gamestate = value; }
        }
        public GameState PreGamestate
        {
            get { return previousGamestate; }
            set { previousGamestate = value; }
        }
        //property for levelcounter
        public int LevelCounter
        {
            get { return levelCounter; }
            set { levelCounter = value; }
        }
        //constructor
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
            //initialize config object
            menus = new Config();
            //initialize player object
            player = new Player(50, 50, 50, 80);
            //initialize gun object
            gun = new Gun(player.X + 40, player.Y + 40, 30, 30);
            //initialize terrain and levels
            terrain = new List<Terrain>();
            level1 =  new Level1();
            level2 = new Level2();
            screenCounter = 1;
            levelCounter = 1;
            //initialize game state
            gamestate = GameState.Main;
            //initialize font
            fontPosition = new Vector2(5, 5);
            //initialize bullet object
            bullet = new Bullet(player.X, player.Y, 10, 10);
            mouse = new Rectangle(mouseState.X, mouseState.Y, 30, 30);
            color = Color.Red;
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

            //load in menu textures
            menus.ExitTexture = Content.Load<Texture2D>("Textures/ExitButton.png");
            menus.ExitOvrTexture = Content.Load<Texture2D>("Textures/ExitOvr.png");
            menus.LoadTexture = Content.Load<Texture2D>("Textures/LoadButton.png");
            menus.LoadOvrTexture = Content.Load<Texture2D>("Textures/LoadOvr.png");
            menus.MenuTexture = Content.Load<Texture2D>("Textures/MenuButton.png");
            menus.MenuOvrTexture = Content.Load<Texture2D>("Textures/MenuOvr.png");
            menus.StartTexture = Content.Load<Texture2D>("Textures/NewButton.png");
            menus.StartOvrTexture = Content.Load<Texture2D>("Textures/NewOvr.png");
            menus.RestartTexture = Content.Load<Texture2D>("Textures/RestartButton.png");
            menus.RestartOvrTexture = Content.Load<Texture2D>("Textures/RestartOvr.png");
            menus.ResumeTexture = Content.Load<Texture2D>("Textures/ResumeButton.png");
            menus.ResumeOvrTexture = Content.Load<Texture2D>("Textures/ResumeOvr.png");
            menus.SaveTexture = Content.Load<Texture2D>("Textures/SaveButton.png");
            menus.SaveOvrTexture = Content.Load<Texture2D>("Textures/SaveOvr.png");
            //load in player texture
            stickFigure = Content.Load<Texture2D>("Textures/Stickman_Handgun.png");
            player.PlayerTexture = stickFigure;
            walking = Content.Load<Texture2D>("Textures/Spritesheet.png");
            player.WalkingTexture = walking;
            //load in gun texture
            telegun = Content.Load<Texture2D>("Textures/TeleGun_Handgun.png");
            gun.GunImage = telegun;
            //texture for mouse
            crosshare = Content.Load<Texture2D>("Textures/Crosshair.png");
            // make textures for the level1
            terrain = level1.NextScreen(1, bullet);
            spikes = Content.Load<Texture2D>("Textures/Spikes.png");
            terrainBlock = Content.Load<Texture2D>("Textures/terrain.png");
            foreach (Terrain t in terrain)
            {
                //Will need to be fixed eventually. - has been fixed
                if (t is DeathObject)
                {
                    t.Image = spikes;
                }
                else
                {
                    t.Image = terrainBlock;
                }
            }
            //texture for bullet
            bullet.BulletTexture = Content.Load<Texture2D>("Textures/Bullet.png");
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
            //update mouse
            mouse.X = mouseState.X - 15;
            mouse.Y = mouseState.Y - 15;
            switch (gamestate)
            {
                case GameState.Main:
                    {
                        menus.Load(GraphicsDevice.Viewport.Width / 2 -40, 300);
                        menus.Quit(GraphicsDevice.Viewport.Width / 2 - 40, 375);
                        menus.Start(GraphicsDevice.Viewport.Width / 2 -40, 225);
                        if (kbState.IsKeyDown(Keys.Enter)==true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            //changes game state to game if enter is pressed
                            previousGamestate = gamestate;
                            gamestate = GameState.Game;
                        }
                        else if (kbState.IsKeyDown(Keys.Escape) && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            //exits game if esc is pressed at main menu
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
                        if(previousGamestate == GameState.Main || previousGamestate == GameState.LevelClear) //restarts
                        {
                            Restart();
                        }
                        //pauses menu if player presses esc while playing
                        if (kbState.IsKeyDown(Keys.Escape) == true && previousKbState.IsKeyUp(Keys.Escape))
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.Paused;
                        }
                        // player falls to their death
                        else if (player.Y > GraphicsDevice.Viewport.Height)
                        {
                            player.PlayerLives--;
                            player.X = 50;
                            player.Y = 370;
                            //previousGamestate = gamestate;
                            //gamestate = GameState.GameOver;
                        }
                        else
                        {
                            previousGamestate = gamestate;
                        }
                        //update for moving terrain
                        foreach (Terrain t in terrain)
                        {
                            if (t is SpecialTerrain || t is DeathObject || t is LevelGoal)
                            {
                                t.Update();
                            }
                            if(t is DeathObject)
                            {
                                if(t.CollisionDetected(player.Position)==true)
                                {
                                    player.PlayerLives--;
                                    player.X = 50;
                                    player.Y = 370;
                                    //previousGamestate = gamestate;
                                    //gamestate = GameState.GameOver;
                                }
                            }
                            if(t is LevelGoal)
                            {
                                if(t.CollisionDetected(player.Position)==true)
                                {
                                    previousGamestate = gamestate;
                                    gamestate = GameState.LevelClear;
                                }
                            }
                        }
                        //add player update for movement
                        player.Update(kbState, previousKbState, terrain, gun, gamestate, mouseState);
                        //Keep the gun at the same position relative to the player
                        gun.Update(player);
                        //update the bullet
                        bullet.Update(terrain, gun, player, mouseState, previousMState, gun.Rotation, kbState, GraphicsDevice, this);
                        //changes screen when player passes far right of viewport
                        if (player.X > GraphicsDevice.Viewport.Width || (gamestate==GameState.Game) && (previousGamestate==GameState.LevelClear))
                        {
                            screenCounter++;
                            terrain.Clear();
                            if(levelCounter==1)
                            {
                                terrain = level1.NextScreen(screenCounter, bullet);
                            }
                            if(levelCounter==2)
                            {
                                terrain = level2.NextScreen(screenCounter, bullet);
                            }
                            for (int x = 0; x < terrain.Count; x++)
                            {
                                //terrain[x].Image = Content.Load<Texture2D>("Textures/terrain.png");
                                if (terrain[x] is DeathObject)
                                {
                                    terrain[x].Image = spikes;
                                }
                                else
                                {
                                    terrain[x].Image = terrainBlock;
                                }
                            }
                            player.X = 50;
                            player.Y = 370;
                        }
                        //allows player to return to previous screen if exits viewport to left
                        if (player.X < GraphicsDevice.Viewport.X || (gamestate == GameState.Game) && (previousGamestate == GameState.LevelClear))
                        {
                            screenCounter--;
                            terrain.Clear();
                            if (levelCounter == 1)
                            {
                                terrain = level1.NextScreen(screenCounter, bullet);
                            }
                            if (levelCounter == 2)
                            {
                                terrain = level2.NextScreen(screenCounter, bullet);
                            }
                            for (int x = 0; x < terrain.Count; x++)
                            {
                                //terrain[x].Image = Content.Load<Texture2D>("Textures/terrain.png");
                                if (terrain[x] is DeathObject)
                                {
                                    terrain[x].Image = spikes;
                                }
                                else
                                {
                                    terrain[x].Image = terrainBlock;
                                }
                            }
                            player.X = GraphicsDevice.Viewport.Width - 50;
                            player.Y = 370;
                        }
                        if(player.PlayerLives == 0)
                        {
                            previousGamestate = gamestate;
                            gamestate = GameState.GameOver;
                        }

                        // update animation
                        player.UpdateAnimation(gameTime);
                    }//end of game case
                    break;
                case GameState.Paused:
                    {
                        menus.Restart(GraphicsDevice.Viewport.Width / 2 - 40, 200);
                        menus.Save(GraphicsDevice.Viewport.Width / 2 - 40, 275);
                        menus.Resume(GraphicsDevice.Viewport.Width / 2 - 40, 125);
                        menus.Menu(GraphicsDevice.Viewport.Width / 2 - 40, 350);
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
                case GameState.LevelClear:
                    {
                        if(kbState.IsKeyDown(Keys.Enter) == true && previousKbState.IsKeyUp(Keys.Enter))
                        {
                            previousGamestate = gamestate;
                            levelCounter++;
                            screenCounter = 1;
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
                        menus.Restart(GraphicsDevice.Viewport.Width / 2 - 40, 125);
                        menus.Menu(GraphicsDevice.Viewport.Width / 2 - 40, 200);
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
            }//end of switch statement
            menus.Update(mouseState, this, previousGamestate, previousMState);
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
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Start);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Load);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Exit);
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
                            if(terrain[x] is LevelGoal)
                            {
                                terrain[x].Draw(spriteBatch);
                            }
                        }
                        //THIS SHOULD BE TRACKING THE MOUSE POSITION BUT IT ISN'T AND I HATE IT! For some reason the mouseState is never changing...
                        string mouse = ("Mouse X: " + mouseState.X + " Mouse Y: " + mouseState.Y + " Rotation: " + gun.Rotation);
                        //spriteBatch.DrawString(font, mouse, fontPosition, Color.Red);
                        //UI - Lives left
                        spriteBatch.DrawString(font, "Lives: " + player.PlayerLives, fontPosition, Color.Black);
                        //UI-level #
                        spriteBatch.DrawString(font, "Level: "+ levelCounter, new Vector2(GraphicsDevice.Viewport.Width -100, 5), Color.Black);
                        //UI- bullets left for puzzle
                        spriteBatch.DrawString(font, "Bullets: " + bullet.Bullets, new Vector2(GraphicsDevice.Viewport.Width - 100, GraphicsDevice.Viewport.Height - 25), Color.Black);
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
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Resume);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Restart);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Menu);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Save);
                    }
                    break;
                case GameState.LevelClear:
                    {
                        string cleared = "Level Cleared! \n Press Enter to go to next level";
                        spriteBatch.DrawString(font, cleared, fontPosition, Color.Black);
                    }
                    break;
                case GameState.GameOver:
                    {
                        string death = "GAME OVER\n Press Esc to go to the main menu \n Press Enter to start over";
                        spriteBatch.DrawString(font, death, fontPosition, Color.Red);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Restart);
                        menus.Draw(spriteBatch, mouseState, Config.Buttons.Menu);
                    }
                    break;
            }//end of switch statement
            //draw mouse
            spriteBatch.Draw(crosshare, mouse, Color.White);
            //end spritebatch
            spriteBatch.End();

            base.Draw(gameTime);
        }//end of draw method
        /// <summary>
        /// Ensures that the player starts on the first screen of the level
        /// </summary>
        public void Restart()
        {
            screenCounter = 1;
            if (levelCounter == 1)
            {
                terrain = level1.NextScreen(screenCounter, bullet);
            }
            if (levelCounter == 2)
            {
                terrain = level2.NextScreen(screenCounter, bullet);
            }
            //loads terrain
            for (int x = 0; x < terrain.Count; x++)
            {
                if (terrain[x] is DeathObject)
                {
                    terrain[x].Image = spikes;
                }
                else
                {
                    terrain[x].Image = terrainBlock;
                }
            }
            //resets player position
            player.X = 50;
            player.Y = 370;
            //resets player lives
            player.PlayerLives = 3;
        }
    }
}
