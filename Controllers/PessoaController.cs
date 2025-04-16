using System.Text.Json;
using CadastroUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Conexao _context;
        public PessoaController(Conexao context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Criar()
        {
            
            return View((new Pessoa()));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            
            if (ModelState.IsValid)
            {
                if (pessoa.ID > 0)
                {
                    _context.Entry(pessoa).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("PessoasCadastradas");
                }
                await _context.Pessoa.AddAsync(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("PessoasCadastradas");
            }
            return View("Criar", pessoa);
        }

        public IActionResult Editar()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id)
        {
           
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                ModelState.AddModelError("", "Pessoa não encontrada!");
                return View();  
            }
            return View("Criar", pessoa);    
        }

        public IActionResult Remover()
        {
            return View();
        }
        
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(int id)
        {
              var pessoa = await _context.Pessoa.FirstOrDefaultAsync(p => p.ID == id);
              if (pessoa != null)
              {
                  _context.Pessoa.Remove(pessoa);   
              }
              else
              {
                  return View("Remover");
                  
              }
              await _context.SaveChangesAsync();
              return RedirectToAction("PessoasCadastradas");
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
