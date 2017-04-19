using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.ViewModels;

namespace truckeventsXamPL.Events
{
   public class AlteraQuantidadeProdutoArgs : EventArgs
    {
        public ProdutoVendaViewModel ProdutoVendaViewModel { get; set; }
    }
}
