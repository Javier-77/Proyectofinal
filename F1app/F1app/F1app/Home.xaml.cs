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

        async public void pasarPistas()
        {
            await ((NavigationPage)Parent).PushAsync(new ListarPistas());
        }

        async public void ClickListarUsuarios()
        {
            await ((NavigationPage)Parent).PushAsync(new ListaUsuarios());
        }

        async public void ClickListarEscuderias()
        {
            await ((NavigationPage)Parent).PushAsync(new ListarEscuderias());
        }

        

        //CERRAR SESION
        async public void ClickButtonSignOff(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            
            await ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }
        //FIN CERRAR SESION
    }
}