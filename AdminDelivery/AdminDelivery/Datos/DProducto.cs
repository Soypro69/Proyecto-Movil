using AdminDelivery.Conexion;
using AdminDelivery.Modelo;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdminDelivery.ViewModel;

namespace AdminDelivery.Datos
{
     public class DProducto
     {   
        public async Task<bool> InsertarProducto(MProducto producto)
        {
            // Insertar el nuevo producto en la base de datos Firebase
            await ConexionFirebase.ClientFirebase
                .Child("Productos")
                .PostAsync(new MProducto()
                {
                    Nombre = producto.Nombre,
                    PrecioCompra = producto.PrecioCompra,
                    PrecioVenta = producto.PrecioVenta,
                    Stock = producto.Stock,
                    FechaRegistro = producto.FechaRegistro,
                    FechaVencimiento = producto.FechaVencimiento,
                    Foto = producto.Foto,
                    Proveedor = producto.Proveedor,
                });

            return true;
        }

        public async Task<List<MProducto>> ListarProductos()
        {
            return (await ConexionFirebase.ClientFirebase.Child("Productos")
                .OnceAsync<MProducto>()).Select(item => new MProducto
                {
                    FechaVencimiento = item.Object.FechaVencimiento,
                    Foto = item.Object.Foto,
                    Nombre = item.Object.Nombre,
                    PrecioCompra = item.Object.PrecioCompra,
                    Stock = item.Object.Stock,
                    PrecioVenta = item.Object.PrecioVenta,
                    idProducto = item.Key,
                    Proveedor = item.Object.Proveedor

                }).ToList();
        }

        public async Task<int> ContarProductos()
        {
            var conteo = await ConexionFirebase.ClientFirebase.Child("Productos")
                 .OnceAsync<MProducto>();
            return conteo.Count();
        }
        public void ActualizarConteo(Action<int> contar)
        {
            ConexionFirebase.ClientFirebase.Child("Productos")
               .AsObservable<MProducto>().Subscribe(async item =>
               {
                   int conteo = await ContarProductos();
                   contar(conteo);
               });
        }
    }
}
