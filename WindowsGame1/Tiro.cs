using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace RIVER_RAID
{
    class Tiro
    {
        
        public Rectangle pos;
        public int altura;
        public int largura;
        private Thread thr;
        public bool vivo;
        public bool ativo;

        public Tiro(int x, int y)
        {
            pos = new Rectangle(x, y, 20, 15);
            altura = 20;
            largura = 15;
            vivo = false;
            ativo = true;
            thr = new Thread(new ThreadStart(Subir));
            thr.Start();
        }

        private void Subir()
        {
            while (ativo)
            {
                if (vivo)
                {
                    pos.Y = pos.Y - 1;
                    Thread.Sleep(10);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }


        public void Disparar()
        {
            this.vivo = true;
            //thr.Start();
        }
    }
}
