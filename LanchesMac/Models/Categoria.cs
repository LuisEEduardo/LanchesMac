using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; private set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo e de 100 carateres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]        
        [Display(Name = "Nome")]
        public string Nome { get; private set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo e de 100 carateres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; private set; }

        public List<Lanche> Lanches { get; set; }
    }
}
