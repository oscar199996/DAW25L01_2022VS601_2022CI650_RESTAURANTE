using Microsoft.EntityFrameworkCore;
using L01_2022CI650_2022VS601.Models;

namespace L01_2022CI650_2022VS601.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Motoristas> Motoristas { get; set; }
    }
}
