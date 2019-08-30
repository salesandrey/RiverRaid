using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RIVER_RAID
{
    class DrawTiro
    {
        public static void draw(Tiro tiro, SpriteBatch spriteBatch, Texture2D texture)
        {

            Rectangle r = new Rectangle((int)tiro.pos.X, (int)tiro.pos.Y , tiro.largura, tiro.altura);
            spriteBatch.Draw(texture, r, Color.White);
            
        }
    }
}
