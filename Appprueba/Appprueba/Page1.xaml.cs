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
            // Si en Titulo no hay texto, no te dejará guardar
            if (entrada.Text == null)
            {
                return;
            }
            
            var lista = GestorNotas.LeerNotas();
            if (_item == null)
            {
                //item es nuevo
                _item = new Nota()
                {
                    Titulo = entrada.Text,
                    Contenido = editor.Text
                };
                GestorNotas.CrearNota(_item);
            }
            else
            {
                //si no, actualizamos el item de la lista
                _item.Titulo = entrada.Text;
                _item.Contenido = editor.Text;
                GestorNotas.ActualizarNota(_item);
            }
        }

        void BotonParaEliminar(object sender, EventArgs e)
        {
            editor.Text = string.Empty;
        }
        
    }
}