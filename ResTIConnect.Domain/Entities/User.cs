using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities;
public class User : BaseEntity
{
      public int UserId { get; set; }
      public string? Name { get; set; }
      public required string Email { get; set; }
      public required string Password { get; set; }
      public string? Telefone { get; set; }


      public Enderecos? Endereco { get; set; }
      public ICollection<Perfis>? Perfis { get; set; }
      public ICollection<Sistemas>? Sistemas { get; set; }
}
