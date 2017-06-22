using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
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
            get { return string.Format("{1} as {0}",_venda.CriadoEm.Value.ToLocalTime().ToString(@"hh\:mm").ToString(),_venda.CriadoEm.Value.Date.ToString("dd/MM")); }
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
            get { return _venda.Cancelada == true ? "Cancelada" : "Realizada"; }
            set { status = value; Notify(nameof(this.Status)); }
        }

        private Color corStatus;

        public Color CorStatus
        {
            get { return _venda.Cancelada == true ? Color.IndianRed : Color.Green; }
            set { corStatus = value; Notify(nameof(this.CorStatus)); }
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
