using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace classes
{
    public class Pessoa_Fisica : Cliente
    {
        [MaxLength(11)]
        public string CPF {get; set;}
        [Length(7, 11)]
        public string RG {get;set;}
        public override decimal Porcentagem_imposto => 0.10m;

        public Pessoa_Fisica (string nome, string endereco, string cpf, string rg) : base(nome, endereco) {
            CPF = cpf;
            RG = rg;
        }
    }
}