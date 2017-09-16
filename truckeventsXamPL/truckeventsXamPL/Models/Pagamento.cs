using System.Collections.Generic;

namespace truckeventsXamPL.Models
{
    public class Pagamento : BaseEntity
    {
        public double? Total { get; set; } = 0;

        public bool? Cancelado { get; set; } = false;

        public virtual Venda Venda { get; set; }

        public virtual ICollection<Pagamento_Ficha> Pagamento_Fichas { get; set; }

    }
}
