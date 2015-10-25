using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MiniMinecraft
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Initialize the player object
        Player player;

        //Initialize the zombie object
        Zombie zombie;

        //Initialize the cloud object
        Cloud cloud;
        
        //Initialize the Dust Object and its values
        Dust dust;
        Texture2D dustTexture;
        Rectangle dustHolder;
        int dustWidth = 30, dustHeight = 30;

        //screen values
        int screenHeight, screenWidth;



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
            // TODO: Add your initialization logic here

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
            // TODO: use this.Content to load your game content here
            
            /*Loading the Value of screen parameters*/
            screenHeight = GraphicsDevice.Viewport.Height;
            screenWidth = GraphicsDevice.Viewport.Width;

            /*Load content for player*/
            player = new Player();
            player.PlayerSetTexture(Content.Load<Texture2D>("Player"));
            player.PlayerSetRectangle(new Rectangle(770, 338, 30, 50));

            //Load content for Zombie
            zombie = new Zombie(Content.Load<Texture2D>("Zombie"));
            zombie.makeZombieCrew();

            //Load Content for Cloud
            cloud = new Cloud(Content.Load<Texture2D>("Cloud"));
            cloud.setCloudPosition();

            //Load content for Dust
            dust = new Dust();
            dust.setSize(3 * screenWidth / 25);

            for (int i = 0; i < 3; i++)
            {
                dustTexture = Content.Load<Texture2D>("dust");
                for (int j = 0; j < 27; j++)
                {   
                    dustHolder = new Rectangle((j * dustWidth), screenHeight - ((i+1) * dustHeight), dustWidth, dustHeight);
                    dust.InitDustStruct((i * 27 + j), dustTexture, dustHolder);
                }
            }
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            //show mouse on the Game Screen;
            IsMouseVisible = true;

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            //Update Movement for Zombie;
            zombie.GetPlayerPosition(player.playerGetRectangle().X);
            zombie.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                player.Draw(spriteBatch);
                dust.Draw(spriteBatch);
                zombie.Draw(spriteBatch);
                cloud.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
