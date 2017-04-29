using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckevents.Domain
{
   public class Pagamento_Tipo
    {
        public string Descricao { get; set; } = null;

        public virtual ICollection<Venda_Pagamento> Venda_Pagamentos { get; set; }
    }
}
