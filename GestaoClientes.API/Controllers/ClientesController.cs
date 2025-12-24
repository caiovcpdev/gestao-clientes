using GestaoClientes.Application.Clientes.Criar;
using GestaoClientes.Application.Clientes.ObterPorId;
using GestaoClientes.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClientes.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteRepositoryEmMemoria _repo = new ();

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriaClienteCommand command)
        {
            var handler = new CriaClienteCommandHandler(_repo);
            var id = await handler.HandleAsync(command);

            return CreatedAtAction(nameof(ObterPorId), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var handler = new ObtemClientePorIdQueryHandler(_repo);
            var cliente = await handler.HandleAsync(new ObtemClientePorIdQuery(id));

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
    }
}
