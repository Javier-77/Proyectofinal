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
    public partial class Home : ContentPage
    {
        public Home ()
        {
            InitializeComponent();
        }

        async public void listaPilotos()
        {
            await((NavigationPage)Parent).PushAsync(new ListaPilotos());
        }

        async public void ClickListarUsuarios()
        {
            await ((NavigationPage)Parent).PushAsync(new ListaUsuarios());
        }
    }
}