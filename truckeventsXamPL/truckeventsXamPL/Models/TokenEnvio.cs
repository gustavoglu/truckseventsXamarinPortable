using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckeventsXamPL.Models
{
    public class TokenEnvio : BaseEntity
    {
        public string Token { get; set; }

        public bool Ativo { get; set; }

        public DateTime ExpiraEm { get; set; }
    }
}
