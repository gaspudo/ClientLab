using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLab.classes
{
    public class Menu
    {
        public Menu ()
        {
            return;
        }
        public void DadosPf (out string nome, out string end, out string cpf,  out string rg)
        {
            ini:
            Console.Write("Pessoa Física\nNome: ");
            nome = Console.ReadLine()!.Trim();
            Console.Write("Endereço: ");
            end = Console.ReadLine()!.Trim();
            Console.Write("CPF (11 digitos): ");
            cpf = Console.ReadLine()!.Trim();
            Console.Write("RG (7 a 11 digitos): ");
            rg = Console.ReadLine()!.Trim();

            if (nome is null || end is null || cpf is null || rg is null )
            {
                Console.WriteLine("Algum dos valores está nulo.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                goto ini;
            } else if (cpf.Length != 11 || rg.Length > 11 || rg.Length < 7 || rg.All(char.IsDigit) == false || cpf.All(char.IsDigit) == false)
            {
                Console.WriteLine("Verifique os campos 'CPF' ou 'RG'\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                goto ini;
            }
        }

        public void DadosPj (out string nome, out string end, out string cnpj, out string ie)
        {
            ini: 
            Console.Write("Pessoa Jurídica\nNome: ");
            nome = Console.ReadLine()!.Trim();
            Console.Write("Endereco: ");
            end = Console.ReadLine()!.Trim();
            Console.Write("CNPJ: ");
            cnpj = Console.ReadLine()!.Trim();
            Console.Write("IE: ");
            ie = Console.ReadLine()!.Trim();
            if (nome is null || end is null || cnpj is null || ie is null )
            {
                Console.WriteLine("Algum dos valores está nulo.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                goto ini;
            } else if (cnpj.Length != 14 || ie.Length < 8 || ie.Length> 12 || cnpj.All(char.IsDigit) == false || ie.All(char.IsDigit) == false)
            {
                Console.WriteLine("Verifique os campos 'CNPJ' ou 'IE'\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                goto ini;
            }
        }

        
    }
}