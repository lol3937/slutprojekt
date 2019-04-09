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

        //Skapar en konstruktor som visar specifikt vad som händer i just denna klass
        public Player(Texture2D texture): base(texture)
        {
            
            speed = 3;
            hp = 3;
            //skapar en classvariabel av moving för att tangent ska kopplas ihop med spelaren 
            moving = new moving(texture, 3, 8);
        }


        /// <summary>
        /// Skapar knappar på tangentbodet som visar vad som händer om jag trycker ner exempel W
        /// </summary>
        public override void Update()
        {
            velocity = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = 2;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -2;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -2;
                moving.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 2;
                moving.Update();
            }

            pos += velocity;

            

        }

        //Ritar ut på nytt
        public override void Draw (SpriteBatch spriteBatch)
        {
            moving.Draw(spriteBatch, pos);
        }
    }
}
