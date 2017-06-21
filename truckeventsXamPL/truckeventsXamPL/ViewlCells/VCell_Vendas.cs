using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewlCells
{
    public class VCell_Vendas : ViewCell
    {
        StackLayout sl_principal;
        Label l_data;
        Label l_totalVenda;
        Label l_status;
        Frame frame;

        public VCell_Vendas()
        {
            frame = new Frame() { HasShadow = true };

            l_data = new Label() { HorizontalOptions = LayoutOptions.StartAndExpand };
            l_totalVenda = new Label() { HorizontalOptions = LayoutOptions.End };
            l_status = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand };

            
            l_data.SetBinding(Label.TextProperty, "Data");
            l_totalVenda.SetBinding(Label.TextProperty, "TotalVenda");
            l_status.SetBinding(Label.TextProperty, "Status");
            l_status.SetBinding(Label.TextColorProperty, "CorStatus");
            frame.SetBinding(Frame.OutlineColorProperty, "CorStatus");


            sl_principal = new StackLayout() { Orientation = StackOrientation.Horizontal
                ,Children = { l_data,l_status,l_totalVenda }
            };

            frame.Content = sl_principal;

            this.View = frame;

        }
    }
}
