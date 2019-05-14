using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_slutprojekt
{
    class Gubbe:Bas
    {
        //Egenskaperna som både fiende och spelare ska ha
        protected int hp;
        protected float speed;

        //För att kunna rita ut gubben, måste texture ritas ut
        public Gubbe(Texture2D texture): base(texture)
        {

        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        protected void move(int xDif, int yDif)
        {
            pos.X += xDif;
            pos.Y += yDif;
        }
    }
}
