using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appprueba
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {


       





        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        string _fileName2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes2.txt");
        public Page1()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
               

            }
            if (File.Exists(_fileName2))
            { 
                entrada.Text = File.ReadAllText(_fileName2); 
            }
        }
         

        void BotonParaSalvar(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
            File.WriteAllText(_fileName2, entrada.Text);
        }

        void BotonParaEliminar(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }

        //hola

        /*
        public string hola { get; set; }





        public override string ToString()
        {
            return hola;
        }
        */
    }
}