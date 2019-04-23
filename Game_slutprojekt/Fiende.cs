using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_slutprojekt
{
    class Fiende:Gubbe
    {
        private Player Spelare;
        private moving moving;
        public Fiende(Texture2D texture, Player Spelare): base(texture)
        {
            speed = 6;
            hp = 1;
            Random rand = new Random();
            moving = new moving(texture, 3, 8, 0.3f);
            int sida = rand.Next(0, 4);
            // Skärmstorlek    800 x 480
            // Vänster
            if (sida == 0)
            {
                pos.X = rand.Next(-100, -20);
                pos.Y = rand.Next(0, 400);
            }
            //Höger
            else if(sida == 1)
            {
                pos.X = rand.Next(490, 880);
                pos.Y = rand.Next(0, 400);
            }
            //Upp
            else if (sida == 2)
            {
                pos.X = rand.Next(-20, 800);
                pos.Y = rand.Next(-100, -20);
            }
            //Ner
            else if(sida == 3) 
            {
                pos.X = rand.Next(-20, 800);
                pos.Y = rand.Next(485, 585);
            }
            this.Spelare = Spelare;


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            moving.Draw(spriteBatch, pos);
        }
        //Här fixar jag till det så att fienden ska kunna spawna från olika vinklar och följa efter spelaren beroende på vart spelaren är
        public override void Update()
        {
            Vector2 vel = Spelare.Pos - pos;
            vel.Normalize();
            pos += vel * speed;
        }
    }
}
