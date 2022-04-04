using LivrariaAPI_DIO.Models;

namespace LivrariaAPI_DIO.Repositories.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> GetProductByName(string name);
    }
}
