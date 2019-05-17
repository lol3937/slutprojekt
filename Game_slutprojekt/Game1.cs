using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System;

namespace Game_slutprojekt
{
    public enum Menu
    {
        Start,
        Option,
        Game,
        LoserScreen
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
        private string file;
        private List<Bas> deadList;
        private SpriteFont highscore;
        private SpriteFont font;
        private SpriteFont font2;
        private Random random = new Random();
        private int poäng = 0;

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
            //deadlist är listan där allt som försvinner ifrån spelrådet hamnar i. Dvs skott och fiender ev spelare
            deadList = new List<Bas>();
            //Här lägger jag in en fil som heter file där saker som highscore står i
            try
            {
                StreamReader sr = new StreamReader("File.txt");
                file = sr.ReadLine();
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
            highscore = Content.Load<SpriteFont>("Highscore");
            font = Content.Load<SpriteFont>("Over");
            font2 = Content.Load<SpriteFont>("About");
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

                foreach (Fiende f in fiendeList)
                {
                    //Om spelare blir träffad = game over
                    if (player.Hitbox.Intersects(f.Hitbox))
                    {
                        menu = Menu.LoserScreen;

                    }
                }

                foreach (Skott s in player.SkottLista)
                {
                    foreach (Fiende f in fiendeList)
                    {
                        if (s.Hitbox.Intersects(f.Hitbox))
                        {
                            deadList.Add(f);
                            deadList.Add(s);
                            //Poäng ökar efter varje fiende som dör
                            poäng++;

                        }
                    }
                }

                foreach (Bas s in deadList)
                {
                    if (s is Skott)
                    {
                        player.SkottLista.Remove((s as Skott));
                    }
                    else if (s is Fiende)
                    {
                        fiendeList.Remove((s as Fiende));
                       
                    }
                }
                int chans = random.Next(0, 1000);
                if (chans <= 10)
                {
                    fiendeList.Add(new Fiende(fiendeTex, player));
                }

                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    menu = Menu.Start;
                }

            }
            else if (menu == Menu.Option)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    menu = Menu.Option;
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    menu = Menu.Start;
                }

            }
            else if (menu == Menu.LoserScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    menu = Menu.Start;
                    fiendeList.Clear();
                    poäng = 0;
                }

            }

            //Skott ska träffa fiende. När skott träffar fiende så ska fiende och skott försvinna. Om spelare träffas av fiende så ska spelare försvinna dvs Game Over


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

                spriteBatch.DrawString(highscore, "Highscore: "+ poäng.ToString(), new Vector2(700,5), Color.Black);
            }
            else if (menu == Menu.Option)
            {
                
                spriteBatch.DrawString(font2, "Skulle vara en option men blev en about istället. \nSpelet är skapat under ett slutprodjekt i Feberuari på Teknikum \nSpelet är ett survivalliknande där du skjuter så många fiender du kan \n Lycka till \n kommandon: röra sig = wsad \n skjuta = vänstemusknapp \n tillbaka till start = b \n start = enter/knappen \n options/about = p", new Vector2(150, 10), Color.Black);
                
            }
            else if(menu == Menu.LoserScreen)
            {
                
                spriteBatch.DrawString(font, "Game Over, Try again", new Vector2(300, 200), Color.DarkRed);
                
            }

            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public static void YouLose()
        {
            
        }

    }
}
