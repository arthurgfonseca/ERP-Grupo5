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
    public partial class Financas : Page
    {
        public Financas()
        {
            InitializeComponent();
            InitializeReport();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private RelatorioFinancas _relatorioFinancas;

        private void InitializeReport()
        {
            ReportFinancas.EndPrint += (s, e) =>
            {
                MessageBox.Show("Report printed.");
            };

            ReportFinancas.BeginBuildReport += (s, e) =>
            {
                // initialize running totals
                _relatorioFinancas = new RelatorioFinancas();
            };

            ReportFinancas.BeginBuildReportItem += (s, e) =>
            {
                // this event fires with each report item, so you
                // can use it to build a running total
                var item = e.DataContext as Data.Financas;

                _relatorioFinancas.registrosContagem++;
                _relatorioFinancas.valorRegistroTotal += item.valorRegistro;
            };

            ReportFinancas.BeginBuildReportFooter += (s, e) =>
            {
                 // set the running total as the context for the report footer
                e.DataContext = _relatorioFinancas;
            };

        }

        private void RelatórioFinancas_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<SatisfacaoFuncionarios> observableCollecion = new ObservableCollection<SatisfacaoFuncionarios>();

            ReportFinancas.Print();
        }

    }
}
