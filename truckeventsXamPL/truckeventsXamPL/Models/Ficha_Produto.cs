using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class Ficha_Produto : BaseEntity
    {
        public Guid? Id_Ficha { get; set; }

        public Guid? Id_Produto { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Ficha Ficha { get; set; }

        public bool? ProdutoRetirado { get; set; }
    }
}
