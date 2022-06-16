using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {        
        [Key]
        public int Id { get; private set; }
        
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do lanche")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} carateres")]
        public string DescricaoCurta { get; private set; }
        public string DescricaoDetalhada { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public string ImagemThumbnailUrl { get; private set; }
        public bool IsLanchePreferido { get; private set; }
        public bool EmEstoque { get; private set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
