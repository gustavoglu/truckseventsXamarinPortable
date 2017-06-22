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
        ListView listV_VendasEvento;
        ToolbarItem toolbar_novaVenda;

        ObservableCollection<VendaViewModel> Vendas; 
        Evento _evento;

        public Evento_Vendas_Page(Evento evento)
        {
            this._evento = evento;
            this.Title = string.Format("Vendas Evento: {0}" , evento.Descricao);

            Vendas = new ObservableCollection<VendaViewModel>();
            listV_VendasEvento = new ListView() { HasUnevenRows = true, SeparatorVisibility = SeparatorVisibility.None};
            listV_VendasEvento.ItemTemplate = new DataTemplate(typeof(VCell_Vendas));
            listV_VendasEvento.ItemsSource = Vendas;

            toolbar_novaVenda = new ToolbarItem("Nova Venda", "", NovaVenda, ToolbarItemOrder.Default);
            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { listV_VendasEvento } };
            this.ToolbarItems.Add(toolbar_novaVenda);
            this.Content = sl_principal;



            getVendas();

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
            var vendas = await WSOpen.Get<List<Venda>>(uri);

            if (vendas != null && vendas.Count > 0)
            {
                vendas = vendas.OrderByDescending(x => x.CriadoEm).ToList();
                foreach (var venda in vendas)
                {
                    Vendas.Add(new VendaViewModel(venda));
                }
            }

        }
    }
}
