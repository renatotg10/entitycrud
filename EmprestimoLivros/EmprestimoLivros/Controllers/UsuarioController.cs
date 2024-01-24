using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using EmprestimoLivros.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepositorio;

        public UsuarioController(IUsuario usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepositorio.BuscarUsuarios();

            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.AdicionarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!✅";

                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {

                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Recupere o usuário com o ID especificado do repositório
            Usuario usuario = _usuarioRepositorio.BuscarUsuarioPorId(id);

            if (usuario == null)
            {
                // Se o usuário não for encontrado, redirecione para a página de índice ou exiba uma mensagem de erro
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Atualize o usuário no repositório
                    _usuarioRepositorio.AtualizarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Edição realizada com sucesso!✅";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            Usuario usuario = _usuarioRepositorio.BuscarUsuarioPorId(id);
            return View(usuario);

        }

        public IActionResult ApagarConfirmacao(int id)
        {
            try
            {
                // Exclua o usuário com o ID especificado do repositório
                _usuarioRepositorio.ApagarUsuario(id);
                TempData["MensagemSucesso"] = "Usuário excluído com sucesso!✅";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return RedirectToAction("Index");
            }
        }

       
    }

}


