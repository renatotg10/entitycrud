using Microsoft.AspNetCore.Identity;

namespace EmprestimoLivros.Models
{
    public class Role : IdentityRole<string>
    {
        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
