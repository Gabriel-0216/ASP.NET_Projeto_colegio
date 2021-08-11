using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoColegio.Models
{ 
    [Serializable]
    public class Disciplinas
    {
        public int CodigoDisciplina { get; set; }
        public int CodigoCurso { get; set; }
        public string Nome { get; set; }
        public int NumeroSemestre { get; set; }

        public Disciplinas(int CodigoDisciplina, int CodigoCurso, string Nome, int NumeroSemestre)
        {
            this.CodigoCurso = CodigoCurso;
            this.CodigoDisciplina = CodigoDisciplina;
            this.Nome = Nome;
            this.NumeroSemestre = NumeroSemestre;
        }
            
    }
}