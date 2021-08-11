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
    public class DisciplinasDAO
    {
        SqlConnection ioConexao;
        SqlCommand ioQuery;

        public BindingList<Disciplinas> MostrarDisciplinasPorCurso(Cursos curso)
        {
            var listaDisciplinas = new BindingList<Disciplinas>();
            if (curso == null) { throw new Exception("Não é possível recuperar as disciplinas desse curso."); }
            else
            {
                using(ioConexao=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT * FROM DISCIPLINA_GABRIELNASCIMENTO WHERE CODIGOCURSO = @idCurso", ioConexao);
                    ioQuery.Parameters.Add("@idCurso", curso.CodigoCurso);

                    using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                    {
                        while (ioReader.Read())
                        {
                            Disciplinas disciplina = new Disciplinas(ioReader.GetInt32(0), ioReader.GetInt32(1), ioReader.GetString(2), ioReader.GetInt32(3));
                            listaDisciplinas.Add(disciplina);
                        }
                    }
                }
            }
            return listaDisciplinas;
        }

        public int RetornarUltimoCodigoDisciplina()
        {
            int codigoDisciplina = 0;
            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("SELECT TOP 1 CODIGODISCIPLINA FROM Disciplina_GabrielNascimento ORDER BY CodigoDisciplina DESC", ioConexao);
                    codigoDisciplina = (int)ioQuery.ExecuteScalar();
                }
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro ao buscar o código da última disciplina");
            }
            return codigoDisciplina;
        }
        public int AdicionarDisciplina(Disciplinas disciplina) {
            int numeroLinhasAlteradas = 0;

            try
            {
                using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    ioConexao.Open();
                    ioQuery = new SqlCommand("INSERT INTO Disciplina_GabrielNascimento (CodigoDisciplina, CodigoCurso, Nome, NumeroSemestre) VALUES (@CodigoDisciplina, @CodigoCurso, @Nome, @NumeroSemestre)",ioConexao);
                    ioQuery.Parameters.Add("@CodigoDisciplina", disciplina.CodigoDisciplina);
                    ioQuery.Parameters.Add("@CodigoCurso", disciplina.CodigoCurso);
                    ioQuery.Parameters.Add("@Nome", disciplina.Nome);
                    ioQuery.Parameters.Add("@NumeroSemestre", disciplina.NumeroSemestre);
                    numeroLinhasAlteradas = ioQuery.ExecuteNonQuery();
                }

            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro ao adicionar essa disciplina.");
            }
            return numeroLinhasAlteradas;
        }
        public BindingList<Disciplinas> ListarDisciplinas(int? CodigoDisciplina = null)
        {
            var listaDisciplinas = new BindingList<Disciplinas>();
            if (CodigoDisciplina == null)
            {
                try { 
                using(ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                        ioConexao.Open();
                        ioQuery = new SqlCommand("Select * from disciplina_GabrielNascimento", ioConexao);
                        using(SqlDataReader ioReader = ioQuery.ExecuteReader())
                        {
                            while (ioReader.Read())
                            {
                                Disciplinas disciplina = new Disciplinas(ioReader.GetInt32(0), ioReader.GetInt32(1), ioReader.GetString(2), ioReader.GetInt32(3));
                                listaDisciplinas.Add(disciplina);
                            }
                            ioReader.Close();
                        }
                        
                }
                 }catch(Exception e){
                    throw new Exception("Ocorreu um problema ao listar as disciplinas");
                }

            }else
            {
                try
                {
                    using (ioConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        ioQuery = new SqlCommand("Select * from disciplina_GabrielNascimento where CodigoDisciplina = @idDisciplina", ioConexao);
                        ioQuery.Parameters.Add("@idDisciplina", CodigoDisciplina);
                        using (SqlDataReader ioReader = ioQuery.ExecuteReader())
                        {
                            while (ioReader.Read())
                            {
                                Disciplinas disciplina = new Disciplinas(ioReader.GetInt32(0), ioReader.GetInt32(1), ioReader.GetString(2), ioReader.GetInt32(3));
                                listaDisciplinas.Add(disciplina);
                            }
                            ioReader.Close();
                        }
                       
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Ocorreu um problema ao listar as disciplinas");
                }

            }
            return listaDisciplinas;
        }
    }
}