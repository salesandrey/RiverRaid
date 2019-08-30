using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace RIVER_RAID
{
    public enum tipoObstaculo {Missil,AviaoInimigo,Cloud,Arvore};
     class Obstaculo
    {
         public Rectangle pos;
         public int altura ;
         public int largura;
         public bool atingido;
         public bool ativo;
         public bool vivo;
         
         private Thread thr;
         

         public tipoObstaculo tipo;
         
         public Obstaculo(tipoObstaculo t,int x, int y)
         {
             tipo = t;
             altura = 50;
             largura = 60;
             atingido = false;
             ativo = false;
             vivo = true;
             pos = new Rectangle(x, y, 50, 60);
             thr = new Thread(new ThreadStart(descer));
         }
          public void descer()
         {
             while (vivo)
             {
                 if (ativo)
                 {
                     pos.Y++;
                     

                     if (this.tipo == tipoObstaculo.AviaoInimigo)
                     {
                         
                         pos.Y=pos.Y+5;
                         
                     }
                     if (this.tipo == tipoObstaculo.Missil)
                     {
                         for(int i=0;i<5;i++)
                         pos.X = pos.X - i;

                     }


                     Thread.Sleep(1000 / 60);
                 }
                 else
                 {
                     Thread.Sleep(800);
                 }
             }
         }

         public void Disparar()
         {
             thr.Start();
         }

    }
}
