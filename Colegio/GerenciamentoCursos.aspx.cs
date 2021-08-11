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
    public partial class GerenciamentoCursos : System.Web.UI.Page
    {
        CursosDAO ioCursosDAO = new CursosDAO();
        public BindingList<Cursos> ListarCursos
        {
            get
            {
                if ((BindingList<Cursos>)ViewState["ListarCursos"] == null)
                    CarregarDados();
                return (BindingList<Cursos>)ViewState["ListarCursos"];
            }
            set
            {
                ViewState["ListarCursos"] = value;
            }
        }

        public Cursos CursoSession
        {
            get
            {
                return (Cursos)Session["CursoSelecionado"];
            }
            set
            {
                Session["CursoSelecionado"] = value;
            }
        }

        private void CarregarDados()
        {
            try
            {
                ListarCursos = ioCursosDAO.ListarCursos();
                gvGerenciamentoCursos.DataSource = ListarCursos.OrderBy(e => e.CodigoCurso);
                gvGerenciamentoCursos.DataBind();
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro ao buscar os cursos cadastrados.')</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { CarregarDados(); }
        }

        protected void gvGerenciamentoCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linhaSelecionado = Convert.ToInt32(e.CommandArgument);
            int CodigoCurso = Convert.ToInt32((this.gvGerenciamentoCursos.Rows[linhaSelecionado].FindControl("lblCodigoCurso") as Label).Text);
            string nome = (this.gvGerenciamentoCursos.Rows[linhaSelecionado].FindControl("lblNomeCurso") as Label).Text;
            int quantidadeSemestres = Convert.ToInt32((this.gvGerenciamentoCursos.Rows[linhaSelecionado].FindControl("lblQntdeSemestres") as Label).Text);
            var Curso = new Cursos(CodigoCurso, nome, quantidadeSemestres);
            CursoSession = Curso;

            switch (e.CommandName)
            {
                case "MostrarDisciplinas":
                    Response.Redirect("MostrarDisciplinasPorCurso?@INFO=CursoSession");
                    break;

                default:

                    break;

            }
        }
    }
}