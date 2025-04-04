using CadastroUsuarios.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarios.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Conexao _context;
        public PessoaController(Conexao context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var pessoas = _context.Pessoa.ToList();
            return View();
        }
    }
}
