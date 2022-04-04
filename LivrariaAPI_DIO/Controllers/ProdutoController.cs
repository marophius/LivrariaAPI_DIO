using LivrariaAPI_DIO.Models;
using LivrariaAPI_DIO.Notification;
using LivrariaAPI_DIO.Repositories.Interfaces;
using LivrariaAPI_DIO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAPI_DIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly INotificador _notificador;
        public ProdutoController(
            INotificador notificador,
            IProdutoRepository repository,
            IProdutoService service
            )
        {
            _produtoRepository = repository;
            _produtoService = service;
            _notificador = notificador;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAll()
        {
            try
            {
                var list = await _produtoRepository.GetAllAsync();

                if(list == null)
                {
                    return NotFound("Nenhum produto encontrado");
                }

                return Ok(list);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Produto>> Get(
            [FromRoute]
            Guid id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);
                if(produto == null)
                {
                    return NotFound("Nenhum produto encontrado");
                }

                return Ok(produto);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostAsync(
            [FromBody]
            Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    throw new ArgumentNullException(nameof(produto));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Dados inválidos!");
                }

                await _produtoService.Adicionar(produto);
                if (!IsOperationValid())
                {
                    return BadRequest(_notificador.ObterNotificacoes());
                }

                return StatusCode(201, produto);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Produto>> UpdateAsync(
            [FromRoute]
            Guid id,
            [FromBody]
            Produto produto
            )
        {
            try
            {
                if (id != produto.Id)
                {
                    return BadRequest("Os ids informados não são iguais!");
                }
                if (produto == null)
                {
                    throw new ArgumentNullException(nameof(produto));
                }

                await _produtoService.Atualizar(produto);

                if(!IsOperationValid())
                {
                    return BadRequest(_notificador.ObterNotificacoes());
                }

                return Accepted(produto);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(
            [FromRoute]
            Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new Exception("Id inválido!");
                }

                await _produtoService.Remover(id);

                if (!IsOperationValid()) 
                { 
                    return BadRequest(_notificador.ObterNotificacoes());
                }

                return Ok("Objeto deletado com sucesso!");


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public bool IsOperationValid()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
