using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_slutprojekt
{
    class Bas
    {
        
        protected Vector2 pos;
        protected Texture2D tex;

        public Bas(Texture2D texture)
        {
            tex = texture;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

        public Texture2D Tex
        {
            get { return tex; }
            set { tex = value; }
        }

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
    }
}

