using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Entities
{
    public class Logs
    {
        public int LogId { get; }
        public required string  Tipo { get; set; } 
        public required string  Descricao { get; set; }
        public DateTime DataHoraEvento { get; set; }
        public string? Entidade { get; set; }
        public int TuplaId { get; set; }

    }
}