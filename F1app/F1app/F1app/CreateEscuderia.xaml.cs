using F1app.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F1app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEscuderia : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/escuderias";
        private readonly HttpClient client = new HttpClient();


        public CreateEscuderia ()
        {
            InitializeComponent();
        }

        public void ClickButtonCreateEscuderia(object sender, EventArgs e)
        {
            CreatEscuderia();
        }

        public async void CreatEscuderia()
        {
            Escuderias escuderia = new Escuderias()
            {
                Name = entryName.Text,
                Points = Convert.ToInt32(entryPoints.Text),
                Country = entryCountry.Text,
             };

            var json = JsonConvert.SerializeObject(escuderia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(Url, content);

            entryName.Text = "";
            entryPoints.Text = "";
            entryCountry.Text = "";
            

            await DisplayAlert("Felicidades", "La pista fue creada correctamente", "OK");

        }

        public void CancelarRegresar()
        {
            entryName.Text = "";
            entryPoints.Text = "";
            entryCountry.Text = "";


            ((NavigationPage)Parent).PushAsync(new ListarEscuderias());

        }
    }
}