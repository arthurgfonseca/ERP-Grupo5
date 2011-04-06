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
using ERPQualidadeModel;
using ERP.Web;
using System.ServiceModel.DomainServices.Client;
using System.Text;
using ERP.Web.Services;

namespace ERP.Views.QualidadeCliente
{
    public partial class QualidadeCliente : Page
    {
        public ObservableCollection<SatisfacaoClienteSet> listaSatisfacaoCliente { get; set; }
        public SatisfacaoClienteSet satisfacaoClienteAnteriorEscolhido = null;

        public QualidadeCliente()
        {
            InitializeComponent();
            satisfacaoClienteSetDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(satisfacaoClienteSetDomainDataSource_SubmittedChanges);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }



        private void satisfacaoClienteSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroSatisfacaoCliente satisfacaoCliente = new RegistroSatisfacaoCliente();
            satisfacaoCliente.Closed += new EventHandler(satisfacaoCliente_Closed);
            satisfacaoCliente.Show();

        }

        void satisfacaoCliente_Closed(object sender, EventArgs e)
        {
            RegistroSatisfacaoCliente registro = (RegistroSatisfacaoCliente)sender;
            QualidadeContext context = (QualidadeContext)satisfacaoClienteSetDomainDataSource.DomainContext;

            if (registro.DialogResult == true && registro.novaSatisfacaoCliente != null)
            {
                context.SatisfacaoClienteSets.Add(registro.novaSatisfacaoCliente);
                satisfacaoClienteSetDomainDataSource.SubmitChanges();
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            SatisfacaoClienteSet produtoDeletado = (SatisfacaoClienteSet)satisfacaoClienteSetDataGrid.SelectedItem;
            QualidadeContext context = (QualidadeContext)satisfacaoClienteSetDomainDataSource.DomainContext;

            if (produtoDeletado != null)
            {
                context.SatisfacaoClienteSets.Remove(produtoDeletado);
                satisfacaoClienteSetDomainDataSource.SubmitChanges();
            }
        }

        void satisfacaoClienteSetDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            satisfacaoClienteSetDomainDataSource.Load();
            satisfacaoClienteSetDataGrid.ItemsSource = satisfacaoClienteSetDomainDataSource.Data;
            pgrSatisfacaoCliente.Source = satisfacaoClienteSetDomainDataSource.Data;

        }

        private void servicoMedicoSetDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (satisfacaoClienteAnteriorEscolhido == null)
            {
                satisfacaoClienteAnteriorEscolhido = new SatisfacaoClienteSet();
                satisfacaoClienteAnteriorEscolhido.nome = ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).nome;
                satisfacaoClienteAnteriorEscolhido.comentarios = ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).comentarios;
                satisfacaoClienteAnteriorEscolhido.data_avaliacao = ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).data_avaliacao;
            }

            if (dfrSatisfacaoCliente.CurrentItem != null)
            {
                if (dfrSatisfacaoCliente.CancelEdit())
                {
                    if (!((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).Equals(satisfacaoClienteAnteriorEscolhido))
                    {
                        ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).nome = satisfacaoClienteAnteriorEscolhido.nome;
                        ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).comentarios = satisfacaoClienteAnteriorEscolhido.comentarios;
                        ((SatisfacaoClienteSet)dfrSatisfacaoCliente.CurrentItem).data_avaliacao = satisfacaoClienteAnteriorEscolhido.data_avaliacao;
                    }
                }
                else
                {
                    dfrSatisfacaoCliente.CurrentItem = satisfacaoClienteSetDataGrid.SelectedItem;
                }
            }
        }

        private void dfrSatisfacaoCliente_EditEnding(object sender, DataFormEditEndingEventArgs e)
        {
            if (e.EditAction.Equals(DataFormEditAction.Commit))
            {
                try
                {
                    satisfacaoClienteSetDomainDataSource.SubmitChanges();
                    MessageBox.Show("Satisfação do Cliente atualizado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Atualização da Satisfação do Cliente Falhou: {0}", ex.ToString()));
                }
            }
        }


        

    }
}
