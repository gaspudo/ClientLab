using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class Pessoa_Juridica : Cliente
    {
        public long CNPJ {get; set;}
        public long IE {get; set;}
        protected override double porcentagem_imposto => 0.20;

        public Pessoa_Juridica (long cnpj, long ie) {
            CNPJ = cnpj;
            IE = ie;
        }
    }
}