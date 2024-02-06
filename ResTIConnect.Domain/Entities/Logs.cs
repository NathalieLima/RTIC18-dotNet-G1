using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Logs: BaseEntity
    {
        public int LogId { get; }
        public required string  Tipo { get; set; } 
        public required string  Descricao { get; set; }
        public DateTimeOffset DataHoraEvento { get; set; }
        public string? Entidade { get; set; }
        public int TuplaId { get; set; }

    }
}