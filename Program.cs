using classes;
using ClientLab;
using ClientLab.classes;
using DotNetEnv;

namespace ClientLab;    
class Program
    {
        static void Main( string[] args )
        {
            Env.Load();
            var conexao = new ConexaoBanco();
            SistemaDAO sistemaDAO = new SistemaDAO(conexao);
            Menu menu = new Menu();
            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine("SISTEMA DE GESTÃO - CLIENTLAB");
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Registrar nova venda");
                Console.WriteLine("3 - Consultar Vendas");
                Console.WriteLine("4 - Gerar relatório de vendas (CSV)");
                Console.WriteLine("5 - Sair");
                Console.Write("Selecione uma opção:");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        tipo_cliente:
                        Console.Write("Escolha o tipo de cliente (f/j): ");
                        string cliente = Console.ReadLine()!.Trim().ToLower();
                        string nome, end, cpf, rg, ie, cnpj;
                        switch (cliente)
                    {
                        case "f":
                            menu.DadosPf(out nome, out end, out cpf, out rg);
                            Pessoa_Fisica pf = new Pessoa_Fisica(nome, end, rg, cpf);
                            sistemaDAO.CadastrarClientePf(pf);
                            break;

                        case "j":
                            menu.DadosPj(out nome , out end, out cnpj, out ie );
                            Pessoa_Juridica pj = new Pessoa_Juridica(nome, end, cnpj, ie);
                            sistemaDAO.CadastrarClientePj(pj);
                            break;
                        default:
                            Console.WriteLine("Tipo de cliente inválido. Tente novamente.");
                            goto tipo_cliente;
                    }
                        break;
                    case "2":
                        Console.Write("Digite o tipo de Cliente para registrar a venda (f/j): ");
                        string tipoCliente = Console.ReadLine()!.Trim().ToLower();
                        Console.Write("Digite o ID: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Digite o valor da compra: ");
                        decimal valor_compra = Convert.ToDecimal(Console.ReadLine());
                        if (tipoCliente == "f")
                        {
                            var clientePf = sistemaDAO.BuscarClientePf(id);
                            clientePf.Pagar_imposto(valor_compra);
                            sistemaDAO.RegistrarVendaPf(clientePf);
                        }
                        else if (tipoCliente == "j")
                        {
                            var clientePj = sistemaDAO.BuscarClientePj(id);
                            clientePj.Pagar_imposto(valor_compra);
                            sistemaDAO.RegistrarVendaPj(clientePj);
                        }
                        else
                        {
                            Console.WriteLine("Tipo de cliente inválido. Tente novamente.");
                            goto case "2";
                        }
                        break;
                    case "3":
                        sistemaDAO.MostrarVendas();
                        break;
                    case "4":
                        sistemaDAO.GerarRelatorioCSV();
                        break;
                    case "5":
                        isActive = false;
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
