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
        public decimal valor_compra {get; set;}
        public decimal valor_imposto {get;set;}
        public decimal valor_total {get; set;}
        public double porcentagem_imposto;

        public Cliente (string nome, string endereco) {
                Nome = nome;
                Endereco = endereco;
        }

        public void Pagar_imposto (float valor) 
        {
            valor_compra = valor;
            valor_imposto = porcentagem_imposto * valor_compra;
            valor_total = valor_compra + valor_imposto;
        }



    }
}