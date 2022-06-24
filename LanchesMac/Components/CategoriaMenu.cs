using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaMenu(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepositorio
                .Categorias
                .OrderBy(c => c.Nome);

            return View(categorias);
        }
    }
}
