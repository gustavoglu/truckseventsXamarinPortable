using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.ViewModels;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    class Popup_Venda_Ficha_Valor : PopupPage
    {
        StackLayout sl_principal;
        Label l_codFicha;
        Label l_clienteFicha;
        Label l_valor;
        Entry e_valor;
        Button b_confirmar;
        FichaValorViewModel _fichaValor;

        public Popup_Venda_Ficha_Valor(FichaValorViewModel fichaValor)
        {
            this._fichaValor = fichaValor;
            l_clienteFicha = new Label() { Text = string.Format("Cliente: {0}", fichaValor._venda_Pagamento_Ficha.Ficha.NomeCliente), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            l_codFicha = new Label() { Text = string.Format("Cód. Ficha: {0}", fichaValor._venda_Pagamento_Ficha.Ficha.Codigo), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            l_valor = new Label() { Text = "Valor a ser descontado da Ficha:" , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center}; 
            e_valor = new Entry() { Text = _fichaValor.Valor.ToString() , Keyboard = Keyboard.Numeric , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            b_confirmar = new Button() { Text = "Confirmar", Margin = new Thickness(0,30,0,0) , HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.End };

            sl_principal = new StackLayout()
            {
                Padding = Util.Constantes.PADDINGDEFAULT,MinimumHeightRequest = 200,
                MinimumWidthRequest = 150,
                HorizontalOptions = LayoutOptions.Center,VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Children = { l_codFicha,l_clienteFicha,l_valor, e_valor,b_confirmar }
            };

            this.Content = sl_principal;
            this.Padding = 100;
            this.HasSystemPadding = true;


            b_confirmar.Clicked += B_confirmar_Clicked;

        }

        private void B_confirmar_Clicked(object sender, EventArgs e)
        {
            if (e_valor.Text != null && e_valor.Text != string.Empty)
            {
                _fichaValor.Valor = double.Parse(e_valor.Text);
                PopupNavigation.PopAsync();
            }
        }
    }
}
