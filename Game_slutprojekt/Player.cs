using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_slutprojekt
{
    class Player:Gubbe
    {

        //Skapar 2 "håll" X och Y där starthastigeten och sluthastigheten när jag inte trycker in angiven tangent är 0
        private Vector2 velocity = new Vector2(0);
        private moving moving;
        List<Skott> skottlista = new List<Skott>();
        private Texture2D skottTex;
        private double reloadT = 0;
        private GameTime gameTime;

        //Skapar en konstruktor som visar specifikt vad som händer i just denna klass
        public Player(Texture2D texture, Texture2D texSkott) : base(texture)
        {
            speed = 4;
            //skapar en classvariabel av moving för att tangent ska kopplas ihop med spelaren 
            moving = new moving(texture, 3, 8, 0.3f);
            skottTex = texSkott;

            //när spelare nuddar fiende så ska spelare försvinna
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, 65, 90);
        }


        /// <summary>
        /// Skapar knappar på tangentbodet som visar vad som händer om jag trycker ner exempel W
        /// För att se till så att spelaren inte kan gå utanför spelområdet så avänder jag mig av && pos.x/y > 0
        /// </summary>
        public void PlayerUpdate(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.S) && pos.Y <= 480f-90)
            {
                velocity.Y = 5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && pos.Y > 0)
            {
                velocity.Y = -5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && pos.X > 0)
            {
                velocity.X = -5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && pos.X <= 800f - 65)
            {
                velocity.X = 5;
                moving.Update();
            }

            //När vänster musknapp är nertryckt så skjuts skott i en halvsekund åt gången (ett i taget)
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if(reloadT >= 0.5)
                {
                    skottlista.Add(new Skott(skottTex, pos));
                    reloadT = 0;
                }               
            }
            //kod för att kunna uppdatera lista
            foreach (var Skott in skottlista)
            {
                Skott.Update();
            }

            pos += velocity;
            reloadT += gameTime.ElapsedGameTime.TotalSeconds;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, 65, 90);
        }

        //Ritar ut på nytt
        public override void Draw (SpriteBatch spriteBatch)
        {
            moving.Draw(spriteBatch, pos);
            foreach (var Skott in skottlista)
            {
                Skott.Draw(spriteBatch);
            }
            
        }

        //För att komma åt skottlista från andra klasser
        public List<Skott> SkottLista
        {
            get { return skottlista; }
            set { skottlista = value; }
        }

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }
    }
}
