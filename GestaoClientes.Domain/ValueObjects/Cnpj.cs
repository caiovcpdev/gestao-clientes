using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Domain.ValueObjects
{
    public sealed class Cnpj
    {
        public string Valor { get; }

        public Cnpj(string valor)
        {
            if (string.IsNullOrEmpty(valor)) 
            {
                throw new ArgumentException("CNPJ não pode ser vazio, favor preencher.");
            }

            valor = new string(valor.Where(char.IsDigit).ToArray());

            if (valor.Length != 14)
            {
                throw new ArgumentException("CNPJ inválido");
            }

            Valor = valor;
        }

        public override bool Equals(object? obj) =>  obj is Cnpj cnpj && Valor == cnpj.Valor;

        public override int GetHashCode()  => Valor.GetHashCode();

    }
}
