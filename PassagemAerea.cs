using System;
using System.Collections.Generic;
using System.Text;

namespace Passagens
{
    class PassagemAerea
    {
        private static int _idPassagem;
        public int IDPassagem { get; }
        public string Origem;
        public string Destino;
        public DateTime DataViagem;
        public double Preco;
        public TipoPassagem Tipo;
        public bool Frequente;
        public PassagemAerea(string origem, string destino, DateTime data, double preco, TipoPassagem tipo, bool frequente)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.DataViagem = data;
            this.Preco = preco;
            this.Tipo = tipo;
            this.Frequente = frequente;
            IDPassagem = ++_idPassagem;
        }
        public virtual double CalcularPreco(double preco, bool frequente)
        {
            return 0.0;
        }
    }
}
