using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Game_slutprojekt
{
    public enum Menu
    {
        Start,
        Option,
        Game
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
        private Menu menu = Menu.Start;
        private Rectangle knapp = new Rectangle(30, 50, 70, 90);
        private Rectangle knapp2 = new Rectangle(110, 50, 70, 90);
        private Texture2D menu1;
        private Texture2D menu2;
        private List<Fiende> fiendeList;
        private Texture2D r;
        private string File;
        private bool hit;
        private bool träff;

        private bool isPlaying;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            player = new Player(spelareTex, r);
            enemy = new Fiende(fiendeTex, player);
            fiendeList = new List<Fiende>();
            fiendeList.Add(enemy);
            //Här lägger jag in en fil som heter File där saker som highscore står i
            try
            {
                StreamReader sr = new StreamReader("File.txt");
                File = sr.ReadLine();
                sr.Close();
            }
            catch
            {

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

            //Istället för o skapa en ny klass kan jag använda denna mening.
            spelareTex = Content.Load<Texture2D>("Sans");
            fiendeTex = Content.Load<Texture2D>("Sans2");
            menu1 = Content.Load<Texture2D>("menu1");
            r = Content.Load<Texture2D>("R");
            menu2 = Content.Load<Texture2D>("menu2");
            //För att kunna ladda in och skapa animationen. 8 visar hur många rader vågrätt och 3 visar hur många rader lodrätt (delar även bilden)
            Texture2D texture = Content.Load<Texture2D>("Sans");
            animatedSprite = new moving(texture, 3, 8,.3f);


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

        //Gametime = "speltiden" 
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            /// <summary>
            /// Menyerna uppdateras. Om meny är start så uppdateras start. Om man därefter trycker ner enter så ska spelet börja starta. Om meny inte är start så är meny något annat. exempel game
            /// </summary>
            if (menu == Menu.Start)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    menu = Menu.Game;
                else if(Mouse.GetState().LeftButton == ButtonState.Pressed && knapp.Contains(Mouse.GetState().Position))
                {
                    menu = Menu.Game;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    menu = Menu.Option;
            }
            //´När "Gamemenyn" är igång så uppdateras spelare, animation och fiende 
            else if (menu == Menu.Game)
            {
                player.PlayerUpdate(gameTime);
                //Går igenom fiendelistan så varje fiende gör samma sak
                foreach (Fiende f in fiendeList)
                {
                    f.Update();
                }
                animatedSprite.Update();
                
            }
            else if (menu == Menu.Option)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    menu = Menu.Option;
            }


            // Försökte kopiera en kollision på nätet mellan 2 objekt men något verkar fel
            if (träff)
            {
                spelareTex = fiendeTex;
            }

            Rectangle playerBox = new Rectangle((int)pos.X, (int)pos.Y,
                spelareTex.Width, spelareTex.Height);
            hit = false;

            foreach (var Fiende in fiendeList)
            {
                Rectangle fiendeBox = new Rectangle((int)fiendeTex.X, (int)fiendeTex.Y,
                    fiendeTex.Width, fiendeTex.Height);

                
                var kollision = Intersection(playerBox, fiendeBox);

                if (kollision.Width > 0 && kollision.Height > 0)
                {
                    Rectangle r1 = Normalize(playerBox, kollision);
                    Rectangle r2 = Normalize(fiendeBox, kollision);
                    hit = Träff(spelareTex, r1, fiendeTex, r2);
                    if (hit)
                    {
                        isPlaying = false;
                    }
                }
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
            if (menu == Menu.Start)
            {
                spriteBatch.Draw(menu1, knapp, Color.White);
                spriteBatch.Draw(menu2, knapp2, Color.White);
            }
            else if (menu == Menu.Game)
            {
                player.Draw(spriteBatch);
                foreach(Fiende f in fiendeList)
                {
                    f.Draw(spriteBatch);
                }
            }
            else if (menu == Menu.Option)
            {
            
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }
}
