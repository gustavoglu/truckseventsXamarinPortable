﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewlCells;
using truckeventsXamPL.ViewModels;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    public class Nova_Venda_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_total;

        Loading_Layout loading;
        ListView listV_produtos;
        Label l_total;
        Label l_total_h;
        ObservableCollection<ProdutoVendaViewModel> ProdutosVendaViewModel;
        ToolbarItem toolbar_finalizar;
        ToolbarItem toolbar_cancelar;

        Venda _venda;
        Evento _evento;
        public Nova_Venda_Page(Venda venda, Evento evento)
        {
            this._venda = venda;
            this._evento = evento;

            this.Title = "Nova Venda";

            VCell_Venda_Produto.AdicionaQuantidadeHandler += VCell_Venda_Produto_AdicionaQuantidadeHandler;
            VCell_Venda_Produto.DiminuiQuantidadeHandler += VCell_Venda_Produto_DiminuiQuantidadeHandler;

            loading = new Loading_Layout();
            ProdutosVendaViewModel = new ObservableCollection<ProdutoVendaViewModel>();
            l_total = new Label() { Text = "Total R$ 0 ", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.White, FontAttributes = FontAttributes.Bold };

            listV_produtos = new ListView() { Margin = 5 };
            listV_produtos.ItemsSource = ProdutosVendaViewModel;
            listV_produtos.ItemTapped += ListV_produtos_ItemTapped;
            listV_produtos.ItemTemplate = new DataTemplate(typeof(VCell_Venda_Produto));


            sl_hori_total = new StackLayout() { Padding = 5, BackgroundColor = Color.ForestGreen, Orientation = StackOrientation.Horizontal, Children = {  l_total } };

            toolbar_finalizar = new ToolbarItem("Finalizar", "", Finalizar, ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);
            sl_principal = new StackLayout()
            {

                Children =
                {
                     sl_hori_total,
                    listV_produtos

                }
            };
            this.ToolbarItems.Add(toolbar_cancelar);
            this.ToolbarItems.Add(toolbar_finalizar);
            this.Content = sl_principal;

            populaProdutos();
        }

        private async void Cancelar()
        {
            var resultado = await Utilidades.DialogReturn("Deseja cancelar esta venda?");
            if (resultado)
            {
                Utilidades.removeDaStackPaginaAtualNavigation(App.Nav);
            }

        }

        private void Finalizar()
        {
            double totalvenda = double.Parse(l_total.Text.Replace("Total R$ ", ""));
            _venda.TotalVenda = totalvenda;

            var produtosEscolhidos = ProdutosVendaViewModel.Where(vm => vm.Quantidade > 0);

            List<Venda_Produto> venda_produtos = new List<Venda_Produto>();

            foreach (var produtovendaviewmodel in produtosEscolhidos)
            {
                venda_produtos.Add(new Venda_Produto() { Id_Venda = _venda.Id, Produto = produtovendaviewmodel._produto, Id_produto = produtovendaviewmodel.Id_produto, Quantidade = produtovendaviewmodel.Quantidade, Total = produtovendaviewmodel.Total });
            }

            //if (ValidacaoFinalizacaoVenda(_venda))
            //{
            _venda.Venda_Produtos = venda_produtos;
            App.Nav.Navigation.PushAsync(new Resumo_Venda_Page(_venda, _evento));
            //}
            //else
            //{
            //    Utilidades.DialogMessage(Constantes.ERRO_VENDASEMPRODUTOS);
            //}


        }

        private bool ValidacaoFinalizacaoVenda(Venda venda)
        {
            var totalVenda = venda.TotalVenda;
            var countVenda_Produtos = venda.Venda_Produtos == null ? 0 : venda.Venda_Produtos.Count;
            if (totalVenda > 0 && countVenda_Produtos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ListV_produtos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listview = sender as ListView;
            listview.SelectedItem = null;

        }

        private void VCell_Venda_Produto_DiminuiQuantidadeHandler(object sender, Events.AlteraQuantidadeProdutoArgs e)
        {
            CalculaTotais();
        }

        private void VCell_Venda_Produto_AdicionaQuantidadeHandler(object sender, Events.AlteraQuantidadeProdutoArgs e)
        {
            CalculaTotais();
        }

        private async void populaProdutos()
        {
            List<Produto> produtos = null;

            loading.Enable(this);

            await Task.Factory.StartNew(async () =>
            {
               // produtos = await WSOpen.Get<List<Produto>>(Constantes.WS_PRODUTOS);
            });

            if (produtos != null && produtos.Count > 0)
            {
                foreach (var produto in produtos)
                {
                    ProdutosVendaViewModel.Add(new ProdutoVendaViewModel(produto));
                }
            }

            loading.Disable(this, sl_principal);
        }

        private void CalculaTotais()
        {
            double total = ProdutosVendaViewModel.Where(vm => vm.Quantidade > 0).Sum(vm => vm.Total);
            l_total.Text = string.Format("Total R$ {0}", total);
        }
    }
}
