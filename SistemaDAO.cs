using System;
using ClientLab;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;
using classes;

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

        
    }
}