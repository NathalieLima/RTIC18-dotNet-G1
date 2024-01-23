using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Entities
{
    public class Sistemas
    {
        public int SistemaId { get; }
        public required string Descricao { get; set; }
        public string? Tipo { get; set; }
        public string? EnderecoEntrada { get; set; }
        public string? EnderecoSaida { get; set; }
        public string? Protocolo { get; set; }
        public DateTime DataHoraInicioIntegracao { get; set; }
        public string? Status { get; set; }
    }
}