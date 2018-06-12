using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F1app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu ()
        {
            InitializeComponent();

            Item1.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PerfilUsuario());
                App.Modificador.IsPresented = false;
            };
            /*Item2.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemDos());
                App.Modificador.IsPresented = false;
            };
            Item3.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemTres());
                App.Modificador.IsPresented = false;
            };
            Item4.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemCuatro());
                App.Modificador.IsPresented = false;
            };*/
        }
    }
}