using Microsoft.AspNetCore.Identity;

namespace EmprestimoLivros.Models
{
    public class UsuarioRole : IdentityUserRole<string>
    {
        public virtual Usuario Usuario{ get; set; }

        public virtual Role Role { get; set; }
    }
}
