using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class DrawMenu
    {

        public static void draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.Draw(Botaoiniciar, posButton2, Color.White);
            spriteBatch.Draw(Botaoinstrucoes, posButton3, Color.White);
            spriteBatch.Draw(BotaoSair, posbutton, Color.White);
        }



    }
}
