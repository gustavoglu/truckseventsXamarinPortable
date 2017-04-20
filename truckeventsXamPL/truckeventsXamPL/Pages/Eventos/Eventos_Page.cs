using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
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

        }

        private void ListV_Eventos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
