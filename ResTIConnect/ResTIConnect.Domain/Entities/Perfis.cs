using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Perfis
    {
        public int PerfilId { get; }
        public required string  Descricao { get; set; }
        public required string  Permissoes { get; set; }       
    }
}