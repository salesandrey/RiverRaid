using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace RIVER_RAID
{
    class Aviao
    {
        #region ATRIBUTOS
        public Rectangle pos;
        public Boolean aviaovivo;
        #endregion
        #region PROPRIEDADES
        #endregion
        #region CONSTRUTORES
        public Aviao()
        {

            pos = new Rectangle(400, 400, 50, 60);
            aviaovivo = true;
        }
        #endregion
        #region MÉTODOS
        public void direita()
        {
            if (pos.X <= 750)
            pos.X = pos.X + 5;
        }
        public void esquerda()
        {
            if(pos.X>=135)
            pos.X = pos.X - 5;
        }

        public void frente()
        {
            if (pos.Y >= 0)
            pos.Y = pos.Y - 3;
        }

        public void tras()
        {
            if (pos.Y <= 540)
            pos.Y = pos.Y + 3;
        }
        public Tiro atirar(GerenciadorTiro gt)
        {
            Tiro t = gt.getTiro();
            if (t != null)
            {
                t.pos = this.pos;
                t.pos.X += 10;
                t.pos.Y += 5;
                t.Disparar();
            }
            return t;
        }

        public bool Colisaodoavisao(Obstaculo[] obs, Aviao Avi)
        {
            if(aviaovivo)
                for (int i = 0; i < obs.Length; i++)
                {
                    if (obs[i].ativo)
                    {
                        for (int j = 0; j < obs.Length; j++)
                        {
                            if (Avi.pos.Intersects(obs[j].pos))
                            {
                                aviaovivo = false;
                                obs[j].atingido=true;
                                
                                
                            }
                        }
                    }
                }

            

            return true;
        }

        #endregion


    }
}

