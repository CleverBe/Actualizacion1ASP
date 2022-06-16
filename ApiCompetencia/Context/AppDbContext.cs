using ApiCompetencia.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCompetencia.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
               
        }
        public DbSet<Categoria_BD> categoria { get; set; }
        //public DbSet<Gestores_Bd> gestores_bd { get; set; }
        
    }
}
