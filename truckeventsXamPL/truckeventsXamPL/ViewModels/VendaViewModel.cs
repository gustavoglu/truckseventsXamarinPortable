using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewModels
{
    public class VendaViewModel : INotifyPropertyChanged
    {
        public Venda _venda;

        public VendaViewModel(Venda venda)
        {
            this._venda = venda;
        }

        private string venda;

        public string Data
        {
            get { return string.Format("{0},{1}",_venda.Data.Value.ToLocalTime(),_venda.Data.Value.Date.ToString()); }
            set { Data = value; Notify(nameof(Data)); }
        }

        private double totalVenda;

        public double TotalVenda
        {
            get { return _venda.TotalVenda.Value; }
            set { totalVenda = value; Notify(nameof(TotalVenda)); }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private Color corStatus;

        public Color CorStatus
        {
            get { return corStatus; }
            set { corStatus = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
