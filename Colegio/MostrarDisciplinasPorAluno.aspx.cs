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
    public partial class MostrarDisciplinasPorAluno : System.Web.UI.Page
    {
        AlunoCursoDAO ioAcurso = new AlunoCursoDAO();
        DisciplinasDAO ioDisciplinas = new DisciplinasDAO();
        CursosDAO ioCursos = new CursosDAO();

        private void CarregarDados()
        {
            try
            {
                Alunos aluno = (Alunos)Session["SessionAlunoSelecionado"];
                int CodigoCurso = ioAcurso.RetornarCursoAluno(aluno);
                Cursos ioCurso = ioCursos.RetornarCurso(CodigoCurso);
                gvGerenciamentoDisciplinasAluno.DataSource = ioDisciplinas.MostrarDisciplinasPorCurso(ioCurso);
                gvGerenciamentoDisciplinasAluno.DataBind();

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro')</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { CarregarDados(); }

        }
    }
}