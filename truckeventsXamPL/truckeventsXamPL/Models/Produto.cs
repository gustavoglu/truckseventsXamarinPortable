﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; }
        public int? Numero { get; set; }

        public Guid? Id_produto_cor { get; set; }
        public Guid? Id_produto_tipo { get; set; }

        public virtual Produto_Cor Produto_Cor { get; set; } = null;
        public virtual Produto_Tipo Produto_Tipo { get; set; } = null;

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }

        public virtual ICollection<Ficha_Produto> Ficha_Produtos { get; set; }
    }
}
