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
        Frame frame;


        #endregion

        public VCell_Eventos()
        {

            frame = new Frame() {  HasShadow = true, OutlineColor = Constantes.ROXOPADRAO};

            l_descricaoEvento = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand , TextColor = Constantes.ROXOPADRAO};

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
