using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class IndexModel : PageModel
    {
        public List<ClienteInfo> listaClientes = new List<ClienteInfo>();
        public List<ClienteInfo> OnGet()
        {
            try
            {
                string cn = "Data Source=.\\SQLEXPRESS;Initial Catalog=myroom;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();
                    string query = "SELECT * FROM Clientes";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClienteInfo cliente = new ClienteInfo();
                                cliente.Id = "" + reader.GetInt32(0);
                                cliente.nombre= reader.GetString(1);
                                cliente.email = reader.GetString(2);
                                cliente.telefono = reader.GetString(3);
                                cliente.direccion = reader.GetString(4);
                                cliente.fecha_registro = reader.GetDateTime(5).ToString();
                                listaClientes.Add(cliente);

                            }

                        }
                    }

                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return listaClientes;
        }
    }
    public class ClienteInfo
    {
        public String Id;
        public String email;
        public String nombre;
        public String direccion;
        public String fecha_registro;
        public String telefono;
    }
}
