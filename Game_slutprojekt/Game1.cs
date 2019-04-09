﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_slutprojekt
{
    public enum Menu
    {
        Start,
        Option,
        Game,
        End
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D spelareTex;
        private Texture2D fiendeTex;
        private Player player;
        private Fiende enemy;
        private moving animatedSprite;
        private Menu Menu = Menu.Start;
        private GameTime gametime = 0;

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
            
            //För att skapa något använder jag initialize för att först skapa spelare, fiende osv för att sedan lägga kunna skriva ut dem i Draw
            base.Initialize();
            player = new Player(spelareTex);
            enemy = new Fiende(fiendeTex);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Istället för o skapa en ny klass kan jag använda denna mening.
            spelareTex = Content.Load<Texture2D>("Sans");
            fiendeTex = Content.Load<Texture2D>("Sans2");

            //För att kunna ladda in och skapa animationen. 8 visar hur många rader vågrätt och 3 visar hur många rader lodrätt
            Texture2D texture = Content.Load<Texture2D>("Sans");
            animatedSprite = new moving(texture, 3, 8);


            // TODO: use this.Content to load your game content here
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
            /// <summary>
            /// Menyerna uppdateras. Om meny är start så uppdateras start. Om man därefter trycker ner enter så ska spelet börja starta. Om meny inte är start så är meny något annat. exempel game
            /// </summary>
            if (Menu == Menu.Start)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    Menu = Menu.Game;
            }
            //´När "Gamemenyn" är igång så uppdateras spelare, animation och fiende 
            else if (Menu == Menu.Game)
            {
                player.Update();
                enemy.Update();
                animatedSprite.Update();
                
            }
            else if (Menu == Menu.Option)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    Menu = Menu.Option;
            }
            else if (Menu == Menu.End)
            {
              
            }

            base.Update(gameTime);
             // TODO: Add your update logic here
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
