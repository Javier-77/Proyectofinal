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
    public partial class ListaUsuarios : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/users";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> _user;

        public ListaUsuarios ()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        /*public void ListarUsuarios()
        {
            ListData();
        }*/

        async public void ListData()
        {
            string content = await client.GetStringAsync(Url);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
            _user = new ObservableCollection<User>(users);
            listViewUsers.ItemsSource = _user;
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
            var item = mi.BindingContext as User;

            User user = new User()
            {
                Id = item.Id,
                Name = item.Name,
                UserName = item.UserName,
                LastName = item.LastName,
                Email= item.Email,
                Password = item.Password
            };

           //showWindowUpdate(user);
        }

       //async public void showWindowUpdate(User user)
       // {
       //    await Navigation.PushAsync(new UpdatePage(user));
       // }

        async public void CrearPiloto()
        {
            await ((NavigationPage)Parent).PushAsync(new CrearPiloto());
        }









    }
}