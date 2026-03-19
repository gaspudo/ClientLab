using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using classes;

namespace ClientLab
{
    public class Teste
    {

        [Fact]
        public void ImpostoPfCorreto()
        {
            var nome = "nome";
            var end = "end";
            var cpf = "cpf";
            var rg = "rg";
            Pessoa_Fisica pf = new Pessoa_Fisica(nome, end, cpf, rg);

            pf.Pagar_imposto(2500m);
            Assert.Equal(2750m, pf.Valor_total);
        }

        [Fact]
        public void ImpostoPjCorreto () {
            var nome = "nome";
            var end = "end";
            var cnpj = "cnpj";
            var ie = "ie";
            Pessoa_Juridica pj = new Pessoa_Juridica(nome, end, cnpj, ie);

            pj.Pagar_imposto(35000m);
            Assert.Equal(42000m, pj.Valor_total);
        }

        [Fact]
        public void PessoaFisicaCompraZero () {
            var nome = "nome";
            var end = "end";
            var cpf = "cpf";
            var rg = "rg";
            Pessoa_Fisica pf = new Pessoa_Fisica(nome, end, cpf, rg);

            pf.Pagar_imposto(0m);
            Assert.Equal(0m, pf.Valor_total);
            Assert.Equal(0m, pf.Valor_imposto);
        } 
        
        [Fact]
        public void PessoaJuridicaCompraZero () {
            var nome = "nome";
            var end = "end";
            var cnpj = "cnpj";
            var ie = "ie";
            Pessoa_Juridica pj = new Pessoa_Juridica(nome, end, cnpj, ie);
            
            pj.Pagar_imposto(0m);
            Assert.Equal(0m, pj.Valor_total);
            Assert.Equal(0m, pj.Valor_imposto);
        }
        
        [Fact]
        public void CalculoFracionadoPf () {
            var nome = "nome";
            var end = "end";
            var cpf = "cpf";
            var rg = "rg";
            Pessoa_Fisica pf = new Pessoa_Fisica(nome, end, cpf, rg);

            pf.Pagar_imposto(100.50m);
            Assert.Equal(110.55m, pf.Valor_total);
        }

        [Fact]
        public void CalculoFracionadoPj () {
            var nome = "nome";
            var end = "end";
            var cnpj = "cnpj";
            var ie = "ie";
            Pessoa_Juridica pj = new Pessoa_Juridica(nome, end, cnpj, ie);

            pj.Pagar_imposto(100.50m);
            Assert.Equal(120.60m, pj.Valor_total);
        }
    }
}