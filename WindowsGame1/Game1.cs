using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace RIVER_RAID
{
    /// <summary>
    /// This is the main type for your game
    
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        #region Atributos do fundo
        private Texture2D backGround;
        private int posY1=0;
        #endregion
        bool tiroPreparado;
        int tempoTiro;
        Aviao aviao;
        Tiro tiro;
        Obstaculo obstaculo;
        GerenciadorTiro gt;
        GerenciadorObstaculo go;
        
        Random rnd;
        int pontos = 0;
        
        MouseState mousestate;


        Texture2D texturaAviao;
        Texture2D texturaTiro;
        Texture2D texturaBarco;
        Texture2D [] texturaObstaculo;
        Texture2D Botaoiniciar;
        Texture2D Botaoinstrucoes;
        Texture2D Tela;
        Texture2D BotaoSair;
        SpriteFont arialFont;
        Rectangle posbutton;
        Rectangle posButton2;
        Rectangle posButton3;


        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            aviao = new Aviao();
            tiro = null;
            obstaculo = null;
            tiroPreparado = false;
            tempoTiro = 0;
            gt = new GerenciadorTiro();
            go = new GerenciadorObstaculo();
            rnd = new Random();
            IsMouseVisible = true;
            posbutton = new Rectangle(250, 400, 300, 100);
            posButton2=new Rectangle(250, 200, 300, 100);
            posButton3 = new Rectangle(250, 300, 300, 100);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arialFont = Content.Load<SpriteFont>("Arial");
            carregarSprites();
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            gt.finalizar();
            go.finalizar();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
              

            
            
            tempoTiro--;

            posY1 = posY1 + 4;

            if (posY1 > 600)
            {
                posY1 = 0;

            }

            int rand = rnd.Next(-1000, 1000);

            if ((Math.Abs(rand) <= 0) || (go.obstaculosAtivos==0))
            {
                obstaculo=go.gerarObstaculo();
            }

            Obstaculo[] obstaculos = go.toArray();

            for (int i = 0; i < obstaculos.Length; i++)
            {
                if (gt.verificarColisao(obstaculos[i]))
                {
                    obstaculos[i].atingido = true;
                    pontos += 1;

                }
                
            }



            aviao.Colisaodoavisao(obstaculos, aviao);
            Clickdomouse(mousestate.X,mousestate.Y); 
                   
                    

                

            

            avaliarJogada();
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

                //spriteBatch.Draw(Tela, new Rectangle(0, 0, 800, 600), Color.White);
                //spriteBatch.Draw(Botaoiniciar, posButton2, Color.White);
                //spriteBatch.Draw(Botaoinstrucoes, posButton3, Color.White);
                //spriteBatch.Draw(BotaoSair, posbutton, Color.White);

            
           
                spriteBatch.Draw(backGround, new Rectangle(0, posY1, 800, 600), Color.White);
                spriteBatch.Draw(backGround, new Rectangle(0, posY1 - 600, 800, 600), Color.White);
                gt.drawTiros(texturaTiro, spriteBatch);
                go.drawObstaculo(texturaObstaculo, spriteBatch);

                if (aviao.aviaovivo == true)
                    DrawAviao.draw(aviao, spriteBatch, texturaAviao);

                Vector2 posPontos = new Vector2(10, 10);

                spriteBatch.DrawString(arialFont, "Pontos : " + pontos, posPontos, Color.Black);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        #region Funções Auxiliares
          private void carregarSprites()
          {
              backGround = Content.Load<Texture2D>("fundo");
              texturaAviao = Content.Load<Texture2D>("aviao");
              texturaTiro = Content.Load<Texture2D>("Tiro");
              texturaBarco = Content.Load<Texture2D>("missil");
              Botaoiniciar = Content.Load<Texture2D>("botaojogar");
              Botaoinstrucoes = Content.Load<Texture2D>("botaooop");
              Tela = Content.Load<Texture2D>("menu");
              BotaoSair = Content.Load<Texture2D>("botaosair");
              
              texturaObstaculo = new Texture2D[3];
              texturaObstaculo[0] = Content.Load<Texture2D>("missil");
              texturaObstaculo[1] = Content.Load<Texture2D>("aviao1");
              texturaObstaculo[2] = Content.Load<Texture2D>("cloud");
          }


        

        protected void avaliarJogada()
        {
            KeyboardState newState = Keyboard.GetState();


            if (newState.IsKeyDown(Keys.Right))
            {
                aviao.direita();
            }

            if (newState.IsKeyDown(Keys.Left))
            {
                aviao.esquerda();
            }

            if (newState.IsKeyDown(Keys.Up))
            {
                aviao.frente();
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                aviao.tras();
            }

            if ((newState.IsKeyDown(Keys.Space)) && (!tiroPreparado) && (tempoTiro<=0))
            {
                tiroPreparado = true;
                tiro = aviao.atirar(gt);
                if (tiro != null)
                {
                    tiro.Disparar();
                }
                
                tiroPreparado = false;
                tempoTiro = 30;
                //tempoTiro = 100;
            }


            if ((newState.IsKeyUp(Keys.Space)) && (tiroPreparado))
            {
                /*tiro = aviao.atirar();
                tiro.Disparar();
                gt.Add(tiro);
                soundBank.PlayCue("Explosion");
                tiroPreparado = false;
                tempoTiro = 10;*/
            }


            if (newState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }


        }

        protected void Clickdomouse(int x, int y)
        {
            mousestate = Mouse.GetState();
            Point posicaodomouse = new Point(x, y);
            //if ( mousestate.LeftButton == ButtonState.Pressed && posbutton.Contains(posicaodomouse))
            //{

               
                

            //}

            //if (mousestate.LeftButton == ButtonState.Pressed && posButton2.Contains(posicaodomouse))
            //{

                
                
            //}

        }

        #endregion

    }
}
