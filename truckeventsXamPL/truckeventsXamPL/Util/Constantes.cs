using truckeventsXamPL.Models;
using Xamarin.Forms;

namespace truckeventsXamPL.Util
{
    public class Constantes
    {
        bool Homologacao = true;

        public static Token Token { get; set; }

        #region layout
        public const int PADDINGDEFAULT = 20;

        public static Color VERDESELECAO = Color.FromHex("#c9ff46");

        public static Color VERMELHOPADRAO = Color.FromHex("#cd3030");

        public static Color ROXOPADRAO = Color.FromHex("#6730cd");

        public static Color ROXOESCURO = Color.FromHex("#531db8");

        #endregion
    

        #region WS
        public const string WS_HMLAZURE = "http://eventosproject.azurewebsites.net/api/";
        public const string WS_HMLLOCAL = "http://localhost:51949/api/";
        public const string WS_SERVER = "http://localhost:51949/api/";
        public static string WS_URILOGINTOKEN = WS_SERVER + "Contas/Login";
        public const string WS_REGISTRO = WS_SERVER + "/api/Account/Register";
        public const string WS_PRODUTOS = WS_SERVER + "produtos";
        public const string WS_EVENTOS = WS_SERVER + "/api/eventos";
        public const string WS_VENDAS = WS_SERVER + "vendas";
        public const string WS_FICHAS = WS_SERVER + "fichas";
        public const string WS_VENDAS_EVENTO = WS_SERVER + "/api/vendas/evento";

        #endregion

        #region Icones

        //public static IconLabel ICON_ORGANIZADOR = new IconLabel() {Text = "fa-handshake-o", ClassId = "fa-handshake-o" };
        //public static IconLabel ICON_LOJA = new IconLabel() {Text = "users", ClassId = "users" };


        #endregion


        #region Erro Mensagens

        public const string ERRO_VENDASEMPRODUTOS = "É Necessário adicionar algum produto a venda, favor verificar sua venda";
        #endregion
    }
}
