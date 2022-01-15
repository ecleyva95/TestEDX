using System.ComponentModel.DataAnnotations;

namespace TestEDX.Models
{
    public class Personas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El campo debe tener un maximo de 100 caracteres y un minimo de 1"), MinLength(1)]
        public string ApPaterno { get; set; }

        [MaxLength(100, ErrorMessage = "El campo debe tener un maximo de 100 caracteres y un minimo de 1"), MinLength(1)]
        public string ApMaterno { get; set; }

        [MaxLength(100, ErrorMessage = "El campo debe tener un maximo de 100 caracteres y un minimo de 1"), MinLength(1)]
        public string Nombre { get; set; }
    }
}
