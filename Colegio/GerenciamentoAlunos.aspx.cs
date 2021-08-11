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
    public partial class GerenciamentoAlunos : System.Web.UI.Page
    {
        AlunosDAO ioAlunosDAO = new AlunosDAO();
        CursosDAO ioCursosDAO = new CursosDAO();

        public BindingList<Alunos> ListarAlunos
        {
            get
            {
                if ((BindingList<Alunos>)ViewState["ListarAlunos"] == null)
                    CarregarDados();
                return (BindingList<Alunos>)ViewState["ListarAlunos"];
            }
            set
            {
                ViewState["ListarAlunos"] = value;
            }
        }
        public BindingList<Cursos> ListarCursosAluno
        {
            get
            {
                if ((BindingList<Cursos>)ViewState["ListarCursos"] == null)
                    CarregarDadosCurso();
                return (BindingList<Cursos>)ViewState["ListarCursos"];
            }
            set
            {
                ViewState["ListarCursos"] = value;
            }
        }
        
        protected void BtnNovoAluno_click(object sender, EventArgs e)
        {
            
            try
            {
               
                string nomeAluno = tbxNomeAluno.Text;
                string DataNascimento = tbxDataNascimento.Text;
                string email = tbxEmail.Text;
                int CodigoAluno = ioAlunosDAO.RetornarUltimoIdAluno();
                CodigoAluno++;
                string NumeroMatricula = ioAlunosDAO.RetornarUltimoNumeroMatricula();
               

                Alunos novoAluno = new Alunos(CodigoAluno, nomeAluno, NumeroMatricula, DataNascimento, email);
               if (ioAlunosDAO.AdicionarAluno(novoAluno) >= 1)
                {
                    HttpContext.Current.Response.Write("Aluno adicionado com sucesso");
                    tbxNomeAluno.Text = string.Empty;
                    tbxDataNascimento.Text = string.Empty;
                    tbxEmail.Text = string.Empty;
                }
                else
                {
                    HttpContext.Current.Response.Write("Não foi possível adicionar esse aluno");
                    throw new Exception("Ocorreu um erro");
                }



            }
            catch { 
            HttpContext.Current.Response.Write("<script>alert('ocorreu um erro ao adicionar o novo aluno')</script>");
            }

           

        }
        private void CarregarDados()
        {
            try
            {
                ListarAlunos = ioAlunosDAO.RetornarAlunos();
                gvGerenciamentoAlunos.DataSource = ListarAlunos;
                gvGerenciamentoAlunos.DataBind();
               
            }
            catch
            {
                HttpContext.Current.Response.Write("Ocorreu um erro ao popular a grid view.");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { CarregarDados(); }

        }

        public Alunos AlunoSessao
        {
            get
            {
                return (Alunos)Session["SessionAlunoSelecionado"];
            }
            set
            {
                Session["SessionAlunoSelecionado"] = value;
            }
        }
        private void CarregarDadosCurso()
        {
            try
            {
                var Aluno = (Alunos)Session["SessionAlunoSelecionado"];

                ListarCursosAluno = ioCursosDAO.ListarCursos(Aluno.CodigoAluno);
            }
            catch
            {
                HttpContext.Current.Response.Write("Ocorreu um erro ao popular a grid view.");
            }
        }
        protected void gvGerenciamentoAlunos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var teste = e.CommandArgument;
            switch (e.CommandName)
            {
               
                case "MostrarDisciplinas"://        //CodigoAluno (int)  Nome (string)  NumeroMatricula (string)  DataNascimento (string)  Email (string)
                    int linhaRowIndexSelecionado = Convert.ToInt32(e.CommandArgument);
                    int CodigoAluno = Convert.ToInt32((this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblIdAluno") as Label).Text);
                    string Nome = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblNomeAluno") as Label).Text;
                    string NumMatricula = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTxtNumeroMatricula") as Label).Text;
                    string DataNascimento = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTxtNumeroMatricula") as Label).Text;
                    string Email = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTextDataNascimento") as Label).Text;

                    Alunos novoAluno = new Alunos(CodigoAluno, Nome, NumMatricula, DataNascimento, Email);
                    this.AlunoSessao = novoAluno;
                    Response.Redirect("MostrarDisciplinasPorAluno");
                    break;

                case "MostrarCursos":
                    linhaRowIndexSelecionado = Convert.ToInt32(e.CommandArgument);
                    CodigoAluno = int.Parse((this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblIdAluno") as Label).Text);
                    Nome = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblNomeAluno") as Label).Text;
                    NumMatricula = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTxtNumeroMatricula") as Label).Text;
                    DataNascimento = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTxtNumeroMatricula") as Label).Text;
                    Email = (this.gvGerenciamentoAlunos.Rows[linhaRowIndexSelecionado].FindControl("lblTextDataNascimento") as Label).Text;

                    novoAluno = new Alunos(CodigoAluno, Nome, NumMatricula, DataNascimento, Email);
                    this.AlunoSessao = novoAluno;
                    Response.Redirect("AdicionarAlunoCurso");

                    break;

                default:

                    break;

            }

        }
    }
}