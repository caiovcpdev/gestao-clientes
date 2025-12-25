using GestaoClientes.Application.Clientes.ObterPorId;
using GestaoClientes.Domain.Entidades;
using GestaoClientes.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Tests.Application.Clientes
{
    public class ObtemClientePorIdQueryHandlerTests
    {
        [Fact]
        public async Task Deve_retornar_cliente_quando_id_existir()
        {
            var repo = new ClienteRepositoryEmMemoria();

            var cliente = new Cliente(
                "Rede Gym Power",
                new Domain.ValueObjects.Cnpj("12345678000199")
            );

            await repo.AdicionarAsync(cliente);

            var handler = new ObtemClientePorIdQueryHandler(repo);
            var query = new ObtemClientePorIdQuery(cliente.Id);

            var resultado = await handler.HandleAsync(query);

            Assert.NotNull(resultado);
            Assert.Equal(cliente.Id, resultado!.Id);
            Assert.Equal("Rede Gym Power", resultado.NomeFantasia);
            Assert.Equal("12345678000199", resultado.Cnpj.Valor);
        }

        [Fact]
        public async Task Deve_retornar_null_quando_cliente_nao_existir()
        {
            var repo = new ClienteRepositoryEmMemoria();
            var handler = new ObtemClientePorIdQueryHandler(repo);

            var query = new ObtemClientePorIdQuery(Guid.NewGuid());

            var resultado = await handler.HandleAsync(query);

            Assert.Null(resultado);
        }
    }
}
