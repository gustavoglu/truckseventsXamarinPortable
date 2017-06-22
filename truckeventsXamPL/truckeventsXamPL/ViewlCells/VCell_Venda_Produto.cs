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
        StackLayout sl_lado_hori_A;
        StackLayout sl_lado_ver_A;
        StackLayout sl_lado_ver_B;
        StackLayout sl_lado_B;
        BoxView box_corProduto;
        Label l_nomeProduto;
        Label l_valor;
        Label l_totalValor;
        Label l_quantidade;
        Stepper st_quantidade;
        TapGestureRecognizer clickBackground;
        Button b_diminuir;

        public delegate void AdicionaQuantidade(object sender, AlteraQuantidadeProdutoArgs e);
        public static event AdicionaQuantidade AdicionaQuantidadeHandler;
        public delegate void DiminuiQuantidade(object sender, AlteraQuantidadeProdutoArgs e);
        public static event DiminuiQuantidade DiminuiQuantidadeHandler;


        public VCell_Venda_Produto()
        {
            box_corProduto = new BoxView() { };
            l_nomeProduto = new Label() { VerticalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Bold };
            l_valor = new Label() { VerticalTextAlignment = TextAlignment.Center };
            l_totalValor = new Label() { VerticalTextAlignment = TextAlignment.Center , HorizontalOptions = LayoutOptions.End };
            l_quantidade = new Label() { VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.EndAndExpand};
            b_diminuir = new Button() { BackgroundColor = Color.Transparent, TextColor = Color.IndianRed, Text = "Remover" , HorizontalOptions = LayoutOptions.EndAndExpand};
            st_quantidade = new Stepper() {  HorizontalOptions = LayoutOptions.EndAndExpand };

            clickBackground = new TapGestureRecognizer();
            clickBackground.Tapped += ClickBackground_Tapped;

            l_quantidade.GestureRecognizers.Add(clickBackground);

            box_corProduto.SetBinding(BoxView.ColorProperty, "CorProduto");
            l_nomeProduto.SetBinding(Label.TextProperty, "Descricao");
            l_valor.SetBinding(Label.TextProperty, "Valor", stringFormat: "R${0}");
            l_totalValor.SetBinding(Label.TextProperty, "Total", stringFormat: "Total R${0}");
            l_quantidade.SetBinding(Label.TextProperty, "Quantidade", stringFormat: "Qtd {0}");
            st_quantidade.SetBinding(Stepper.ValueProperty, "Quantidade");

            st_quantidade.ValueChanged += St_quantidade_ValueChanged;

            b_diminuir.Clicked += B_diminuir_Clicked;


            sl_lado_hori_A = new StackLayout() { Orientation = StackOrientation.Horizontal, Children = { box_corProduto, l_nomeProduto, l_valor } };

            sl_principal = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                  sl_lado_hori_A,
                  l_quantidade,
                  b_diminuir
                }
            };

            sl_principal.SetBinding(StackLayout.BackgroundColorProperty, "CorBackground");
            sl_lado_hori_A.GestureRecognizers.Add(clickBackground);

            this.View = sl_principal;


        }

        private void B_diminuir_Clicked(object sender, EventArgs e)
        {
            var produtoViewModel = returnViewModel();

            if (produtoViewModel.Quantidade > 0)
            {
                produtoViewModel.Quantidade--;
                AdicionaQuantidadeHandler?.Invoke(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = produtoViewModel });
            }
           
        }

        private void ClickBackground_Tapped(object sender, EventArgs e)
        {
            var produtoviewmodel = returnViewModel();
            produtoviewmodel.Quantidade++;
            AdicionaQuantidadeHandler?.Invoke(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = produtoviewmodel });
        }

        private void St_quantidade_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var produtoviewmodel = returnViewModel();

            if (e.NewValue > e.OldValue)
            {
                AdicionaQuantidadeHandler?.Invoke(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = produtoviewmodel });
            }
            else if (e.NewValue < e.OldValue)
            {
                DiminuiQuantidadeHandler?.Invoke(this, new AlteraQuantidadeProdutoArgs() { ProdutoVendaViewModel = produtoviewmodel });
            }
        }


        private ProdutoVendaViewModel returnViewModel()
        {
            var viewmodel = this.BindingContext as ProdutoVendaViewModel;
            return viewmodel;
        }
    }
}
