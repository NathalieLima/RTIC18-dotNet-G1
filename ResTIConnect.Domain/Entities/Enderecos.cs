using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Enderecos : BaseEntity
    {
        public int EnderecoId { get; }
        public required string Logradouro { get; set; }
        public string? Numero { get; set; }
        public required string Cidade { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public required string Estado { get; set; }
        public required string Cep { get; set; }
        public string? Pais { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        
    }
}