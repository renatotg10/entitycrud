using EmprestimoLivros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EmprestimoLivros.Data
{
    public partial class AppDbContext : IdentityDbContext
        <
            Usuario,
            Role,
            string,
            IdentityUserClaim<string>,
            UsuarioRole,
            IdentityUserLogin<string>,
            IdentityRoleClaim<string>,
            IdentityUserToken<string>
        >
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Emprestimo> Emprestimos { get; set;}

        public DbSet<Usuario> Usuarios { get; set;}
    }
}
