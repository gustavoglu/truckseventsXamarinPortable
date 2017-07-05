using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.Util
{
    public class Loading_Layout : StackLayout
    {
        ActivityIndicator indicator;

        public Loading_Layout()
        {

            indicator = new ActivityIndicator() { Color = Constantes.ROXOPADRAO, IsRunning = true, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            this.Children.Add(indicator);
        }

        public void Enable(ContentPage pagina)
        {
            pagina.Content = this;
        }

        public void Disable(ContentPage pagina ,Layout layout)
        {
            pagina.Content = layout;
        }

    }
}
