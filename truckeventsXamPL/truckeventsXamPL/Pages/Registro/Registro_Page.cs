using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.Pages.Registro
{
    public class Registro_Page : ContentPage
    {
        #region Layout

        StackLayout sl_principal;

        Label l_email;
        Label l_senha;
        Label l_confirmacaoSenha;
        Label l_nome;
        Label l_sobrenome;
        Label l_razaosocial;
        Label l_telefone1;
        Label l_telefone2;
        Label l_documento;

        Entry e_email;
        Entry e_senha;
        Entry e_confirmacaoSenha;
        Entry e_nome;
        Entry e_sobrenome;
        Entry e_razaosocial;
        Entry e_telefone1;
        Entry e_telefone2;
        Entry e_documento;

        Button b_registrar;

        #endregion

        public Registro_Page()
        {

            #region Layout
            l_email = new Label() { Text = "E-mail", HorizontalOptions = LayoutOptions.Start };
            l_senha = new Label() { Text = "Senha", HorizontalOptions = LayoutOptions.Start };
            l_confirmacaoSenha = new Label() { Text = "Confirmação da Senha", HorizontalOptions = LayoutOptions.Start };
            l_nome = new Label() { Text = "Nome", HorizontalOptions = LayoutOptions.Start };
            l_sobrenome = new Label() { Text = "Sobrenome", HorizontalOptions = LayoutOptions.Start };
            l_razaosocial = new Label() { Text = "Razão Social", HorizontalOptions = LayoutOptions.Start };
            l_telefone1 = new Label() { Text = "Telefone Principal", HorizontalOptions = LayoutOptions.Start };
            l_telefone2 = new Label() { Text = "Telefone Opcional ", HorizontalOptions = LayoutOptions.Start };
            l_documento = new Label() { Text = "Documento(CPF ou CNPJ)", HorizontalOptions = LayoutOptions.Start };

            e_email = new Entry() { Keyboard = Keyboard.Email };
            e_senha = new Entry() { IsPassword = true };
            e_confirmacaoSenha = new Entry() { IsPassword = true };
            e_nome = new Entry(); ;
            e_sobrenome = new Entry();
            e_razaosocial = new Entry();
            e_telefone1 = new Entry() { Keyboard = Keyboard.Telephone };
            e_telefone2 = new Entry() { Keyboard = Keyboard.Telephone };
            e_documento = new Entry() { };

            b_registrar = new Button() { Text = "Registrar", VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.End };

            #endregion

            b_registrar.Clicked += B_registrar_Clicked;

            sl_principal = new StackLayout()
            {
                Padding = Util.Constantes.PADDINGDEFAULT,
                Children =
                {
                    l_email
                    ,e_email
                    ,l_senha
                    ,e_senha
                    ,l_confirmacaoSenha
                    ,e_confirmacaoSenha
                    ,l_nome
                    ,e_nome
                    ,l_sobrenome
                    ,e_sobrenome
                    ,l_razaosocial
                    ,e_razaosocial
                    ,l_telefone1
                    ,e_telefone1
                    ,l_telefone2
                    ,e_telefone2
                    ,l_documento
                    ,e_documento
                    ,b_registrar
                }
            };

            this.Content = sl_principal;

        }

        private void B_registrar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("", "Clique", "Ok");
        }
    }
}
