using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewlCells;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Eventos
{
    public class Eventos_Page : ContentPage
    {

        #region Layout

        StackLayout sl_principal;
        ListView listV_Eventos;
        Loading_Layout loading;

        #endregion

        ObservableCollection<Evento> Eventos;

        public Eventos_Page()
        {
            this.Title = "Meus Eventos";

            #region Layout
            listV_Eventos = new ListView() { HasUnevenRows = true, SeparatorVisibility = SeparatorVisibility.None };
            listV_Eventos.ItemTemplate = new DataTemplate(typeof(VCell_Eventos));
            listV_Eventos.ItemsSource = Eventos;


            #endregion

            loading = new Loading_Layout();

            Eventos = new ObservableCollection<Evento>();

            listV_Eventos.ItemTapped += ListV_Eventos_ItemTapped;

            sl_principal = new StackLayout() { Padding = Constantes.PADDINGDEFAULT, Children = { listV_Eventos } };

            this.Content = sl_principal;


            GetEventos();


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


        private async void GetEventos()
        {
            List<Evento> eventos = null;

            this.loading.Enable(this);

            await Task.Factory.StartNew(async () =>
            {
                eventos = await WSOpen.Get<List<Evento>>(Constantes.WS_EVENTOS);
            });

            if (eventos != null && eventos.Count > 0)
            {
                this.listV_Eventos.ItemsSource = eventos;
            }

            this.loading.Disable(this, sl_principal);
        }
    }
}
