using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    class VMProducto : BaseViewModel
    {

        #region Variables
        string fechavencimiento;
        string foto;
        string nombre;
        string preciocompra;
        string precioventa;
        string proveedor;
        string stock;
        #endregion

        #region Objetos
        public string txtFechaVencimiento
        {
            get { return fechavencimiento; }
            set { SetValue(ref fechavencimiento, value); }
        }
        public string txtFoto
        {
            get { return foto; }
            set { SetValue(ref foto, value); }
        }
        public string txtNombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value); }
        }
        public string txtStock
        {
            get { return stock; }
            set { SetValue(ref stock, value); }
        }
        public string txtPrecioCompra
        {
            get { return preciocompra; }
            set { SetValue(ref preciocompra, value); }
        }
        public string txtPrecioVenta
        {
            get { return precioventa; }
            set { SetValue(ref precioventa, value); }
        }
        public string txtProveedor
        {
            get { return proveedor; }
            set { SetValue(ref proveedor, value); }
        }
        #endregion

        #region Procesos
        private async Task InsertarProductos()
        {
            var funcion = new DProducto();
            var campos = new MProducto();
            campos.Nombre = txtNombre;
            campos.PrecioVenta = txtPrecioVenta;
            campos.PrecioCompra = txtPrecioCompra;
            campos.FechaVencimiento = txtFechaVencimiento;
            campos.Stock = txtStock;
            campos.Foto = txtFoto;
            campos.Proveedor = txtProveedor;
            var ejecucion = await funcion.InsertarProducto(campos);
            if (ejecucion == true)
            {
                await DisplayAlert("Correcto", "Se ingreso correctamente", "ok");
            }
        }
        #endregion

        #region Comandos
        public Command ComandoInsertarProducto { get; }
        #endregion

        #region Constructor
        public VMProducto(INavigation navigation)
        {
            Navigation = navigation;
            ComandoInsertarProducto = new Command(async () => await InsertarProductos());
        }
        #endregion
    }
}
