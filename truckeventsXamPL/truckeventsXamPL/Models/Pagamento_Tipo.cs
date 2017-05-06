using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
   public class Pagamento_Tipo : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public virtual ICollection<Venda_Pagamento> Venda_Pagamentos { get; set; }
    }
}
