using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WatchMe.Datos;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WatchMe.Catalogo;
using Xamarin.Essentials;

namespace WatchMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        List<Model> modelList = new List<Model>();
        public Home()
        {
            InitializeComponent();

            GetJsonAsync();
            
        }                                    
        public async Task GetJsonAsync()
        {
            var uri = new Uri("http://192.168.100.5/peliculas?select=*");
            HttpClient httpClient= new HttpClient();
            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["status"];
                var total = jsonObject["total"];
                var result = jsonObject["result"];
                var JsonArray = JArray.Parse(result.ToString());
                foreach(var token in JsonArray)
                {
                    Model m = new Model();
                    string ID_Pelicula = token["ID_Pelicula"].ToString();
                    string Titulo = token["Titulo"].ToString();
                    string Year = token["Year"].ToString();
                    string Sinopsis = token["Sinopsis"].ToString();
                    string Categoria = token["Categoria"].ToString();
                    string Imagen = token["Imagen"].ToString();
                    string Trailer = token["Trailer"].ToString();
                    string Enlace_Película = token["Enlace_Película"].ToString();
                    m.ID_Pelicula = ID_Pelicula;
                    m.Titulo = Titulo;
                    m.Year = Year;
                    m.Sinopsis= Sinopsis;
                    m.Categoria= Categoria;
                    m.Imagen= Imagen;
                    m.Trailer= Trailer;
                    m.Enlace_Pelcula = Enlace_Película;
                    modelList.Add(m);
                }
            }

            testListView.ItemsSource= modelList;
        }

        
        
        private void Ver_Ahora_Clicked(object sender, EventArgs e)
        {
               
        }

        private void Trailer_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}