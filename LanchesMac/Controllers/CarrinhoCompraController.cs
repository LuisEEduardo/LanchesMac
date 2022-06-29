using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepositorio _lancheRepositorio;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepositorio lancheRepositorio, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepositorio = lancheRepositorio;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepositorio
                                            .Lanches
                                            .FirstOrDefault(p => p.Id == lancheId);

            if (lancheSelecionado != null)
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepositorio
                                            .Lanches
                                            .FirstOrDefault(p => p.Id == lancheId);

            if (lancheSelecionado == null)
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

            return RedirectToAction("Index");
        }

    }
}
