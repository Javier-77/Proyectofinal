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
    public partial class CreatePista : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/pistas";
        private readonly HttpClient client = new HttpClient();

        public CreatePista ()
        {
            InitializeComponent();
        }

        public void ClickButtonCreatePista(object sender, EventArgs e)
        {
            CreateUser();
        }

        async public void CreateUser()
        {
            Pistas pista = new Pistas()
            {
                Name = entryName.Text,
                FirstGrandPrix = entryFirstGrandPrix.Text,
                NumberLaps = entryVueltas.Text,
                CircuitLength = entryCircuit.Text,
                RaceDistance = entryDistance.Text,
                CountryPrix = entryCountry.Text

            };

            var json = JsonConvert.SerializeObject(pista);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(Url, content);

            entryName.Text = "";
            entryCircuit.Text = "";
            entryCountry.Text = "";
            entryFirstGrandPrix.Text = "";
            entryVueltas.Text = "";
            entryDistance.Text = "";

            await DisplayAlert("Felicidades", "La pista fue creada correctamente", "OK");

        }

        async public void CancelarRegresar()
        {
            await ((NavigationPage)Parent).PushAsync(new ListarPistas());

        }
    }
}