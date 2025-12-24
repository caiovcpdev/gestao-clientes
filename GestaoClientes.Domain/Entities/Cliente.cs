using GestaoClientes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Domain.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente(string nomeFantasia, Cnpj cnpj)
        {
            if (string.IsNullOrWhiteSpace(nomeFantasia))
                throw new ArgumentException("Nome fantasia é obrigatório.");

            Id = Guid.NewGuid();
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }

    }
}
