using AdminDelivery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdminDelivery.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vinicio : ContentPage
    {
        public Vinicio()
        {
            InitializeComponent();
            BindingContext = new VMInicio(Navigation);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VInicioProdcuto());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VInicioDelivery());
        }
    }
}