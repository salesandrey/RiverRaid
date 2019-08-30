using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RIVER_RAID 
{
    class GerenciadorTiro
    {

        private List<Tiro> lista;
        private int numTiros = 20;

        public GerenciadorTiro()
        {
            lista = new List<Tiro>(numTiros );

            for (int i = 0; i < numTiros ; i++)
            {
                Tiro t = new Tiro(0, 0);
                lista.Add(t);
            }
        }


        public Tiro getTiro()
        {
            foreach (Tiro t in lista)
            {
                if (!t.vivo)
                {
                    return t;
                }
            }

            return null;

        }



        public void finalizar()
        {
            Tiro[] t = lista.ToArray();
            int i = 0;
            while (i < t.Length) 
            {
                t[i].vivo=false;
                t[i].ativo = false;
                i++;
            }

            lista.Clear();
        }

        public void Add(Tiro t)
        {
            lista.Add(t);
        }


        public bool verificarColisao(Obstaculo obs)
        {
            Tiro[] t = lista.ToArray();
            int i = 0;
            while ((i < t.Length)&& (obs!=null))
            {
                if (t[i].vivo)
                {
                    if (obs.ativo)
                    {
                        /*if ((obs.pos.Y >= t[i].pos.Y) && (obs.pos.Y <= t[i].pos.Y + t[i].altura) &&
                            (obs.pos.X >= t[i].pos.X) && (obs.pos.X <= t[i].pos.X + t[i].largura)
                            )*/
                        if ((t[i].pos.Y + (t[i].altura / 2) >= obs.pos.Y ) && (t[i].pos.Y - (t[i].altura / 2) <= obs.pos.Y + (obs.altura / 2)) &&
                            (t[i].pos.X+(t[i].largura / 2) >= obs.pos.X ) && (t[i].pos.X-(t[i].largura/2) <= obs.pos.X + (obs.largura / 2))
                           )

                        {
                            //lista.Remove(t[i]);
                            t[i].vivo = false;
                            return true;
                        }
                    }
                }
                i++;
            }
            return false;
        }

        public void drawTiros(Texture2D texture, SpriteBatch SB)
        {
            Tiro[] t = lista.ToArray();

            for (int i = 0; i < t.Length;i++ )
            {
                if (t[i].vivo)
                {
                    DrawTiro.draw(t[i], SB, texture);
                    if (t[i].pos.Y < 0)
                    {
                        t[i].vivo = false;
                        //lista.Remove(t[i]);
                    }
                }
            }
        }
    }
}
