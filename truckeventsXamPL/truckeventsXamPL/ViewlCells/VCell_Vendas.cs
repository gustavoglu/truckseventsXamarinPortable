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
        Label l_data_e;
        Label l_data;
        Label l_totalVenda_e;
        Label l_totalVenda;
        Label l_status;
        Frame frame;
        Grid grid_data;
        Grid grid_total;

        public VCell_Vendas()
        {
            frame = new Frame() { HasShadow = true , Margin = 5};
            grid_data = new Grid() { HorizontalOptions = LayoutOptions.StartAndExpand  };
            grid_total = new Grid() { HorizontalOptions = LayoutOptions.EndAndExpand };

            l_data = new Label() { Text = "Vendido Em:" };
            l_totalVenda = new Label() { Text = "Total:" };
            l_data_e = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand };
            l_totalVenda_e = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand};
            l_status = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand , VerticalOptions = LayoutOptions.CenterAndExpand};

            
            l_data_e.SetBinding(Label.TextProperty, "Data");
            l_totalVenda_e.SetBinding(Label.TextProperty, "TotalVenda", stringFormat: "R${0}");
            l_status.SetBinding(Label.TextProperty, "Status");
            l_status.SetBinding(Label.TextColorProperty, "CorStatus");
            frame.SetBinding(Frame.OutlineColorProperty, "CorStatus" );

            grid_data.Children.Add(l_data, 0, 0);
            grid_data.Children.Add(l_data_e, 0, 1);
            grid_total.Children.Add(l_totalVenda, 0, 0);
            grid_total.Children.Add(l_totalVenda_e, 0, 1);

            sl_principal = new StackLayout() { Orientation = StackOrientation.Horizontal
                ,Children = { grid_data,l_status,grid_total}
            };

            frame.Content = sl_principal;

            this.View = frame;

        }
    }
}
