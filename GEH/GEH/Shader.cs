﻿using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Threading;
namespace GEH
{
    public class Shader
    {
        public bool ShaderIsLoad;
        private int _idVertexShader;
        private int _idFragmentShader;
        private Matrix4 sendMatrix;
        private string _pathShaderVetrex;
        private string _pathShaderColor;
        private bool disposedValue = false;
        public int Handle { get; private set; }
        public Shader()
        {

        }
        public Shader(string pathShaderVetrex, string pathShaderColor)
        {
            _pathShaderVetrex = pathShaderVetrex;
            _pathShaderColor = pathShaderColor;
        }
        public void UpdateUniform(Matrix4 matrixForUniform)
        {

            // Thread.Sleep(0);
            sendMatrix = matrixForUniform;
            //      Console.WriteLine("time obj update shader:" + DateTime.Now.Millisecond);
            //   Console.WriteLine("Fine");
        }

        private void SetAllUniforms()
        {

           
            // _dictionaryForShaderUniforms[_dictionaryForShaderUniforms.ElementAt(i).Key] = sendMatrix;
            //        Console.WriteLine("time obj set// shader:" + DateTime.Now.Millisecond);


        }
        public void LoadShaders()
        {
           
            string VertexShaderSource;

            using (StreamReader reader = new StreamReader(@"Shaders\"+_pathShaderVetrex, Encoding.UTF8))
            {
                VertexShaderSource = reader.ReadToEnd();
            }

            string FragmentShaderSource;

            using (StreamReader reader = new StreamReader(@"Shaders\" + _pathShaderColor, Encoding.UTF8))
            {
                FragmentShaderSource = reader.ReadToEnd();
            }
            _idVertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(_idVertexShader, VertexShaderSource);

            _idFragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(_idFragmentShader, FragmentShaderSource);
            GL.CompileShader(_idVertexShader);

            string infoLogVert = GL.GetShaderInfoLog(_idVertexShader);
            if (infoLogVert != String.Empty)
                Console.WriteLine(infoLogVert);

            GL.CompileShader(_idFragmentShader);

            string infoLogFrag = GL.GetShaderInfoLog(_idFragmentShader);

            if (infoLogFrag != String.Empty)
                Console.WriteLine(infoLogFrag);

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, _idVertexShader);
            GL.AttachShader(Handle, _idFragmentShader);

            GL.LinkProgram(Handle);
            GL.DetachShader(Handle, _idVertexShader);
            GL.DetachShader(Handle, _idFragmentShader);
            GL.DeleteShader(_idFragmentShader);
            GL.DeleteShader(_idVertexShader);

            ShaderIsLoad = true;

        }
        public void Use()
        {
            //    Console.WriteLine(Camera.main.GetMatrix());
            GL.UseProgram(Handle);

            int location = GL.GetUniformLocation(Handle, "all");


            GL.UniformMatrix4(location, false, ref sendMatrix);

        }




    }
}
