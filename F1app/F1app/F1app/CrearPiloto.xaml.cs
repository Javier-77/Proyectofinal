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
    public partial class CrearPiloto : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/pilotos";
        private readonly HttpClient client = new HttpClient();

        public CrearPiloto()
        {
            InitializeComponent();
        }

        public void ClickButtonCreatePiloto(object sender, EventArgs e)
        {
            CreatePiloto();
        }

        async public void CreatePiloto()
        {
            Pilotos piloto = new Pilotos()
            {
                Name = entryName.Text,
                Numero =  Convert.ToInt32(entryNumero.Text),
                LastName = entryLastName.Text,
                Team = entryEscuderia.Text,
                Country = entryPais.Text,
                DateBirth = entryFechaNacimiento.Text,
                PlaceBirth = entryLugarNacimiento.Text

            };

            var json = JsonConvert.SerializeObject(piloto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(Url, content);

            entryName.Text = "";
            entryLastName.Text = "";
            entryNumero.Text = "";
            entryEscuderia.Text = "";
            entryFechaNacimiento.Text = "";
            entryLugarNacimiento.Text = "";
            entryPais.Text = "";

            await DisplayAlert("Felicidades", "La pista fue creada correctamente", "OK");

        }

        public void CancelarRegresar()
        {
            entryName.Text = "";
            entryLastName.Text = "";
            entryNumero.Text = "";
            entryEscuderia.Text = "";
            entryFechaNacimiento.Text = "";
            entryLugarNacimiento.Text = "";
            entryPais.Text = "";

            ((NavigationPage)Parent).PushAsync(new ListaPilotos());

        }
    }
}