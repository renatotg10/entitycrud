using EmprestimoLivros.Models;

namespace EmprestimoLivros.Repositorio
{
    public interface IUsuario
    {
        List<Usuario> BuscarUsuarios();

        Usuario BuscarUsuarioPorId(int id);

        Usuario AdicionarUsuario(Usuario usuario);

        Usuario AtualizarUsuario(Usuario usuario);

        bool ApagarUsuario (int id);
    }
}
