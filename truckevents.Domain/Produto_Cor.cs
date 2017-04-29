using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckevents.Domain
{
    public class Produto_Cor : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public string Cor { get; set; } = null;

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
