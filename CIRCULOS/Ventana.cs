﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CIRCULOS
{



    class VentanaGame : GameWindow
    {
        Cuadro raqueta1 = new Cuadro();
        Cuadro raqueta2 = new Cuadro();
        Circulo boli = new Circulo();
        Punto uno = new Punto(1, 0);
        Punto dos = new Punto(2,1 );
        Punto tres = new Punto(7, 1);
        Punto cuatro = new Punto(13,13);
        Punto cinco = new Punto(7, 5);
        Colision colisionador = new Colision();
       

        public VentanaGame(int ancho, int alto) : base(ancho, alto)
        {
           
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);


            switch (e.KeyChar)
            {
                
                    case 'w':
                    dos.y++;
                    
                    break;
                    case 's':
                    dos.y--;
                    break;

                case 'o':
                    tres.y++;
                    break;
                case 'l':
                    tres.y--;
                    break;



                }
        }
       


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, 15, 0, 13, -1, 1);
          

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            base.OnUpdateFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(0.5f, 0.5f, 1f, 1f);

        }



        protected override void OnRenderFrame(FrameEventArgs e)
        {


            if (!colisionador.checarlacolision(raqueta1, boli))
            {
                cinco.x -= 0.1;
            }
            else cinco.x += 0.1;


            base.OnRenderFrame(e);


            raqueta1.Imprime(uno, dos);
            raqueta2.Imprime(tres, cuatro);
            boli.Imprime(cinco, 0.5);
            dos.x = uno.x + 0.5;
            

            this.SwapBuffers();
        }

       

    }
}
