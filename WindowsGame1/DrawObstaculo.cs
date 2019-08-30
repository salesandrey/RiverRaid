using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RIVER_RAID
{
    class DrawObstaculo
    {
        public static void draw(Obstaculo obs, SpriteBatch spriteBatch, Texture2D texture)
        {
            
            Rectangle r = new Rectangle((int)obs.pos.X, (int)obs.pos.Y , obs.largura, obs.altura);
            if(obs.atingido==false)
            spriteBatch.Draw(texture, r, Color.White);
        }
    }
}
