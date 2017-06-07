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

        public Resumo_Venda_Page(Venda venda, Evento _evento)
        {
            this._venda = venda;
            this._evento = _evento;
            this._venda_pagamento = new Venda_Pagamento();

            l_totalVenda_h = new Label() { Text = "Total Venda: " };
            l_totalVenda = new Label() { Text = string.Format("R$ {0}", venda.TotalVenda) };
            e_troco = new Entry() { Keyboard = Keyboard.Numeric };
            l_troco = new Label() { Text = "Troco:" };
            l_trocoResultado = new Label() { Text = "0" };
            l_nomeCliente = new Label() { Text = "Nome Cliente:", HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_nomeCliente = new Entry() { Placeholder = "ex: Pedro", HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_codigoFicha = new Label() { Text = "Cód. Ficha Pagamento: ", HorizontalTextAlignment = TextAlignment.Center };
            e_codigoFicha = new Entry() { Placeholder = "00000", Keyboard = Keyboard.Numeric };
            b_adicionarFicha = new Button() { Text = "Adicionar" };

            fichasValor = new ObservableCollection<FichaValorViewModel>();

            listV_venda_pagamento_fichas = new ListView();
            listV_venda_pagamento_fichas.ItemTemplate = new DataTemplate(typeof(VCell_Fichas));
            listV_venda_pagamento_fichas.ItemsSource = fichasValor;
            listV_venda_pagamento_fichas.ItemTapped += ListV_venda_pagamento_fichas_ItemTapped;

            listV_produtosEscolhidos = new ListView();
            listV_produtosEscolhidos.ItemTemplate = new DataTemplate(typeof(VCell_Resumo_Venda));
            listV_produtosEscolhidos.ItemsSource = from venda_produto in _venda.Venda_Produtos
                                                   select new { Descricao = venda_produto.Produto.Descricao, Quantidade = venda_produto.Quantidade, Total = venda_produto.Total } ;

            toolbar_confirmar = new ToolbarItem("Confirmar", "", Confirmar, ToolbarItemOrder.Default);
            toolbar_cancelar = new ToolbarItem("Cancelar", "", Cancelar, ToolbarItemOrder.Default);

            sl_hori_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_codigoFicha, e_codigoFicha, b_adicionarFicha } };
            sl_hori_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_totalVenda_h, l_totalVenda } };
            sl_hori_3 = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Children = { l_troco, e_troco, l_trocoResultado } };

            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { sl_hori_2, listV_produtosEscolhidos, sl_hori_1, listV_venda_pagamento_fichas } };

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
            ValidaCampoFicha(codigoFicha);

            Ficha ficha = null;
            ficha = await getFicha(codigoFicha);

            if (ficha != null)
            {
                if (fichasValor.ToList().Exists(f => f._venda_Pagamento_Ficha.Ficha.Codigo == ficha.Codigo))
                {
                    Utilidades.DialogMessage("Esta Ficha ja foi adicionada a lista de pagamentos! ");
                }
                else
                {
                    fichasValor.Add(new FichaValorViewModel(new Venda_Pagamento_Ficha() { Id_Ficha = ficha.Id , Ficha = ficha}));
                }
            }

        }

        private void Cancelar()
        {
            Utilidades.removeDaStackPaginaAtualNavigation(App.Nav);
        }

        private async void Confirmar()
        {

            AdicionaVenda_Pagamento_Fichas(_venda);

            var validacao = await ValidaVenda();
            if (validacao)
            {
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
            var ficha = await WSOpen.Get<Ficha>(string.Format("{0}?id_evento={1}&codigo={2}", Constantes.WS_FICHAS, _evento.Id, codigo));

            if (ficha == null)
            {
                Utilidades.DialogMessage("Esta ficha não existe");
            }

            if (!(ficha.Saldo > 0))
            {
                Utilidades.DialogMessage("Esta ficha não tem saldo");
            }

            return ficha ?? null;

        }

        private void ValidaCampoFicha(string textCampoFicha)
        {
            if (textCampoFicha == null)
            {
                Utilidades.DialogMessage("Campo do código da ficha vázio");
            }
            if (textCampoFicha == "")
            {
                Utilidades.DialogMessage("Campo do código da ficha vázio");
            }

        }

        private async Task<bool> ValidaVenda()
        {

            var fichas = from fichaValor in fichasValor
                         select fichaValor._venda_Pagamento_Ficha.Ficha;

            double valorTotalVenda = _venda.TotalVenda.Value;
            double valorTotalFichas = 0;
            var countFichas = fichas.ToList().Count;

            if (!(countFichas > 0))
            {
                Utilidades.DialogMessage("Nenhuma Ficha informada como pagamento");
                return false;
            }
            else
            {
                valorTotalFichas = fichas.Sum(f => f.Saldo).Value;
                if (valorTotalFichas < valorTotalVenda)
                {
                    Utilidades.DialogMessage(string.Format("Não existe saldo o suficiente na(s) Ficha(s) Informada(s) para esta Venda, \n Saldo Total Fichas: {0} \n Valor Total Venda: {1}", valorTotalFichas, valorTotalVenda));
                    return false;
                }

                return true;
            }

        }

        private void AdicionaVenda_Pagamento_Fichas(Venda venda)
        {
            _venda_pagamento = new Venda_Pagamento();

            foreach (var venda_Pagamento_Ficha in fichasValor)
            {
                _venda_pagamento.Venda_Pagamento_Fichas.Add(venda_Pagamento_Ficha._venda_Pagamento_Ficha);
            }

            venda.Venda_Pagamentos.Add(this._venda_pagamento);
        }
    }
}
