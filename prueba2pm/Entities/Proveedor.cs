using System.Data;
using System.Text.Json.Serialization;

namespace prueba2pm.Entities
{
	public class Proveedor : IEntity
    {
        public int IdProveedor { get; set; }
        public string Codigo { get; set; }
        public string Razon_social { get; set; }
        public string Rfc { get; set; }
        public Proveedor() { }


        public Proveedor(int Idproveedor, string codigo, string razon_social, string rfc)
        {
            IdProveedor = Idproveedor;
            Codigo = codigo;
            Razon_social = razon_social;
            Rfc = rfc;
        }
    }
}