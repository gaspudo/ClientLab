using System;
using ClientLab;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;
using classes;
using Microsoft.VisualBasic;

namespace ClientLab
{
    public class SistemaDAO
    {
        private readonly ConexaoBanco _conexaoBanco;

        public SistemaDAO (ConexaoBanco porta_conexao)
        {
            _conexaoBanco = porta_conexao;
        }

        public void CadastrarClientePf(Pessoa_Fisica pessoa_Fisica)
        {
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_cliente_pf (nm_cliente, ed_cliente, cpf_cliente, rg_cliente) VALUES (@nome, @endereco, @cpf, @rg)";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", pessoa_Fisica.Nome);
                    comando.Parameters.AddWithValue("@endereco", pessoa_Fisica.Endereco);
                    comando.Parameters.AddWithValue("cpf", pessoa_Fisica.CPF);
                    comando.Parameters.AddWithValue("rg", pessoa_Fisica.RG);
                    try {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        Console.WriteLine($"Pessoa física: '{pessoa_Fisica.Nome}' \nCadastrado(a) com sucesso.");
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex}");
                    }
                }
            }
        }

        public void CadastrarClientePj (Pessoa_Juridica pessoa_Juridica)
        {
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_cliente_pj (nm_cliente, ed_cliente, cnpj_cliente, ie_cliente) VALUES (@nome, @endereco, @cnpj, @ie)";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", pessoa_Juridica.Nome);
                    comando.Parameters.AddWithValue("@endereco", pessoa_Juridica.Endereco);
                    comando.Parameters.AddWithValue("@cnpj", pessoa_Juridica.CNPJ);
                    comando.Parameters.AddWithValue("@ie", pessoa_Juridica.IE);
                    try
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        Console.WriteLine($"Pessoa jurídica: '{pessoa_Juridica.Nome}' \nCadastrado(a) com sucesso.");
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex}");
                    }
                }
            }
        }

        public void RegistrarVendaPf (Pessoa_Fisica cliente)
        {
            DateTime data = DateTime.UtcNow;
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_vendas (data_hora_venda, vl_compra, vl_imposto, vl_total, fk_cliente_pf) VALUES (@data, @vl_compra, @vl_imposto, @vl_total, @fk_pf); SELECT LAST_INSERT_ID();";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    cliente.Id = Convert.ToInt32(comando.ExecuteScalar());
                    comando.Parameters.AddWithValue("@data", data);
                    comando.Parameters.AddWithValue("@vl_compra", cliente.Valor_compra);
                    comando.Parameters.AddWithValue("@vl_imposto", cliente.Valor_imposto);
                    comando.Parameters.AddWithValue("@vl_total", cliente.Valor_total);
                    comando.Parameters.AddWithValue("@fk_pf", cliente.Id);
                    try
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        
                        Console.WriteLine("Processando cálculos...");
                        Console.WriteLine("------ RECIBO: Pessoa Física ------");
                        Console.WriteLine($"\nCliente.....: {cliente.Nome}");
                        Console.WriteLine($"Data/Hora....: {data}");
                        Console.WriteLine($"Endereço: {cliente.Endereco}");
                        Console.WriteLine($"CPF: {cliente.CPF}");
                        Console.WriteLine($"RG: {cliente.RG}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Valor da compra: R${cliente.Valor_compra:c}");
                        Console.WriteLine($"Imposto (10%): R${cliente.Valor_imposto:c}");
                        Console.WriteLine($"Total: R${cliente.Valor_total:c}");
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex}");
                    }
                }
            }
        }

        
    }
}