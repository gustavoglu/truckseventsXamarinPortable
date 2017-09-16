using System.ComponentModel;
using truckeventsXamPL.Models;

namespace truckeventsXamPL.ViewModels
{
    public class FichaValorViewModel : INotifyPropertyChanged
    {
        private Pagamento_Ficha _pagamento_Ficha;

        public FichaValorViewModel(Pagamento_Ficha pagamento_Ficha)
        {
            this._pagamento_Ficha = pagamento_Ficha;
        }

        private string codFicha;

        public string CodFicha
        {
            get { return _pagamento_Ficha.Ficha.Codigo; }
            set { codFicha = value; Notify(nameof(this.CodFicha)); }
        }

        private string cliente;

        public string Cliente
        {
            get { return _pagamento_Ficha.Ficha.NomeCliente == string.Empty || _pagamento_Ficha.Ficha.NomeCliente == null ? "Não Informado" : _pagamento_Ficha.Ficha.NomeCliente; }
            set { cliente = value; Notify(nameof(this.Cliente)); }
        }

        private double saldo;

        public double Saldo
        {
            get { return _pagamento_Ficha.Ficha.Saldo.Value; }
            set { saldo = value; Notify(nameof(this.Saldo)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Pagamento_Ficha Pagamento_Ficha { get { return _pagamento_Ficha; } set { _pagamento_Ficha = value; } }

    }
}
