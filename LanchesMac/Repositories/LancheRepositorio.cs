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
            =>  _context
                .Lanches
                .AsNoTracking()
                .Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos 
            =>  _context
                .Lanches
                .AsNoTracking()
                .Where(p => p.IsLanchePreferido)
                .Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
            =>  _context
                .Lanches
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == lancheId);

    }
}
