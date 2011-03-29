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
using ErpAdministracaoModel;

namespace ERP
{
    public partial class RegistroServicoMedico : ChildWindow
    {
        public ServicoMedicoSet novoServico { get; set; }

        public RegistroServicoMedico()
        {
            InitializeComponent();
            novoServico = new ServicoMedicoSet();
            dfrNovoServico.CurrentItem = novoServico;
            dfrNovoServico.BeginEdit();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (dfrNovoServico.IsItemValid)
            {
                dfrNovoServico.CommitEdit();
                this.DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            novoServico = null;
            dfrNovoServico.CancelEdit();
            this.DialogResult = false;
        }
    }
}

