using GestaoClientes.Application.Clientes.Criar;
using GestaoClientes.Infrastructure.Repository;


namespace GestaoClientes.Tests.Application.Clientes
{
    public class CriaClienteCommandHandlerTests
    {
        
        [Fact]
        public async Task Deve_criar_cliente_quando_dados_sao_validos()
        {
            var repo = new ClienteRepositoryEmMemoria();
            var handler = new CriaClienteCommandHandler(repo);

            var command = new CriaClienteCommand(
                "Rede Gym Power",
                "12345678000199"
            );

            var id = await handler.HandleAsync(command);

            Assert.NotEqual(Guid.Empty, id);
        }

        [Fact]
        public async Task Deve_lancar_excecao_quando_cnpj_ja_existe()
        {
            var repo = new ClienteRepositoryEmMemoria();
            var handler = new CriaClienteCommandHandler(repo);

            var command = new CriaClienteCommand(
                "Rede Gym Power",
                "12345678000199"
            );
     
            //1° cadastro ok
            await handler.HandleAsync(command);

            //2° cadastro exeção
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => handler.HandleAsync(command)
            );

            Assert.Equal("CNPJ Já cadastrado.", exception.Message);
        }

        [Fact]
        public async Task Deve_lancar_excecao_quando_nome_fantasia_for_invalido()
        {
            var repo = new ClienteRepositoryEmMemoria();
            var handler = new CriaClienteCommandHandler(repo);

            var command = new CriaClienteCommand(
                "",
                "12345678000199"
            );

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => handler.HandleAsync(command)
            );

            Assert.Equal("Nome fantasia é obrigatório.", exception.Message);
        }
    }

}
