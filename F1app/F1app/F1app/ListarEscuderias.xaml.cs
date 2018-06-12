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
    public partial class ListarEscuderias : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/escuderias";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Escuderias> _escuderia;

        public ListarEscuderias ()
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
            List<Escuderias> escuderia = JsonConvert.DeserializeObject<List<Escuderias>>(content);
            _escuderia = new ObservableCollection<Escuderias>(escuderia);
            listViewUsers.ItemsSource = _escuderia;
        }

       

        async public void DeleteUser(string position)
        {
            HttpResponseMessage response = null;
            response = await client.DeleteAsync(Url + "/" + position);

            ListData();
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

        async public void CrearEscuderia()
        {
            await ((NavigationPage)Parent).PushAsync(new CreateEscuderia());
        }

        private void Label_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}