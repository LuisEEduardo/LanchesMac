using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {
        public int Id { get; private set; }
        public Lanche Lanche { get; private set; }
        public int Quantidade { get; private set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; private set; }
    }
}
