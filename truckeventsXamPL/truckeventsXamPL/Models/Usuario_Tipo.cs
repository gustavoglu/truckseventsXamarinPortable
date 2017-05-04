using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Usuario_Tipo
    {
        public string Descricao { get; set; } = null;

        public bool? UserAdmin { get; set; }

        public bool? UserPrincipal { get; set; }

        public bool? Organizador { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
