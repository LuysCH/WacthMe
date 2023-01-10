using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using WatchMe.Catalogo;
using System.Net.Http;
using System.Net;
using static WatchMe.Home;

namespace WatchMe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {            

            Uri RequestUri = new Uri("http://192.168.100.5/usuarios?select=ID_Cliente,Correo,Password&linkTo=Correo,Password&equalTo=" + txtCorreo.Text+ "_"+txtContraseña.Text);                             
            var client = new HttpClient();                                   
            var response = await client.GetAsync(RequestUri);
             if(response.StatusCode==HttpStatusCode.OK)
             {               
                await Navigation.PushAsync(new Vistas.WMenu());
                txtContraseña.Text = "";
                txtCorreo.Text = "";
             }
             else
             {
                 await DisplayAlert("Mensaje","Datos Invalidos","OK");
             }
                       
        }

        private async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}
