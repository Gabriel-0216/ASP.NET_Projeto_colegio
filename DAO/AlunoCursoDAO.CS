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
    public class AlunoCursoDAO
    {
        SqlConnection ioConexao;
        SqlCommand ioQuery;
   
        public int RetornarCursoAluno(Alunos aluno)
        {
            int idCurso = 0;
            try
            {
                using(ioConexao= new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {//ToDo : terminar esse metódo
                    ioConexao.Open();
                    ioQuery = new SqlCommand("select CodigoCurso from alunocurso_gabrielNascimento where CodigoAluno = @idAluno", ioConexao);
                    ioQuery.Parameters.Add("@idAluno", aluno.CodigoAluno);
                    idCurso = (int)ioQuery.ExecuteScalar();
                }
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro ao buscar o id do curso do aluno.");
            }
            return idCurso;
        }
        public BindingList<AlunoCurso> RetornarAlunoCurso(decimal? idCodigoAluno = null)
        {
            var listaAlunosCurso = new BindingList<AlunoCurso>();
            if (idCodigoAluno == null)
            {
                using(ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT * FROM ALUNOCURSO_GABRIELNASCIMENTO", ioConexao);
                    using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            var alunoCurso = new AlunoCurso(ioReader.GetInt32(0), ioReader.GetInt32(1), ioReader.GetString(2));
                            listaAlunosCurso.Add(alunoCurso);
                        }
                        ioReader.Close();
                    }
                }
            }
            else
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT * FROM ALUNOCURSO_GABRIELNASCIMENTO WHERE CodigoAluno = @idCodigoAluno", ioConexao);
                    ioQuery.Parameters.Add("@idCodigoAluno", idCodigoAluno);
                    using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            var alunoCurso = new AlunoCurso(ioReader.GetInt32(0), ioReader.GetInt32(1), ioReader.GetString(2));
                            listaAlunosCurso.Add(alunoCurso);
                        }
                        ioReader.Close();
                    }
                }

            }
            return listaAlunosCurso;
        }

        public int AdicionarAluno(Alunos aluno, Cursos curso)
        {
            int linhasAlteradas = 0;
            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("insert into AlunoCurso_GabrielNascimento (CodigoAluno, CodigoCurso, DataIngresso) VALUES (@CodigoAluno, @CodigoCurso, @DataIngresso)", ioConexao);
                    ioQuery.Parameters.Add("@CodigoAluno", aluno.CodigoAluno);
                    ioQuery.Parameters.Add("@CodigoCurso", curso.CodigoCurso);
                    ioQuery.Parameters.Add("@DataIngresso", DateTime.Now);
                    linhasAlteradas = ioQuery.ExecuteNonQuery();
                }

            }
            catch(Exception e){
                throw new Exception("Ocorreu um erro");
            }

            return linhasAlteradas;
        }
    }
}
