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
    public partial class TestCRUDServicoMedico : Page
    {
        public TestCRUDServicoMedico()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void servicoMedicoSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
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
                ServicoMedicoSet novoServico = new ServicoMedicoSet();

                novoServico.codigo = 0;
                novoServico.descricao = descricaoTextBox.Text;
                novoServico.nome = nomeTextBox.Text;
                novoServico.preco = double.Parse(precoTextBox.Text);

                administracaoContext.ServicoMedicoSets.Add(novoServico);
                administracaoContext.SubmitChanges();
            }
            catch (Exception ex)
            {
            }

        }

    }
}
