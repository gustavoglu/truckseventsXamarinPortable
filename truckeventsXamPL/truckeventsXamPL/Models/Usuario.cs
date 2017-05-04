using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
   public class Usuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Nome { get; set; } = null;
        public string Sobrenome { get; set; } = null;
        public string RazaoSocial { get; set; } = null;
        public string Telefone1 { get; set; } = null;
        public string Telefone2 { get; set; } = null;
        public string Documento { get; set; } = null;
        public DateTime? DataNascimento { get; set; }
        public bool? UserAdmin { get; set; }
        public bool? UserPrincipal { get; set; }
        public bool? Organizador { get; set; }
        public bool? CaixaEvento { get; set; }

        public string id_usuario_organizador { get; set; }
        public virtual Usuario Usuario_Organizador { get; set; }

        public virtual ICollection<Usuario> Caixas { get; set; }
        public virtual ICollection<Usuario> Lojas { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Evento_Usuario> Evento_Usuarios { get; set; }
    }
}
