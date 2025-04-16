using Microsoft.EntityFrameworkCore;



namespace CadastroUsuarios.Models
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }

    }
}
