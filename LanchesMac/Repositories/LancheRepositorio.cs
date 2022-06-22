using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepositorio : ILancheRepositorio
    {
        public readonly AppDbContext _context;

        public LancheRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches
            => _context
                .Lanches
                .AsNoTracking()
                .Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos
            => _context
                .Lanches
                .Where(x => x.IsLanchePreferido)
                .Include(x => x.Categoria);
        
        public Lanche GetLancheById(int lancheId)
            => _context
                .Lanches
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == lancheId);

    }
}
