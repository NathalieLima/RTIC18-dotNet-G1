using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Perfil
    {
        public int PerfilId { get; }
        public required string  Descricao { get; set; }
        public required string  Permissoes { get; set; }       
    }
}