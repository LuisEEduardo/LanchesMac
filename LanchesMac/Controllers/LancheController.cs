using LanchesMac.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepositorio
                            .Lanches
                            .OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepositorio
                                .Lanches
                                .Where(l => l.Categoria.Nome.Equals(categoria))
                                .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepositorio
                            .Lanches
                            .FirstOrDefault(l => l.Id == lancheId);

            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepositorio
                                .Lanches
                                .OrderBy(l => l.Id);

                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepositorio
                                .Lanches
                                .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanche";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
