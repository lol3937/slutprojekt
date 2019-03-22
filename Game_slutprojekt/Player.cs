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

        //Skapar en konstruktor som visar specifikt vad som händer i just denna klass
        public Player(Texture2D texture): base(texture)
        {
            
            speed = 3;
            hp = 3;
        }


        /// <summary>
        /// Skapar knappar på tangentbodet som visar vad som händer om jag trycker ner exempel W
        /// </summary>
        public override void Update()
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = -10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 2;
            }

            pos += velocity;

            //skapar en classvariabel av moving för att tangent ska kopplas ihop med spelaren
            class moving 
        }
    }
}
