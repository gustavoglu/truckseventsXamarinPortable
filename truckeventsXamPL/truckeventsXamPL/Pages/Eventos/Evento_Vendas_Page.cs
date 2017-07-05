using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Pages.Vendas;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewlCells;
using truckeventsXamPL.ViewModels;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Eventos
{


    public class Evento_Vendas_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_total;
        ListView listV_VendasEvento;
        ToolbarItem toolbar_novaVenda;
        Label l_tituloVendas;
        Label l_totalVendas;
        Loading_Layout loading;
        ObservableCollection<VendaViewModel> Vendas;
        Evento _evento;

        public Evento_Vendas_Page(Evento evento)
        {
            this._evento = evento;
            this.Title = string.Format(evento.Descricao);

            l_tituloVendas = new Label() { Text = "Vendas", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.White, FontAttributes = FontAttributes.Bold };
            l_totalVendas = new Label() { Text = "Total : R$ 0", HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.White, FontAttributes = FontAttributes.Bold };
            loading = new Loading_Layout();
            Vendas = new ObservableCollection<VendaViewModel>();
            listV_VendasEvento = new ListView() { Margin = 5, HasUnevenRows = true, SeparatorVisibility = SeparatorVisibility.None };
            listV_VendasEvento.ItemTemplate = new DataTemplate(typeof(VCell_Vendas));
            listV_VendasEvento.ItemsSource = Vendas;

            toolbar_novaVenda = new ToolbarItem("Nova Venda", "", NovaVenda, ToolbarItemOrder.Default);
            sl_hori_total = new StackLayout() { Padding = 10, BackgroundColor = Constantes.ROXOESCURO, Orientation = StackOrientation.Horizontal, Children = { l_tituloVendas, l_totalVendas } };
            sl_principal = new StackLayout() { Children = { sl_hori_total, listV_VendasEvento } };
            this.ToolbarItems.Add(toolbar_novaVenda);
            this.Content = sl_principal;

            listV_VendasEvento.ItemTapped += ListV_VendasEvento_ItemTapped;

            getVendas();

        }

        private void ListV_VendasEvento_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = sender as ListView;

            listView.SelectedItem = null;

        }

        private void GetTotal()
        {
            double total = Vendas.Where(v => v.Status == "Realizada").Sum(v => v.TotalVenda);

            if (total > 0)
            {
                l_totalVendas.Text = string.Format("Total : R$ {0}", total);
            }

        }


        private void NovaVenda()
        {
            App.Nav.Navigation.PushAsync(new Nova_Venda_Page(new Venda() { Id_evento = _evento.Id }, _evento));
        }

        private void populaVendas()
        {
            if (_evento.Vendas != null && _evento.Vendas.Count > 0)
            {
                foreach (var venda in _evento.Vendas)
                {
                    Vendas.Add(new VendaViewModel(venda));
                }
            }
        }

        private async void getVendas()
        {
            string uri = string.Format("{0}/{1}", Constantes.WS_VENDAS_EVENTO, _evento.Id);

            List<Venda> vendas = null;

            loading.Enable(this);

            await Task.Factory.StartNew(async () =>
            {
                vendas = await WSOpen.Get<List<Venda>>(uri);
            });

            if (vendas != null && vendas.Count > 0)
            {
                vendas = vendas.OrderByDescending(x => x.CriadoEm).ToList();

                foreach (var venda in vendas)
                {
                    Vendas.Add(new VendaViewModel(venda));
                }

                GetTotal();
            }

            loading.Disable(this, sl_principal);
        }
    }
}
