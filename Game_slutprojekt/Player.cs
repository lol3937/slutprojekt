using Microsoft.Xna.Framework;
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
        //Skapar en konstruktor som visar specifikt vad som händer i just denna klass
        public Player()
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

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {

            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {

            }
        }
    }
}
