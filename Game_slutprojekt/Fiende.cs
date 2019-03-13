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
       public Fiende(Texture2D texture): base(texture)
        {
            speed = 6;
            hp = 1;
        }
    }
}
