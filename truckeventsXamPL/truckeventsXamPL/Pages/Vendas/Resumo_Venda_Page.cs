using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    public class Resumo_Venda_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_1;
        StackLayout sl_hori_2;
        ListView listV_produtosEscolhidos;
        Entry e_codigoFicha;
        Label l_codigoFicha;
        Label l_totalVenda;
        Label l_totalVenda_h;
        ToolbarItem toolbar_confirmar;
        ToolbarItem toolbar_cancelar;
        Venda _venda;
        public Resumo_Venda_Page(Venda venda)
        {
            this._venda = venda;
            l_totalVenda_h = new Label() { Text = "Total Venda: " };
            l_totalVenda = new Label() { Text = string.Format("R$ {0}",venda.TotalVenda) };

            l_codigoFicha = new Label() { Text = "Cód. Ficha Pagamento: " };
            e_codigoFicha = new Entry() { Placeholder = "00000", Keyboard = Keyboard.Numeric };
            listV_produtosEscolhidos = new ListView();
            listV_produtosEscolhidos.ItemsSource = _venda.Venda_Produtos;

            toolbar_confirmar = new ToolbarItem("Confirmar", "", Confirmar, ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);

            sl_hori_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_codigoFicha,e_codigoFicha } };
            sl_hori_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = {l_totalVenda_h,l_totalVenda } };
            sl_principal = new StackLayout() {Padding = Constantes.PADDINGDEFAULT, Children = {sl_hori_2 ,listV_produtosEscolhidos,sl_hori_1 } };
            this.Content = sl_principal;


            e_codigoFicha.Focus();
        }

        private void Cancelar()
        {

        }

        private void Confirmar()
        {

        }
    }
}
