using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Pages.Eventos;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewlCells;
using truckeventsXamPL.ViewModels;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Vendas
{
    public class Resumo_Venda_Page : ContentPage
    {
        StackLayout sl_principal;
        StackLayout sl_hori_1;
        StackLayout sl_hori_2;
        StackLayout sl_hori_3;
        ListView listV_produtosEscolhidos;
        ListView listV_venda_pagamento_fichas;
        ObservableCollection<FichaValorViewModel> fichasValor;
        Label l_codigoFicha;
        Label l_totalVenda;
        Label l_totalVenda_h;
        Label l_nomeCliente;
        Label l_troco;
        Label l_trocoResultado;
        Entry e_nomeCliente;
        Entry e_codigoFicha;
        Entry e_troco;
        Button b_adicionarFicha;

        ToolbarItem toolbar_confirmar;
        ToolbarItem toolbar_cancelar;

        Venda _venda;
        Evento _evento;
        Venda_Pagamento _venda_pagamento;
        ActivityIndicator indicator;

        public Resumo_Venda_Page(Venda venda, Evento _evento)
        {
            this._venda = venda;
            this._evento = _evento;
            this._venda_pagamento = new Venda_Pagamento();

            l_totalVenda_h = new Label() { Text = "Total Venda: ", TextColor = Color.ForestGreen, FontAttributes = FontAttributes.Bold };
            l_totalVenda = new Label() { Text = string.Format("R$ {0}", venda.Total), TextColor = Color.ForestGreen, FontAttributes = FontAttributes.Bold };
            e_troco = new Entry() { Keyboard = Keyboard.Numeric };
            l_troco = new Label() { Text = "Troco:" };
            l_trocoResultado = new Label() { Text = "0" };
            l_nomeCliente = new Label() { Text = "Nome Cliente:", HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_nomeCliente = new Entry() { Placeholder = "ex: Pedro", HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_codigoFicha = new Label() { Text = "Cód. Ficha Pagamento: ", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            e_codigoFicha = new Entry() { Placeholder = "00000", Keyboard = Keyboard.Numeric, HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.ForestGreen };
            b_adicionarFicha = new Button() { Text = "Adicionar Ficha", HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.White, BackgroundColor = Color.ForestGreen };
            indicator = new ActivityIndicator() { IsRunning = true, IsVisible = false, Color = Constantes.ROXOPADRAO };
            fichasValor = new ObservableCollection<FichaValorViewModel>();

            listV_venda_pagamento_fichas = new ListView();
            listV_venda_pagamento_fichas.ItemTemplate = new DataTemplate(typeof(VCell_Fichas));
            listV_venda_pagamento_fichas.ItemsSource = fichasValor;
            listV_venda_pagamento_fichas.ItemTapped += ListV_venda_pagamento_fichas_ItemTapped;

            listV_produtosEscolhidos = new ListView() { HasUnevenRows = true, SeparatorColor = Constantes.ROXOESCURO };
            listV_produtosEscolhidos.ItemTemplate = new DataTemplate(typeof(VCell_Resumo_Venda));

            listV_produtosEscolhidos.ItemsSource = from venda_produto in _venda.Venda_Produtos
                                                   select new { Descricao = venda_produto.Produto.Descricao, Quantidade = venda_produto.Quantidade, Total = venda_produto.ValorTotal };

            toolbar_confirmar = new ToolbarItem("Confirmar", "", Confirmar, ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);

            sl_hori_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_codigoFicha, e_codigoFicha, indicator } };
            sl_hori_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_totalVenda_h, l_totalVenda } };
            sl_hori_3 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_troco, e_troco, l_trocoResultado } };

            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { sl_hori_2, listV_produtosEscolhidos, sl_hori_1, b_adicionarFicha, listV_venda_pagamento_fichas } };

            this.ToolbarItems.Add(toolbar_cancelar);
            this.ToolbarItems.Add(toolbar_confirmar);
            this.Content = sl_principal;

            b_adicionarFicha.Clicked += B_adicionarFicha_Clicked;


        }

        private void ListV_venda_pagamento_fichas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var fichaValor = e.Item as FichaValorViewModel;

            PopupNavigation.PushAsync(new Popup_Venda_Ficha_Valor(fichaValor));
        }

        private async void B_adicionarFicha_Clicked(object sender, EventArgs e)
        {
            string codigoFicha = e_codigoFicha.Text;

            if (!ValidaCampoFicha(codigoFicha)) return;

            Ficha ficha = null;

            ficha = await getFicha(codigoFicha);

            if (ficha == null) return;

            if (fichasValor.ToList().Exists(f => f.Pagamento_Ficha.Ficha.Codigo == ficha.Codigo))
            {
                Utilidades.DialogMessage("Esta Ficha ja foi adicionada a lista de pagamentos!");
                return;
            }

            fichasValor.Add(new FichaValorViewModel(new Pagamento_Ficha { Id_ficha = ficha.Id.Value, Ficha = ficha }));
        }


        private void Cancelar()
        {
            Utilidades.removeDaStackPaginaAtualNavigation(App.Nav);
        }

        private async void Confirmar()
        {

            AdicionaPagamento(_venda);

            if (ValidaVenda())
            {
                _venda.Id_Evento = _evento.Id.Value;
                var result = await WSOpen.Post(Constantes.WS_VENDAS, _venda);

                if (result != null)
                {
                    Utilidades.DialogMessage("Venda Realizada");
                    await App.Nav.PushAsync(new Evento_Vendas_Page(_evento));
                }

            }
        }

        private async Task<Ficha> getFicha(string codigo)
        {
            Ficha ficha = null;

            disableFichaViews();

            await Task.Factory.StartNew(async () =>
            {
            //ficha = await WSOpen.Get<Ficha>(string.Format("{0}?id_evento={1}&codigo={2}", Constantes.WS_FICHAS, _evento.Id, codigo));
        });

            if (ficha == null)
            {
                Utilidades.DialogMessage("Esta ficha não existe");
            }

            if (ficha != null && !(ficha.Saldo > 0))
            {
                Utilidades.DialogMessage("Esta ficha não tem saldo");
            }

            enableFichaViews();

            return ficha;

        }

        private void disableFichaViews()
        {
            b_adicionarFicha.IsEnabled = false;
            indicator.IsVisible = true;

        }

        private void enableFichaViews()
        {
            b_adicionarFicha.IsEnabled = true;
            indicator.IsVisible = false;
        }


        private bool ValidaCampoFicha(string textCampoFicha)
        {
            if (textCampoFicha == null || textCampoFicha == string.Empty || textCampoFicha == "")
            {
                Utilidades.DialogMessage("Campo do código da ficha vázio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaVenda()
        {

            var fichas = from fichaValor in fichasValor
                         select fichaValor.Pagamento_Ficha.Ficha;

            // Total Saldo das Fichas
            var valorTotalFichas = fichas.Sum(f => f.Saldo).Value;

            // Total de Valor Pré informado
            var valorTotalInfoFichas = _venda_pagamento.Venda_Pagamento_Fichas.Sum(p => p.ValorInformado);

            double valorTotalVenda = _venda.Total.Value;

            var countFichas = fichas.ToList().Count;

            if (!(countFichas > 0))
            {
                Utilidades.DialogMessage("Nenhuma Ficha informada como pagamento");
                return false;
            }

            //Se não houver saldo suficiente para a venda
            if (valorTotalFichas < valorTotalVenda)
            {
                Utilidades.DialogMessage(string.Format("Não existe saldo suficiente na(s) Ficha(s) Informada(s) para esta Venda, \n Saldo Total Fichas: {0} \n Valor Total Venda: {1}", valorTotalFichas, valorTotalVenda));
                return false;
            }

            //Se valor pré informado for maior que o valor da venda
            if (valorTotalInfoFichas > 0 && valorTotalInfoFichas > valorTotalVenda)
            {
                var fichasComValorInfo = from vendaPagamentoFicha in _venda_pagamento.Venda_Pagamento_Fichas
                                         where vendaPagamentoFicha.ValorInformado > 0
                                         select vendaPagamentoFicha;

                var diferenca = valorTotalInfoFichas - valorTotalVenda;

                string fichasEValores = string.Empty;

                foreach (var fichaComValorInfo in fichasComValorInfo)
                {
                    if (fichasEValores == string.Empty)
                    {
                        fichasEValores = string.Format("\n Ficha Cód:{0} , Valor Informado: {1}", fichaComValorInfo.Ficha.Codigo, fichaComValorInfo.ValorInformado);
                    }
                    else
                    {
                        fichasEValores = fichasEValores + string.Format("\n Ficha Cód:{0} , Valor Informado: {1}", fichaComValorInfo.Ficha.Codigo, fichaComValorInfo.ValorInformado);
                    }
                }

                Utilidades.DialogMessage(string.Format("A Soma dos valores pré-informados nas fichas é maior que o Total da Venda, verificar: \n {0} \n Total Pré-Informado: {1} \n Total Venda: {2} \n Diferença : {3} ", fichasEValores, valorTotalInfoFichas, valorTotalVenda, diferenca));
                return false;
            }

            return true;

        }

        private void AdicionaPagamento(Venda venda)
        {
            Pagamento pagamento = new Pagamento();

            foreach (var pagamento_fichaViewModel in fichasValor)
            {
                pagamento.Pagamento_Fichas.Add(pagamento_fichaViewModel.Pagamento_Ficha);
            }

            venda.Pagamento = pagamento;
        }
    }
}

