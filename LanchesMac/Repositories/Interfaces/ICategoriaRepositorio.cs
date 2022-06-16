using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
