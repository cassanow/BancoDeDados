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
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _context.Pessoa.AddAsync(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("PessoasCadastradas");
            }
            return View(pessoa);
        }

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Remover()
        {
            return View();
        }
        public IActionResult PessoasCadastradas()
        {
            var pessoas = _context.Pessoa.ToList();

            Console.WriteLine($"Número de pessoas cadastradas {pessoas.Count}");
            return View(pessoas);
        }

        public IActionResult TesteConexao()
        {
            try
            {
                var pessoas = _context.Pessoa.ToList();
                return Content($"Conexão bem-sucedida! Total de pessoas cadastradas: {pessoas.Count}");
            }
            catch (Exception ex)
            {
                return Content($"Erro de Conexão: {ex.Message}");
            }
        }
    }
}
