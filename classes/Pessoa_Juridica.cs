using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class Pessoa_Juridica : Cliente
    {
        public string CNPJ {get; set;}
        public string IE {get; set;}
        public override decimal Porcentagem_imposto => 0.20m;

        public Pessoa_Juridica (string nome, string endereco, string cnpj, string ie) : base(nome, endereco) {
            CNPJ = cnpj;
            IE = ie;
        }
    }
}