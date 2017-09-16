using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Eventos
{
    public class Eventos_Page : ContentPage
    {

        #region Layout

        StackLayout sl_principal;
        Label l_totalVendas;
        Label l_totalVendas_h;
        Loading_Layout loading;
        #endregion

        ObservableCollection<Evento> Eventos;
        Evento _evento;
        public Eventos_Page(Evento evento)
        {
            _evento = evento;

            this.Title = $"Evento {_evento.Descricao}";
            #region Layout
            l_totalVendas_h = new Label { Text = "Total Vendas", HorizontalOptions = LayoutOptions.Center };
            l_totalVendas = new Label { Text = "0", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            l_totalVendas.FontSize = Device.GetNamedSize(NamedSize.Large, l_totalVendas);
            l_totalVendas_h.FontSize = Device.GetNamedSize(NamedSize.Medium, l_totalVendas);

            #endregion

            loading = new Loading_Layout();

            Eventos = new ObservableCollection<Evento>();


            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { l_totalVendas_h, l_totalVendas } };

            this.Content = sl_principal;

            GetTotalVendas();

        }

        private async void ListV_Eventos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = sender as ListView;

            listView.SelectedItem = null;

            var evento = e.Item as Evento;

            if (evento != null)
            {
                await App.Nav.PushAsync(new Evento_Vendas_Page(evento));
            }
        }


        private async void GetTotalVendas()
        {
            string uri = $"{Constantes.WS_VENDAS}/Total/Loja/{Constantes.Token.Id_usuario}/Evento/{_evento.Id}";
            var result = await WSOpen.Get(uri);
            if (result.GetType() == typeof(string)) { await DisplayAlert("Erro", (string)result, "Ok"); }
            double total = 0;
            if (double.TryParse(result.ToString(), out total)) l_totalVendas.Text = total.ToString("#.##");//total.ToString(); 
           // await TotalAnimacao(500.00);
        }

        private async Task TotalAnimacao(double total)
        {
            double numeracao = 0.00;
            while (numeracao < total)
            {
                l_totalVendas.Text = numeracao.ToString("#.##");
                numeracao = numeracao + 0.01 ;
                await Task.Delay(1);
            }

        }

        private async void GetEventos()
        {
            //List<Evento> eventos = null;

            //this.loading.Enable(this);

            //await Task.Factory.StartNew(async () =>
            //{
            //    eventos = await WSOpen.Get<List<Evento>>(Constantes.WS_EVENTOS);
            //});

            //if (eventos != null && eventos.Count > 0)
            //{
            //    this.listV_Eventos.ItemsSource = eventos;
            //}

            //this.loading.Disable(this, sl_principal);
        }
    }
}
