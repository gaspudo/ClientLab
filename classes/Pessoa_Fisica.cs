using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class Pessoa_Fisica : Cliente
    {
        public long CPF {get; set;}
        public long RG {get;set;}
        protected override double porcentagem_imposto => 0.10;

        public Pessoa_Fisica (long cpf, long rg) {
            CPF = cpf;
            RG = rg;
        }
    }
}