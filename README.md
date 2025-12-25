Desafio Técnico: GestaoClientes API

Este repositório contém a solução do desafio técnico de Desenvolvedor(a) .NET Pleno para a funcionalidade de Gestão de Clientes.
O foco está em implementar a criação e consulta de clientes seguindo princípios de Clean Architecture, SOLID, DDD e CQRS, com testes automatizados usando xUnit. 

Estrutura do Projeto
GestaoClientes.API	Projeto Web API que expõe os endpoints REST
GestaoClientes.Application	Casos de uso (Commands, Queries, Handlers)
GestaoClientes.Domain	Entidades, Value Objects e regras de negócio
GestaoClientes.Infrastructure	Implementação de infraestrutura (repositório em memória)
GestaoClientes.Tests	Testes unitários para validação do comportamento
Requisitos Funcionais

Criar Cliente
Endpoint POST /clientes para criação de um novo cliente.

Consultar Cliente por ID
Endpoint GET /clientes/{id} para recuperar o cliente pelo identificador. 


Requisitos Técnicos Implementados
Domínio

Cliente modelado com propriedades:

Id — Identificador único
NomeFantasia — Nome da empresa
Cnpj — Value Object com validação

Regras de negócio encapsuladas na entidade (invariantes, validação de campos). 

Aplicação

Padrão CQRS:
CriaClienteCommand / CriaClienteCommandHandler
ObtemClientePorIdQuery / ObtemClientePorIdQueryHandler 


Infraestrutura

Abstração de repositório:
IClienteRepository
Implementação de repositório em memória para testes e execução local. 


Testes
Cobertura mínima dos seguintes cenários:

CriaClienteCommandHandler
Deve criar um cliente com sucesso quando os dados são válidos.
Deve retornar erro se o CNPJ já existir.
Deve retornar erro se dados essenciais forem inválidos.

ObtemClientePorIdQueryHandler
Deve retornar o cliente correto quando o ID existe.
Deve retornar null quando o cliente não existe. 

Como Rodar
Pré-requisitos

.NET 9 SDK ou superior

Executar API
dotnet run --project GestaoClientes.API


A API irá rodar por padrão em https://localhost:7005 (ou conforme configuração).

Testes Automatizados

Os testes estão no projeto GestaoClientes.Tests.
Para executá-los:

dotnet test


Todos os cenários definidos foram implementados e estão passando.

Endpoints
Método	Caminho	Descrição
POST	/clientes	Cria um novo cliente
GET	/clientes/{id}	Recupera cliente por ID
Exemplo de Requisição

Criar Cliente

POST /clientes
{
  "nomeFantasia": "Minha Empresa",
  "cnpj": "12345678000199"
}
