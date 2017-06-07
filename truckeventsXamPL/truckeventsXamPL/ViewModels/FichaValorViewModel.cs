using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;

namespace truckeventsXamPL.ViewModels
{
    public class FichaValorViewModel : INotifyPropertyChanged
    {
        public Venda_Pagamento_Ficha _venda_Pagamento_Ficha;

        public FichaValorViewModel(Venda_Pagamento_Ficha venda_Pagamento_Ficha)
        {
            this._venda_Pagamento_Ficha = venda_Pagamento_Ficha;
        }

        private string codFicha;

        public string CodFicha
        {
            get { return _venda_Pagamento_Ficha.Ficha.Codigo; }
            set { codFicha = value; Notify(nameof(this.CodFicha)); }
        }

        private string cliente;

        public string Cliente
        {
            get { return _venda_Pagamento_Ficha.Ficha.NomeCliente; }
            set { cliente = value; Notify(nameof(this.Cliente)); }
        }

        private double saldo;

        public double Saldo
        {
            get { return _venda_Pagamento_Ficha.Ficha.Saldo.Value; }
            set { saldo = value; Notify(nameof(this.Saldo)); }
        }

        private double valor;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Valor
        {
            get { return _venda_Pagamento_Ficha.Valor; }
            set { _venda_Pagamento_Ficha.Valor = value; Notify(nameof(this.Valor)); }
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
