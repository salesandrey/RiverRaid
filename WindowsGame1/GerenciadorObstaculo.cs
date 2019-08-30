using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RIVER_RAID
{
    class GerenciadorObstaculo
    {

        private List<Obstaculo> lista;
        private Random rnd;
        public int obstaculosAtivos;

        public GerenciadorObstaculo()
        {
            lista = new List<Obstaculo>();
            obstaculosAtivos = 0;
            rnd = new Random();
            Obstaculo obst;
            for (int i = 0; i < 20; i++)
            {

                obst = fabricarObstaculo();
                obst.Disparar();
                lista.Add(obst);
            }
        }

        private Obstaculo fabricarObstaculo()
        {
            Obstaculo obstac=null;

            int i = rnd.Next(0, 3);

            
            switch (i) 
            {
                case 0:obstac = new Obstaculo(tipoObstaculo.Cloud, 0, 0);
                    break;
                case 1:obstac = new Obstaculo(tipoObstaculo.Missil, 0, 0);
                    break;
                case 2:obstac = new Obstaculo(tipoObstaculo.AviaoInimigo, 0, 0);
                    break;

            }

            return obstac;
        }

        public Obstaculo gerarObstaculo()
        {
            Obstaculo obst = null;
            int i=0;

            while ((i<lista.Count) && (obst==null)){

                if (lista[i].ativo == false)
                {
                    lista[i].ativo = true;
                    lista[i].atingido = false;
                    obst = lista[i];
                    if(tipoObstaculo.AviaoInimigo==obst.tipo)
                    obst.pos= new Rectangle(410 - rnd.Next(1, 5)*60, 0-rnd.Next(1,7)*70, 60,60);
                    else if(tipoObstaculo.Missil==obst.tipo)
                    obst.pos = new Rectangle(1000 - rnd.Next(1, 3) * 70, 600 - rnd.Next(1, 7) * 60, 60, 60);
                    else if(tipoObstaculo.Cloud==obst.tipo)
                        obst.pos = new Rectangle(410 - rnd.Next(1, 5) * 60, -60, 60, 60);
                    obstaculosAtivos++;
                }
 
                i++;
            }

            return obst;
        }


        public void finalizar()
        {
            int i = 0;

            while (i < lista.Count) 
            {
               lista[i].vivo = false;
               i++;
            }
            obstaculosAtivos = 0;
        }

        public void Add(Obstaculo t)
        {
            lista.Add(t);
        }

        public Obstaculo[] toArray()
        {
            return lista.ToArray();
        }

        public void drawObstaculo(Texture2D []texture, SpriteBatch SB)
        {
            

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ativo)
                {
                    int iTextura = (int)lista[i].tipo;
                    DrawObstaculo.draw(lista[i], SB, texture[iTextura]);
                    if ((lista[i].pos.Y > 600) || (lista[i].atingido))
                    {
                        //lista.Remove(lista[i]);
                        lista[i].ativo = false;
                        obstaculosAtivos--;
                    }
                }
            }
        }
    }
}
