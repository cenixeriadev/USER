using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IClienteService
    {
        List<ClienteInfo> ObtenerClientes();
        void EliminarCliente(int id);
    }
    public class ClienteService: IClienteService
    {
        private readonly string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=myroom;Integrated Security=True;TrustServerCertificate=True";
        public List<ClienteInfo> ObtenerClientes()
        {
            var listaClientes = new List<ClienteInfo>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Clientes";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaClientes.Add(new ClienteInfo
                            {
                                Id = reader.GetInt32(0).ToString(),
                                Nombre = reader.GetString(1),
                                Email = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Direccion = reader.GetString(4),
                                FechaRegistro = reader.GetDateTime(5).ToString()
                            });
                        }
                    }
                }
            }
            return listaClientes;
        }

        public void EliminarCliente(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "DELETE FROM Clientes WHERE cliente_id = @Id";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
