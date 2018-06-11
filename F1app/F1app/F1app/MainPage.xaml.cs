﻿using F1app.Model;
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
        
        private const string Url = "https://javierjdapiproyectofinal.herokuapp.com/";
        private const string UrlValidarUser = Url + "validateUser";
        private readonly HttpClient client = new HttpClient();
        

        public MainPage()
		{
			InitializeComponent();
		}

        //LOGIN USUARIO
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                //ShowWindowListContacts();
                ((NavigationPage)Parent).PushAsync(new Home());

            }
        }

        async private void ClickButtonSignIn(object sender, EventArgs e)
        {
            User user = new User() { UserName = entryUsuario.Text, Password = entryPassword.Text };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlValidarUser, content);
            string message = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message);

            if (users[0].Success)
            {
                Application.Current.Properties["id_user"] = users[0].Id;
                //ShowWindowListContacts();
                await ((NavigationPage)this.Parent).PushAsync(new Home());
                entryUsuario.Text = "";
                entryPassword.Text = "";
                
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
        
    }
}
