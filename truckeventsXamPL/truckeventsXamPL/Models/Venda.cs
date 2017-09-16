using System;
using System.Collections.Generic;

namespace truckeventsXamPL.Models
{
    public class Venda : BaseEntity
    {
        public Venda()
        {
            Venda_Produtos = new List<Venda_Produto>();
        }

        public DateTime Data { get; set; }

        public bool Cancelada { get; set; } = false;

        public double? Total { get; set; } = 0;

        public Guid Id_loja { get; set; }

        public Guid Id_Evento { get; set; }

        public virtual Pagamento Pagamento { get; set; }

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }
    }
}
