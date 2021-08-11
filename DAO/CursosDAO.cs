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
    public class CursosDAO
    {
        SqlConnection ioConexao;
        SqlCommand ioQuery;


        public int RetornarQtdeSemestres(Cursos curso)
        {
            int qtdeSemestres = 0;
            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT QuantidadeSemestres from curso_GabrielNascimento where CodigoCurso = @CodigoCurso", ioConexao);
                    ioQuery.Parameters.Add("@CodigoCurso", curso.CodigoCurso);
                    qtdeSemestres = (int)ioQuery.ExecuteScalar();
                }
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro ao buscar a quantidade de semestres;");
            }
            return qtdeSemestres;
        }

        public Cursos RetornarCurso(decimal CodigoCurso) {
            Cursos cursoRetorno = null;
            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("Select * from curso_gabrielNascimento where CodigoCurso = @CodigoCurso", ioConexao);
                    ioQuery.Parameters.Add("@CodigoCurso", CodigoCurso);
                    using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Cursos curso = new Cursos(ioReader.GetInt32(0), ioReader.GetString(1), ioReader.GetInt32(2));
                            cursoRetorno = curso;
                        }
                        ioReader.Close();
                    }
                }

            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro");
            }
         
            return cursoRetorno;
        }

        public BindingList<Cursos> ListarCursos(decimal? CodigoCurso = null)
        {
            var ListaCursos = new BindingList<Cursos>();
            if (CodigoCurso == null)
            {
                try
                {
                    using(ioConexao= new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        ioConexao.Open();
                        ioQuery = new SqlCommand("Select * from curso_gabrielNascimento", ioConexao);
                        using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                        {
                            while (ioReader.Read())
                            {
                                var curso = new Cursos(ioReader.GetInt32(0), ioReader.GetString(1), ioReader.GetInt32(2));
                                ListaCursos.Add(curso);

                            }
                            ioReader.Close();

                        }

                    }
                }
                catch(Exception e)
                {
                    throw new Exception("ocorreu um erro ao buscar a lista de cursos;");
                }


            }
            else
            {
                try
                {
                    using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        ioConexao.Open();
                        ioQuery = new SqlCommand("Select * from curso_gabrielNascimento where CodigoCurso = @idCurso", ioConexao);
                        ioQuery.Parameters.Add("@idCurso", CodigoCurso);
                        using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                        {
                            while (ioReader.Read())
                            {
                                var curso = new Cursos(ioReader.GetInt32(0), ioReader.GetString(1), ioReader.GetInt32(2));
                                ListaCursos.Add(curso);

                            }
                            ioReader.Close();

                        }

                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ocorreu um erro ao buscar a lista de cursos;");
                }

            }
            return ListaCursos;
        }

        public int CursoExiste(int CodigoCurso)
        {
            int CursoExiste = 0;
            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("select CodigoCurso from Curso_GabrielNascimento where CodigoCurso = @CodigoCurso", ioConexao);
                    ioQuery.Parameters.Add("@CodigoCurso", CodigoCurso);
                    CursoExiste = (int)ioQuery.ExecuteScalar();

                }

            }
            catch(Exception e)
            {
                throw new Exception("ocorreu um erro");
            }

            return CursoExiste;
        }
    }
}