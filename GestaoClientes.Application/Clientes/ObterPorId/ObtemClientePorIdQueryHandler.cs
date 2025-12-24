using GestaoClientes.Application.IRepository;
using GestaoClientes.Domain.Entidades;


namespace GestaoClientes.Application.Clientes.ObterPorId
{
    public class ObtemClientePorIdQueryHandler
    {
        private readonly IClienteRepository _repository;

        public ObtemClientePorIdQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }   

        public async Task<Cliente?> HandleAsync(ObtemClientePorIdQuery query)
        {
            return await _repository.ObterPorIdAsync(query.Id);
        }
    }
}
