using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Token
    {
        public string access_token { get; set; } = null;
        public string userName { get; set; } = null;
        public DateTime? expires { get; set; }
        public bool? Admin { get; set; }
        public bool? Organizador { get; set; }
        public bool? UsuarioPrincipal { get; set; }
        public string id_usuario_principal { get; set; } = null;
    }
}
