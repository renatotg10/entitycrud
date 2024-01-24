using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private AppDbContext _context;

        //pegar os dados do banco com o dbcontext
        public EmprestimoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //acessando a tabela emprestimos no db
            IEnumerable<Emprestimo> emprestimos = _context.Emprestimos;
            
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            // não existe registro no banco de dados
            if(id == null || id == 0)
            {
                return NotFound();

            }
            // basicamente é um WHERE no banco de dados
            Emprestimo emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Apagar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            Emprestimo emprestimo = _context.Emprestimos.FirstOrDefault(x =>x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }


        [HttpPost]
        public IActionResult Cadastrar(Emprestimo emprestimos)
        {
            if(ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimos);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!✅";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(Emprestimo emprestimo)
        {
            if(ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!✅";


                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Apagar(Emprestimo emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!✅";


            return RedirectToAction("Index");
        }
    }
}
