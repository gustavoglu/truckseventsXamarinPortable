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
  public  class ProdutoVendaViewModel : INotifyPropertyChanged
    {

        public Venda_Produto _venda_produto  { get; set; }

        public ProdutoVendaViewModel(Venda_Produto venda_produto)
        {
            this._venda_produto = venda_produto;
        }

        public double? Total
        {
            get { return _venda_produto.Total; }
            set { _venda_produto.Total = value; }
        }

        public string Descricao
        {
            get { return _venda_produto.Produto.Descricao; }
            set { _venda_produto.Produto.Descricao = value; Notify(nameof(this.Descricao)); }
        }

        private Color cor;

        public Color Cor
        {
            get { return cor; }
            set { cor = value; Notify(nameof(this.Cor)); }
        }

        public int? Quantidade
        {
            get { return _venda_produto.Quantidade; }
            set { _venda_produto.Quantidade = value; Notify(nameof(this.Quantidade)); }
        }

        public double? Valor
        {
            get { return _venda_produto.Produto.Valor; }
            set { _venda_produto.Produto.Valor = value; Notify(nameof(this.Valor)); }
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
