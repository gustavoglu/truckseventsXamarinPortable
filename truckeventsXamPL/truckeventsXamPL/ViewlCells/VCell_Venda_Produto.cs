using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Events;
using truckeventsXamPL.ViewModels;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
   public class VCell_Venda_Produto : ViewCell
    {
        StackLayout sl_principal;
        BoxView box_corProduto;
        Label l_nomeProduto;
        Label l_valor;
        Label l_totalValor;
        Label l_quantidade;
        Stepper st_quantidade;

        public delegate void AdicionaQuantidade(object sender, AlteraQuantidadeProdutoArgs e);
        public event AdicionaQuantidade AdicionaQuantidadeHandler;
        public delegate void DiminuiQuantidade(object sender, AlteraQuantidadeProdutoArgs e);
        public event DiminuiQuantidade DiminuiQuantidadeHandler;

        public VCell_Venda_Produto()
        {
            box_corProduto = new BoxView() { };
            l_nomeProduto = new Label() { };
            l_valor = new Label() { };
            l_totalValor = new Label() { };
            l_quantidade = new Label() { };
            st_quantidade = new Stepper() { HorizontalOptions = LayoutOptions.End };

            box_corProduto.SetBinding(BoxView.ColorProperty, "Cor");
            l_nomeProduto.SetBinding(Label.TextProperty, "Descricao");
            l_valor.SetBinding(Label.TextProperty, "Valor");
            l_totalValor.SetBinding(Label.TextProperty, "TotalValor");
            l_quantidade.SetBinding(Label.TextProperty, "Quantidade");


            st_quantidade.ValueChanged += St_quantidade_ValueChanged;

            sl_principal = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { box_corProduto, l_nomeProduto, l_totalValor, l_quantidade, st_quantidade } };

            this.View = sl_principal;
        }

        private void St_quantidade_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > int.Parse(l_quantidade.Text))
            {
                AdicionaQuantidadeHandler(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = returnViewModel() });
            }
            else if (e.NewValue < int.Parse(l_quantidade.Text))
            {
                DiminuiQuantidadeHandler(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = returnViewModel() });
            }
        }


        private ProdutoVendaViewModel returnViewModel()
        {
            var viewmodel = this.BindingContext as ProdutoVendaViewModel;
            return viewmodel;
        }
    }
}
