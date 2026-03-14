using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public abstract class Cliente
    {
        public int Id {get; set;}
        public string Nome {get;set;}
        public string Endereco {get;set;}
        public decimal Valor_compra {get; set;}
        public decimal Valor_imposto {get;set;}
        public decimal Valor_total {get; set;}
        public virtual decimal Porcentagem_imposto {get; set;}

        public Cliente (string nome, string endereco) {
                Nome = nome;
                Endereco = endereco;
        }

        public void Pagar_imposto (decimal valor) 
        {
            Valor_compra = valor;
            Valor_imposto = Porcentagem_imposto * Valor_compra;
            Valor_total = Valor_compra + Valor_imposto;
        }
    }
}