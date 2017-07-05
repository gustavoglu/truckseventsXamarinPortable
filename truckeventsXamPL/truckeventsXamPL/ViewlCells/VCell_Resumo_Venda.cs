using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
    public class VCell_Resumo_Venda : ViewCell
    {
        StackLayout sl_principal;
        Label l_nomeProduto;
        Label l_quantidadeProduto;
        Label l_totalProduto;

        public VCell_Resumo_Venda()
        {
            l_nomeProduto = new Label() { HorizontalOptions = LayoutOptions.StartAndExpand , TextColor = Constantes.ROXOPADRAO};
            l_quantidadeProduto = new Label() { HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Constantes.ROXOPADRAO };
            l_totalProduto = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Constantes.ROXOPADRAO };

            l_nomeProduto.SetBinding(Label.TextProperty, "Descricao");
            l_quantidadeProduto.SetBinding(Label.TextProperty, "Quantidade", stringFormat:"Qtd {0}");
            l_totalProduto.SetBinding(Label.TextProperty, "Total",stringFormat: "Total {0}");


            sl_principal = new StackLayout() {Orientation = StackOrientation.Horizontal, Padding = Util.Constantes.PADDINGDEFAULT, Children = { l_nomeProduto,l_totalProduto,l_quantidadeProduto } };

            this.View = sl_principal;
        }
    }
}
