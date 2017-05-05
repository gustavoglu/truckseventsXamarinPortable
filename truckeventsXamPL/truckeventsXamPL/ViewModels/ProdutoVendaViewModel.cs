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
    public class ProdutoVendaViewModel : INotifyPropertyChanged
    {

        private Produto _produto { get; set; }

        public ProdutoVendaViewModel(Produto produto)
        {
            this._produto = produto;
        }

        public Guid Id_produto { get { return _produto.Id.Value; } }

        private double total;

        public double Total
        {
            get { return Quantidade * Valor.Value; }
            set { total = value; this.Notify(nameof(Total)); }
        }

        public string Descricao
        {
            get { return _produto.Descricao; }
            set { _produto.Descricao = value; Notify(nameof(this.Descricao)); }
        }

        public Color CorProduto
        {
            get { return Color.FromHex(_produto.Produto_Cor.Cor); }
        }

        private Color corBackground;

        public Color CorBackground
        {
            get { return quantidade > 0 ? Constantes.VERDESELECAO : Color.Transparent; }
            set { corBackground = value; this.Notify(nameof(CorBackground)); }
        }

        private int quantidade;

        public int Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                Notify(nameof(this.Quantidade));
                Notify(nameof(this.Total));
                Notify(nameof(this.CorBackground));
            }
        }

        private double valor;

        public double? Valor
        {
            get { return _produto.Valor; }
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
