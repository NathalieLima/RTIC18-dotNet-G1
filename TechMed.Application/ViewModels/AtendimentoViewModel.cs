using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.ViewModel
{
    public class AtendimentoViewModel
    {
      public int AtendimentoId { get; set; }
      public DateTime DataHora { get; set; }
      public PacienteViewModel Paciente { get; set; } = null!;
      public MedicoViewModel Medico { get; set; } = null!;
    }
}