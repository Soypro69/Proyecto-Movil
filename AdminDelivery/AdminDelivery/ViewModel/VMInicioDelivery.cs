using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMInicioDelivery:BaseViewModel
    {
        List<MDelivery> delivery;

        public List<MDelivery> ListDelivery
        {
            get { return delivery; }
            set { SetValue(ref delivery, value); }
        }

        public async Task Listardelivery()
        {
            var funcion = new Ddelivery(); 
            ListDelivery = await funcion.ListarDelivery();
        }

        public VMInicioDelivery(INavigation navigation)
        {
            Navigation = navigation;
            Listardelivery(); 
        }

    }
}
