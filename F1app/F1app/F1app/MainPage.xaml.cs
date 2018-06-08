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

namespace F1app
{
    public partial class MainPage : ContentPage
	{

        private const string Url = "https://jonmidpruebanode.herokuapp.com/users";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> _user;

        public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
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
                Email = entryEmail.Text,
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
            var item = mi.BindingContext as User;

            User user = new User()
            {
                Id = item.Id,
                Name = item.Name
            };

            //showWindowUpdate(user);
        }

       

    }
}
