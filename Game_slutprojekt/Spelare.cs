using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_slutprojekt
{
    class Spelare
    {

        //Vad som händer med spelaren om jag trycker ner en knapp på tangentbordet 
        public override void Update()
        {
            //Om jag trycker ner "S" kommer gubben gå 10 pixlar neråt
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -1.5f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 1.5f;
            }
        }
    }
}
