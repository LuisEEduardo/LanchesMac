using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string Id { get; private set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; private set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtém um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // Obtém ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // Atribui o id do carrinho da sessão
            session.SetString("CarrinhoId", carrinhoId);

            // Retorna o carrinho com o contexto e o Id atribuído ou obtido
            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };

        }
    }
}
