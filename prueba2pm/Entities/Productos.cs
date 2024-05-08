using System.Data;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;
using prueba2pm.Entities;

namespace prueba2pm.Entities
{
    public class Productos : IEntity
    {
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string Costo { get; set; }
        public Productos() { }


        public Productos(int idproducto, int idproveedor, string codigo, string descripcion, string unidad, string costo)
        {
            idProducto = idproducto;
            idProveedor = idproveedor;
            Codigo = codigo;
            Descripcion = descripcion;
            Unidad = unidad;
            Costo = costo;
        }
    }
}