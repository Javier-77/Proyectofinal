using F1app.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    public partial class MainPage : ContentPage
	{
        
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/users";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> _user;

        public MainPage()
		{
			InitializeComponent();
		}
        /*
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
            List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
            _user = new ObservableCollection<User>(users);
            listViewUsers.ItemsSource = _user;
        }

        async public void CreateUser()
        {
            User user = new User()
            {
                Name = entryNameUser.Text,
                LastName = entryLastName.Text,
                Email = entryLastName.Text,
                Password = entryPassword.Text
                
            };

            var json = JsonConvert.SerializeObject(user);
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

        async public void ClickListarPilotos()
        {
            await Navigation.PushAsync(new ListarPilotos());
        }

        async public void ClickListarPistas()
        {
            await Navigation.PushAsync(new ListarPistas());
        }


        public void ClickUpdateUser(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.BindingContext as User;

            User user = new User()
            {
                Id = item.Id,
                Name = item.Name,
                LastName = item.LastName,
                Email = item.Email,
                Password = item.Password
            };

            ShowWindowUpdateUser(user);
        }

        async public void ShowWindowUpdateUser(User user)
        {
            await Navigation.PushModalAsync(new UpdatePage());
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
        */

        //LOGIN USUARIO
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                //ShowWindowListContacts();
                DisplayAlert("Info","mensaje para reconocer paso","OK");

            }
        }

        async private void ClickButtonSignIn(object sender, EventArgs e)
        {
            User user = new User() { Name = entryUsuario.Text, Password = entryPassword.Text };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(Url, content);
            string message = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message);

            if (users[0].Success)
            {
                Application.Current.Properties["id_user"] = users[0].Id;
                await ((NavigationPage)Parent).PushAsync(new Home());

            }
            else
            {
                await DisplayAlert("Error", "El usuario no existe", "OK");
            }
        }

        //FIN LOGIN USUARIO




        // INICIO BOTON PARA PASAR AL REGISTRO
        private void pasarRegistro(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
        // FIN BOTON PARA PASAR AL REGISTRO

        /* INICIO BOTON PARA PASAR AL HOME
        private void pasarHome(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Home());
        }

        // FIN BOTON PARA PASAR AL HOME*/

        







    }
}
