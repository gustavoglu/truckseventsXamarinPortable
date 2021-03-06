﻿using System;
using System.ComponentModel;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using Xamarin.Forms;

namespace truckeventsXamPL.ViewModels
{
    public class ProdutoVendaViewModel : INotifyPropertyChanged
    {

        private Produto _produto;

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
            get { return Color.FromHex(_produto.Cor?.CorFromHex ?? "0000"); }
        }

        private Color corBackground;

        public Color CorBackground
        {
            get { return quantidade > 0 ? Constantes.ROXOPADRAO : Color.Transparent; }
            set { corBackground = value; this.Notify(nameof(CorBackground)); }
        }

        private Color corFont;

        public Color CorFont
        {
            get { return quantidade > 0 ? Color.White : Constantes.ROXOPADRAO; }
            set { corFont = value; Notify(nameof(this.CorFont)); }
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
                Notify(nameof(this.CorFont));
            }
        }

        private double valor;

        public double? Valor
        {
            get { return _produto.Preco; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Produto Produto { get { return this._produto; } set { _produto = value; } }
    }
}
