using GestaoClientes.Application.IRepository;
using GestaoClientes.Domain.Entidades;

namespace GestaoClientes.Infrastructure.Repository
{
    public class ClienteRepositoryEmMemoria : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new();

        public Task AdicionarAsync(Cliente cliente)
        {
            _clientes.Add(cliente);
            return Task.CompletedTask;
        }

        public Task<bool> ExisteCnpjAsync(string cnpj)
        {
            var existe = _clientes.Any(c => c.Cnpj.Valor == cnpj);
            return Task.FromResult(existe);
        }

        public Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente); 
        }
    }
}
