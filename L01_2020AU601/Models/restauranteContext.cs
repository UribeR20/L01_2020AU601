using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2020AU601.Models

{
    public class restauranteContext : DbContext

    {
        public restauranteContext(DbContextOptions<restauranteContext> options) : base(options)
        {

        }
        public DbSet<pedidos> restauranteDB { get; set; }
    }
}
