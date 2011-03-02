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
using System.Windows.Navigation;
using ErpAdministracaoModel;

namespace ERP
{
    public partial class TestCRUD : Page
    {
        public TestCRUD()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void convenioPlanoSaudeSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            ERP.Web.AdministracaoContext administracaoContext = new Web.AdministracaoContext();

            try
            {

                ConvenioPlanoSaudeSet novoConvenio = new ConvenioPlanoSaudeSet();

                novoConvenio.codigo = int.Parse(codigoTextBox.Text);
                novoConvenio.empresa = empresaTextBox.Text;
                novoConvenio.observacoes = observacoesTextBox.Text;
                novoConvenio.plano = planoTextBox.Text;
                novoConvenio.telefone = telefoneTextBox.Text;

                administracaoContext.ConvenioPlanoSaudeSets.Add(novoConvenio);
                administracaoContext.SubmitChanges();
            }
            catch (Exception ex)
            {
            }
            

        }

    }
}
