using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using ProjetoColegio.DAO;
using ProjetoColegio.Models;
using System.ComponentModel;
using System.Configuration;

namespace ProjetoColegio.DAO
{
    public class AlunosDAO
    {
        SqlConnection ioConexao;
        SqlCommand ioQuery;


        public BindingList<Alunos> RetornarAlunos(decimal? idAluno = null)
        {
            var ListaAlunos = new BindingList<Alunos>();
            if (idAluno == null)
            {
                try
                {
                    using(ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        ioConexao.Open();
                        ioQuery = new SqlCommand("SELECT * FROM aluno_gabrielNascimento", ioConexao);
                        using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                        {
                            while (ioReader.Read())
                            { //txt_razao.Text = dr.IsDBNull(1) ? null : dr.GetString(1);
                                //Data nascimento ou email podem ser nulls
                                var Data = ioReader.IsDBNull(3) ? null : String.Empty;
                                var Email = ioReader.IsDBNull(4) ? null : ioReader.GetString(4);
                                Alunos aluno = new Alunos(ioReader.GetInt32(0), ioReader.GetString(1), ioReader.GetString(2), Data, Email);
                                ListaAlunos.Add(aluno);
                            }
                            ioReader.Close();
                        }
                    }
                }
                catch(Exception e)
                {
                    throw new Exception("Ocorreu um erro ao buscar os alunos no banco.");
                }

            }
            else
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioQuery = new SqlCommand("SELECT * FROM ALUNO_GABRIELNASCIMENTO WHERE CodigoAluno = @idCodigoAluno", ioConexao);
                    ioQuery.Parameters.Add("@idCodigoAluno", idAluno);
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            var Data = ioReader.IsDBNull(3) ? null : String.Empty;
                            var Email = ioReader.IsDBNull(4) ? null : ioReader.GetString(4);
                            Alunos aluno = new Alunos(ioReader.GetInt32(0), ioReader.GetString(1), ioReader.GetString(2), Data, Email);
                            ListaAlunos.Add(aluno);
                        }
                        ioReader.Close();
                    }
                }

            }


            return ListaAlunos;
        }

        public int AdicionarAluno(Alunos aluno)
        {
            int qtdeLinhasAlteradas = 0;
            using(ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO aluno_GabrielNascimento (CodigoAluno, Nome, NumeroMatricula, DataNascimento, Email) VALUES (@CodigoAluno, @Nome, @NumeroMatricula, @DataNascimento, @Email)", ioConexao);
                    ioQuery.Parameters.Add("@CodigoAluno", aluno.CodigoAluno);
                    ioQuery.Parameters.Add("@Nome", aluno.Nome);
                    DateTime hora = Convert.ToDateTime(aluno.DataNascimento);
                    ioQuery.Parameters.Add("@NumeroMatricula", aluno.NumeroMatricula);           
                    ioQuery.Parameters.Add("@DataNascimento", hora);
                    ioQuery.Parameters.Add("@Email", aluno.Email);
                    qtdeLinhasAlteradas = ioQuery.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    throw new Exception("Ocorreu um erro ao adicionar o aluno no sistema");
                }
            }
            return qtdeLinhasAlteradas;
        }

        public string RetornarUltimoNumeroMatricula()
        {
            string UltimoNumMatricula = string.Empty;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("select top 1 NumeroMatricula from aluno_GabrielNascimento order by NumeroMatricula DESC", ioConexao);
                    UltimoNumMatricula = (string)ioQuery.ExecuteScalar();

                }catch(Exception e)
                {
                    throw new Exception("Ocorreu um erro ao buscar o último número de matrícula cadastrado");
                }
            }
            int numeroAux = Convert.ToInt32(UltimoNumMatricula);
            numeroAux++;

            UltimoNumMatricula = numeroAux.ToString();

            return UltimoNumMatricula;
        }
        public int RetornarUltimoIdAluno()
        {
            int UltimoID = 0;
            using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                try
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("select top 1 CodigoAluno from aluno_GabrielNascimento order by CodigoAluno DESC", ioConexao);
                    UltimoID = (int)ioQuery.ExecuteScalar();

                }
                catch (Exception e)
                {
                    throw new Exception("Ocorreu um erro ao buscar o último número de matrícula cadastrado");
                }
            }
            return UltimoID;
        }
    }
}