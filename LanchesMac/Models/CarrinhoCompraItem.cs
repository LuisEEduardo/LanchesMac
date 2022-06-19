using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {
        public CarrinhoCompraItem(Lanche lanche, int quantidade, string carrinhoCompraId)
        {            
            Lanche = lanche;
            Quantidade = quantidade;
            CarrinhoCompraId = carrinhoCompraId;
        }

        public int Id { get; private set; }
        public Lanche Lanche { get; private set; }
        public int Quantidade { get; private set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; private set; }

        public void AlterarLanche(Lanche lanche)
        {
            Lanche = lanche;
        }
       
        public void AumentarQuantidade(int valor)
        {
            Quantidade += valor;
        }       

        public void DiminuirQuantidade(int valor)
        {
            Quantidade -= valor;
        }

    }
}
