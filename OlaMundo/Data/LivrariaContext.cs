using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Models;

namespace MinhaAplicacao.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
