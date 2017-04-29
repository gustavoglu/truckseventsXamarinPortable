using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truckevents.Domain
{
    public class TokenEnvio
    {
        public string Token { get; set; }

        public bool Ativo { get; set; }

        public DateTime ExpiraEm { get; set; }
    }
}
