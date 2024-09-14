using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMDelivery:BaseViewModel
    {
        #region Variables
        string nombreCompleto;
        string correo;
        string direccion;
        string dni;
        string fechaNacimiento;
        string foto;
        string colorVehiculo;
        string modeloVehiculo;
        string placaVehiculo;
        string telefono;
        string fotoVehiculo;
        #endregion

        #region Objetos
        public string txtNombreCompleto
        {
            get { return nombreCompleto; }
            set { SetValue(ref nombreCompleto, value); }
        }
        public string txtCorreo
        {
            get { return correo; }
            set { SetValue(ref correo, value); }
        }
        public string txtDireccion
        {
            get { return direccion; }
            set { SetValue(ref direccion, value); }
        }
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
        public string txtFechaNacimiento
        {
            get { return fechaNacimiento; }
            set { SetValue(ref fechaNacimiento, value); }
        }
        public string txtFoto
        {
            get { return foto; }
            set { SetValue(ref foto, value); }
        }
        public string txtColorVehiculo
        {
            get { return colorVehiculo; }
            set { SetValue(ref colorVehiculo, value); }
        }
        public string txtModeloVehiculo
        {
            get { return modeloVehiculo; }
            set { SetValue(ref modeloVehiculo, value); }
        }
        public string txtPlacaVehiculo
        {
            get { return placaVehiculo; }
            set { SetValue(ref placaVehiculo, value); }
        }
        public string txtTelefono
        {
            get { return telefono; }
            set { SetValue(ref telefono, value); }
        }
        public string txtFotoVehiculo
        {
            get { return fotoVehiculo; }
            set { SetValue(ref fotoVehiculo, value); }
        }
        #endregion

        #region Procesos
        private async Task InsertarCliente()
        {
            var funcion = new Ddelivery();  
            var campos = new MDelivery
            {
                NombreCompleto = txtNombreCompleto,
                Correo = txtCorreo,
                Direccion = txtDireccion,
                Dni = txtDni,
                FechaNacimiento = txtFechaNacimiento,
                Foto = txtFoto,
                ColorVehiculo = txtColorVehiculo,
                ModeloVehiculo = txtModeloVehiculo,
                PlacaVehiculo = txtPlacaVehiculo,
                Telefono = txtTelefono,
                fotoVehiculo = txtFotoVehiculo
            };
            var ejecucion = await funcion.InsertarCliente(campos);
            if (ejecucion == true)
            {
                await DisplayAlert("Correcto", "Cliente ingresado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el cliente", "OK");
            }
        }
        #endregion

        #region Comandos
        public Command ComandoInsertarCliente { get; }
        #endregion

        #region Constructor
        public VMDelivery(INavigation navigation)
        {
            Navigation = navigation;
            ComandoInsertarCliente = new Command(async () => await InsertarCliente());
        }
        #endregion
    }
}
