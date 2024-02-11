using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.ViewModel
{
    public class ExameViewModel
    {
        public int ExameId { get; set; }
        public string? Nome { get; set; }
        public DateTimeOffset DataHora { get; set; }
        public AtendimentoViewModel Atendimento { get; set; } = null!;
    }
}