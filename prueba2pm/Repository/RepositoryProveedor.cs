using System;
using prueba2pm.Entities;
using prueba2pm.Repository;
using System.Data.SqlClient;
using System.Data;

namespace prueba2pm.Repository
{
	public class RepositoryProveedor : RepositorioAbstrato<Proveedor>
    {
		public RepositoryProveedor()
		{
		}
        private IConfiguration _configuracoes;
        private string connectionString = "Data Source=localhost;Initial Catalog=Proveedores; User ID=SA;Password=MyPass@word";
        public RepositoryProveedor(IConfiguration config)
        {
            _configuracoes = config;
        }

        public override List<Proveedor> getProveedor()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Proveedor> listProveedor = new List<Proveedor>();
                try
                {
                    connection.Open();
                    IDbCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM dbo.Proveedores;";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                            if (reader.Read())
                            {
                                var proveedor = new Proveedor();
                                proveedor.IdProveedor = (int)reader["id_Proveedor"];
                                proveedor.Codigo = (string)reader["codigo"];
                                proveedor.Razon_social = (string)reader["razon_social"];
                                proveedor.Rfc = (string)reader["rfc"];
                                listProveedor.Add(proveedor);
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error en el metodo getProveedor" + ex.Message + " Linea: " + ex.StackTrace);
                    throw ex;
                }
                return listProveedor;
                
            }


        }

        public override void addProveedor(Proveedor proveedor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO dbo.Proveedores(razon_social,rfc,codigo) 
                            VALUES(@param1,@param2,@param3)";

                    cmd.Parameters.AddWithValue("@param1", proveedor.Razon_social);
                    cmd.Parameters.AddWithValue("@param2", proveedor.Rfc);
                    cmd.Parameters.AddWithValue("@param3", proveedor.Codigo);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Ocurrio un error en el metodo getProveedor" + ex.Message + " Linea: " + ex.StackTrace);
                        throw ex;
                    }

                }
            }
        }

        public override Proveedor getProveedorByCodigo(String codigo)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Proveedor> listProveedor = new List<Proveedor>();
                try
                {
                    connection.Open();
                    IDbCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM dbo.Proveedores where codigo = @param1;";
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@param1";
                    parameter.Value = codigo;
                    command.Parameters.Add(parameter);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var proveedor = new Proveedor();
                            proveedor.IdProveedor = (int)reader["id_Proveedor"];
                            proveedor.Codigo = (string)reader["codigo"];
                            proveedor.Razon_social = (string)reader["razon_social"];
                            proveedor.Rfc = (string)reader["rfc"];
                            return proveedor;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error en el metodo getProveedor" + ex.Message + " Linea: " + ex.StackTrace);
                    throw ex;
                }
                return null;

            }


        }
    }
}