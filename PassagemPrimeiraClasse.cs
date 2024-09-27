﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passagens
{
    class PassagemPrimeiraClasse : PassagemAerea
    {
        public PassagemPrimeiraClasse(string origem, string destino, 
            DateTime data, double preco, TipoPassagem tipo, bool frequente)
                : base(origem, destino, data, preco, tipo, frequente) { }
        public override double CalcularPreco(double preco, bool frequente)
        {
            return preco + (preco * 0.50);
        }
    }
}
