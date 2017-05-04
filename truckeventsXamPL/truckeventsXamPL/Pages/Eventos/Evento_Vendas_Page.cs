using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Eventos
{


    public class Evento_Vendas_Page : ContentPage
    {
        StackLayout sl_principal;
        ListView listV_VendasEvento;
        ToolbarItem toolbar_novaVenda;

        ObservableCollection<Venda> Vendas;
        Evento _evento;

        public Evento_Vendas_Page(Evento evento)
        {
            this._evento = evento;
            Vendas = new ObservableCollection<Venda>();
            listV_VendasEvento = new ListView();
            listV_VendasEvento.ItemsSource = Vendas;

            toolbar_novaVenda = new ToolbarItem("Nova Venda", "", NovaVenda, ToolbarItemOrder.Default);
            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { listV_VendasEvento } };
            this.ToolbarItems.Add(toolbar_novaVenda);
            this.Content = sl_principal;

        }

        private void NovaVenda()
        {

        }
    }
}
