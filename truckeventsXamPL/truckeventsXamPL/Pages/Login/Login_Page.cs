using System;
using truckeventsXamPL.Pages.Eventos;
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

        #endregion

        public Login_Page()
        {

            #region Layout

            NavigationPage.SetHasNavigationBar(this, false);

            img_logo = new Image { VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
            e_email = new Entry { Text = "giancarlo_fernandesreis@hotmail.com", WidthRequest= 200 , Placeholder = "E-mail", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            e_senha = new Entry { Text = "admin123*", Placeholder = "Senha",  WidthRequest = 200, IsPassword = true, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            l_email = new Label { Text = "E-mail", WidthRequest = 200, HorizontalTextAlignment = TextAlignment.Start, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            l_senha = new Label { Text = "Senha", WidthRequest = 200, HorizontalTextAlignment = TextAlignment.Start, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            b_confirmar = new Button { Text = "Login", WidthRequest = 200, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

            #endregion



            b_confirmar.Clicked += B_confirmar_Clicked;

            sp_principal = new StackLayout() { Padding = Constantes.PaddingDefault, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Children = { img_logo, l_email, e_email, l_senha, e_senha, b_confirmar } };
            this.Content = sp_principal;


        }

        private async void B_confirmar_Clicked(object sender, EventArgs e)
        {
            var token = await WSOpen.GetLogin(new Models.Login() { UserName = e_email.Text, Password = e_senha.Text });

            if (token != null)
            {
                Constantes.Token = token;
               await App.Nav.Navigation.PushAsync(new Eventos_Page());

            }
            else
            {
                await DisplayAlert("", "Erro", "Ok");
            }

        }
    }
}

