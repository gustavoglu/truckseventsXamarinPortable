using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using Xamarin.Forms;

namespace truckeventsXamPL.Util
{
    public class Constantes
    {
        #region layout
        public static Thickness PaddingDefault = 20;
        public static Token Token;
        #endregion


        #region WS

        public static string WS_UriLoginToken = "http://truckevents.azurewebsites.net/Token";

        #endregion
    }
}
