using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Venda_Pagamento_Ficha
    {
        public Guid? Id_venda_pagamento { get; set; }

        public Guid? Id_Ficha { get; set; }

        public virtual Venda_Pagamento Venda_Pagamento { get; set; }

        public virtual Ficha Ficha { get; set; }

        public double ValorInformado { get; set; }

    }
}
