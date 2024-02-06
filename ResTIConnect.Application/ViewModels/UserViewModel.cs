using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public EnderecoViewModel? Endereco { get; set; }
        public PerfilViewModel? Perfil { get; set; }
        public SistemaViewModel? Sistema { get; set; }
    }
}