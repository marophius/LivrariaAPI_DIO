using LivrariaAPI_DIO.Data;
using LivrariaAPI_DIO.Models;
using LivrariaAPI_DIO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI_DIO.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context)
            : base(context)
        {

        }

        public async Task<Produto> GetProductByName(string nome)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
