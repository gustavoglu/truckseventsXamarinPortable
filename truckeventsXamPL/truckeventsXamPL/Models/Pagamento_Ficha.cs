using System;

namespace truckeventsXamPL.Models
{
    public class Pagamento_Ficha
    {
        public Guid Id_ficha { get; set; }

        public Guid Id_pagamento { get; set; }

        public double? Valor { get; set; } = 0;

        public Ficha Ficha { get; set; }
    }
}
