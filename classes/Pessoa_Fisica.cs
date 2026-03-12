using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class Pessoa_Fisica : Cliente
    {
        public string CPF {get; set;}
        public string RG {get;set;}
        public override decimal Porcentagem_imposto => 0.10m;

        public Pessoa_Fisica (string cpf, string rg, string nome, string endereco) : base(nome, endereco) {
            CPF = cpf;
            RG = rg;
        }
    }
}