using System;
using System.Collections.Generic;

namespace truckeventsXamPL.Models
{
    public class Pagamento
    {
        public Guid Id { get; set; }

        public double? Total { get; set; } = 0;

        public bool? Cancelado { get; set; } = false;

        public virtual Venda Venda { get; set; }

        public virtual ICollection<Pagamento_Ficha> Pagamento_Fichas { get; set; }

    }
}
