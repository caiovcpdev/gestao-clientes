using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Application.Clientes.Criar
{
    public record CriaClienteCommand
    (
        string NomeFantasia,
        string Cnpj
    );
}
