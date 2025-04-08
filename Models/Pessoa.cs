using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuarios.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(15)]
        public string EstadoCivil { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF{ get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereço { get; set; }

        [Required]
        [StringLength(5)]
        public string Número { get; set; }

        [StringLength(50)]
        public string? Complemento { get; set; }
        [Required]
        [StringLength(30)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(20)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }
    }
}
