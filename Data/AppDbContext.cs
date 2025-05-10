using AutoNomā.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoNomā.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Auto> Automobiļi { get; set; }
        public DbSet<Rezervācija> Rezervācijas { get; set; }
        public DbSet<Lietotājs> Lietotāji { get; set; }
    }
}
