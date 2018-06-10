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
    public partial class ListarPistas : ContentPage
    {

        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/pistas";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Pistas> _pista;

        public ListarPistas ()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void ClickListarPistas()
        {
            ListData();
        }

        async public void ListData()
        {
            string content = await client.GetStringAsync(Url);
            List<Pistas> pistas = JsonConvert.DeserializeObject<List<Pistas>>(content);
            _pista = new ObservableCollection<Pistas>(pistas);
            listViewUsers.ItemsSource = _pista;
        }

        async public void CreateUser()
        {
            Pistas pista = new Pistas()
            {
                Name = entryNamePista.Text,

            };

            var json = JsonConvert.SerializeObject(pista);
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
            var item = mi.BindingContext as Pistas;

            Pistas pistas = new Pistas()
            {
                Id = item.Id,
                Name = item.Name
            };

            DisplayAlert("Info","Usuario actualizado","OK");
            //showWindowUpdate(user);
        }
    }
}