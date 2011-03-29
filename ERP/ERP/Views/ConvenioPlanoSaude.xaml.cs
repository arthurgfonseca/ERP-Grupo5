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
using System.Windows.Markup;
using ErpAdministracaoModel;
using ERP.Web;
using System.ServiceModel.DomainServices.Client;
using System.Text;

namespace ERP.Views
{
    public partial class ConvenioPlanoSaude : Page
    {
        private AdministracaoContext administracaoContext = new AdministracaoContext();

        public ConvenioPlanoSaude()
        {
            InitializeComponent();
            convenioPlanoSaudeSetDataGrid.SelectionChanged += new SelectionChangedEventHandler(convenioPlanoSaudeSetDataGrid_SelectionChanged);
        }

        void convenioPlanoSaudeSetDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvenioPlanoSaudeSet convenioSelecionado = (ConvenioPlanoSaudeSet)((DataGrid)sender).SelectedItem;

            StringBuilder dtxaml = new StringBuilder();

            dtxaml.Append(" <DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:dataForm='clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data.DataForm.Toolkit' xmlns:controls='clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls'>" +
                                "<StackPanel>");

            LoadOperation<ServicoMedicoSet> loadOpServicosMedicos = administracaoContext.Load<ServicoMedicoSet>(administracaoContext.GetServicoMedicoSetQuery());
            loadOpServicosMedicos.Completed += (s2, e2) =>
            {
                LoadOperation<ConvenioServicoSet> loadOp = administracaoContext.Load<ConvenioServicoSet>(administracaoContext.GetConvenioServicoSetQuery());
                loadOp.Completed += (s3, e3) =>
                {
                    foreach (ConvenioServicoSet servico in ((LoadOperation)s3).Entities)
                    {
                        dtxaml.Append("<dataForm:DataField Label='Desconto do Serviço " + servico.ServicoMedicoSet.descricao + "'>" +
                                            "<TextBox Text='" + servico.porcentagem_desconto + "' />" +
                                        "</dataForm:DataField>");
                    }

                    dtxaml.Append("</StackPanel>" +
                                    "</DataTemplate>");

                    dfrDescontosServicos.EditTemplate = (DataTemplate)XamlReader.Load(dtxaml.ToString());
                    dfrDescontosServicos.OnApplyTemplate();
                };
            };
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

        private void dfrConvenio_EditEnding(object sender, DataFormEditEndingEventArgs e)
        {
            administracaoContext = (AdministracaoContext)convenioPlanoSaudeSetDomainDataSource.DomainContext;

            if (e.EditAction.Equals(DataFormEditAction.Commit))
            {
                try
                {
                    administracaoContext.SubmitChanges(OnSubmitCompleted, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Atualização de Serviço Médico Falhou: {0}", ex.ToString()));
                }
            }
        }

        private void OnSubmitCompleted(SubmitOperation so)
        {
            if ((so.HasError))
            {
                MessageBox.Show(string.Format("Atualização de Serviço Médico Falhou: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                MessageBox.Show("Serviço Médico atualizado");
            }
        }

    }
}
