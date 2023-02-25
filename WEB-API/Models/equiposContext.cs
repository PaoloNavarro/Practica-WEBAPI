using Microsoft.EntityFrameworkCore;

namespace WEB_API.Models
{
    public class equiposContext : DbContext
    {
        public equiposContext(DbContextOptions<equiposContext> option):base(option)
        {

        }
        public DbSet<equipos> equipos {get;set;}
    }
}
