using Rg.Plugins.Popup.Pages;
using truckeventsXamPL.ViewModels;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    class Popup_Venda_Ficha_Valor : PopupPage
    {
        StackLayout sl_principal;
        Label l_codFicha;
        Label l_clienteFicha;
        Button b_confirmar;
        FichaValorViewModel _fichaValor;

        public Popup_Venda_Ficha_Valor(FichaValorViewModel fichaValor)
        {
            this._fichaValor = fichaValor;
            l_clienteFicha = new Label() { Text = string.Format("Cliente: {0}", fichaValor.Pagamento_Ficha.Ficha.NomeCliente), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            l_codFicha = new Label() { Text = string.Format("Cód. Ficha: {0}", fichaValor.Pagamento_Ficha.Ficha.Codigo), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            b_confirmar = new Button() { Text = "Confirmar", Margin = new Thickness(0,30,0,0) , HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.End };

            sl_principal = new StackLayout()
            {
                Padding = Util.Constantes.PADDINGDEFAULT,MinimumHeightRequest = 200,
                MinimumWidthRequest = 150,
                HorizontalOptions = LayoutOptions.Center,VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Children = { l_codFicha,l_clienteFicha,b_confirmar }
            };

            this.Content = sl_principal;
            this.Padding = 100;
            this.HasSystemPadding = true;
        }
    }
}
