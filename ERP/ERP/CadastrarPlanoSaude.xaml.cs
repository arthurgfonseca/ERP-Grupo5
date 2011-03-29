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
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;


namespace ERP
{
    public partial class CadastrarPlanoSaude : Page
    {
        private class DescontosServicosMedicos
        {
            public string descricao { get; set; }
            public double preco { get; set; }
            public double desconto { get; set; }
            public int precoDesconto { get; set; }

            public DescontosServicosMedicos(string descricao, double preco)
            {
                this.descricao = descricao;
                this.preco = preco;
            }
        }

        private ObservableCollection<DescontosServicosMedicos> lstDescontosServicosMedicos = new ObservableCollection<DescontosServicosMedicos>();

        public CadastrarPlanoSaude()
        {
            ERP.Web.AdministracaoContext administracaoContext = new Web.AdministracaoContext();

            List<ServicoMedicoSet> servicosMedicos = administracaoContext.ServicoMedicoSets.ToList();
            foreach (ServicoMedicoSet servicoMedico in servicosMedicos)
            {
                DescontosServicosMedicos desconto = new DescontosServicosMedicos(servicoMedico.descricao, servicoMedico.preco);
                lstDescontosServicosMedicos.Add(desconto);
            }
            grdServicos.ItemsSource = lstDescontosServicosMedicos;

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

        private void servicoMedicoSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void convenioServicoSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void servicoMedicoSetDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
