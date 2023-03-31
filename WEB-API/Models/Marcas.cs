using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models
{
    public class Marcas
    {
        [Key]
        public int id_marcas { get; set; }
        public string? nombre_marca { get; set; }
        public string? estados { get; set; }
    }
}
