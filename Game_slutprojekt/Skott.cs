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
    class Skott: Bas
    {
        private int speed = 4;
        Vector2 dir;
        public Skott(Texture2D Texture, Vector2 p) : base(Texture)
        {
            pos = p;
            Hitbox = new Rectangle(p.ToPoint(),new Point(10,10));
            dir = Mouse.GetState().Position.ToVector2() - pos;
            dir.Normalize();
        }

        public override void Update()
        {
            
            pos += dir * speed;
        }
    }
}
