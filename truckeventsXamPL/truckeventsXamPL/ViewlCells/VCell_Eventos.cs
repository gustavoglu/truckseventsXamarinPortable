using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
    public class VCell_Eventos : ViewCell
    {
        #region Layout

        StackLayout sl_principal;
        Label l_descricaoEvento;


        #endregion

        public VCell_Eventos()
        {
            l_descricaoEvento = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand };

            l_descricaoEvento.SetBinding(Label.TextProperty, "Descricao");


            sl_principal = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    l_descricaoEvento
                }
            };

            this.View = sl_principal;
        }
    }
}
