using F1app.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F1app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {


        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/users";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> _user;


        public Registro ()
        {
            InitializeComponent();
        }

        public void ClickButtonCreateContact(object sender, EventArgs e)
        {
            CreateUser();
        }

        async public void CreateUser()
        {
            User user = new User()
            {
                Name = entryName.Text,
                LastName = entryLastName.Text,
                Email = entryEmail.Text,
                Password = entryPassword.Text

            };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(Url, content);

            DisplayAlert("Felicidades","El usuario fue creado correctamente","OK");

        }
    }
}