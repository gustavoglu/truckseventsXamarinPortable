using System;
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

        ListView listV_produtos;
        Label l_total;
        Label l_total_h;
        ObservableCollection<ProdutoVendaViewModel> ProdutosVendaViewModel;
        ToolbarItem toolbar_finalizar;
        ToolbarItem toolbar_cancelar;

        Venda _venda;

        public Nova_Venda_Page(Venda venda)
        {
            this._venda = venda;

            VCell_Venda_Produto.AdicionaQuantidadeHandler += VCell_Venda_Produto_AdicionaQuantidadeHandler;
            VCell_Venda_Produto.DiminuiQuantidadeHandler += VCell_Venda_Produto_DiminuiQuantidadeHandler;

            ProdutosVendaViewModel = new ObservableCollection<ProdutoVendaViewModel>();
            l_total = new Label() { HorizontalOptions = LayoutOptions.End };
            l_total_h = new Label() { Text = "Total", HorizontalOptions = LayoutOptions.End };
          
            listV_produtos = new ListView();
            listV_produtos.ItemsSource = ProdutosVendaViewModel;
            listV_produtos.ItemTapped += ListV_produtos_ItemTapped;
            listV_produtos.ItemTemplate = new DataTemplate(typeof(VCell_Venda_Produto));


            sl_hori_total = new StackLayout() { Children = { l_total_h,l_total } };

            toolbar_finalizar = new ToolbarItem("Finalizar","",Finalizar,ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);
            sl_principal = new StackLayout()
            {
                Padding = Constantes.PADDINGDEFAULT,
                Children =
                {
                    listV_produtos,
                    sl_hori_total
                }
            };
            this.ToolbarItems.Add(toolbar_cancelar);
            this.ToolbarItems.Add(toolbar_finalizar);
            this.Content = sl_principal;

            populaProdutos();
        }

        private void Cancelar()
        {

        }

        private void Finalizar()
        {
            double totalvenda = double.Parse(l_total.Text);
            var produtosEscolhidos = ProdutosVendaViewModel.Where(vm => vm.Quantidade > 0);
            List<Venda_Produto> venda_produtos = new List<Venda_Produto>();
            foreach (var produtovendaviewmodel in produtosEscolhidos)
            {
                venda_produtos.Add(new Venda_Produto() {Id_Venda = _venda.Id ,Id_produto = produtovendaviewmodel.Id_produto });
            }

            _venda.Venda_Produtos = venda_produtos;

            App.Nav.Navigation.PushModalAsync(new Resumo_Venda_Page(_venda));

        }

        private async void ValidacaoFinalizacao()
        {

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
            var produtos = await WSOpen.Get<List<Produto>>(Constantes.WS_PRODUTOS);
           
            if (produtos != null && produtos.Count > 0)
            {
                foreach (var produto in produtos)
                {
                    ProdutosVendaViewModel.Add(new ProdutoVendaViewModel(produto));
                }
            }
        }

        private void CalculaTotais()
        {
            double total = ProdutosVendaViewModel.Where(vm => vm.Quantidade > 0).Sum(vm => vm.Total);
            l_total.Text = total.ToString();
        }
    }
}
