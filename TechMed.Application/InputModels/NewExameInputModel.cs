using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.InputModel
{
    public class NewExameInputModel
    {
        public string Nome { get; set; } = null!;
        public DateTime DataHora { get; set; }
        public int AdendimentoId { get; set; }
    }
}