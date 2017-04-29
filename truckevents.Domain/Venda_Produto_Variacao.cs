﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckevents.Domain
{
    public class Venda_Produto_Variacao : BaseEntity
    {
        public Guid? Id_produto_variacao { get; set; }

        public Guid? Id_venda_produto { get; set; }

        public virtual Produto_Variacao Produto_Variacao { get; set; } = null;

        public virtual Venda_Produto Venda_Produto { get; set; } = null;
    }
}
