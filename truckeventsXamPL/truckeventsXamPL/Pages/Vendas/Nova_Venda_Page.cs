using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    public class Nova_Venda_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_total;

        ListView listV_produtos;
        Label l_total;
        Label l_total_h;
        ObservableCollection<Produto> Produtos;

        Evento _evento;


        public Nova_Venda_Page(Evento evento)
        {
            this._evento = evento;
            Produtos = new ObservableCollection<Produto>();
            l_total = new Label() { HorizontalOptions = LayoutOptions.End };
            l_total_h = new Label() { Text = "Total", HorizontalOptions = LayoutOptions.End };
            listV_produtos = new ListView();


            sl_hori_total = new StackLayout() { Children = { l_total_h,l_total } };
            sl_principal = new StackLayout()
            {
                Padding = Constantes.PADDINGDEFAULT,
                Children =
                {
                    listV_produtos,
                    sl_hori_total
                }
            };
        }
    }
}
