using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities;
public class User 
{
      public int UserId { get; set; }
       public string? Name { get; set; }
      required public string Email { get; set; }
      required public string Password { get; set; }

      public string? Telefone { get; set; }
}
