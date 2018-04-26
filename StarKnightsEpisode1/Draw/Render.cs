﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using StarKnightsEpisode1.App;
using StarKnightsEpisode1.Tex;



namespace StarKnightsEpisode1.Draw
{
    public enum BlendMode
    {
        None,Alpha,Add,Mod,Sub
    }
    public static class Render
    {

        public static Vector4 Col = new Vector4(1, 1, 1, 1);

        public static void To2D()
        {

            var pm = Matrix4.CreateOrthographicOffCenter(0, StarKnightsEpisode1.App.StarKnightsAPP.RW,StarKnightsAPP.RH,0, 0, 1);

            //pm = Matrix4.CreateOrthographic(StarKnightsAPP.RW, StarKnightsAPP.RH, 0, 1);


            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
           GL.MultMatrix(ref pm);
           // GL.Ortho(0, StarKnightsAPP.RW, StarKnightsAPP.RH, 0, -200, 1);

        }
        public static void SetBlend(BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.None:
                    GL.Disable(EnableCap.Blend);

                    break;
                case BlendMode.Alpha:
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrc1Alpha);
                    break;
                case BlendMode.Add:
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.One);
                    break;
            }
        }
        public static void Image(Vector2[] p,Tex2D img)
        {
            float[] x = new float[4];
            float[] y = new float[4];
            for(int i = 0; i < 4; i++)
            {
                x[i] = p[i].X;
                y[i] = p[i].Y;
            }
            Image(x, y, img);
        }
        public static void Image(float[] xc,float[] yc,Tex2D img)
        {

            img.Bind(0);

            //'  Col = new Vector4(1, 1, 1, 0.5f);

            GL.Color4(Col);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(xc[0], yc[0]);
            GL.TexCoord2(1, 0);
            GL.Vertex2(xc[1] , yc[1]);
            GL.TexCoord2(1, 1);
            GL.Vertex2(xc[2],yc[2]);
            GL.TexCoord2(0, 1);
            GL.Vertex2(xc[3],yc[3]);

            GL.End();

            img.Unbind(0);

        }
        public static void Image(int x,int y,int w,int h,Tex2D tex)
        {

            tex.Bind(0);

          //'  Col = new Vector4(1, 1, 1, 0.5f);

            GL.Color4(Col);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(x, y);
            GL.TexCoord2(1, 0);
            GL.Vertex2(x + w, y);
            GL.TexCoord2(1, 1);
            GL.Vertex2(x + w, y + h);
            GL.TexCoord2(0, 1);
            GL.Vertex2(x, y + h);

            GL.End();

            tex.Unbind(0);

        }

        public static void Rect(int x,int y,int w,int h)
        {

            GL.Color4(Col);

            GL.Begin(PrimitiveType.Quads);

            GL.Vertex2(x, y);
            GL.Vertex2(x + w, y);
            GL.Vertex2(x + w, y + h);
            GL.Vertex2(x, y + h);

            GL.End();

        }

    }
}