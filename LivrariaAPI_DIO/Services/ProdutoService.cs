using LivrariaAPI_DIO.Models;
using LivrariaAPI_DIO.Notification;
using LivrariaAPI_DIO.Repositories.Interfaces;
using LivrariaAPI_DIO.Validators;

namespace LivrariaAPI_DIO.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotificador _notificador;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            INotificador notificador
            ) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _notificador = notificador;
        }
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidator(), produto)) return;

            await _produtoRepository.CreateAsync(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidator(), produto)) return;

            await _produtoRepository.UpdateAsync(produto);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            try
            {
                await _produtoRepository.Delete(id);

            }catch(Exception ex)
            {
                _notificador.Handle(new Notificacao(ex.Message));
                return;
            }
            
        }
    }
}
