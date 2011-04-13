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
using ERP.Web;
using ERP.Data;
using System.Windows.Printing.Reporting;
using System.Collections.ObjectModel;

namespace ERP.Views
{
    public partial class SatisfaçãoClientes : Page
    {
        public SatisfaçãoClientes()
        {
            InitializeComponent();
            InitializeReport();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private RelatorioSatisfacaoClientes _relatorioSatisfacaoClientes;

        private void InitializeReport()
        {
            ReportSatisfacaoClientes.EndPrint += (s, e) =>
            {
                MessageBox.Show("Report printed.");
            };

            ReportSatisfacaoClientes.BeginBuildReport += (s, e) =>
            {
                // initialize running totals
                _relatorioSatisfacaoClientes = new RelatorioSatisfacaoClientes();
            };

            ReportSatisfacaoClientes.BeginBuildReportItem += (s, e) =>
            {
                // this event fires with each report item, so you
                // can use it to build a running total
                var item = e.DataContext as Data.SatisfacaoClientes;
                
                _relatorioSatisfacaoClientes.clientesContagem++;
                _relatorioSatisfacaoClientes.tempoEsperaMedio += item.tempoEspera;
                _relatorioSatisfacaoClientes.qualidadeAtendimentoMedia += item.qualidadeAtendimento;
                if (item.outraOpiniao == true)
                    _relatorioSatisfacaoClientes.outraOpiniaoContagem++;
                _relatorioSatisfacaoClientes.notaFinalMedia += item.notaFinal;
            };

            ReportSatisfacaoClientes.BeginBuildReportFooter += (s, e) =>
            {
                // set the running total as the context for the report footer
                _relatorioSatisfacaoClientes.tempoEsperaMedio = _relatorioSatisfacaoClientes.tempoEsperaMedio / _relatorioSatisfacaoClientes.clientesContagem;
                _relatorioSatisfacaoClientes.qualidadeAtendimentoMedia = _relatorioSatisfacaoClientes.qualidadeAtendimentoMedia / _relatorioSatisfacaoClientes.clientesContagem;
                _relatorioSatisfacaoClientes.notaFinalMedia = _relatorioSatisfacaoClientes.notaFinalMedia / _relatorioSatisfacaoClientes.clientesContagem;
                e.DataContext = _relatorioSatisfacaoClientes;
            };

        }

        private void GetSatisfacaoCliente()
        {
        }

        private void RelatórioSatisfaçãoClientes_Click(object sender, RoutedEventArgs e)
        {
            GetSatisfacaoCliente();

            ObservableCollection<SatisfacaoFuncionarios> observableCollecion = new ObservableCollection<SatisfacaoFuncionarios>();

            ReportSatisfacaoClientes.Print();
        }

    }
}
