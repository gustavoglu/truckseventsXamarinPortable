using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Registro
{
    public class RegistroEscolha_Page : ContentPage
    {
        #region Layout

        StackLayout sl_principal;
        Grid grid_organizador;
        Grid grid_loja;
        Image img_organizador;
        Image img_loja;
        Label l_organizador;
        Label l_loja;

        #endregion

        TapGestureRecognizer click_GridOrganizador;
        TapGestureRecognizer click_GridLoja;
        public RegistroEscolha_Page()
        {
            #region Layout

            grid_organizador = new Grid();
            grid_loja = new Grid();
            img_organizador = new Image();
            img_loja = new Image();
            l_organizador = new Label() { Text = "Organizador", HorizontalOptions = LayoutOptions.Center };
            l_loja = new Label() { Text = "Loja", HorizontalOptions = LayoutOptions.Center };
            click_GridOrganizador = new TapGestureRecognizer();
            click_GridOrganizador.Tapped += Click_GridOrganizador_Tapped;
            click_GridLoja = new TapGestureRecognizer();
            click_GridLoja.Tapped += Click_GridLoja_Tapped;



            //Configura views nos Grids
            //grid_organizador.Children.Add(Util.Constantes.ICON_ORGANIZADOR, 0, 0);
            grid_organizador.Children.Add(l_organizador);
            //grid_loja.Children.Add(Util.Constantes.ICON_LOJA, 0, 0);
            grid_loja.Children.Add(l_loja);

            #endregion

            //Adiciona Click nos Grids
            grid_organizador.GestureRecognizers.Add(click_GridOrganizador);
            grid_loja.GestureRecognizers.Add(click_GridLoja);

            sl_principal = new StackLayout() {Padding = Util.Constantes.PADDINGDEFAULT, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Children = { grid_organizador, grid_loja } };

            this.Content = sl_principal;
        }

        private void Click_GridLoja_Tapped(object sender, EventArgs e)
        {
            App.Nav.Navigation.PushAsync(new Registro_Page());
           // throw new NotImplementedException();
        }

        private void Click_GridOrganizador_Tapped(object sender, EventArgs e)
        {
            App.Nav.Navigation.PushAsync(new Registro_Page());
        }
    }
}
