using EmprestimoLivros.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set;}
        public PerfilEnum? Perfil { get; set;}

        public DateTime DataCadastro { get; set;}
        public DateTime? DataAlteracaoUsuario { get; set;}
    }
}
