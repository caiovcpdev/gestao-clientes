using GestaoClientes.Application.IRepository;
using GestaoClientes.Domain.Entidades;
using GestaoClientes.Domain.ValueObjects;

namespace GestaoClientes.Application.Clientes.Criar
{
    public class CriaClienteCommandHandler
    {
        private readonly IClienteRepository _repository;
        public CriaClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(CriaClienteCommand command)
        {
            if(await _repository.ExisteCnpjAsync(command.Cnpj))
            {
                throw new InvalidOperationException("CNPJ Já cadastrado.");
            }
            
            var cnpj = new Cnpj(command.Cnpj);
            var cliente = new Cliente(command.NomeFantasia, cnpj);

            await _repository.AdicionarAsync(cliente);

            return cliente.Id;  
        }
    }
}
