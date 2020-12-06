using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace Appprueba
{
   

    public partial class MainPage : ContentPage
    {
        


        public IList<Class1> Class1s { get; private set; }

        /*public IList<Page1> Page1s { get; private set; }*/
        public MainPage()
        {
            InitializeComponent();
            Class1s = new List<Class1>();

            

            Class1s.Add(new Class1

            { name = "n",

              
  
            }
                );

            /*Page1s = new List<Page1>();
            Page1s.Add(new Page1
            { hola=entrada,})*/


            BindingContext = this;

         
        }

       
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1 selectedItem = e.SelectedItem as Class1;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Class1 tappedItem = e.Item as Class1;
        }

        private void boton1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

       
    }
}
