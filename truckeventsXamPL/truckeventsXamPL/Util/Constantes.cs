using FormsPlugin.Iconize;
using Plugin.Iconize;
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

        public static Token Token;

        #region layout
        public const int PADDINGDEFAULT = 20;
        
        #endregion


        #region WS

        public const string WS_SERVER = "http://truckevents.azurewebsites.net";
        public static string WS_URILOGINTOKEN = "http://truckevents.azurewebsites.net/Token";
        public const string WS_REGISTRO = WS_SERVER + "/api/Account/Register";
        public const string WS_PRODUTOS = WS_SERVER + "/api/produtos";
        public const string WS_EVENTOS = WS_SERVER + "/api/eventos";
        public const string WS_VENDAS = WS_SERVER + "/api/vendas";

        #endregion

        #region Icones

        public static IconLabel ICON_ORGANIZADOR = new IconLabel() {Text = "fa-handshake-o", ClassId = "fa-handshake-o" };
        public static IconLabel ICON_LOJA = new IconLabel() {Text = "users", ClassId = "users" };


        #endregion
    }
}
