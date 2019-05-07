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

        //Skapar en konstruktor som visar specifikt vad som händer i just denna klass
        public Player(Texture2D texture, Texture2D texSkott): base(texture)
        {
            
            speed = 3;
            hp = 3;
            //skapar en classvariabel av moving för att tangent ska kopplas ihop med spelaren 
            moving = new moving(texture, 3, 8, 0.3f);
            skottTex = texSkott;
        }


        /// <summary>
        /// Skapar knappar på tangentbodet som visar vad som händer om jag trycker ner exempel W
        /// </summary>
        public override void Update()
        {
            velocity = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = 5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -5;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 5;
                moving.Update();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                skottlista.Add(new Skott(skottTex, pos));
               
            }
            //kod för att kunna uppdatera lista
            foreach (var Skott in skottlista)
            {
                Skott.Update();
            }

            pos += velocity;

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
    }
}
