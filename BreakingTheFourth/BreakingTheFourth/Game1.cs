using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BreakingTheFourth
{
    /// <summary>
    /// This is the main type for your game.
    /// //This is the main game class, will be used to call methods and of course run the game. 
    /// //I assumed most of our methods will be in other classes, but the most recent homework may have proved otherwise
    /// //Will need space for loading content, initialization, etc.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //add in player object and fields but don't intialize
        Player player;
        Texture2D stickFigure;
        //fields for getting keyboard states
        KeyboardState kbState;
        KeyboardState previousKbState;
        List<Terrain> terrain;
        Level1 level1;
        int screenCounter;
        SpecialTerrain st;

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
            terrain = new List<Terrain>();
            level1 =  new Level1();
            st = new SpecialTerrain(400, 399, 75, 75);
            screenCounter = 1;
            base.Initialize();
        }
        public void CreateTerrain()
        {
            terrain.Add(new Terrain(50, 150, 50, 50));
            terrain.Add(new Terrain(0, GraphicsDevice.Viewport.Height-90, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height / 5));

           

            //test platform
            terrain.Add(new Terrain(150, 200, 70, 100));
            for(int x=0; x<terrain.Count; x++)
            {
                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
            }

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
            st.Image = Content.Load<Texture2D>("terrain.png");
            // make textures for the level1
            terrain = level1.NextScreen(1);
            for (int x = 0; x < terrain.Count; x++)
            {
                terrain[x].Image = Content.Load<Texture2D>("terrain.png");
            }
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            previousKbState = kbState;
            kbState = Keyboard.GetState();
            //add player update for movement
            player.Update(kbState, previousKbState, terrain, st);
            st.Update();
            if(player.X > GraphicsDevice.Viewport.Width)
            {
                screenCounter++;
                terrain.Clear();
                terrain = level1.NextScreen(screenCounter);
                for (int x = 0; x < terrain.Count; x++)
                {
                    terrain[x].Image = Content.Load<Texture2D>("terrain.png");
                }
                player.X = 50;
                player.Y = 350;
            }
            

            //level1.CreateLevelOne(player.Position.X);


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
            //drawing methods in here
            player.Draw(spriteBatch);
            for (int x = 0; x < terrain.Count; x++)
            {
                terrain[x].Draw(spriteBatch);
            }
            st.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
