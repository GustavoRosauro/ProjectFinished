using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BluDataList.Models
{
    public class DAO
    {
        SqlConnection connection = new SqlConnection(@"Data Source=den1.mssql5.gear.host;User ID=bludata;Password=@Apartamento903;Initial Catalog=bludata");


        public List<Fornecedor> MostrarFornecedor(int id)
        {
            List<Fornecedor> fornecedors = new List<Fornecedor>();
            connection.Open();
            string query = @"SELECT f.Id,
                                   f.Id_Empresa,
                                   f.Empresa,
                                   f.Nome,
                                   f.[CPF/CNPJ],
                                   f.Telefone,
                                   f.[Data/Hora],
                                   f.RG,
                                   f.DataDeNascimento FROM Empresa E
                                   INNER JOIN Fonecedor F 
                                   ON E.Id = F.Id_Empresa WHERE F.Id_Empresa = " + id + " ORDER BY [Nome Fantasia]  ";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Id = Convert.ToInt32(reader["Id"]);
                    fornecedor.Empresa = reader["Empresa"].ToString();
                    fornecedor.Nome = reader["Nome"].ToString();
                    fornecedor.CPFCNPJ = reader["CPF/CNPJ"].ToString();
                    fornecedor.Telefone = reader["Telefone"].ToString();
                    fornecedor.DataCadastro = reader["Data/Hora"].ToString();
                    fornecedor.RG = reader["RG"].ToString() == null ? "" : reader["RG"].ToString();
                    fornecedor.DataNascimento = reader["DataDeNascimento"].ToString() == null ? "" : reader["DataDeNascimento"].ToString();
                    fornecedors.Add(fornecedor);
                }
            }
            return fornecedors;
        }
        public List<Empresa> MostrarEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            connection.Open();
            string query = @"SELECT [Id]
                            ,[Nome Fantasia]
                            ,[CNPJ]
                            ,[UF]
                        FROM [dbo].[Empresa] ORDER BY [Nome Fantasia]";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.Id = Convert.ToInt32(reader["Id"]);
                    empresa.NomeFantasia = reader["Nome Fantasia"].ToString();
                    empresa.CNPJ = reader["CNPJ"].ToString();
                    empresa.UF = reader["UF"].ToString();
                    empresas.Add(empresa);
                }
            }
            return empresas;
        }
        public void InserirEmpresa(string nome, string cnpj, string uf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO [dbo].[Empresa]
                           ([Nome Fantasia]
                           ,[CNPJ]
                           ,[UF])
                            VALUES(@nome,@cnpj,@uf)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                cmd.Parameters.AddWithValue("@uf", uf);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void InserirFornecedor(string nome, string cnpj, string telefone, string rg, string nascimento, string estado, string id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO [dbo].[Fonecedor]
                                     ([Nome]
                                     ,[CPF/CNPJ]
                                     ,[Data/Hora]
                                     ,[Telefone]
                                     ,[Id_Empresa]
                                     ,[RG]
                                     ,[DataDeNascimento])
                                      VALUES(@nome,@cnpj,@data,@telefone,@id_empresa,@rg,@dataNascimento)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@id_empresa", id);
                cmd.Parameters.AddWithValue("@rg", rg);
                cmd.Parameters.AddWithValue("@dataNascimento", nascimento);
                //cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeletaFornecedor(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM [dbo].[Fonecedor] where Id = " + id + "";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void DeletaEmpresa(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM [dbo].[Empresa] where Id = " + id + "";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}