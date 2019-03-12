using Microsoft.Xna.Framework;
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
        protected Rectangle hitbox;
        protected int hp;
        protected double speed;


        public Rectangle HitBox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
