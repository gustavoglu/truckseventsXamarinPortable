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
        #region Layout

        StackLayout sl_principal;
        StackLayout sl_total;
        ToolbarItem toolbar_novaVenda;
        Label l_tituloVendas;
        Label l_totalVendas;

        #endregion

        Evento _evento;

        public Evento_Vendas_Page(Evento evento)
        {
            this._evento = evento;

            #region Layout

            this.Title = string.Format(evento.Descricao);
            l_tituloVendas = new Label() { Text = "Total Vendas", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            l_totalVendas = new Label() { Text = "R$ 0", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            l_tituloVendas.FontSize = Device.GetNamedSize(NamedSize.Medium, l_tituloVendas);
            l_totalVendas.FontSize = Device.GetNamedSize(NamedSize.Large, l_totalVendas);
            sl_total = new StackLayout() { Children = { l_tituloVendas, l_totalVendas }, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            toolbar_novaVenda = new ToolbarItem("Nova Venda", "", NovaVenda, ToolbarItemOrder.Default);
            sl_principal = new StackLayout() { Children = { sl_total } };
            this.ToolbarItems.Add(toolbar_novaVenda);
            this.Content = sl_principal;

            #endregion

            GetTotalVendas();
        }

        private void NovaVenda()
        {
            App.Nav.Navigation.PushAsync(new Nova_Venda_Page(new Venda() { Id_Evento = _evento.Id.Value }, _evento));
        }

        private async Task TotalAnimacao(double total)
        {
            if (total == 0) return;
            double numeracao = 0.00;
            double soma = 0.01;
            while (numeracao < total)
            {
                l_totalVendas.Text = $"R$ {numeracao.ToString("#.##")}";
                numeracao = numeracao + soma;
                if (numeracao > total) { l_totalVendas.Text = $"R$ {total.ToString("#.##")}"; break; }
                soma = soma * 1.3;
                await Task.Delay(20);
            }

        }

        private async void GetTotalVendas()
        {
            string uri = $"{Constantes.WS_VENDAS}/Total/Loja/{Constantes.Token.Id_usuario}/Evento/{_evento.Id}";
            var result = await WSOpen.Get<double>(uri);
            if (result.GetType() == typeof(string)) { await DisplayAlert("Erro", (string)result, "Ok"); }
            double total = 0;
            if (double.TryParse(result.ToString(), out total)) await TotalAnimacao(total);
        }
    }
}
