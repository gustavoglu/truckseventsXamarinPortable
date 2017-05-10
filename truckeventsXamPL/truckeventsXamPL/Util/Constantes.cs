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

        public static Token Token { get; set; }

        #region layout
        public const int PADDINGDEFAULT = 20;

        public static Color VERDESELECAO = Color.FromHex("#c9ff46");
        
        #endregion


        #region WS

        public const string WS_SERVER = "http://localhost:50262";
        public static string WS_URILOGINTOKEN = WS_SERVER + "/Token";
        public const string WS_REGISTRO = WS_SERVER + "/api/Account/Register";
        public const string WS_PRODUTOS = WS_SERVER + "/api/produtos";
        public const string WS_EVENTOS = WS_SERVER + "/api/eventos";
        public const string WS_VENDAS = WS_SERVER + "/api/vendas";
        public const string WS_FICHAS = WS_SERVER + "/api/fichas";

        #endregion

        #region Icones

        public static IconLabel ICON_ORGANIZADOR = new IconLabel() {Text = "fa-handshake-o", ClassId = "fa-handshake-o" };
        public static IconLabel ICON_LOJA = new IconLabel() {Text = "users", ClassId = "users" };


        #endregion


        #region Erro Mensagens

        public const string ERRO_VENDASEMPRODUTOS = "É Necessário adicionar algum produto a venda, favor verificar sua venda";
        #endregion
    }
}
