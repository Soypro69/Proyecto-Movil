using AdminDelivery.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMInicio:BaseViewModel
    {
        public int cproductos;
        public int cdelivery;
        public int txtCantProductos
        {
            get { return cproductos; }
            set { SetValue(ref cproductos, value); }
        }
        public int txtCantDelivery
        {
            get { return cdelivery; }
            set { SetValue(ref cdelivery, value); }
        }
        public async Task ConteoProductos()
        {
            var funcion = new DProducto();
            txtCantProductos = await funcion.ContarProductos();
        }
        public async Task ConteoDeliverys()
        {
            var funcion = new Ddelivery();
            txtCantDelivery = await funcion.ContarDelivery();
        }

        public VMInicio(INavigation navigation)
        {
            Navigation = navigation;
            ConteoProductos();
            ConteoDeliverys();
        }
    }
}
