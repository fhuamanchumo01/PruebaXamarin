using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Appprueba
{
    public static class GestorNotas
    {
        static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static string _notesFileName = Path.Combine(path, "notes.txt");

        //Esto devuelve la lista que está en el fichero (o una nueva lista si no existe)
        public static List<Nota> LeerNotas()
        {
            if (!File.Exists(_notesFileName))
            {
                File.Create(_notesFileName);
            }
            var listaSerializada = File.ReadAllText(_notesFileName);
            List<Nota> lista;
            if (string.IsNullOrEmpty(listaSerializada))
            {
                lista = new List<Nota>();
            }
            else
            {
                lista = JsonConvert.DeserializeObject<List<Nota>>(listaSerializada);
            }
            return lista;
        }

        public static void GuardarNotas(List<Nota> notas)
        {
            var textoSerializado = JsonConvert.SerializeObject(notas);
            File.WriteAllText(_notesFileName, textoSerializado);
        }

        public static List<Nota> CrearNota(Nota  nota)
        {
            var lista = LeerNotas();
            var ultimoId=0;
            if (lista.Count == 0) {
                ultimoId = 1;
            }
            else {
                ultimoId = lista.Max(x => x.Id) + 1;
            }
            nota.Id = ultimoId;
            lista.Add(nota);
            GuardarNotas(lista);
            return lista;
        }
        
        public static List<Nota> ActualizarNota(Nota  nota)
        {
            var lista = LeerNotas();
            var match = lista.FirstOrDefault(x => x.Id == nota.Id);
            if (match != null)
            { 
                //op1
                //existe un item en la lista que coincide
                match.Titulo = nota.Titulo;
                match.Contenido = nota.Contenido;

                //op2
                //var index = lista.IndexOf(match);
                //lista.Remove(match);
                //lista.Insert(index, nota);
                
                GuardarNotas(lista);
            }
            return lista;
        }

        public static List<Nota> BorrarNota(Nota nota)
        {
            var lista = LeerNotas();
            var match = lista.FirstOrDefault(x => x.Id == nota.Id);
            if (match != null)
            {
                //existe un item en la lista que coincide
                lista.Remove(match);
                GuardarNotas(lista);
            }
            return lista;
        }
    }
}