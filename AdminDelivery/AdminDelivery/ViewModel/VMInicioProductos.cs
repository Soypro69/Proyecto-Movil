using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMInicioProductos:BaseViewModel
    {
        List<MProducto> products;

        public List<MProducto> ListProductos
        {
            get { return products; }
            set { SetValue(ref products, value); }
        }

        public async Task ListarProductos()
        {
            var funcion = new DProducto();
            ListProductos = await funcion.ListarProductos();
        }
        public VMInicioProductos(INavigation navigation)
        {
            Navigation = navigation;
            ListarProductos();
        }
    }
}
