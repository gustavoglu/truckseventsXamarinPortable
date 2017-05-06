using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Pages.Eventos;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewlCells;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    public class Resumo_Venda_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_1;
        StackLayout sl_hori_2;
        StackLayout sl_hori_3;
        ListView listV_produtosEscolhidos;
        Label l_codigoFicha;
        Label l_totalVenda;
        Label l_totalVenda_h;
        Label l_nomeCliente;
        Label l_troco;
        Label l_trocoResultado;
        Entry e_nomeCliente;
        Entry e_codigoFicha;
        Entry e_troco;

        ToolbarItem toolbar_confirmar;
        ToolbarItem toolbar_cancelar;

        Venda _venda;
        Evento _evento;

        public Resumo_Venda_Page(Venda venda,Evento _evento)
        {
            this._venda = venda;
            this._evento = _evento;

            l_totalVenda_h = new Label() { Text = "Total Venda: " };
            l_totalVenda = new Label() { Text = string.Format("R$ {0}", venda.TotalVenda) };
            e_troco = new Entry() { Keyboard = Keyboard.Numeric };
            l_troco = new Label() { Text = "Troco:" };
            l_trocoResultado = new Label() { Text = "0" };
            l_nomeCliente = new Label() { Text = "Nome Cliente:", HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_nomeCliente = new Entry() { Placeholder = "ex: Pedro", HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_codigoFicha = new Label() { Text = "Cód. Ficha Pagamento: " };
            e_codigoFicha = new Entry() { Placeholder = "00000", Keyboard = Keyboard.Numeric };

            listV_produtosEscolhidos = new ListView();
            listV_produtosEscolhidos.ItemTemplate = new DataTemplate(typeof(VCell_Resumo_Venda));
            listV_produtosEscolhidos.ItemsSource = _venda.Venda_Produtos;

            toolbar_confirmar = new ToolbarItem("Confirmar", "", Confirmar, ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);

            sl_hori_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_codigoFicha, e_codigoFicha } };
            sl_hori_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_totalVenda_h, l_totalVenda } };
            sl_hori_3 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = {l_troco,e_troco,l_trocoResultado } };
            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { sl_hori_2, listV_produtosEscolhidos,sl_hori_3, sl_hori_1 } };

            this.ToolbarItems.Add(toolbar_cancelar);
            this.ToolbarItems.Add(toolbar_confirmar);
            this.Content = sl_principal;


            e_codigoFicha.Focus();
        }

        private void Cancelar()
        {
            Utilidades.removeDaStackPaginaAtualNavigation(App.Nav);
        }

        private async void Confirmar()
        {
            var result = await WSOpen.Post(Constantes.WS_VENDAS, _venda);
            if (result != null)
            {
                Utilidades.DialogMessage("Venda Realizada");
                await App.Nav.PushAsync(new Evento_Vendas_Page(_evento));
            }
        }
    }
}
