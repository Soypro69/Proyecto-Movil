﻿using AdminDelivery.ViewModel;
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
	public partial class VInicioProdcuto : ContentPage
	{
		public VInicioProdcuto ()
		{
			InitializeComponent ();
            BindingContext = new VMInicioProductos(Navigation);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VIngrProducto());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}