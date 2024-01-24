using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Repositorio
{
    public class UsuarioRepositorio : IUsuario
    {
        readonly private AppDbContext _context;

        //pegar os dados do banco com o dbcontext
        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public Usuario BuscarUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
            
        }

        public List<Usuario> BuscarUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario AdicionarUsuario(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario AtualizarUsuario(Usuario usuario)
        {
           Usuario usuarioContext = BuscarUsuarioPorId(usuario.Id);

            if (usuarioContext == null) throw new Exception("Houve um erro na atualização do usuário");

            usuarioContext.Nome = usuario.Nome;
            usuarioContext.Email = usuario.Email;
            usuarioContext.Perfil = usuario.Perfil;
            usuarioContext.DataAlteracaoUsuario = DateTime.Now;

            _context.Usuarios.Update(usuarioContext);
            _context.SaveChanges();

            return usuarioContext;
        }

        public bool ApagarUsuario(int id)
        {
            Usuario usuarioContext = BuscarUsuarioPorId(id);

            if (usuarioContext == null) throw new Exception("Houve um erro na exclusão do usuário");


            _context.Usuarios.Remove(usuarioContext);
            _context.SaveChanges();

            return true;
        }
    }

   
}



