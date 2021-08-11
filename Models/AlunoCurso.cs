using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoColegio.Models
{[Serializable]//CodigoAluno, CodigoCurso, DataIngresso
    public class AlunoCurso
    {
        public int CodigoAluno { get; set; }
        public int CodigoCurso { get; set; }
        public string DataIngresso { get; set; }

        public AlunoCurso(int CodigoAluno, int CodigoCurso, string DataIngresso)
        {
            this.CodigoAluno = CodigoAluno;
            this.CodigoCurso = CodigoCurso;
            this.DataIngresso = DataIngresso;
        }
    }
}
