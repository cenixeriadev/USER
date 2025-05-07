using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class ClienteInfo
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public String FechaRegistro { get; set; }

        public string FormattedFechaRegistro => DateTime.Parse(FechaRegistro).ToString("dd/MM/yyyy");

    }
}
