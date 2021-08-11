using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoColegio.DAO;
using ProjetoColegio.Models;

namespace ProjetoColegio.Colegio
{
    public partial class AdicionarAlunoCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { CarregarDados(); }

        }
        protected void BtnAdicionarAlunoCurso_click(object sender, EventArgs e)
        {
            try
            {
                Alunos aluno = (Alunos)Session["SessionAlunoSelecionado"];
                int CodigoCurso = Convert.ToInt32(tbxIdCurso.Text);

                CursosDAO cursos = new CursosDAO();

                if(cursos.CursoExiste(CodigoCurso) >= 1)
                {
                    Cursos curso = cursos.RetornarCurso(CodigoCurso);
                    AlunoCursoDAO acurso = new AlunoCursoDAO();
                    acurso.AdicionarAluno(aluno, curso);

                    HttpContext.Current.Response.Write("Sucesso!");
                   
                }

                else
                {
                    throw new Exception("erro!");
                }

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro')</script>");
            }
        }
        private void CarregarDados()
        {
            try
            {
                Alunos aluno = (Alunos)Session["SessionAlunoSelecionado"];
                tbxCodigoAluno.Text = aluno.CodigoAluno.ToString();
                tbxNumMatricula.Text = aluno.NumeroMatricula;
                tbxNome.Text = aluno.Nome;
                tbxDataNascimento.Text = aluno.DataNascimento;
                tbxEmail.Text = aluno.Email;

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro')</script>");
            }
        }
    }
}