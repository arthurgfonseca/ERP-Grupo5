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
using System.Windows.Printing.Reporting;
using System.Collections.ObjectModel;
using ERP.Data;

namespace ERP.Views
{
    public partial class SatisfacaoFuncionarios : Page
    {
        public SatisfacaoFuncionarios()
        {
            InitializeComponent();

            InitializeReport();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private RelatorioSatisfacaoFuncionarios _relatorioSatisfacaoFuncionarios;

        private void InitializeReport()
        {
            ReportSatisfacaoFuncionarios.EndPrint += (s, e) =>
            {
                MessageBox.Show("Report printed.");
            };

            ReportSatisfacaoFuncionarios.BeginBuildReport += (s, e) =>
            {
                // initialize running totals
                _relatorioSatisfacaoFuncionarios = new RelatorioSatisfacaoFuncionarios();
            };

            ReportSatisfacaoFuncionarios.BeginBuildReportItem += (s, e) =>
            {
                // this event fires with each report item, so you
                // can use it to build a running total
                var item = e.DataContext as Data.SatisfacaoFuncionarios;

                _relatorioSatisfacaoFuncionarios.funcionariosContagem++;
                _relatorioSatisfacaoFuncionarios.notaAmbienteTrabalhoMedia += item.notaAmbienteTrabalho;
                _relatorioSatisfacaoFuncionarios.notaCologasTrabalhoMedia += item.notaColegasTrabalho;
                _relatorioSatisfacaoFuncionarios.notaSatisfacaoPessoal += item.notaSatisfacaoPessoal;
                _relatorioSatisfacaoFuncionarios.notaFinalMedia += item.notaFinal;
            };

            ReportSatisfacaoFuncionarios.BeginBuildReportFooter += (s, e) =>
            {
                // set the running total as the context for the report footer
                _relatorioSatisfacaoFuncionarios.notaAmbienteTrabalhoMedia = _relatorioSatisfacaoFuncionarios.notaAmbienteTrabalhoMedia / _relatorioSatisfacaoFuncionarios.funcionariosContagem;
                _relatorioSatisfacaoFuncionarios.notaCologasTrabalhoMedia = _relatorioSatisfacaoFuncionarios.notaCologasTrabalhoMedia / _relatorioSatisfacaoFuncionarios.funcionariosContagem;
                _relatorioSatisfacaoFuncionarios.notaSatisfacaoPessoal = _relatorioSatisfacaoFuncionarios.notaSatisfacaoPessoal / _relatorioSatisfacaoFuncionarios.funcionariosContagem;
                _relatorioSatisfacaoFuncionarios.notaFinalMedia = _relatorioSatisfacaoFuncionarios.notaFinalMedia / _relatorioSatisfacaoFuncionarios.funcionariosContagem;
                e.DataContext = _relatorioSatisfacaoFuncionarios;
            };

        }

        private void RelatórioSatisfaçãoFuncionários_Click(object sender, RoutedEventArgs e)
        {
            var satisfacaoFuncionarios = new SatisfacaoFuncionarios();
             
             
            
            ObservableCollection<SatisfacaoFuncionarios> observableCollecion = new ObservableCollection<SatisfacaoFuncionarios>();

            ReportSatisfacaoFuncionarios.Print();
        }

    }
}
