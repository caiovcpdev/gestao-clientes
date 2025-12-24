using GestaoClientes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Application.IRepository
{
    public interface IClienteRepository
    {
        Task AdicionarAsync(Cliente cliente);
        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task<bool> ExisteCnpjAsync(string cnpj);
    }
}
