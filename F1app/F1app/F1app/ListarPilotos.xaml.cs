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
    public partial class ListarPilotos : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/pilotos";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Pilotos> _piloto;

        public ListarPilotos ()
        {
        
        InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void ClickListar()
        {
            ListData();
        }

        async public void ListData()
        {
            string content = await client.GetStringAsync(Url);
            List<Pilotos> pilotos = JsonConvert.DeserializeObject<List<Pilotos>>(content);
            _piloto = new ObservableCollection<Pilotos>(pilotos);
            listViewUsers.ItemsSource = _piloto;
        }

        async public void CreateUser()
        {
            Pilotos piloto = new Pilotos()
            {
                Name = entryNameUser.Text,

            };

            var json = JsonConvert.SerializeObject(piloto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(Url, content);

            ListData();
        }

        async public void DeleteUser(string position)
        {
            HttpResponseMessage response = null;
            response = await client.DeleteAsync(Url + "/" + position);

            ListData();
        }


        public void ClickCreateUser(object sender, EventArgs e)
        {
            CreateUser();
        }

        public void ClickDeleteUser(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DeleteUser(mi.CommandParameter.ToString());
        }

        public void ClickUpdateUser(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.BindingContext as Pilotos;

            Pilotos pilotos = new Pilotos()
            {
                Id = item.Id,
                Name = item.Name
            };

            //showWindowUpdate(user);
        }
    }
}