using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepositorio _lancheRepositorio;

        public LancheController(ILancheRepositorio lancheRepositorio)
        {
            _lancheRepositorio = lancheRepositorio;
        }

        public IActionResult List()
        {
            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = _lancheRepositorio.Lanches,
                CategoriaAtual = "Categoria atual"
            };

            return View(lanchesListViewModel);
        }
    }
}
