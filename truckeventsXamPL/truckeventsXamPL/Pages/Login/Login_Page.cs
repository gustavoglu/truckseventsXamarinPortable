using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Pages.Eventos;
using truckeventsXamPL.Pages.Vendas;
using truckeventsXamPL.Util;
using truckeventsXamPL.WS;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Login
{
    public class Login_Page : ContentPage
    {
        #region Layout

        StackLayout sp_principal;
        Entry e_email;
        Entry e_senha;
        Label l_email;
        Label l_senha;
        Button b_confirmar;
        Image img_logo;
        ActivityIndicator indicator;
        #endregion

        public Login_Page()
        {

            #region Layout

            NavigationPage.SetHasNavigationBar(this, false);

            img_logo = new Image { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand, Source = ImageSource.FromResource("truckeventsXamPL.Img.logo1x.png") };
            e_email = new Entry { Text = "loja4", WidthRequest = 200, Placeholder = "E-mail", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = Color.White };
            e_senha = new Entry { Text = "l123456", Placeholder = "Senha", WidthRequest = 200, IsPassword = true, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = Color.White };
            l_email = new Label { Text = "E-mail", WidthRequest = 200, HorizontalTextAlignment = TextAlignment.Start, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = Color.White };
            l_senha = new Label { Text = "Senha", WidthRequest = 200, HorizontalTextAlignment = TextAlignment.Start, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = Color.White };
            b_confirmar = new Button { Text = "Login", WidthRequest = 200, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Constantes.ROXOPADRAO, TextColor = Color.White };
            indicator = new ActivityIndicator() { Color = Constantes.ROXOPADRAO, IsRunning = false, IsVisible = false };

            #endregion

            b_confirmar.Clicked += B_confirmar_Clicked;

            sp_principal = new StackLayout() { BackgroundColor = Color.Transparent, Padding = Constantes.PADDINGDEFAULT, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Children = { img_logo, l_email, e_email, l_senha, e_senha, b_confirmar, indicator } };
            this.Content = sp_principal;
            this.BackgroundColor = Constantes.VERMELHOPADRAO;

        }

        private async void B_confirmar_Clicked(object sender, EventArgs e)
        {
            DisableViews();

            await Login();

            enableViews();
            //Utilidades.EnableControlButton(b_confirmar, true);

            //Utilidades.IndicatorControl(ref indicator, false);
        }

        private async Task Login()
        {
            object result = null;
            await Task.Factory.StartNew(async () =>
            {
                result = await WSOpen.GetLogin(new Models.Login() { Email = e_email.Text, Senha = e_senha.Text });
            });

            if (result.GetType() == typeof(string))
            {
                await DisplayAlert("", (string)result, "Ok");
                return;
            }

            Constantes.Token = (Token)result;
            await App.Nav.Navigation.PushAsync(new Eventos_Page(Constantes.Token.EventoPrincipal));
        }


        private void enableViews()
        {
            Utilidades.EnableControlButton(b_confirmar, true);
            Utilidades.IndicatorControl(ref indicator, false);
        }

        private void DisableViews()
        {
            Utilidades.EnableControlButton(b_confirmar, false);
            Utilidades.IndicatorControl(ref indicator, true);
        }
    }
}

