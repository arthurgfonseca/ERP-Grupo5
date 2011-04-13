using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ERP.Views.ConvenioPlanoSaude
{
    public partial class ListaConveniosPlanoSaude : Page
    {
        public class DescontoServico
        {
            public DescontoServico(int id, string nome, string descricao, double desconto)
            {
                Id = id;
                Nome = nome;
                Descricao = descricao;
                Desconto = desconto;
            }

            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public double Desconto { get; set; }
        }

        private ObservableCollection<DescontoServico> listaDescontosServicos;

        public ListaConveniosPlanoSaude()
        {
            InitializeComponent();
            convenioPlanoSaudeSetDataGrid.SelectionChanged += new SelectionChangedEventHandler(convenioPlanoSaudeSetDataGrid_SelectionChanged);
        }

        void convenioPlanoSaudeSetDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem != null)
            {
                dgrDescontosServicos.Visibility = Visibility.Visible;

                AdministracaoContext administracaoContext = new AdministracaoContext();
                ConvenioPlanoSaudeSet convenioSelecionado = (ConvenioPlanoSaudeSet)((DataGrid)sender).SelectedItem;

                listaDescontosServicos = new ObservableCollection<DescontoServico>();
                DescontoServico descontoServico = null;

                LoadOperation<ServicoMedicoSet> loadOpServicosMedicos = administracaoContext.Load<ServicoMedicoSet>(administracaoContext.GetServicoMedicoSetQuery());
                loadOpServicosMedicos.Completed += (s2, e2) =>
                {
                    LoadOperation<ConvenioServicoSet> loadOp = administracaoContext.Load<ConvenioServicoSet>(administracaoContext.GetConvenioServicoSet_CodigoConvenioQuery(convenioSelecionado.codigo));
                    loadOp.Completed += (s3, e3) =>
                    {
                        foreach (ConvenioServicoSet servico in ((LoadOperation)s3).Entities)
                        {
                            descontoServico = new DescontoServico(servico.id, servico.ServicoMedicoSet.nome, servico.ServicoMedicoSet.descricao, servico.porcentagem_desconto);
                            listaDescontosServicos.Add(descontoServico);
                        }

                        dgrDescontosServicos.ItemsSource = listaDescontosServicos;
                    };
                };
            }
            else
            {
                dgrDescontosServicos.Visibility = Visibility.Collapsed;
            }
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
            if (e.EditAction.Equals(DataFormEditAction.Commit))
            {
                try
                {
                    convenioPlanoSaudeSetDomainDataSource.SubmitChanges();
                    MessageBox.Show("Dados do Convênio atualizados");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Atualização de Dados do Convênio Falhou: {0}", ex.ToString()));
                }
            }
        }

        private void dgrDescontosServicos_RowEditEnded(object sender, DataGridRowEditEndedEventArgs e)
        {
            AdministracaoContext administracaoContext = new AdministracaoContext();
            ConvenioPlanoSaudeSet convenioSelecionado = (ConvenioPlanoSaudeSet)convenioPlanoSaudeSetDataGrid.SelectedItem;
            DescontoServico descontoServicoAlterado = (DescontoServico)((DataGrid)sender).SelectedItem;

            LoadOperation<ConvenioServicoSet> loadOp = administracaoContext.Load<ConvenioServicoSet>(administracaoContext.GetConvenioServicoSet_IdQuery(descontoServicoAlterado.Id));
            loadOp.Completed += (s3, e3) =>
            {
                ConvenioServicoSet descontoServico = administracaoContext.ConvenioServicoSets.Where<ConvenioServicoSet>(desc => desc.id == descontoServicoAlterado.Id).Single<ConvenioServicoSet>();
                descontoServico.porcentagem_desconto = descontoServicoAlterado.Desconto;
                administracaoContext.SubmitChanges();
            };
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroConvenioPlanoSaude registroConvenio = new RegistroConvenioPlanoSaude();
            registroConvenio.Closed += new EventHandler(registroConvenio_Closed);
            registroConvenio.Show();
        }

        void registroConvenio_Closed(object sender, EventArgs e)
        {
            RegistroConvenioPlanoSaude registro = (RegistroConvenioPlanoSaude)sender;
            AdministracaoContext context = (AdministracaoContext)convenioPlanoSaudeSetDomainDataSource.DomainContext;

            if (registro.DialogResult == true && registro.novoConvenio != null)
            {
                context.ConvenioPlanoSaudeSets.Add(registro.novoConvenio);
                convenioPlanoSaudeSetDomainDataSource.SubmitChanges();
                dfrConvenio.CurrentItem = registro.novoConvenio;

                ConvenioPlanoSaudeSet convenio = (ConvenioPlanoSaudeSet)registro.novoConvenio;
                ConvenioServicoSet desconto = null;

                AdministracaoContext administracaoContext = new AdministracaoContext();
                LoadOperation<ServicoMedicoSet> loadOpServicosMedicos = administracaoContext.Load<ServicoMedicoSet>(administracaoContext.GetServicoMedicoSetQuery());
                loadOpServicosMedicos.Completed += (s2, e2) =>
                {
                    foreach (ServicoMedicoSet servico in ((LoadOperation)s2).Entities)
                    {
                        desconto = new ConvenioServicoSet();
                        desconto.ConvenioPlanoSaude_codigo = convenio.codigo;
                        desconto.ServicoMedicoSet_codigo = servico.codigo;
                        desconto.porcentagem_desconto = 0;

                        context.ConvenioServicoSets.Add(desconto);
                    }
                    convenioPlanoSaudeSetDomainDataSource.SubmitChanges();
                };
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
