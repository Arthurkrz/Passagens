using System;
using System.Collections.Generic;
using System.Text;

namespace Passagens
{
    class PassagemEconomica : PassagemAerea
    {
        public PassagemEconomica(string origem, string destino, 
            DateTime data, double preco, TipoPassagem tipo, bool frequente)
                : base(origem, destino, data, preco, tipo, frequente) { }
        public override double CalcularPreco(double preco, bool frequente)
        {
            if (frequente == true)
            {
                return preco - (preco * 0.10);
            }
            else
            {
                return preco;
            }
        }
    }
}
