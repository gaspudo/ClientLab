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
                string query = "INSERT INTO tb_cliente_pf (nm_cliente, ed_cliente, cpf_cliente, rg_cliente) VALUES (@nome, @endereco, @cpf, @rg);  SELECT LAST_INSERT_ID();";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", pessoa_Fisica.Nome);
                    comando.Parameters.AddWithValue("@endereco", pessoa_Fisica.Endereco);
                    comando.Parameters.AddWithValue("cpf", pessoa_Fisica.CPF);
                    comando.Parameters.AddWithValue("rg", pessoa_Fisica.RG);
                    try {
                        conexao.Open();
                        pessoa_Fisica.Id = Convert.ToInt32(comando.ExecuteScalar());
                        Console.WriteLine($"Pessoa física: '{pessoa_Fisica.Nome}' \nCadastrado(a) com sucesso.");
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }
                }
            }
        }

        public void CadastrarClientePj (Pessoa_Juridica pessoa_Juridica)
        {
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_cliente_pj (nm_cliente, ed_cliente, cnpj_cliente, ie_cliente) VALUES (@nome, @endereco, @cnpj, @ie); SELECT LAST_INSERT_ID();";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    
                    comando.Parameters.AddWithValue("@nome", pessoa_Juridica.Nome);
                    comando.Parameters.AddWithValue("@endereco", pessoa_Juridica.Endereco);
                    comando.Parameters.AddWithValue("@cnpj", pessoa_Juridica.CNPJ);
                    comando.Parameters.AddWithValue("@ie", pessoa_Juridica.IE);
                    try
                    {
                        conexao.Open();
                        pessoa_Juridica.Id = Convert.ToInt32(comando.ExecuteScalar());
                        Console.WriteLine($"Pessoa jurídica: '{pessoa_Juridica.Nome}' \nCadastrado(a) com sucesso.");
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }
                }
            }
        }

        public Pessoa_Fisica BuscarClientePf(int id)
            {
                using (var conexao = _conexaoBanco.ObterConexao())
                {
                    string query = "SELECT * FROM tb_cliente_pf WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    conexao.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pessoa_Fisica(
                                reader["nm_cliente"].ToString()!,
                                reader["ed_cliente"].ToString()!,
                                reader["cpf_cliente"].ToString()!,
                                reader["rg_cliente"].ToString()!
                            ) { Id = Convert.ToInt32(reader["id_cliente"]) };
                        }
                    }
                }
                return null!;
            }

            public Pessoa_Juridica BuscarClientePj(int id)
            {
                using (var conexao = _conexaoBanco.ObterConexao())
                {
                    string query = "SELECT * FROM tb_cliente_pj WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    conexao.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pessoa_Juridica (
                                reader["nm_cliente"].ToString()!,
                                reader["ed_cliente"].ToString()!,
                                reader["cnpj_cliente"].ToString()!,
                                reader["ie_cliente"].ToString()!
                            ) { Id = Convert.ToInt32(reader["id_cliente"]) };
                        }
                    }
                }
                return null!;
            }

        public void RegistrarVendaPf (Pessoa_Fisica cliente)
        {
            DateTime data = DateTime.UtcNow;
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_vendas (data_hora_venda, nm_cliente, vl_compra, vl_imposto, vl_total, fk_cliente_pf, tipo) VALUES (@data, @nm_cliente, @vl_compra, @vl_imposto, @vl_total, @fk_pf, @tipo)";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@data", data);
                    comando.Parameters.AddWithValue("@nm_cliente", cliente.Nome);
                    comando.Parameters.AddWithValue("@vl_compra", cliente.Valor_compra);
                    comando.Parameters.AddWithValue("@vl_imposto", cliente.Valor_imposto);
                    comando.Parameters.AddWithValue("@vl_total", cliente.Valor_total);
                    comando.Parameters.AddWithValue("@fk_pf", cliente.Id);
                    comando.Parameters.AddWithValue("tipo", "PF");
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
                    try
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                        
                        
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }
                }
            }
        }

        public void RegistrarVendaPj (Pessoa_Juridica cliente)
        {
            DateTime data = DateTime.UtcNow;
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "INSERT INTO tb_vendas (data_hora_venda, nm_cliente, vl_compra, vl_imposto, vl_total, fk_cliente_pj, tipo) VALUES (@data, @nm_cliente, @vl_compra, @vl_imposto, @vl_total, @fk_pj, @tipo)";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@data", data);
                    comando.Parameters.AddWithValue("@nm_cliente", cliente.Nome);
                    comando.Parameters.AddWithValue("@vl_compra", cliente.Valor_compra);
                    comando.Parameters.AddWithValue("@vl_imposto", cliente.Valor_imposto);
                    comando.Parameters.AddWithValue("@vl_total", cliente.Valor_total);
                    comando.Parameters.AddWithValue("@fk_pj", cliente.Id);
                    comando.Parameters.AddWithValue("@tipo", "PJ");
                    Console.WriteLine("Processando cálculos...");
                    Console.WriteLine("------ RECIBO: Pessoa Jurídica ------");
                    Console.WriteLine($"\nCliente....: {cliente.Nome}");
                    Console.WriteLine($"Data/Hora....: {data}");
                    Console.WriteLine($"Endereço.....: {cliente.Endereco}");
                    Console.WriteLine($"CNPJ.........: {cliente.CNPJ}");
                    Console.WriteLine($"IE...........: {cliente.IE}");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Valor da compra: R${cliente.Valor_compra:c}");
                    Console.WriteLine($"Imposto (10%): R${cliente.Valor_imposto:c}");
                    Console.WriteLine($"Total: R${cliente.Valor_total:c}");
                    try
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
                    } catch (MySqlException ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }
                }
            }
        }

        public void MostrarVendas()
        {
            using (var conexao = _conexaoBanco.ObterConexao())
            {
                string query = "SELECT id_venda, nm_cliente, data_hora_venda, tipo, vl_compra, vl_imposto, vl_total FROM tb_vendas ";
                using (var comando = new MySqlCommand(query, conexao) )
                {
                    conexao.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        Console.WriteLine("--- VENDAS ---");
                        Console.WriteLine($"{"ID",-4} | {"NOME",-40} | {"DATA",-20} | {"TIPO", -4} | {"VALOR",-12} | {"IMPOSTO",-10} | {"TOTAL"}");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id_venda"],-4} | {reader["nm_cliente"],-40} | {reader["data_hora_venda"],-20} | {reader["tipo"],-4} | {reader["vl_compra"],-12:C} | {reader["vl_imposto"],-10:C} | {reader["vl_total"]:C}");
                        }
                    }
                }
            }
        }

        public void GerarRelatorioCSV()
        {
            string caminhoArquivo = "RelatorioGeral.csv";
            
            string conteudoCSV = "ID Venda;Data;Cliente;Subtotal;Imposto;Total da Venda\n";

            // Inicia a conexão
            using (var conexao = _conexaoBanco.ObterConexao())
            {

                string query = @"
                    SELECT 
                        v.id_venda, 
                        v.data_hora_venda, 
                        v.tipo,
                        COALESCE(pf.nm_cliente, pj.nm_cliente) AS nm_cliente,
                        v.vl_compra, 
                        v.vl_imposto, 
                        v.vl_total
                    FROM tb_vendas v
                    LEFT JOIN tb_cliente_pf pf ON v.fk_cliente_pf = pf.id_cliente
                    LEFT JOIN tb_cliente_pj pj ON v.fk_cliente_pj = pj.id_cliente
                    ORDER BY v.id_venda ASC";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    conexao.Open();
                    
                    using (var reader = comando.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            conteudoCSV += $"{reader["id_venda"]};{reader["data_hora_venda"]};{reader["nm_cliente"]};{reader["vl_compra"]};{reader["vl_imposto"]};{reader["vl_total"]}\n";
                        }
                    }
                }
            }
            File.WriteAllText(caminhoArquivo, conteudoCSV);
            Console.WriteLine($"\nRelatório gerado com sucesso em: {Path.GetFullPath(caminhoArquivo)}");
        }
    }
}