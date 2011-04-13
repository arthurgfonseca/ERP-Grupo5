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

namespace ERP.Views.ConvenioPlanoSaude
{
    public partial class RegistroConvenioPlanoSaude : ChildWindow
    {
        public ConvenioPlanoSaudeSet novoConvenio { get; set; }

        public RegistroConvenioPlanoSaude()
        {
            InitializeComponent();
            novoConvenio = new ConvenioPlanoSaudeSet();
            dfrNovoConvenio.CurrentItem = novoConvenio;
            dfrNovoConvenio.BeginEdit();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            dfrNovoConvenio.CommitEdit();
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            novoConvenio = null;
            dfrNovoConvenio.CancelEdit();
            this.DialogResult = false;
        }
    }
}

