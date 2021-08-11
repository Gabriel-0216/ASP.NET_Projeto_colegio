using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoColegio.Models
{   
    [Serializable]
    public class Alunos
    {////int CodigoAluno, varchar Nome, NumeroMatricula varchar, DataNasciemnto DATE, Email Varchar
        public int CodigoAluno { get; set; }
        public string Nome { get; set; }
        public string NumeroMatricula { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public Alunos(int CodigoAluno, string Nome, string NumeroMatricula, string DataNascimento, string Email)
        {
            this.CodigoAluno = CodigoAluno;
            this.Nome = Nome;
            this.NumeroMatricula = NumeroMatricula;
            this.DataNascimento = DataNascimento;
            this.Email = Email;
        }

    }
}