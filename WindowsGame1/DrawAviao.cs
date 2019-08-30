using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RIVER_RAID
{
    class DrawAviao
    {
        public static void draw(Aviao aviao, SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, aviao.pos, Color.White);
        }
    }
}
