﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Pages.Vendas;
using truckeventsXamPL.Util;
using truckeventsXamPL.WS;
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
                    Vendas.Add(venda);
                }
            }
        }

        private async void getVendas()
        {
            string uri = string.Format("{0}/{1}", Constantes.WS_VENDAS_EVENTO, _evento.Id);
            var vendas = await WSOpen.Get<List<Venda>>(uri);
            if (vendas != null && vendas.Count > 0)
            {
                foreach (var venda in _evento.Vendas)
                {
                    Vendas.Add(venda);
                }
            }

        }
    }
}
