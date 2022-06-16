namespace LanchesMac.Models
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public List<Lanche> Lanches { get; set; }
    }
}
