using AdminDelivery.Conexion;
using AdminDelivery.Modelo;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDelivery.Datos
{
    public class Ddelivery
    {
        public async Task<bool> InsertarCliente(MDelivery delivery)
        {
            // Insertar el nuevo delivery en la base de datos Firebase
            await ConexionFirebase.ClientFirebase
                .Child("Delivery")
                .PostAsync(new MDelivery()
                {
                    ColorVehiculo = delivery.ColorVehiculo,
                    Correo = delivery.Correo,
                    Direccion = delivery.Direccion,
                    Dni = delivery.Dni,
                    FechaNacimiento = delivery.FechaNacimiento,
                    Foto = delivery.Foto,
                    ModeloVehiculo = delivery.ModeloVehiculo,
                    NombreCompleto = delivery.NombreCompleto,
                    PlacaVehiculo = delivery.PlacaVehiculo,
                    Telefono = delivery.Telefono,
                    fotoVehiculo = delivery.fotoVehiculo
                });

            return true;
        }
        public async Task<List<MDelivery>> ListarDelivery()
        {
            return (await ConexionFirebase.ClientFirebase
                .Child("Delivery")
                .OnceAsync<MDelivery>()).Select(item => new MDelivery
                {
                    ColorVehiculo = item.Object.ColorVehiculo,
                    Correo = item.Object.Correo,
                    Direccion = item.Object.Direccion,
                    Dni = item.Object.Dni,
                    FechaNacimiento = item.Object.FechaNacimiento,
                    Foto = item.Object.Foto,
                    ModeloVehiculo = item.Object.ModeloVehiculo,
                    NombreCompleto = item.Object.NombreCompleto,
                    PlacaVehiculo = item.Object.PlacaVehiculo,
                    Telefono = item.Object.Telefono,
                    fotoVehiculo = item.Object.fotoVehiculo
                }).ToList();
        }

        public async Task<int> ContarDelivery()
        {
            var conteo = await ConexionFirebase.ClientFirebase.Child("Delivery")
                 .OnceAsync<MProducto>();
            return conteo.Count();
        }

    }
}
