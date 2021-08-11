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
    public partial class MostrarDisciplinasPorCurso : System.Web.UI.Page
    {
        DisciplinasDAO ioDisciplina = new DisciplinasDAO();
        CursosDAO ioCursos = new CursosDAO();

        public BindingList<Disciplinas> ListaDisciplinas
        {
            get
            {
                if ((BindingList<Disciplinas>)ViewState["ListarDisciplinas"] == null)
                    CarregarDados();
                return (BindingList<Disciplinas>)ViewState["ListarDisciplinas"];
            }
            set
            {
                ViewState["ListarDisciplinas"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { CarregarDados(); }
            
        }

        protected void BtnAdicionarDisciplina_click(object sender, EventArgs e)
        {
            try
            {
                Cursos curso = (Cursos)Session["CursoSelecionado"];
                string nomeDisciplina = tbxNomeDisciplina.Text;
                int numeroSemestre = Convert.ToInt32(tbxNumeroSemestre.Text);
                
                if(numeroSemestre > ioCursos.RetornarQtdeSemestres(curso))
                {
                    HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro, o curso não possui essa quantidade de semestres!') </script>");
                    throw new Exception("Ocorreu um erro");
                }
                else
                {
                    int NumeroDisciplina = ioDisciplina.RetornarUltimoCodigoDisciplina();
                    NumeroDisciplina++;
                    Disciplinas novaDisciplina = new Disciplinas(NumeroDisciplina, curso.CodigoCurso, nomeDisciplina, numeroSemestre);
                    ioDisciplina.AdicionarDisciplina(novaDisciplina);
                    HttpContext.Current.Response.Write("<script>alert('Disciplina adicionada com sucesso!') </script>");
                    tbxNomeDisciplina.Text = string.Empty;
                    tbxNumeroSemestre.Text = string.Empty;

                    CarregarDados();


                }


            } catch {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro ao adicionar uma nova disciplina nesse curso.')</script>");
            }
        }
        private void CarregarDados()
        {
            try
            {

                Cursos curso = (Cursos)Session["CursoSelecionado"];
                ListaDisciplinas = ioDisciplina.MostrarDisciplinasPorCurso(curso);
                gvGerenciamentoDisciplinas.DataSource = ListaDisciplinas.OrderBy(e => e.CodigoDisciplina);
                gvGerenciamentoDisciplinas.DataBind();
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro ao buscar as disciplinas')</script>");
            }
        }
    }
}