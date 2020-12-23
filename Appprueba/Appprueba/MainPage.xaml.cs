using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace Appprueba
{
    
    public partial class MainPage : ContentPage
    {
        static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string _notesFileName = Path.Combine(path, "notes.txt");


        public IList<Nota> notas { get; private set; }

        /*public IList<Page1> Page1s { get; private set; }*/
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            if (File.Exists(_notesFileName))
            {
                var textoSerializado =  File.ReadAllText(_notesFileName);
                if (string.IsNullOrEmpty(textoSerializado))
                {
                    notas = new List<Nota>();
                    notas.Add(new Nota
                    {
                        Titulo = "Hola",
                        Contenido = "Soy una nota"
                    });
                }
                else
                {
                    notas =  JsonConvert.DeserializeObject<List<Nota>>(textoSerializado);
                }
            }
            else
            {
                notas = new List<Nota>();
                notas.Add(new Nota
                {
                    Titulo = "Hola",
                    Contenido = "Soy una nota"
                });
            }
            listadoNotas.ItemsSource = notas;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!File.Exists(_notesFileName))
            {
                return;
            }
            var textoSerializado =  File.ReadAllText(_notesFileName);
            if (!string.IsNullOrEmpty(textoSerializado))
            {
                listadoNotas.ItemsSource = null;
                notas =  JsonConvert.DeserializeObject<List<Nota>>(textoSerializado);
                listadoNotas.ItemsSource = notas;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Nota selectedItem = e.SelectedItem as Nota;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Nota tappedItem = e.Item as Nota;
            Navigation.PushAsync(new Page1(tappedItem));
        }

        void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void ButtonBorrar(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                //lo ha podido castear o convertir
                var grid = button.Parent as Grid;
                var viewcell = grid.Parent as ViewCell;
                var bindingContext = viewcell.BindingContext;
                var nota = bindingContext as Nota;
                var lista = GestorNotas.BorrarNota(nota);
                listadoNotas.ItemsSource = lista;
            }
        }
    }
}
