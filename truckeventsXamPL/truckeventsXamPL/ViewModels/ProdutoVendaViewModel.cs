using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewModels
{
  public  class ProdutoVendaViewModel : INotifyPropertyChanged
    {


        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; Notify(nameof(this.Descricao)); }
        }


        private Color cor;

        public Color Cor
        {
            get { return cor; }
            set { cor = value; Notify(nameof(this.Cor)); }
        }


        private int quantidade;

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Notify(nameof(this.Quantidade)); }
        }

        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; Notify(nameof(this.Valor)); }
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
