using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Evento_Usuario : BaseEntity
    {
        public string Id_Usuario { get; set; } = null;

        public Guid? Id_Evento { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Evento Evento { get; set; } = null;

        public bool? UsuarioConfirmado { get; set; }
    }
}
