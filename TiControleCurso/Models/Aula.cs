using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiControleCurso.Models
{
    public class Aula
    {
        public string NomeAula { get; set; }
        public bool Status { get; set; }
        public int IdUsuario { get; set; }
        public string Uia { get; set; }
    }
}