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
	public partial class VInicioDelivery : ContentPage
	{
		public VInicioDelivery ()
		{
			InitializeComponent ();
            BindingContext = new VMInicioDelivery(Navigation);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VIngrDelivery());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}