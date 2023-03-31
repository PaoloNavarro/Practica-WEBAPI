using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models
{
    public class Tipo_equipo
    {
        [Key]
        public int id_tipo_equipo { get; set; }
        public string? descripcion { get; set; }
        public string? estado { get; set; }
    }
}
