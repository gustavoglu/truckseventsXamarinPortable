using System;
using truckeventsXamPL.Models.Enums;

namespace truckeventsXamPL.Models
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public double? Preco { get; set; } = 0;

        public ProdutoTipo Tipo { get; set; }

        public Guid? Id_Cor { get; set; }

        public Guid Id_loja { get; set; }

        public Cor Cor { get; set; }
    }
}
