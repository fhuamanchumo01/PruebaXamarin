using System;
using System.Collections.Generic;
using System.Text;

namespace Appprueba
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        
        public string Contenido { get; set; }
        
        public override string ToString()
        {
            return Titulo;
        }
    }
}
