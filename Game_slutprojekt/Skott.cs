﻿using Microsoft.Xna.Framework;
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
        private int speed = 7;
        Vector2 dir;
        private bool isDead = false;

        public Skott(Texture2D Texture, Vector2 p) : base(Texture)
        {
            pos = p;
            hitbox = new Rectangle((int)p.X, (int)p.Y, 15, 15);
            dir = Mouse.GetState().Position.ToVector2() - pos;
            dir.Normalize();
        }

        public override void Update()
        {
            pos += dir * speed;
            hitbox.Location = pos.ToPoint();
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
    }
}
