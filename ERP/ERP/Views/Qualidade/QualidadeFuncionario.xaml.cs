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
    public partial class QualidadeFuncionario : Page
    {
        public ObservableCollection<SatisfacaoFuncionarioSet> listaSatisfacaoFuncionario { get; set; }


        public QualidadeFuncionario()
        {
            InitializeComponent();
            //satisfacaoFuncionarioSetDomainDataSource.SubmittedChanges += new EventHandler<SubmittedChangesEventArgs>(satisfacaoFuncionarioSetDomainDataSource_SubmittedChanges);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void satisfacaoFuncionarioSetDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void dfrSatisfacaoFuncionario_EditEnding(object sender, DataFormEditEndingEventArgs e)
        {
            if (e.EditAction.Equals(DataFormEditAction.Commit))
            {
                try
                {
                    satisfacaoFuncionarioSetDomainDataSource.SubmitChanges();
                    MessageBox.Show("Satisfação do Funcionario atualizado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Atualização da Satisfação do Funcionario Falhou: {0}", ex.ToString()));
                }
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            RegistroSatisfacaoFuncionario satisfacaoFuncionario = new RegistroSatisfacaoFuncionario();
            satisfacaoFuncionario.Closed += new EventHandler(satisfacaoFuncionario_Closed);
            satisfacaoFuncionario.Show();
        }

        void satisfacaoFuncionario_Closed(object sender, EventArgs e)
        {
            RegistroSatisfacaoFuncionario registro = (RegistroSatisfacaoFuncionario)sender;
            QualidadeContext context = (QualidadeContext)satisfacaoFuncionarioSetDomainDataSource.DomainContext;

            if (registro.DialogResult == true && registro.novaSatisfacaoFuncionario != null)
            {
                context.SatisfacaoFuncionarioSets.Add(registro.novaSatisfacaoFuncionario);
                satisfacaoFuncionarioSetDomainDataSource.SubmitChanges();
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            SatisfacaoFuncionarioSet produtoDeletado = (SatisfacaoFuncionarioSet)satisfacaoFuncionarioSetDataGrid.SelectedItem;
            QualidadeContext context = (QualidadeContext)satisfacaoFuncionarioSetDomainDataSource.DomainContext;

            if (produtoDeletado != null)
            {
                context.SatisfacaoFuncionarioSets.Remove(produtoDeletado);
                satisfacaoFuncionarioSetDomainDataSource.SubmitChanges();
            }
        }

        void satisfacaoFuncionarioSetDomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {

            satisfacaoFuncionarioSetDomainDataSource.Load();
            satisfacaoFuncionarioSetDataGrid.ItemsSource = satisfacaoFuncionarioSetDomainDataSource.Data;
            pgrSatisfacaoFuncionario.Source = satisfacaoFuncionarioSetDomainDataSource.Data;

        }

    }
}
