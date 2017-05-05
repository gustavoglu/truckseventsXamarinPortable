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
        ToolbarItem toolbar_Produtos;
        ToolbarItem toolbar_Usuarios;


        #endregion

        ObservableCollection<Evento> Eventos;

        public Eventos_Page()
        {

            #region Layout
            listV_Eventos = new ListView();
            listV_Eventos.ItemTemplate = new DataTemplate(typeof(VCell_Eventos));
            listV_Eventos.ItemsSource = Eventos;


            toolbar_Produtos = new ToolbarItem("Produtos","",()=> { });
            toolbar_Usuarios = new ToolbarItem("Usuarios", "", () => { });
            #endregion

            Eventos = new ObservableCollection<Evento>();

            listV_Eventos.ItemTapped += ListV_Eventos_ItemTapped;

            sl_principal = new StackLayout() {Padding = Constantes.PADDINGDEFAULT, Children = { listV_Eventos } };
            this.ToolbarItems.Add(toolbar_Produtos);
            this.ToolbarItems.Add(toolbar_Usuarios);
            this.Content = sl_principal;


            GetEventos();


        }

        private void ListV_Eventos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var evento = e.Item as Evento;
            if (evento != null)
            {
                App.Nav.PushAsync(new Evento_Vendas_Page(evento));
            }
        }


        private async void GetEventos()
        {
            var eventos = await WSOpen.Get<List<Evento>>(Constantes.WS_EVENTOS);
            if (eventos != null && eventos.Count > 0)
            {
                this.listV_Eventos.ItemsSource = eventos;
            }
        }
    }
}
