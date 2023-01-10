using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaPelicula : ContentPage
    {
        public VistaPelicula(string Nombre, string imagen)
        {
            InitializeComponent();
            lbPelicula.Text = Nombre;
            pbImagen.Source = imagen.ToString();
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {

        }
    }
}