using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ERPQualidadeModel;

namespace ERP
{
    public partial class RegistroSatisfacaoCliente : ChildWindow
    {
        public SatisfacaoClienteSet novaSatisfacaoCliente { get; set; }

        public RegistroSatisfacaoCliente()
        {
            InitializeComponent();
            novaSatisfacaoCliente = new SatisfacaoClienteSet();
            dfrSatisfacaoCliente.CurrentItem = novaSatisfacaoCliente;
            dfrSatisfacaoCliente.BeginEdit();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (dfrSatisfacaoCliente.IsItemValid)
            {
                dfrSatisfacaoCliente.CommitEdit();


                this.DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            novaSatisfacaoCliente = null;
            dfrSatisfacaoCliente.CancelEdit();
            this.DialogResult = false;
        }
    }
}

