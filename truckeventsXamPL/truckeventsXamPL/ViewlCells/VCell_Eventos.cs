using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
    public class VCell_Eventos : ViewCell
    {
        #region Layout

        StackLayout sl_principal;
        Label l_descricaoEvento;
        Label l_dataEvento;
        Frame frame;


        #endregion

        public VCell_Eventos()
        {

            frame = new Frame() {  HasShadow = true, BackgroundColor = Constantes.ROXOPADRAO , Margin = 5};

            l_descricaoEvento = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.White};
            l_dataEvento = new Label() { HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.White };
            l_descricaoEvento.SetBinding(Label.TextProperty, "Descricao");


            sl_principal = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    l_descricaoEvento
                }
            };

            frame.Content = sl_principal;

            this.View = frame;
        }
    }
}
