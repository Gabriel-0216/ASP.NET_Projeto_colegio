using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoColegio.Models
{   [Serializable]
    public class Cursos
    {
        //CodigoCurso, Nome, QtdeSemestres

        public int CodigoCurso { get; set; }
        public string nome { get; set; }
        public int QuantidadeSemestres { get; set; }

        public Cursos(int CodigoCurso, string nome, int QuantidadeSemestres)
        {
            this.CodigoCurso = CodigoCurso;
            this.nome = nome;
            this.QuantidadeSemestres = QuantidadeSemestres;
        }
    }
}