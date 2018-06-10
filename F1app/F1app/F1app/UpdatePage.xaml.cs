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
    public partial class UpdatePage : ContentPage
    {
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/users";
        private readonly HttpClient client = new HttpClient();
        private User user;

        public UpdatePage()
        {
            InitializeComponent();
            this.user = user;
            BindingContext = user;
            
        }


        async public void UpdateUser(object sender, EventArgs e)
        {
            user.Name = entryNameUpdate.Text;
            user.LastName = entryLastNameUpdate.Text;
            user.Email = entryEmailUpdate.Text;
            user.Password = entryPasswordUpdate.Text;

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(Url + "/" + user.Id, content);

            await Navigation.PushAsync(new MainPage());
        }
    }
}