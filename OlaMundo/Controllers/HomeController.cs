using Microsoft.AspNetCore.Mvc;
using MinhaAplicacao.Data;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly LivrariaContext _context;

    public HomeController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Certifique-se de obter a lista de usuários do seu contexto
        var usuarios = _context.Usuarios.ToList();
        return View(usuarios);
    }
}
