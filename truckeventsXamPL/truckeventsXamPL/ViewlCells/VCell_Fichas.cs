using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
    public class VCell_Fichas : ViewCell
    {
        StackLayout sl_principal;
        Label l_codigoFicha;
        Label l_saldoFicha;
        Label l_nomeCliente;

        public VCell_Fichas()
        {
            l_codigoFicha = new Label() { HorizontalOptions = LayoutOptions.StartAndExpand };
            l_saldoFicha = new Label() { HorizontalOptions = LayoutOptions.FillAndExpand };
            l_nomeCliente = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand };

            l_codigoFicha.SetBinding(Label.TextProperty, "Codigo" );
            l_saldoFicha.SetBinding(Label.TextProperty, "Saldo");
            l_nomeCliente.SetBinding(Label.TextProperty, "NomeCliente");

            sl_principal = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { l_codigoFicha, l_nomeCliente, l_saldoFicha } };

            this.View = sl_principal;

        }
    }
}
