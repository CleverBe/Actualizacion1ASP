using ApiCompetencia.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCompetencia.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
               
        }
        public DbSet<Gestores_Bd> gestores_bd { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
    }
}
