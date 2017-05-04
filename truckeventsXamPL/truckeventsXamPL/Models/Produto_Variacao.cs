﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
   public class Produto_Variacao : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public double? Valor { get; set; }

        public Guid? Id_consequencia { get; set; }

        public string Id_usuario { get; set; } = null;

        public virtual Consequencia Consequencia { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Venda_Produto_Variacao> Venda_Produto_Variacoes { get; set; }
    }
}
