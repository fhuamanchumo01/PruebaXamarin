using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appprueba
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string _notesFileName = Path.Combine(path, "notes.txt");

        Nota _item;

        //para las nuevas
        public Page1()
        {
            InitializeComponent();
        }

        //para las existentes
        public Page1(Nota tappedItem)
        {
            InitializeComponent();
            _item = tappedItem;
            entrada.Text = _item.Titulo;
            editor.Text = _item.Contenido;
        }

        void BotonParaSalvar(object sender, EventArgs e)
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

            if (_item == null)
            {
                //item es nuevo
                int ultimoId = 0;
                if (lista.Any())
                {
                    ultimoId = lista.Max(x => x.Id);
                }
                _item = new Nota()
                {
                    Id = ultimoId +1,
                    Titulo = entrada.Text,
                    Contenido = editor.Text
                };
                lista.Add(_item);
            }
            else
            {
                //si no, actualizamos el item de la lista
                var itemEnLista = lista.First(x => x.Id == _item.Id);
                itemEnLista.Titulo = entrada.Text;
                itemEnLista.Contenido = editor.Text;
            }

            // Si en Titulo no hay texto, no te dejará guardar
            if (entrada.Text != null)
            {
                var textoSerializado = JsonConvert.SerializeObject(lista);
                File.WriteAllText(_notesFileName, textoSerializado);
            }
        }

        void BotonParaEliminar(object sender, EventArgs e)
        {
            if (File.Exists(_notesFileName))
            {
                File.Delete(_notesFileName);
            }

            editor.Text = string.Empty;
        }

       
    }
}