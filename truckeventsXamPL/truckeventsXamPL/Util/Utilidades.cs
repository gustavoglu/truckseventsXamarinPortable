using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.Util
{
    public class Utilidades
    {
        public static void removeDaStackPaginaAtualNavigation(NavigationPage navigationPage)
        {
            var count = navigationPage.Navigation.NavigationStack.Count;
            var paginaAtual = navigationPage.Navigation.NavigationStack[count];
            navigationPage.Navigation.NavigationStack.ToList().Remove(paginaAtual);
        }

        public static async Task<bool> DialogReturn(string mensagem)
        {
            return await App.Current.MainPage.DisplayAlert("Atenção", mensagem, "Sim", "Não");
        }

        public static async void DialogMessage(string mensagem)
        {
             await App.Current.MainPage.DisplayAlert("Atenção", mensagem, "Ok");
        }

        public static async void DialogErrorMessage(string mensagem)
        {
            await App.Current.MainPage.DisplayAlert("Erro", mensagem, "Ok");
        }

        public static async void DialogErrorRestMessage(string mensagem)
        {
            mensagem = mensagem.Replace("message:", "");
            await App.Current.MainPage.DisplayAlert("Erro", mensagem, "Ok");
        }
    }
}
