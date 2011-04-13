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
    public partial class RegistroSatisfacaoFuncionario : ChildWindow
    {
        public SatisfacaoFuncionarioSet novaSatisfacaoFuncionario { get; set; }

        public RegistroSatisfacaoFuncionario()
        {
            InitializeComponent();
            novaSatisfacaoFuncionario = new SatisfacaoFuncionarioSet();
            dfrSatisfacaoFuncionario.CurrentItem = novaSatisfacaoFuncionario;
            dfrSatisfacaoFuncionario.BeginEdit();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (dfrSatisfacaoFuncionario.IsItemValid)
            {
                dfrSatisfacaoFuncionario.CommitEdit();
                this.DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            novaSatisfacaoFuncionario = null;
            dfrSatisfacaoFuncionario.CancelEdit();
            this.DialogResult = false;
        }
    }
}

