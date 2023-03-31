using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models
{
    public class Estados_reserva
    {
        [Key]
        public int estado_res_id { get; set; }
        public string? estado { get; set; }
    }
}
