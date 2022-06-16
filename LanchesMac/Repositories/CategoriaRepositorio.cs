using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias
            =>  _context
                .Categorias
                .AsNoTracking();
    }
}
